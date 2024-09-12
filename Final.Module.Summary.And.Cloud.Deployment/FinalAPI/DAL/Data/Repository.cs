using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Data;

public abstract class Repository<T>(ContextDAL context) : IRepository<T> where T : class
{
    DbSet<T> DbSet = context.Set<T>();
    public virtual void Add(T entity)
    {
        DbSet.Add(entity);
        context.SaveChanges();
    }

    public virtual void Delete(int id)
    {
        var item = GetById(id) ?? throw new ArgumentException("Item not found");
        Delete(item);
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
        context.SaveChanges();
    }

    public virtual void Delete(Expression<Func<T, bool>> predicate)
    {
        DbSet.RemoveRange(FindAll(predicate));
        context.SaveChanges();
    }

    public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Where(predicate);
    }

    public virtual T? FindOne(Expression<Func<T, bool>> predicate)
    {
        return DbSet.SingleOrDefault(predicate);
    }

    public virtual IEnumerable<T> GetAll()
    {
        //return context Products.Include(p=>p.category);
        return DbSet.ToList();
    }

    public virtual T? GetById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual void Update(T entity)
    {
        DbSet.Update(entity);
        context.SaveChanges();
    }
}