using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.DAL.Contracts.Models.DTOs
{
    public class HistoryDTO
    {
        public int Id { get; set; }
        public int DatabaseId { get; set; }
        public int TableId { get; set; }
        public string GenerateScript { get; set; }
        public DateTime AddDate { get; set; }
    }
}
