using GlobalClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.CustomExceptions
{
    public class VerifyLicenseException : Exception
    {
        public VerifyLicenseExceptions Ex { get; set; }
        public VerifyLicenseException(VerifyLicenseExceptions e) : base()
        {
            this.Ex = e;
        }
    }
}
