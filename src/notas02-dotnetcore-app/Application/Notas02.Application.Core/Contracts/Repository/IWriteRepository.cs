using System;

namespace Notas02.Application.Core.Contracts.Repository
{
    public interface IWriteRepository<T>
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(Guid id);
    }
}