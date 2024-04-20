namespace EmployeeManagementApplication.Respository
{
    /// <summary>
    /// interface to list out all the methods that must be implemented.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        bool Exists(int? id);
    }

}
    