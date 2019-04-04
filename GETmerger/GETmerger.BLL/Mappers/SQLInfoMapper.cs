using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.BLL.Mappers
{
    public static class SQLInfoMapper
    {
        public static TableQueryInputModel ToQueryTableModel(this TableDTO input)
        {
            if (input == null)
            {
                return null;
            }

           return new TableQueryInputModel
            {
                Id = input.Id,
                Name = input.Name
            };
        }
        public static DBQueryInputModel ToQueryDBModel(this DataBaseDTO input)
        {
            if (input == null)
            {
                return null;
            }

            return new DBQueryInputModel
            {
                Id = input.Id,
                Name = input.Name
            };
        }
    }
}