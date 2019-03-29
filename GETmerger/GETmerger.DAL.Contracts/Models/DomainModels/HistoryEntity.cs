﻿using System;

namespace GETmerger.DAL.Contracts.Models.DomainModels
{
    public class HistoryEntity
    {
        public int Id { get; set; }
        public string BaseName { get; set; }
        public string TableName { get; set; }
        public string ExecProc{ get; set; }
        public string GenerateScript { get; set; }
        public DateTime datenow { get; set; }
    }
}
