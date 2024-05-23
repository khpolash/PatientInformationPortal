using System.Linq.Expressions;

namespace PatientInformationPortal.Application.Repositories.Base;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();

    IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

    Task<List<T>> GetAllAsync();

    Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

    T FirstOrDefault(long? id);

    Task<T> FirstOrDefaultAsync(long? id);

    T FirstOrDefault(long? id, params Expression<Func<T, object>>[] includeProperties);

    Task<T> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties);

    #region CURD Operation
    Task<T> InsertAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> UpdateAsync(object id, T entity);
    Task<T> DeleteAsync(object id);

    #endregion

}
