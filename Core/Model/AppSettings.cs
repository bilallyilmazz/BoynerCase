using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class AppSettings
    {
        private static string _CaseConnectionString;

        public static string CaseConnectionString
        {
            get { return _CaseConnectionString; }
            set { _CaseConnectionString = value; }
        }
    }
}
