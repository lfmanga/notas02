using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Notas02.Application.EF.Context;
using Notas02.Application.Core.Contracts.Repository;

namespace Notas02.Application.EF.Repository
{
    public class Notas02Repository<T> : INotas02Repository<T> where T : class
    {
        private readonly Notas02Context _context;
        private readonly DbSet<T> _dbSet;

        public Notas02Repository(Notas02Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> List()
        {
            return _dbSet.ToList();
        }
    }
}