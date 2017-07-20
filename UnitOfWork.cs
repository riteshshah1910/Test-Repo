using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MVCTraining.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext entities = null;

        private DbContextTransaction ObjectSetTransaction { get; set; }

        public UnitOfWork()
        {
            entities = new BlogContext();
        }

        //private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        //[Dependency]
        public IRepository<T> Repository<T>() where T : class
        {
            return new Repositories<T>(entities);
            //return new Repositories<T>(entities.Set<T>());

            //if (repositories.Keys.Contains(typeof(T)) == true)
            //{
            //    return (IRepository<T>)repositories[typeof(T)];
            //}

            //IRepository<T> repository = new Repositories<T>(entities);
            //repositories.Add(typeof(T), repository);
            //return repository;
        }

        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        public void BeginTransaction()
        {
            ObjectSetTransaction = entities.Database.BeginTransaction();
        }

        public void RollBackTransaction()
        {
            ObjectSetTransaction.Rollback();
            ObjectSetTransaction.Dispose();

        }
        public void CommitTransaction()
        {
            ObjectSetTransaction.Commit();
            ObjectSetTransaction.Dispose();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}