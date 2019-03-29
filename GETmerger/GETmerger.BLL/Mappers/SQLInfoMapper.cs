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
        public static TableQueryModel ToQueryTableModel(this TableDTO input)
        {
            if (input == null)
            {
                return null;
            }

           return new TableQueryModel
            {
                Id = input.Id,
                Name = input.Name
            };
        }
        public static DataBaseQueryModel ToQueryDBModel(this DataBaseDTO input)
        {
            if (input == null)
            {
                return null;
            }

            return new DataBaseQueryModel
            {
                Id = input.Id,
                Name = input.Name
            };
        }
    }
}