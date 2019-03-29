using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.DAL.Contracts.Models.DTOs;
using GETmerger.DAL.Contracts.QueryRepositories;

namespace GETmerger.BLL.Services
{
    public class DBQueryService : IDBQueryService
    {
        private IDBQueryRepository _db { get; }

        public DBQueryService(IDBQueryRepository db)
        {
            _db = db;
        }

        public List<DataBaseQueryModel> GetAll()
        {
            List<DataBaseQueryModel> DBList = new List<DataBaseQueryModel>();
            List<DataBaseDTO> list = _db.GetAll().ToList();
            foreach (DataBaseDTO item in list)
            {
                DataBaseQueryModel dbDTO = new DataBaseQueryModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                DBList.Add(dbDTO);
            }
            return DBList;
        }
    }
}
