using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GETmerger.BLL.Contracts.Models.Output
{
    public class DatabasesOutputModelcs
    {
        public IEnumerable<string> Names { get; set; }
    }
}