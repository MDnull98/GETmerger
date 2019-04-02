using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GETmerger.Core.Contracts.Data.Queries;
using GETmerger.Core.Contracts.QueryRepositories;

namespace GETmerger.Core.QueryRepositories
{
    public class BaseQueryRepository:IBaseQueryRepository
    {
        private readonly string _dbConnectionString;
        private SqlConnection _connection;

        public BaseQueryRepository(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString ?? string.Empty;
        }

        protected SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_dbConnectionString);
            }
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }


        public T Get<T>(string query, ISqlDbParameter parameter = null)
        {
            var connection = GetConnection();

            return connection.Query<T>(query, parameter).SingleOrDefault();
        }

        public List<T> GetList<T>(string query, ISqlDbParameter parameter = null)
        {
            var connection = GetConnection();

            return connection.Query<T>(query, parameter).ToList();
        }

        public string MergeScript(string query, ISqlDbParameter parameter=null)
        {
            var connection = GetConnection();
            return connection.Query(query, parameter).ToString();
        }
    }
}
