using Data.Interfaces;
using Domain.LocomotiveData;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class LocoSeriesRepository : IRepository<LocoSeries>
    {
        private readonly DocContext? _db;

        public LocoSeriesRepository(DocContext context) => this._db = context;
        public LocoSeries Get(int id) => _db?.LocoSeries.Find(id)!;
        public LocoSeries GetByTranslit(string translit)
        {
            translit = translit.Trim();
            var series = _db?.LocoSeries.Where(s => s.TranslitMatching! == translit)!;
            LocoSeries locoSeries = new();
            foreach (var item in series)
            {
                locoSeries.Id = item.Id;
                locoSeries.Series = item.Series;
                locoSeries.LocoTypeId = item.LocoTypeId;
                locoSeries.TranslitMatching = item.TranslitMatching;
            }

            return locoSeries;
        }

        public void Create(LocoSeries series) => _db!.LocoSeries.Add(series);
        public void Update(LocoSeries series) => _db!.Entry(series).State = EntityState.Modified;
        public void Delete(int id)
        {
            LocoSeries locoType = _db?.LocoSeries.Find(id)!;
            if (locoType != null)
                _db!.LocoSeries.Remove(locoType);
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
