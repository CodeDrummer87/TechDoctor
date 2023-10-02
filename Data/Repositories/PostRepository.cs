using Data.Interfaces;
using Domain.EmployeeData;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private DocContext? _db;

        public PostRepository(DocContext context) => this._db = context;

        public IEnumerable<Post> GetAll(byte relevance)
        {
            if (relevance == (byte)1)
                return _db!.Posts.Where(p => p.IsActive == 1).OrderBy(n => n.Name);

            return _db!.Posts.OrderBy(n => n.Name);
        }
        public Post Get(int id) => _db?.Posts.Find(id)!;
        public void Create(Post post) => _db!.Posts.Add(post);
        public void Update(Post post) => _db!.Entry(post).State = EntityState.Modified;
        public void Delete(int id)
        {
            Post post = _db?.Posts.Find(id)!;
            if (post != null)
                _db!.Posts.Remove(post);
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
