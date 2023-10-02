using Data.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly DocContext? _db;

        public CompanyRepository(DocContext context) => this._db = context;
        public Company Get(int id) => _db?.Companies.Find(id)!;
        public void Create(Company company) => _db!.Companies.Add(company);
        public void Update(Company company) => _db!.Entry(company).State = EntityState.Modified;
        public void Delete(int id)
        {
            Company company = _db?.Companies.Find(id)!;
            if (company != null)
                _db!.Companies.Remove(company);
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
