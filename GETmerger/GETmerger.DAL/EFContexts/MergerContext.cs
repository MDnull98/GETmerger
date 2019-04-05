using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.Models;
using GETmerger.DAL.Contracts.Models.DomainModels;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.EFContexts
{
    public class MergerContext:DbContext
    {
        public DbSet<HistoryEntity> History { get; set; }

        public MergerContext() : base(@"Data Source=MDNULL\SQLEXPRESS;Initial Catalog=Merger Context;Integrated Security=True;")
        {
            
        }
    }
}
