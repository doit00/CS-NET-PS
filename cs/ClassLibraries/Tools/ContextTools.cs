using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class ContextTools
    {
        public string UserName => Environment.UserName + " user";
        public string MachineName => Environment.MachineName;
        public DateTime Now => DateTime.Now;
    }
}
