using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GETmerger.Core.Repositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class BaseRepository:IBaseRepository<BaseName>
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<BaseName> GetAll()
        {
            List<BaseName> bases = new List<BaseName>();
            using (IDbConnection db1 = new SqlConnection(connectionString))
            {
                bases = db1.Query<BaseName>("SELECT name from sys.databases").ToList();
            }
            return bases;
        }

        public BaseName Get(string dbname)
        {
            throw new System.NotImplementedException();
        }
    }
}
