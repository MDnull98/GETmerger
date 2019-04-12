using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GETmerger.BLL
{
    public static class XMLParser
    {
        public static string GetSQL(string xmlfile)
        {
            var pars = xmlfile.Substring(4);
            pars = pars.Substring(0, pars.Length - 8);
            return pars;
        }
    }
}
