using System.Linq;
using generic_classes.Entities;
using generics_classes.Entities;

namespace generics_classes.Repositories
{
    public class ListRepository<T>: IRepository<T> where T: class, IEntity
    {
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
        private readonly List<T> _items = new();
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }
        public void Save()
        {
            // everything is saved already in the List<T>
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}