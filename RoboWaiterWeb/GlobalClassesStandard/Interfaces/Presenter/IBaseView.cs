using GlobalClasses.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Interfaces
{
    /// <summary>
    /// Interface containing base fields and methods that all application's forms must implement
    /// </summary>
    public interface IBaseView
    {
        /// <summary>
        /// The name used to distinguish forms
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Method that translates all the controls on the form
        /// </summary>
        /// <param name="res">The specific resource manager used by the form</param>
        void TranslateLabels(ResourceManager res);

        void Close();

        bool IsDisposed { get; }

        void Show();

        void Hide();

        Color BackColor
        {
            get; set;
        }

        object BackgroundImage
        {
            get; set;
        }
    }
}
