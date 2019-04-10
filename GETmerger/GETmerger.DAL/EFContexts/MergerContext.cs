using System.Data.Entity;
using GETmerger.DAL.Contracts.Models.DomainModels;

namespace GETmerger.DAL.EFContexts
{
    public class MergerContext:DbContext
    {
        public DbSet<HistoryEntity> History { get; set; }
        public static readonly string conn = @"Data Source=MDNULL\SQLEXPRESS;Initial Catalog=History;Integrated Security=True;";

        public MergerContext() : base(conn)
        {
            
        }
    }
}
