using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Classes
{
    public class ComboBoxItem
    {
        public ComboBoxItem(string text, object value, object tag = null)
        {
            this.Text = text;
            this.Value = value;
            this.Tag = tag;
        }
        public object Tag { get; set; }
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
