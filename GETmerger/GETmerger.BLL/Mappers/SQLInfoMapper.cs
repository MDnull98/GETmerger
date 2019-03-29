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
        public static TableQueryModel ToQueryModel(this TableDTO input)
        {
            if (input == null)
            {
                return null;
            }

            var mapper = new TableDTO()
            {
                Id = input.Id,
                Name = input.Name
            };
            return mapper.ToQueryModel();
        }
    }
}