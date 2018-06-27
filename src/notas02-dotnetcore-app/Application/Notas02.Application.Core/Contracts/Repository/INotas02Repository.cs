using System.Collections.Generic;

namespace Notas02.Application.Core.Contracts.Repository
{
    public interface INotas02Repository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> List();
    }
}