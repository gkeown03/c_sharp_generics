using System.Linq;
using generic_classes.Entities;
using generics_classes.Entities;

namespace generics_classes.Repositories
{
    public class GenericRepository<T> where T: class, IEntity, new()
    {

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
            foreach (var item in _items) {
                Console.WriteLine(item);
            }
        }
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}