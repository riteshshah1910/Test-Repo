using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVCTraining.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}