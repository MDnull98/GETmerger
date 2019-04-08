using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GETmerger.API.ViewModels
{
    public class HistoryVM
    {
        public int Id { get; set; }
        public int DatabaseId { get; set; }
        public int TableId { get; set; }
        public string GenerateScript { get; set; }
        public DateTime AddDate { get; set; }
    }
}