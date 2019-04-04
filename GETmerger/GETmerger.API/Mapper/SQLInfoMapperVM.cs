using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GETmerger.API.ViewModels;
using GETmerger.BLL.Contracts.Models.Input;

namespace GETmerger.API.Mapper
{
    public static class SQLInfoMapperVM
    {
        public static SQLInfoDatabaseVM ToVMdatabases(this DBQueryInputModel input)
        {
            if (input == null)
            {
                return null;
            }

            SQLInfoDatabaseVM mapperdb = new SQLInfoDatabaseVM
            {
                Id = input.Id,
                Name = input.Name
            };
            return mapperdb;
        }
        public static SQLInfoTablesVM ToVMtables(this TableQueryInputModel input)
        {
            if (input == null)
            {
                return null;
            }

            SQLInfoTablesVM mappertables = new SQLInfoTablesVM
            {
                Id = input.Id,
                Name = input.Name
            };
            return mappertables;
        }
    }
}