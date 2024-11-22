using MVC_Resume.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_Resume.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Db_ResumeEntities entities = new Db_ResumeEntities();

        public List<T> GetAll() 
        {
            return entities.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return entities.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return entities.Set<T>().FirstOrDefault(where);
        }

        public void Add(T p)
        {
            entities.Set<T>().Add(p);
            entities.SaveChanges();
        }

        public void Delete(T p)
        {
            entities.Set<T>().Remove(p);
            entities.SaveChanges();
        }

        public void Update(T p)
        {
            entities.SaveChanges();
        }
    }
}