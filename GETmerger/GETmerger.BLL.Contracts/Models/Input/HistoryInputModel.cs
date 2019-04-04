using System;

namespace GETmerger.BLL.Contracts.Models.Input
{
    public class HistoryInputModel
    {
        public int Id { get; set; }
        public int DatabaseId { get; set; }
      //  public string DataBaseName { get; set; }
        public int TableId { get; set; }
      //  public string TableName { get; set; }
        public string GenerateScript { get; set; }
        public DateTime AddDate { get; set; }
    }
}
