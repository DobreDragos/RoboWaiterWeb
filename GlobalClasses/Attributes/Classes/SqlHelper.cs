using GlobalClasses.Extensions;
using GlobalClasses.Attributes;
using GlobalClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GlobalClasses.Interfaces;

namespace GlobalClasses.Classes
{
    /// <summary>
    /// This class contains methods for getting a model's properties, fields and values
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// This method returns the name of the model's field as it is in the database. This is set by attributes (SqlFieldName) in the models.
        /// </summary>
        /// <param name="propInfo">The property info of the model's field</param>
        /// <param name="fieldNameId">The database field name of the ID. Is is needed because ID can not have a SqlFieldName</param>
        /// <returns>The field's name as string</returns>
        public static string GetPropertyDBFieldName(PropertyInfo propInfo)
        {
            var sqlFieldName = propInfo.GetCustomAttributes(typeof(SqlFieldName), false);
            return (sqlFieldName == null || sqlFieldName.Count() == 0 ? propInfo.Name : sqlFieldName[0].ToString());
        }
        /// <summary>
        /// This method outputs two lists containing the model's field names and values.
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="fieldNames">The output list of the model's field names as strings</param>
        /// <param name="values">The output list of the model's field values as objects</param>
        /// <param name="ignoredFields">A list containing field's names to ignore (As they are in the model)</param>
        public static void GetModelFieldsAndValues(IModelBase model, out List<string> fieldNames, out List<object> values, List<string> ignoredFields = null)
        {
            fieldNames = new List<string>();
            values = new List<object>();

            foreach (var prop in model.GetType().GetProperties())
            {
                if (prop.GetCustomAttributes(typeof(IgnoredProperty), false).FirstOrDefault() != null ||
                    (ignoredFields != null && ignoredFields.Exists(x => x.ToLower().Equals(prop.Name.ToLower()))))
                    continue;
                             
                fieldNames.Add(GetPropertyDBFieldName(prop));
                values.Add(prop.GetValue(model,null));
            }
        }
        /// <summary>
        /// This methods returns a list which contains all the properties of the model's fields.
        /// Fields that have the attribute "IgnoredProperty" are ignored.
        /// </summary>
        /// <param name="type">The type of the model(class)</param>
        /// <returns>A list of PropertyInfo objects</returns>
        public static List<PropertyInfo> GetProperties(Type type)
        {
            List<PropertyInfo> retList = new List<PropertyInfo>();
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttributes(typeof(IgnoredProperty), false).FirstOrDefault() != null)
                    continue;
                retList.Add(prop);
            }
            return retList;
        }

        public static string GetPrimaryKeyFieldName(Type type)
        {
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetCustomAttributes(typeof(PrimaryKey), false).FirstOrDefault() != null)
                {
                    return GetPropertyDBFieldName(prop);
                }
            }
            return null;
        }

        public static string GetTableName<T>() where T: IModelBase
        {
            var att = typeof(T).GetCustomAttributes(
                typeof(TableName), true).FirstOrDefault();
            return att != null ? att.ToString() : typeof(T).Name.TrimEnd("Model");
        }
    }
}
