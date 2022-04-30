using Microsoft.EntityFrameworkCore;
using Operas.Data.Context;
using Operas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operas.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> FindAll();
        T FindByPrimaryKey(int id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(int id);
    }

    public class GenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(OperaDbContext context)
        {
            this.Context = context;
        }

        public OperaDbContext Context { get; set; }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByPrimaryKey(int id)
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
            Context.Add<T>(entity);

            return entity;
        }

        public T Update(T entity)
        {
            this.Context.Attach<T>(entity);
            this.Context.Entry<T>(entity).State = EntityState.Modified;

            return entity;
        }

        public T Delete(int id)
        {
            var entity = this.FindByPrimaryKey(id);
            this.Context.Remove<T>(entity);

            return entity;
        }
    }
}
