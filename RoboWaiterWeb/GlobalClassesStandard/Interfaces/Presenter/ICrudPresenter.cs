using GlobalClasses.Models;

namespace GlobalClasses.Interfaces
{
    /// <summary>
    /// Interface containing base methods used by forms.
    /// </summary>
    /// <typeparam name="T">The object model implementing <see cref="IModel"/></typeparam>
    public interface ICrudPresenter<T> where T: IModelBase
    {
        void BindViewToModel();
        /// <summary>
        /// Bind model to the view
        /// </summary>
        /// <param name="model">The model implementing <see cref="IModel"/></param>
        void BindModelToView(T model);
        void InitializeView();
        /// <summary>
        /// Add new object
        /// </summary>
        void Add();
        /// <summary>
        /// Update existing object
        /// </summary>
        void Update();
        /// <summary>
        /// Delete existing object
        /// </summary>
        void Delete();
        /// <summary>
        /// Save modifications
        /// </summary>
        void Save();
        /// <summary>
        /// Cancel modifications
        /// </summary>
        void Cancel();
        void Back();
    }
}