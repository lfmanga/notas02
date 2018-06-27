using System;
using System.Collections.Generic;

namespace Notas02.Application.Core.Contracts.Repository
{
    public interface IReadRepository<T> where T : class
    {
        IEnumerable<T> List();
        IEnumerable<T> List(int skip, int take);
        T GetById(Guid id);       
    }
}