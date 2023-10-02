using Data.Interfaces;
using Domain;
using Domain.ElectricValues;
using Domain.EmployeeData;
using Domain.LocomotiveData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MeasuringDataRepository : IRepository<MeasuringData>
    {
        private readonly DocContext? _db;

        public MeasuringDataRepository(DocContext context) => this._db = context;

        public List<MeasuringData> GetAllFreshEntries(DataFilter filter, string condition, int numberOfRows, int alreadyPublished, int targetId)
        {
            List<MeasuringData> list = new();

            string fullCondition = filter switch
            {
                DataFilter.Locomotive => $"(s.Series || '-' || l.Number) LIKE '%{condition}%'",
                _ => $"e.PersonnelNumber LIKE '%{condition}%'"
            };

            string query = "SELECT m.Id, m.LocomotiveId, m.EmployeeId, m.MeasuringId, m.Denotement, m.SaveDate " +
                "FROM MeasuringsData m " +
                "INNER JOIN Locomotives l " +
                "ON m.LocomotiveId = l.Id " +
                "INNER JOIN LocoSeries s " +
                "ON l.SeriesId = s.Id " +
                $"WHERE ({fullCondition}) AND (m.Denotement NOT LIKE '%D%') AND (m.Id > @targetId)" +
                $"LIMIT @numberOfRows OFFSET @alreadyPublished ";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@numberOfRows", SqliteType.Integer).Value = numberOfRows;
                command.Parameters.Add("@alreadyPublished", SqliteType.Integer).Value = alreadyPublished;
                command.Parameters.Add("@targetId", SqliteType.Integer).Value = targetId - 1;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new MeasuringData
                    {
                        Id = reader.GetInt32(0),
                        LocomotiveId = reader.GetInt32(1),
                        EmployeeId = reader.GetInt32(2),
                        MeasuringId = reader.GetInt32(3),
                        Denotement = reader.GetString(4),
                        SaveDate = reader.GetString(5)
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();

            return list.ToList();
        }

        public IEnumerable<string> GetAllMeasurementsByLocoId(int locoId)
        {
            string query = "SELECT md.Denotement || ';' || md.SaveDate || ';' || (REPLACE(p.Lastname, '-', '') || ' ' " +
                    "|| REPLACE((SUBSTR(p.Firstname, 1, 1) || '.'), '-', '') || REPLACE((SUBSTR(p.Surname, 1, 1) || '.'), '-', '') || " +
                    "' (таб.N ' || e.PersonnelNumber || ')') || ';' || COALESCE(m.FirstValue, -1) || ';' " +
                    "|| COALESCE(m.SecondValue, -1) || ';' || COALESCE(m.ThirdValue, -1) " +
                "FROM MeasuringsData md " +
                "INNER JOIN Measurings m " +
                "ON md.MeasuringId = m.Id " +
                "INNER JOIN Employees e " +
                "ON md.EmployeeId = e.Id " +
                "INNER JOIN Persons p " +
                "ON e.PersonId = p.Id " +
                "WHERE md.LocomotiveId = @locoId " +
                "ORDER BY md.Id DESC";

            List<string> result = new();
            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@locoId", SqliteType.Integer).Value = locoId;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new String(reader.GetString(0)));
                }
                reader.Close();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();

            return result;
        }

        public MeasuringData Get(int id) => _db?.MeasuringsData.Find(id)!;

        public int CountPlotPoints(int locoId)
            => (int)_db?.MeasuringsData
            .Where(m => m.Denotement!.Contains("D") && m.LocomotiveId == locoId)
            .Count()!;

        public void Create(MeasuringData mData) => _db!.MeasuringsData.Add(mData);

        public void Update(MeasuringData mData) => _db!.Entry(mData).State = EntityState.Modified;

        public void UnbindDataBeforeDelete(int employeeId)
        {
            string query = "UPDATE MeasuringsData SET EmployeeId=1 WHERE EmployeeId=@employeeId";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@employeeId", SqliteType.Integer).Value = employeeId;

                DocContext.OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();
        }

        public void Delete(int id)
        {
            MeasuringData mData = _db?.MeasuringsData.Find(id)!;
            if (mData != null)
                _db!.MeasuringsData.Remove(mData);
        }

        public List<MeasuringData> GetAll(DataFilter filter, string condition, int numberOfRows, int alreadyPublished, string reverse)
        {
            List<MeasuringData> list = new();

            string fullCondition = filter switch
            {
                DataFilter.Locomotive => $"(s.Series || '-' || l.Number) LIKE '%{condition}%'",
                _ => $"e.PersonnelNumber LIKE '%{condition}%'"
            };

            string query = "SELECT m.Id, m.LocomotiveId, m.EmployeeId, m.MeasuringId, m.Denotement, m.SaveDate " +
                "FROM MeasuringsData m " +
                "INNER JOIN Locomotives l " +
                "ON m.LocomotiveId = l.Id " +
                "INNER JOIN LocoSeries s " +
                "ON l.SeriesId = s.Id " +
                "INNER JOIN Employees e " +
                "ON m.EmployeeId = e.Id " +
                $"WHERE {fullCondition} AND m.Denotement NOT LIKE '%D%' " +
                $"ORDER BY m.Id {reverse} " +
                $"LIMIT @numberOfRows OFFSET @alreadyPublished";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@numberOfRows", SqliteType.Integer).Value = numberOfRows;
                command.Parameters.Add("@alreadyPublished", SqliteType.Integer).Value = alreadyPublished;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new MeasuringData
                    {
                        Id = reader.GetInt32(0),
                        LocomotiveId = reader.GetInt32(1),
                        EmployeeId = reader.GetInt32(2),
                        MeasuringId = reader.GetInt32(3),
                        Denotement = reader.GetString(4),
                        SaveDate = reader.GetString(5)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();

            return list.ToList();
        }

        public int Count(DataFilter filter, string condition)
        {
            int result = 0;

            string fullCondition = filter switch
            {
                DataFilter.Locomotive => $"(s.Series || '-' || l.Number) LIKE '%{condition}%'",
                _ => $"e.PersonnelNumber LIKE '%{condition}%'"
            };

            string query = "SELECT COUNT(m.Id) " +
                "FROM MeasuringsData m " +
                "INNER JOIN Locomotives l " +
                "ON m.LocomotiveId = l.Id " +
                "INNER JOIN LocoSeries s " +
                "ON l.SeriesId = s.Id " +
                "INNER JOIN Employees e " +
                "ON m.EmployeeId = e.Id " +
                $"WHERE {fullCondition} AND m.Denotement NOT LIKE '%D%'";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    result = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();

            return result;
        }

        public int CountLastRecords(int startId)
        {
            return (int)_db?.MeasuringsData!
                .Where(m => !m.Denotement!.Contains("D") && m.Id > startId - 1)
                .Count()!;
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db!.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
