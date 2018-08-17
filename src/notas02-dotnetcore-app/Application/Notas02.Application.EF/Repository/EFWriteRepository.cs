using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Notas02.Application.Core.Contracts.Repository;
using Notas02.Application.EF.Context;

namespace Notas02.Application.EF.Repository
{
    public class EFWriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly Notas02Context _context;
        private readonly DbSet<T> _dbSet;

        public EFWriteRepository(Notas02Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            
            _dbSet.Remove(_dbSet.Find(id));
            _context.SaveChanges();
        }

        public void Edit(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();            
        }
    }
}