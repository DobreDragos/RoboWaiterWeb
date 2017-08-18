using GlobalClasses.Extensions;
using GlobalClasses.Classes;
using GlobalClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite
{
    public class SqlCommands
    {
        public IDbCommand InsertValuesByVariable(string tableName, List<string> colNames, List<object> values)
        {
            List<string> valuesString = new List<string>();
            for (int i = 0; i < values.Count; i++)
                valuesString.Add(":value" + i);

            IDbCommand sqlCommand = new SQLiteCommand(string.Format("INSERT INTO {0} ({1}) VALUES ({2}); SELECT last_insert_rowid()",
                tableName,
                String.Join(", ", colNames.ToArray()), 
                String.Join(", ", valuesString.ToArray())));

            for (int i = 0; i < valuesString.Count; i++)
                sqlCommand.AddParam("value" + i, values[i]);

            return sqlCommand;
        }

        public IDbCommand UpdateValuesByVariable(string tableName, string pkName, object pkValue, List<string> colNames, List<object> values)
        {
            List<string> setString = new List<string>();
            for (int i = 0; i < colNames.Count; i++)
                setString.Add(colNames[i] + " = :value" + i);

            IDbCommand sqlCommand = new SQLiteCommand(string.Format("UPDATE {0} SET {1} where {2} = :pkValue",
                tableName, String.Join(", ", setString.ToArray()), pkName));

            for (int i = 0; i < setString.Count; i++)
                sqlCommand.AddParam("value" + i, values[i]);
            sqlCommand.AddParam("pkValue", pkValue);
            return sqlCommand;
        }
        
        public IDbCommand LoadAllValuesByVariable(string what, string tableName, params SqlFilter[] parameters)
        {
            List<string> setString = new List<string>();
            for (int i = 0; i < parameters.Length; i++)
            {
                
                 //for isIn or isNotIn we mut have paranthesis to work!
                string valueToReplace = $":value{i}";

                //do not put operator for the last filter
                var sqlOperator = (i == parameters.Count() - 1) ? String.Empty : parameters[i].GetSqlLogicOperator();

                //<example> Id(0) >(1) : value(2) AND(3)</example>
                setString.Add($"{parameters[i].Name} {parameters[i].GetSqlOperator()} {valueToReplace} {sqlOperator}");
            }
            string commandString = $"SELECT {what} FROM {tableName} ";
            if (parameters.Count() > 0)
                commandString += $"where {string.Join(" ", setString)}";
            IDbCommand sqlCommand = new SQLiteCommand(commandString);

            for (int i = 0; i < parameters.Length; i++)
            {
                sqlCommand.AddParam("value" + i, parameters[i].GetParsedValue());
            }

            return sqlCommand;
        }

        public IDbCommand LoadAllValuesByVariable(string what, string tableName)
        {
            IDbCommand sqlCommand = new SQLiteCommand("SELECT " + what + " from " + tableName + ";");

            return sqlCommand;
        }

        public IDbCommand DeleteByVariable(string tableName, string where, object value)
        {
            IDbCommand sqlCommand = new SQLiteCommand("Delete from " + tableName + " where " + where + " = :value;");
            sqlCommand.AddParam("value", value);

            return sqlCommand;
        }

        public IDbCommand DeleteAll(string tableName, SqlFilter[] parameters)
        {
            List<string> setString = new List<string>();
            for (int i = 0; i < parameters.Length; i++)
            {

                //for isIn or isNotIn we mut have paranthesis to work!
                string valueToReplace = $":value{i}";

                //do not put operator for the last filter
                var sqlOperator = (i == parameters.Count() - 1) ? String.Empty : parameters[i].GetSqlLogicOperator();

                //<example> Id(0) >(1) : value(2) AND(3)</example>
                setString.Add($"{parameters[i].Name} {parameters[i].GetSqlOperator()} {valueToReplace} {sqlOperator}");
            }
            string commandString = $"DELETE FROM {tableName} ";
            if (parameters.Count() > 0)
                commandString += $"where {string.Join(" ", setString)}";
            IDbCommand sqlCommand = new SQLiteCommand(commandString);

            for (int i = 0; i < parameters.Length; i++)
            {
                sqlCommand.AddParam("value" + i, parameters[i].GetParsedValue());
            }

            return sqlCommand;
        }
    }
}
