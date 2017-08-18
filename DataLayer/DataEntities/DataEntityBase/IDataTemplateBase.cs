using System.Collections.Generic;
using GlobalClasses.Classes;
using GlobalClasses.Models;

namespace DataLayer.DataLogic
{
    public interface IDataTemplateBase<T> : IDataBase where T : IModelBase, new()
    {
        bool Delete(T model);
        List<T> GetAll();
        List<T> GetAllFromDb(params SqlFilter[] filters);
        T GetById(long Id);
        long Insert(T model, bool includeId = false);
        bool Update(T model);
       
    }
}