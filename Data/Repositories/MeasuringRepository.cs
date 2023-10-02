using Data.Interfaces;
using Domain.ElectricValues;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class MeasuringRepository : IRepository<Measuring>
    {
        private readonly DocContext? _db;

        public MeasuringRepository(DocContext context) => this._db = context;

        public IEnumerable<Measuring> GetAll() => _db!.Measurings;
        public Measuring Get(int id) => _db?.Measurings.Find(id)!;
        public void Create(Measuring measuring) => _db!.Measurings.Add(measuring);
        public void Update(Measuring measuring) => _db!.Entry(measuring).State = EntityState.Modified;
        public void Delete(int id)
        {
            Measuring measuring = _db?.Measurings.Find(id)!;
            if (measuring != null)
                _db!.Measurings.Remove(measuring);
        }
        public IEnumerable<string> GetAllPlotPoints(int locoId)
        {
            string query = "SELECT m.FirstValue, m.SecondValue, m.ThirdValue, m.FourthValue, m.FifthValue, m.SixthValue " +
                "FROM Measurings m " +
                "INNER JOIN MeasuringsData md " +
                "ON m.Id=md.MeasuringId " +
                "WHERE md.LocomotiveId=@locoId AND md.Denotement LIKE '%D%' " +
                "ORDER BY m.Id DESC " +
                "LIMIT 50";

            string[] result = new string[50];
            int index = 50;

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@locoId", SqliteType.Integer).Value = locoId;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result[--index] = $"{reader.GetString(0)};" +
                                      $"{reader.GetString(1)};" +
                                      $"{reader.GetString(2)};" +
                                      $"{reader.GetString(3)};" +
                                      $"{reader.GetString(4)};" +
                                      $"{reader.GetString(5)};";
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
