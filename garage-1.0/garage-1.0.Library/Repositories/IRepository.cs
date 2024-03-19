namespace Garage_1_0.Library.Repositories;


interface IRepository<T> where T : class
{
    public T Add(T entity);
    public T Update(T entity);
    public T? Remove(T entity);
    public IEnumerable<T?>  Find(Func<T?, bool> predicate);
    public bool Any();
    public IEnumerable<T?> All();
    public void SaveChanges();
}