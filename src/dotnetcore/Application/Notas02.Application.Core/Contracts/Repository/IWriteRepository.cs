using System;

namespace Notas02.Application.Core.Contracts.Repository
{
    public interface IWriteRepository<T>
    {
        void Add(T entity);
        void Edit(Guid id, T entity);
        void Delete(Guid id);
    }
}