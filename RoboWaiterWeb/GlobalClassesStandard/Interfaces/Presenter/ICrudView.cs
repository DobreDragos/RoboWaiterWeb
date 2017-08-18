using GlobalClasses.Enums;
using GlobalClasses.Interfaces;
using GlobalClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Interfaces
{
    /// <summary>
    /// Interface that contains base methods that most forms must implement.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudView<T> : IBaseView where T: IModelBase
    {
        void SetFormStatus(FormStatus formStatus);

        void RefreshDataGrid(List<T> list);

        void TranslateDataGrid(ResourceManager res);

        bool SelectDataGridItem(string selectedName = "");
    }
}
