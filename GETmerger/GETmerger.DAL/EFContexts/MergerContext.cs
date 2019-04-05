using System.Data.Entity;
using GETmerger.DAL.Contracts.Models.DomainModels;

namespace GETmerger.DAL.EFContexts
{
    public class MergerContext:DbContext
    {
        public DbSet<HistoryEntity> History { get; set; }

        public MergerContext() : base(@"Data Source=MDNULL\SQLEXPRESS;Initial Catalog=MarketContext;Integrated Security=True;")
        {
            
        }
    }
}
