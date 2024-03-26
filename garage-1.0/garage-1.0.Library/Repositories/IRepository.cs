namespace Garage_1_0.Library.Repositories;

public interface IRepository<T> where T : class
{
    public T? Add(T entity);
    public T Update(T entity);
    public T? Remove(string entityName);
    public IEnumerable<T?> Find(Func<T?, bool> predicate);
    public bool Any();
    public IEnumerable<T?> All();
}