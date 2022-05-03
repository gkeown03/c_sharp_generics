using generic_classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace generics_classes.Repositories
{
    
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }
        public event EventHandler<T> ItemAdded;
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }
    }
}