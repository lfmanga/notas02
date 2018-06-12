using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Notas02.Application.Core.Contracts.Repository;
using Dapper;
using System.Linq;

namespace Notas02.Application.Data.Dapper
{
    public class DapperReadRepository<T> : IReadRepository<T> where T : class
    {
        public T GetById(Guid id)
        {
            T t = null;
            using (var _connection = GetSqlConnection())
            {
                t = _connection.QueryFirst<T>("SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id", new { Id = id });
            }
            return t;
        }

        public IEnumerable<T> List()
        {
            var list = new List<T>();
            using (var _connection = GetSqlConnection())
            {
                list = _connection.Query<T>("SELECT * FROM " + typeof(T).Name).ToList();
            }
            return list;
        }

        public IEnumerable<T> List(int skip, int take)
        {
            throw new NotImplementedException();
        }

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Notas02;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}