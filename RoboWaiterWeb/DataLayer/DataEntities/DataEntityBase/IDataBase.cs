using System.Collections.Generic;
using System.Data;
using GlobalClasses.Classes;
using GlobalClasses.Models;

namespace DataLayer.DataLogic
{
    public interface IDataBase
    {
        bool UpdateByValue(string setWhat, object setValues, long id);
        bool UpdateByValue(List<string> setWhat, List<object> setValues, long id);
        bool UpdateByValue(string setWhat, object setValue, string whereWhat, object whereValue);
        bool DeleteAll(string what, object value);
        bool DeleteAllFromDb(params SqlFilter[] filters);
    }
}