using GlobalClasses.Attributes;
using GlobalClasses.Classes;
using GlobalClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Models
{
    public abstract class ModelBase : IModelBase
    {
        public long Id { get; set; }

        [IgnoredProperty]
        public string IdFieldName { get { return "Id"; } }

        [IgnoredProperty]
        public bool IsNew
        {
            get
            {
                return Id <= 0;
            }
        }
    }
}
