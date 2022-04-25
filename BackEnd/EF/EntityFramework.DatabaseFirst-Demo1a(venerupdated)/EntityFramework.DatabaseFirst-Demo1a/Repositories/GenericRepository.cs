using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DatabaseFirst_Demo1a.Data;
using EntityFramework.DatabaseFirst_Demo1a.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DatabaseFirst_Demo1a.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        T Save(T entity);
        T Update(T entity);
        T Delete(int id);
    }

    public class GenericRepository<T> where T: BaseEntity
    {
        public OnlineShopContext Context { get; set; }

        public GenericRepository(OnlineShopContext context)
        {
            this.Context = context;
        }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindById(int id)
        {
            var entity = this.Context.Find<T>(id);
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Entity with {id} doesn't exist");
        }

        public T Save(T entity)
        {
            this.Context.Add<T>(entity);
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
            var existingEntity = this.FindById(id);
            this.Context.Remove<T>(existingEntity);
            return existingEntity;
        }
    }
}
