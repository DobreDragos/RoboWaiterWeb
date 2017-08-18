using System;
using System.Data;
using GlobalClasses.Models;
using SqlLite;

namespace BusinessLayer
{
    public interface IBusinessBase
    {
        void ExecuteInTransaction(Action action, SqlConnectorManager connector, params ModelBase[] models);
    }
}