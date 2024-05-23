using Microsoft.EntityFrameworkCore;
using PatientInformationPortal.Infrastructure.Persistence;
using PatientInformationPortal.SharedKernel.Core;
using PatientInformationPortal.SharedKernel.Entities.BaseEntities;
using System.Linq.Expressions;

namespace PatientInformationPortal.Application.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : AuditableEntity
{
    private readonly PatientInformationPortalDbContext _context;
    private readonly DbSet<T> entities;

    public BaseRepository(PatientInformationPortalDbContext context)
    {
        _context = context;
        entities = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return entities;
    }


    public async Task<List<T>> GetAllAsync()
    {
        return await entities.OrderByDescending(x => x.Id).ToListAsync();
    }


    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return query;
    }

    public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return await query.ToListAsync();
    }

    public T FirstOrDefault(long? id)
    {
        return entities.Find(id);
    }

    public async Task<T> FirstOrDefaultAsync(long? id)
    {
        return await entities.FindAsync(id);
    }

    public T FirstOrDefault(long? id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return query.FirstOrDefault(x => x.Id == id);
    }

    public async Task<T> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    #region CRUD Operations
    public async Task<T> InsertAsync(T entity)
    {
        await entities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        entities.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(object id, T entity)
    {
        var data = await entities.FindAsync(id);

        if (data != null)
        {
            entity.CopyPropertiesTo(data);
            entities.Update(data);
            await _context.SaveChangesAsync();
        }
        return data;
    }


    public async Task<T> DeleteAsync(object id)
    {
        var entity = await entities.FindAsync(id);
        if (entity != null)
        {
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return entity;
    }

    #endregion


}
