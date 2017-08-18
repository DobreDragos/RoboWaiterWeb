using BusinessLayer;
using DataLayer.DataLogic;
using GlobalClasses.Classes;
using GlobalClasses.Interfaces;
using GlobalClasses.Models;
using SqlLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Context
    {
        private Dictionary<Type, IBusinessBase> BusinessEntities;
        private Dictionary<Type, IDataBase> DataEntities;
        private static IEnumerable<Type> ExistingIDataBase = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.IsAbstract == false && t.GetInterfaces().Contains(typeof(IDataBase)));
        private static IEnumerable<Type> ExistingIBusinessBase = Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.IsAbstract == false && t.GetInterfaces().Contains(typeof(IBusinessBase)));
        public Context(bool hasSqlAccess)
        {
            SqlConnectorManager sqlCon = new SqlConnectorManager();
            if (hasSqlAccess)//else if web we should give the URL to the data access
                sqlCon.InitializeConnection(@"C:\PosLite\PosLite.s3db");

            BusinessEntities = new Dictionary<Type, IBusinessBase>();
            DataEntities = new Dictionary<Type, IDataBase>();
            var typeOfDataBase = typeof(IDataBase);
            var typeOfBusinessBase = typeof(IBusinessBase);
            //Loads all Data Entities
            foreach (var type in ExistingIDataBase)
            {
                var entity = hasSqlAccess?(IDataBase)Activator.CreateInstance(type) : (IDataBase)Activator.CreateInstance(type,sqlCon);

                //get interface that is not a base (isgeneric refers to iblentity<T>)
                var first = type.GetInterfaces().First(x => x.IsGenericType == false && !(x.Equals(typeOfDataBase)));
                DataEntities.Add(first, entity);
            }

            foreach (var type in ExistingIBusinessBase)
            {
                //get interface that is not a base
                var first = type.GetInterfaces().First(x => x.IsGenericType == false && !(x.Equals(typeOfBusinessBase)));
                var transaction = (IBusinessBase)Activator.CreateInstance(type);
                BusinessEntities.Add(first, transaction);
            }
        }

        /// <summary>
        /// Gets business entity
        /// </summary>
        /// <typeparam name="T">business entity you want to get</typeparam>
        /// <returns></returns>
        public T GetBusiness<T>() where T : IBusinessBase
        {
            return (T)BusinessEntities[typeof(T)];
        }

        /// <summary>
        /// Gets Transaction component
        /// </summary>
        /// <typeparam name="T">Transaction component you want to get</typeparam>
        /// <returns></returns>
        public T Get<T>() where T: IDataBase
        {
            return (T)DataEntities[typeof(T)];
        }
    }
}
