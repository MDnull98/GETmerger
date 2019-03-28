using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.DAL.Contracts.Models.DomainModels
{
    public class HistoryEntity
    {
        public int Id { get; set; }
        public string BaseName { get; set; }
        public string TableName { get; set; }
        public string ExecProc{ get; set; }
        public string GenerScript { get; set; }
    }
}
