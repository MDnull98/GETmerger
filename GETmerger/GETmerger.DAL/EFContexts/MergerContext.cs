using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GETmerger.DAL.Contracts.Models;
using GETmerger.DAL.Contracts.Models.DTOs;

namespace GETmerger.DAL.Contracts.EF
{
    public class MergerContext:DbContext
    {
        public DbSet<BaseName> Bases { get; set; }
        public DbSet<TableName> Tables { get; set; }

        public MergerContext() : base("MergerContext")
        {
            
        }
    }
}
