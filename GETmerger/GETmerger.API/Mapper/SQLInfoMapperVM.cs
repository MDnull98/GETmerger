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
        public static DBQueryInputModel ToVMdatabases(this DataBaseQueryModel input)
        {
            if (input == null)
            {
                return null;
            }

            DBQueryInputModel mapperdb = new DBQueryInputModel
            {
                Id = input.Id,
                Name = input.Name
            };
            return mapperdb;
        }
        public static TableQueryInputModel ToVMtables(this TableQueryModel input)
        {
            if (input == null)
            {
                return null;
            }

            TableQueryInputModel mappertables = new TableQueryInputModel
            {
                Id = input.Id,
                Name = input.Name
            };
            return mappertables;
        }
    }
}