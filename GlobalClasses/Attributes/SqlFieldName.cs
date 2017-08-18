using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Attributes
{
    public class SqlFieldName : Attribute
    {
        private string originalFieldName { get;  set; }
        public SqlFieldName(string originalFieldName) {

            this.originalFieldName = originalFieldName;
        }

        public override string ToString()
        {
            return originalFieldName;
        }
    }
}
