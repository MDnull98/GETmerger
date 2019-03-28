using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GETmerger.BLL.Contracts.Models.Output
{
    public class DatabasesOutputModels
    {
        public IEnumerable<string> Names { get; set; }
    }
}