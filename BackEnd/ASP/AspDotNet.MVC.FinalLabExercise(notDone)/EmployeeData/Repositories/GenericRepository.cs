using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeData.Data;
using EmployeeData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByPrimaryKey(int id);
        T Insert(T entity);
        T Update(T entity);
        //T Delete(int id);
        public void SaveChanges();

        WorkScheduleDbContext Context { get; set; }
    }

    public class GenericRepository<T> where T : class
    {
        public GenericRepository(WorkScheduleDbContext context)
        {
            this.Context = context;
        }

        public WorkScheduleDbContext Context { get; set; }

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
                this.Context.Entry<T>(entity).State = EntityState.Detached;
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

        //public T Delete(int id)
        //{
        //    var entity = this.FindByPrimaryKey(id);
        //    this.Context.Remove<T>(entity);
        //    this.Context.SaveChanges();
        //    return entity;
        //}
        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}