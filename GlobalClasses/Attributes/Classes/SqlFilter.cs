using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalClasses.Enums;
using GlobalClasses.Extensions;
using GlobalClasses.Interfaces;

namespace GlobalClasses.Classes
{
    public class SqlFilter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public SqlOperators Operator { get; set; }
        public SqlLogicOperators LogicOperator { get; set; }

        /// <summary>
        /// select where [name] [operator] [value]
        /// </summary>
        /// <param name="name">name as is in database</param>
        /// <param name="op">operator</param>
        /// <param name="value">value that is compared with operator</param>
        /// <param name="lo">TODO add description</param>
        public SqlFilter(string name, object value, SqlOperators op = SqlOperators.equals, SqlLogicOperators lo = SqlLogicOperators.and)
        {
            this.Name = name;
            this.Value = value;
            this.Operator = op;
            this.LogicOperator = lo;
        }

        public string GetSqlOperator()
        {
            return Operator.GetDescription();
        }
        public string GetSqlLogicOperator()
        {
            return LogicOperator.GetDescription();
        }

        /// <summary>
        /// Used exclusively for StartsWidth, Contains, EndsWidth
        /// </summary>
        /// <param name="value">returns %value or %value% or value% or value according to sql operator</param>
        /// <returns></returns>
        public object GetParsedValue()
        {
            if (Operator == SqlOperators.startsWidth)
                return "%" + Value;
            if (Operator == SqlOperators.contains)
                return "%" + Value + "%";
            if (Operator == SqlOperators.endsWidth)
                return Value + "%";

            return Value;
        }

    }
}
