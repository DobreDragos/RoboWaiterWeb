using GlobalClasses.Models;

namespace GlobalClasses.Interfaces
{
    public interface ICrudLogicalDeletePresenter<T> :ICrudPresenter<T> where T: IModelBase
    {
        void SearchLogicalDeleted(bool doSearch);
    }
}