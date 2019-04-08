using System;

namespace GETmerger.DAL.Contracts.Models.DomainModels
{
    public class HistoryEntity
    {
        public int Id { get; set; }
        public int DatabaseId { get; set; }
        public int TableId { get; set; }
        public string GenerateScript { get; set; }
        public DateTime AddDate { get; set; }
    }
}
