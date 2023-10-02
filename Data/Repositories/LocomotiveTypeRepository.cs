using Data.Interfaces;
using Domain.LocomotiveData;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class LocomotiveTypeRepository : IRepository<LocomotiveType>
    {
        private readonly DocContext? _db;

        public LocomotiveTypeRepository(DocContext context) => this._db = context;

        public LocomotiveType Get(int id) => _db?.LocomotiveTypes.Find(id)!;
        public void Create(LocomotiveType locoType) => _db!.LocomotiveTypes.Add(locoType);
        public void Update(LocomotiveType locoType) => _db!.Entry(locoType).State = EntityState.Modified;
        public void Delete(int id)
        {
            LocomotiveType locoType = _db?.LocomotiveTypes.Find(id)!;
            if (locoType != null)
                _db!.LocomotiveTypes.Remove(locoType);
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
