using generic_classes.Entities;

namespace generics_classes.Repositories
{
    // contravariance example
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
    // co-variance example using out
    public interface IReadRepository<out T>
    {
        IEnumerable<T>  GetAll();
        T GetById(int id);
    }
    public interface IRepository<T>: IReadRepository<T>, IWriteRepository<T>
     where T : IEntity
    {
    }
}