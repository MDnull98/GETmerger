using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class TableRepository:ITableQueryRepository<TableName>
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<TableName> GetAll(string dbname)
        {
            List<TableName> bases = new List<TableName>();
            using (IDbConnection db1 = new SqlConnection(connectionString))
            {
                bases = db1.Query<TableName>("SELECT table_name FROM information_schema.tables where table_schema='<"+dbname+">'").ToList();
            }
            return bases;
        }

        public string Get(string dbname,string tablename)
        {
          throw new System.NotImplementedException();
        }
    }
}
