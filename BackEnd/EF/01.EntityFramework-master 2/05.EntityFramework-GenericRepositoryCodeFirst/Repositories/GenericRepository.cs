using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Exceptions;
using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> FindAll();
        T FindByPrimaryKey(Guid id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(Guid id);
        T Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        IEnumerable<T> FindQuery(string query, params object[] parameters);
    }

    public class GenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(OnlineShopContext context)
        {
            this.Context = context;
        }

        public OnlineShopContext Context { get; set; }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByPrimaryKey(Guid id)
        {
            var entity = this.Context.Find<T>(id);
            if (entity is object)
            {
                return entity;
            }

            throw new Exception($"Entity does not exist {id}");
        }

        public T Insert(T entity)
        {
            if (entity is null)
            {
                throw new EntityDataException("Entity argument cannot be null.");
            }

            Context.Add<T>(entity);

            return entity;
        }

        public T Update(T entity)
        {
            if (entity is null)
            {
                throw new EntityDataException("Entity argument cannot be null.");
            }

            this.Context.Attach<T>(entity);
            this.Context.Entry<T>(entity).State = EntityState.Modified;

            return entity;
        }

        public T Delete(Guid id)
        {
            var entity = this.FindByPrimaryKey(id);
            this.Context.Remove<T>(entity);

            return entity;
        }

        public T Delete(T entity)
        {
            if (entity is null)
            {
                throw new EntityDataException("Entity argument cannot be null.");
            }

            if (this.Context.Entry(entity).State == EntityState.Detached)
            {
                this.Context.Set<T>().Attach(entity);
            }
            this.Context.Set<T>().Remove(entity);
            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this.Context.Set<T>();

            if (filter is object)
            {
                query = query.Where(filter);
            }

            if (includeProperties is object)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy is object)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public IEnumerable<T> FindQuery(string sqlQuery, params object[] parameters)
        {
            var query = this.Context.Set<T>();
            return query.FromSqlRaw(sqlQuery, parameters).ToList();
        }
    }
}
