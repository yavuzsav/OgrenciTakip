using System;

namespace YavuzSav.DataAccess.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
        where T : class
    {
        IRepository<T> Rep { get; }

        bool Save();
    }
}