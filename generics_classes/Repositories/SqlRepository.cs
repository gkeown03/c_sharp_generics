using generic_classes.Entities;
using Microsoft.EntityFrameworkCore;

namespace generics_classes.Repositories
{
    // contravariance example for more specific manager class
    public delegate void ItemAdded<in T>(T item);
    
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;
        private readonly ItemAdded<T> _itemAddedCallback;

        public SqlRepository(DbContext dbContext, ItemAdded<T>? itemAddedCallback = null)
        {
            _itemAddedCallback = itemAddedCallback;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);
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