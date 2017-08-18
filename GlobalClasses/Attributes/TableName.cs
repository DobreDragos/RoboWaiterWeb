using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Attributes
{
    public class TableName : Attribute
    {
        private string tableName { get;  set; }
        public TableName(string originalFieldName) {

            this.tableName = originalFieldName;
        }

        public override string ToString()
        {
            return tableName;
        }
    }
}
