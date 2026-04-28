using API02.Infra.Contexts;
using API02.Infra.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SqlServerContext context;

        public BaseRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public void Create(T obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
