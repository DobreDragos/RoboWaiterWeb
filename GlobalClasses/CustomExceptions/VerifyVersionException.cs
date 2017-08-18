using GlobalClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.CustomExceptions
{
    public class VerifyVersionException : Exception
    {
        public VerifyVersionExceptions Ex { get; set; }
        public Action UpdateAction { get; set; }
        public VerifyVersionException(VerifyVersionExceptions e, Action updateAction = null) : base()
        {
            this.Ex = e;
            this.UpdateAction = updateAction;
        }
    }
}
