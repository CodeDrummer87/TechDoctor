using Data.Interfaces;
using Domain;
using Domain.EmployeeData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DocContext? _db;

        public EmployeeRepository(DocContext context) => this._db = context;
        
        public Employee Get(int id) => _db?.Employees.Find(id)!;

        public List<EmployeeViewModel> GetEmployeeData(DataFilter filter, string condition, int numberOfRows, int alreadyPublished)
        {
            List<EmployeeViewModel> result = new();

            condition = filter is DataFilter.Relevance ? condition : $"'%{condition.Trim()}%'";
            string fullCondition = filter switch
            {
                DataFilter.Lastname => $"p.Lastname LIKE {condition}",
                DataFilter.PersonnelNumber => $"e.PersonnelNumber LIKE {condition}",
                DataFilter.Post => $"pt.Name LIKE {condition}",
                _ => $"e.IsActive = {condition}"
            };

            string query = "SELECT e.Id, e.PersonnelNumber, p.Firstname, p.Surname, p.Lastname, pt.Name, e.IsActive " +
            "FROM Employees e " +
            "INNER JOIN Persons p " +
            "ON e.PersonId = p.Id " +
            "INNER JOIN Posts pt " +
            "ON e.PostId = pt.Id " +
            $"WHERE {fullCondition} AND e.Id > 1 " +
            $"ORDER BY e.Id DESC " +
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
                    result.Add(new EmployeeViewModel
                    {
                        EmployeeId = reader.GetInt32(0),
                        PersonnelNumber = reader.GetString(1),
                        Firstname = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Lastname = reader.GetString(4),
                        Post = reader.GetString(5),
                        IsActive = reader.GetByte(6)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();

            return result.ToList();
        }

        public int Count(DataFilter filter, string condition)
        {
            int result = 0;

            condition = filter.Equals(DataFilter.Relevance) ? condition : $"'%{condition.Trim()}%'";
            string fullCondition = filter switch
            {
                DataFilter.Lastname => $"p.Lastname LIKE {condition}",
                DataFilter.PersonnelNumber => $"e.PersonnelNumber LIKE {condition}",
                DataFilter.Post => $"pt.Name LIKE {condition}",
                _ => $"e.IsActive = {condition}"
            };

            string query = "SELECT COUNT(e.Id) " +
                "FROM Employees e " +
                "INNER JOIN Persons p " +
                "ON e.PersonId = p.Id " +
                "INNER JOIN Posts pt " +
                "ON e.PostId = pt.Id " +
                $"WHERE {fullCondition} AND e.Id > 1";  //.:: Except default employee

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
        
        public Employee SearchByPersonnelNumber(string number)
        {
            var result = _db!.Employees.Where(e => e.PersonnelNumber!.Contains(number));
            return result.FirstOrDefault<Employee>()!;
        }

        public Employee GetByPersonnelNumber(string number)
        {
            return _db!.Employees.FirstOrDefault(e => e.PersonnelNumber == number)!;
        }

        public void Create(Employee employee) => _db!.Employees.Add(employee);
        
        public void Update(Employee employee) => _db!.Entry(employee).State = EntityState.Modified;

        public void SetDefaultPost(int postId)
        {
            string query = "UPDATE Employees SET PostId=1 WHERE PostId = @postId";

            try
            {
                SqliteCommand command = DocContext.GetConnection().CreateCommand();
                command.CommandText = query;
                command.Parameters.Add("@postId", SqliteType.Integer).Value = postId;

                DocContext.OpenConnection();
                SqliteDataReader reader = command.ExecuteReader();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            DocContext.CloseConnection();
        }

        public void Delete(int id)
        {
            Employee employee = _db?.Employees.Find(id)!;
            if (employee != null)
                _db!.Employees.Remove(employee);
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
