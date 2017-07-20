using System;

namespace MVCTraining.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
        void BeginTransaction();
        void RollBackTransaction();
        void CommitTransaction();
    }
}
