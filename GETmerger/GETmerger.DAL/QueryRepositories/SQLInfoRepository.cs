﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.Core.QueryRepositories;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.DAL.QueryRepositories
{
    public class SQLInfoRepository: BaseQueryRepository,ITableQueryRepository, IDBQueryRepository
    {
        public SQLInfoRepository(string dbconnection)
            : base(dbconnection)
        {

        }
        public List<DataBaseDTO> GetDataBases()
        {
            var sql = "SELECT [name], database_id as id FROM    sys.databases  WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";
            //if (sys == null)
            //{
            //    return GetList<DataBaseDTO>(sql);
            //}

           // sql += " WHERE name NOT IN('master', 'tempdb', 'model', 'msdb')";

            return GetList<DataBaseDTO>(sql);
        }

        public List<TableDTO> GetTables(int databaseId)
        {
            var sql = $"DECLARE @DatabaseName nvarchar(100);" +
                      $"\r\nselect @DatabaseName = [name]\r\nfrom sys.databases\r\nwhere database_id = {databaseId}\r\n" +
                      $"DECLARE @Query nvarchar(max) = 'USE ' + @DatabaseName + ' SELECT * FROM sys.Tables" +
                      $" WHERE name NOT IN(''sysdiagrams'')'\r\nexec  sp_executesql @Query;";
            var res = GetList<TableDTO>(sql);
            return res;
        }
    }
}
