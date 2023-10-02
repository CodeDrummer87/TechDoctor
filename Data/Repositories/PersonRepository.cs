using Data.Interfaces;
using Domain.EmployeeData;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DocContext? _db;

        public PersonRepository(DocContext context) => this._db = context;
        public Person Get(int id) => _db?.Persons.Find(id)!;
        public void Create(Person person) => _db!.Persons.Add(person);
        public void Update(Person person) => _db!.Entry(person).State = EntityState.Modified;
        public void Delete(int id)
        {
            Person person = _db?.Persons.Find(id)!;
            if (person != null)
                _db!.Persons.Remove(person);
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
