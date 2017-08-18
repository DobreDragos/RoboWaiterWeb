using GlobalClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.CustomExceptions
{
    public class VerifyViewException : Exception
    {
        public bool IsWarning;
        public ErrorCode ErrorCode;
        public VerifyViewException(ErrorCode errorCode) : base ()
        {
            ErrorCode = errorCode;
        }
        public VerifyViewException(string msg,bool isWarning = false, ErrorCode errorCode = ErrorCode.NO_ERROR_CODE) : base(msg)
        {
            IsWarning = isWarning;
            this.ErrorCode = errorCode;
        }
    }
}
