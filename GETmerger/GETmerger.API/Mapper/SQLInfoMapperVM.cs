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
        public static SQLInfoViewModel ToVMdatabases(this DataBaseQueryModel input)
        {
            if (input == null)
            {
                return null;
            }

            var mapper = new DataBaseQueryModel()
            {
                Id = input.Id,
                Name = input.Name
            };
            return mapper.ToVMdatabases();
        }
        public static SQLInfoViewModel ToVMtables(this TableQueryModel input)
        {
            if (input == null)
            {
                return null;
            }

            var mapper = new DataBaseQueryModel()
            {
                Id = input.Id,
                Name = input.Name
            };
            return mapper.ToVMdatabases();
        }
    }
}