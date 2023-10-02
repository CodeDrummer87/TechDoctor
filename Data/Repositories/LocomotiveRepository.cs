using Data.Interfaces;
using Domain.LocomotiveData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class LocomotiveRepository : IRepository<Locomotive>
    {
        private readonly DocContext? _db;

        public LocomotiveRepository(DocContext context) => this._db = context;
        public Locomotive Get(int id) => _db?.Locomotives.Find(id)!;
        public string GetLocoSeriesNumber(int locoId, out string locoType)
        {
            string result = string.Empty;
            locoType = string.Empty;
            string query = "SELECT (s.Series || '-' || l.Number), t.Locotype " +
                "FROM Locomotives l " +
                "INNER JOIN LocoSeries s " +
                "ON l.SeriesId=s.Id " +
                "INNER JOIN LocomotiveTypes t " +
                "ON s.LocoTypeId=t.Id " +
                "WHERE l.Id=@locoId";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@locoId", SqliteType.Integer).Value = locoId;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                    locoType = reader.GetString(1);
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

        public Locomotive GetBySeriesIdAndNumber(int seriesId, int number)
        {
            var result = _db?.Locomotives
                .Where(l => l.SeriesId == seriesId && l.Number!.Contains(number.ToString()));

            return result!.FirstOrDefault<Locomotive>()!;
        }
        public void Create(Locomotive locomotive) => _db!.Locomotives.Add(locomotive);
        public void Update(Locomotive locomotive) => _db!.Entry(locomotive).State = EntityState.Modified;
        public void Delete(int id)
        {
            Locomotive locomotive = _db?.Locomotives.Find(id)!;
            if (locomotive != null)
                _db!.Locomotives.Remove(locomotive);
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
