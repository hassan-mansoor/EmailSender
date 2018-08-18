using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPECFILE_M
{
    public class SmtpSettings
    {
        public string server { get; set; }
        public string Enable_ssl { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string port { get; set; }
    }
}
