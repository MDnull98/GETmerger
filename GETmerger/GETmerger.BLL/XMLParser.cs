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
            string pars = xmlfile.Substring(4);
            pars = xmlfile.Substring(0, xmlfile.Length - 2);
         // pars = pars.Replace(@"\r\n", " ");
            return pars;
        }
    }
}
