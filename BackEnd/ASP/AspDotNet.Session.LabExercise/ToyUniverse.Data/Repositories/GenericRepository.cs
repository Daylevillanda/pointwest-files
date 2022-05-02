using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyUniverse.Data.Data;

namespace ToyUniverse.Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByPrimaryKey(string id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(string id);

        ToyUniverseContext Context { get; set; }
    }

    public class GenericRepository<T> where T : class
    {
        public GenericRepository(ToyUniverseContext context)
        {
            this.Context = context;
        }

        public ToyUniverseContext Context { get; set; }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByPrimaryKey(string id)
        {
            var entity = this.Context.Find<T>(id);
            if (entity is object)
            {
                this.Context.Entry<T>(entity).State = EntityState.Detached;
                return entity;
            }

            throw new Exception($"Entity does not exist {id}");
        }

        public T Insert(T entity)
        {
            Context.Add<T>(entity);
            Context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            this.Context.Attach<T>(entity);
            this.Context.Entry<T>(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
            return entity;
        }

        public T Delete(string id)
        {
            var entity = this.FindByPrimaryKey(id);
            this.Context.Remove<T>(entity);
            this.Context.SaveChanges();
            return entity;
        }

    }
}
