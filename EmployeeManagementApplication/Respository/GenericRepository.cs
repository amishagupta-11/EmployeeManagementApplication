using EmployeeManagementApplication.Data;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagementApplication.Respository
{
    /// <summary>
    /// generic repository class that implements the Interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EmployeeManagementContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EmployeeManagementContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        /// <summary>
        /// method to fetch all the data 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Method to fetch data Based by id passed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// method to insert/Add the data.
        /// </summary>
        /// <param name="entity"></param>

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// method to update the fields of a particular table when user wants to edit the details.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// methods to check whether a particular user exists or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int? id)
        {
            return _context.Set<T>().Any(e => e.Equals(id));
        }

        /// <summary>
        /// method to delete the data based on id of the employee.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
