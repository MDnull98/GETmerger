using System;

namespace GETmerger.BLL.Contracts.Models.Input
{
    public class HistoryOutputModel
    {
        public int Id { get; set; }
        public int DatabaseId { get; set; }
        public int TableId { get; set; }
        public string GenerateScript { get; set; }
        public DateTime AddDate { get; set; }
    }
}
