using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GETmerger.DAL.Contracts.Interfaces;
using GETmerger.DAL.Contracts.Models;
using GETmerger.DAL.Contracts.EF;

namespace GETmerger.DAL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public List<BaseName> GetAll()
        {
            List<BaseName> bases = new List<BaseName>();
            using (IDbConnection db1 = new SqlConnection(connectionString))
            {
                bases = db1.Query<BaseName>("SELECT name from sys.databases").ToList();
            }
            return bases;
        }
    }
}
