using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.DAL.Contracts.Models.DomainModels;
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
        public static DBQueryModel ToQueryDBModel(this DataBaseDTO input)
        {
            if (input == null)
            {
                return null;
            }

            return new DBQueryModel
            {
                Id = input.Id,
                Name = input.Name
            };
        }

        public static HistoryOutputModel ToHistoryModel(this HistoryDTO input)
        {
            if (input == null)
            {
                return null;
            }

            return new HistoryOutputModel()
            {
                DatabaseId = input.DatabaseId,
                TableId = input.TableId,
                GenerateScript = input.GenerateScript,
                AddDate = input.AddDate
            };
        }
    }
}