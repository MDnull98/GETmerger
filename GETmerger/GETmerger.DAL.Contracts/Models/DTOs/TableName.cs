using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.DAL.Contracts.Models.DTOs
{
    public class TableName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseID { get; set; }
        public BaseName BaseName { get; set; }
    }
}
