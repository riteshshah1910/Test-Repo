using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCTraining.Models
{
    public class Repositories<T> : IRepository<T> where T : class
    {
        //private readonly BlogContext entities = null;
        private readonly IDbSet<T> objectSet = null;

        public Repositories(BlogContext entities)
        {
            //this.entities = entities;
            this.objectSet = entities.Set<T>();
        }

        public Repositories(IDbSet<T> objectSet)
        {
            this.objectSet = objectSet;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return objectSet.Where(predicate);
            }

            return objectSet.AsEnumerable();
        }

        public T Get(Func<T, bool> predicate)
        {
            return objectSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            objectSet.Add(entity);
        }

        public void Attach(T entity)
        {
            objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            objectSet.Remove(entity);
        }
    }
}