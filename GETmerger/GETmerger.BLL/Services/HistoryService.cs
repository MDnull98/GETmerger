﻿using System;
using System.Collections.Generic;
using System.Linq;
using GETmerger.BLL.Contracts.Models.Input;
using GETmerger.BLL.Contracts.Services;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Repositories;

namespace GETmerger.BLL.Services
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository _historyRepository { get; }

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public IEnumerable<HistoryModel> GetHistory()
        {
            List<HistoryModel> DBList = new List<HistoryModel>();
            List<HistoryEntity> list = _historyRepository.GetAll().ToList();

            foreach (HistoryEntity item in list)
            {
                HistoryModel dbDTO = new HistoryModel
                {
                    Id =item.Id,
                    BaseName = item.BaseName,
                    TableName = item.TableName,
                    ExecProc = item.ExecProc,
                    GenerateScript = item.GenerateScript,
                    datenow = item.datenow
                };

                DBList.Add(dbDTO);
            }

            return DBList;
        }

        public void Create(HistoryModel historyDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public HistoryModel Get(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(HistoryModel historyDTO)
        {
            throw new NotImplementedException();
        }
    }
}
