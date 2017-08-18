using GlobalClasses.Classes;
using GlobalClasses.Enums;
using GlobalClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GlobalClasses.Extensions
{
    public static partial class Extensions
    {
        public static string GetVersion(this Version ver)
        {
            return ver.Major + "." + ver.Minor + "." + ver.Build;
        }


        #region DecimalsExtensions

        public static decimal Rounded(this decimal val)
        {
            return Math.Round(val, 2);
        }

        public static string RoundedStr(this decimal val)
        {
            return val.Rounded().ToString("#,0.00");
        }

        #endregion
        #region StringExtensions

        /// <summary>
        /// Removes the specified suffix from the string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="suffixToRemove"></param>
        /// <returns>The new trimmed string</returns>
        public static string TrimEnd(this string input, string suffixToRemove)
        {

            if (input != null && suffixToRemove != null
              && input.EndsWith(suffixToRemove))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }
            else return input;
        }

        public static string TrimFirstOccurence(this string input, string prefixToRemove)
        {
            int index = input.IndexOf(prefixToRemove);
            return (index < 0)
                        ? input
                        : input.Remove(index, prefixToRemove.Length);
        }

        /// <summary>
        /// Append another string to the current string
        /// </summary>
        /// <param name="input">The string</param>
        /// <param name="textToAdd">The string to add</param>
        /// <returns>The new string</returns>
        public static string Append(this string input, string textToAdd)
        {
            if (textToAdd != null)
            {
                input += textToAdd;
            }
            return input;
        }

        /// <summary>
        /// Remove a set number of characters from a string's end
        /// </summary>
        /// <param name="input">The string</param>
        /// <param name="numberOfCharsToRemove">Number of characters to remove</param>
        /// <returns>The new trimmed string</returns>
        public static string RemoveLast(this string input, int numberOfCharsToRemove)
        {
            if (numberOfCharsToRemove > 0)
            {
                input = input.Substring(0, input.Length - numberOfCharsToRemove);
                //input = input.Remove(0, input.Length - numberOfCharsToRemove - 1);
            }
            return input;
        }
        /// <summary>
        /// Add a prefix to the string
        /// </summary>
        public static string AddPrefix(this string input, string prefix)
        {
            if (prefix != null)
            {
                input = prefix + input;
            }
            return input;
        }
        /// <summary>
        /// Remove the prefix from the string
        /// </summary>
        public static string RemovePrefix(this string input, string prefix)
        {
            if (prefix != null)
            {
                if (input.StartsWith(prefix))
                {
                    input = input.Substring(prefix.Length, input.Length - 1);
                }
            }
            return input;
        }
        #endregion
        /// <summary>
        /// Returns <see cref="decimal.MinValue"/> if conversion fails 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string input)
        {
            decimal aux;
            return Decimal.TryParse(input, out aux) ? aux : Decimal.MinValue;
        }

        public static bool IsDecimal(this string input)
        {
            return !input.ToDecimal().Equals(Decimal.MinValue);
        }

        public static bool IsDecimalGreaterThan(this string input, decimal value)
        {
            return input.ToDecimal() > value;
        }


        /// <summary>
        /// Get the description attribute of the Enum
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Add a paramater to the command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name">The parameter's name, As a convention, : will be added before the name</param>
        /// <param name="value">The parameter's value</param>
        public static void AddParam(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = ":" + name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        //public static partial class ControlsExtensions
        //{
        //    /// <summary>
        //    /// Selects the specified row and sets it as the first to display in the data grid view
        //    /// </summary>
        //    /// <param name="row"></param>
        //    /// <param name="dg"></param>
        //    public static void SelectAndScrollIntoView(this DataGridViewRow row, DataGridView dg)
        //    {
        //        if (dg == null)
        //            return;
        //        //force selection changed trigger event
        //        if (row.Selected)
        //            dg.ClearSelection();

        //        row.Selected = true;
        //        dg.FirstDisplayedScrollingRowIndex = row.Index;
        //    }
        //    /// <summary>
        //    /// Localizes all controls that are contained in this control
        //    /// </summary>
        //    /// <param name="ctrl">The parent control</param>
        //    /// <param name="res">The resource manager used for translations</param>
        //    public static void LocalizeLabels(this Control ctrl, ResourceManager res)
        //    {
        //        try
        //        {
        //            List<Control> ctrlList = GetContainedControls(ctrl);

        //            foreach (Control c in ctrlList)
        //            {
        //                string removePrefix = "";
        //                if (c is Label)
        //                    removePrefix = "lbl";
        //                else if (c is CheckBox)
        //                    removePrefix = "chk";
        //                else if (c is RadioButton)
        //                    removePrefix = "rb";
        //                else if (c is Button)
        //                    removePrefix = "btn";
        //                else if (c is ICustomButton)
        //                    removePrefix = "btn";
        //                else if (c is GroupBox)
        //                    removePrefix = "gb";
        //                else continue;

        //                string resource = c.Name.Replace(removePrefix, "").ToUpper();

        //                c.Text = res.GetString(resource);
        //            }

        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //    }

        //    /// <summary>
        //    /// Gets a list that contains all the child controls of the control
        //    /// </summary>
        //    /// <param name="ctrl">The control which children are required</param>
        //    /// <param name="includeParent">If true, the list will also include the parent itself</param>
        //    /// <param name="resettingControls"></param>
        //    /// <returns></returns>
        //    public static List<Control> GetContainedControls(this Control ctrl, bool includeParent = true, bool resettingControls = false)
        //    {
        //        List<Control> parentList = new List<Control>(),
        //                        childList = new List<Control>(),
        //                        tmpAdd = new List<Control>(),
        //                        tmpRemove = new List<Control>();

        //        parentList.Add(ctrl);
        //        int count = 0;
        //        while (parentList.Count > 0)
        //        {
        //            count++;
        //            foreach (Control c in parentList)
        //            {

        //                if (c is IButtonControl)
        //                {
        //                    tmpRemove.Add(c);
        //                    continue;
        //                }
        //                if (c.HasChildren)
        //                {
        //                    foreach (Control cc in c.Controls)
        //                    {
        //                        tmpAdd.Add(cc);
        //                    }
        //                }

        //                if ((c.HasChildren && includeParent) || c.HasChildren == false)
        //                {
        //                    if (c is TabPage == false && c is TabControl == false && c is ToolStrip == false)
        //                    {
        //                        if (resettingControls == false || (resettingControls && (c is TextBox || c is ComboBox || c is DateTimePicker || c is CheckBox)))
        //                        {
        //                            childList.Add(c);
        //                        }
        //                    }
        //                    else
        //                    {

        //                    }
        //                }
        //                tmpRemove.Add(c);
        //            }
        //            if (tmpRemove.Count > 0)
        //            {
        //                foreach (var v in tmpRemove)
        //                {
        //                    parentList.Remove(v);
        //                }
        //                tmpRemove.Clear();
        //            }
        //            if (tmpAdd.Count > 0)
        //            {
        //                parentList.AddRange(tmpAdd);
        //                tmpAdd.Clear();
        //            }
        //        }

        //        return childList;
        //    }
        //    /// <summary>
        //    /// Localizes a data grid view
        //    /// </summary>
        //    /// <param name="dgv"></param>
        //    /// <param name="res"></param>
        //    public static void LocalizeGrid(this DataGridView dgv, ResourceManager res)
        //    {
        //        try
        //        {
        //            for (int i = 0; i < dgv.ColumnCount; i++)
        //            {
        //                string s = res.GetString(dgv.Columns[i].DataPropertyName.ToUpper());

        //                if (string.IsNullOrEmpty(s))
        //                {
        //                    dgv.Columns[i].Visible = false;
        //                }
        //                else
        //                {
        //                    dgv.Columns[i].HeaderText = s;
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            throw;
        //        }
        //    }

        //    /// <summary>
        //    /// Selects the previous row in the dataGrid if possible and returns the new row index
        //    /// </summary>
        //    /// <param name="dataGrid">The dataGridView on which the selection takes place</param>
        //    /// <returns>The new current row index</returns>
        //    public static int DataGridSelectUp(this DataGridView dataGrid)
        //    {
        //        if (!VerifyDataGridSelect(dataGrid))
        //        {
        //            return 0;
        //        }
        //        int currentIndex = dataGrid.SelectedRows[0].Index;
        //        if (currentIndex > 0)
        //        {
        //            // Select previous item
        //            currentIndex--;
        //            dataGrid.Rows[currentIndex].Selected = true;
        //            // Verify if next item is visible
        //            if (dataGrid.Rows[currentIndex].Displayed == false)
        //            {
        //                dataGrid.FirstDisplayedScrollingRowIndex -= 1;
        //            }
        //        }
        //        return currentIndex;
        //    }

        //    /// <summary>
        //    /// Selects the next row in the dataGrid if possible and returns the new row index
        //    /// </summary>
        //    /// <param name="dataGrid">The dataGridView on which the selection takes place</param>
        //    /// <returns>The new current row index</returns>
        //    public static int DataGridSelectDown(this DataGridView dataGrid)
        //    {
        //        if (!VerifyDataGridSelect(dataGrid))
        //        {
        //            return 0;
        //        }
        //        int currentIndex = dataGrid.SelectedRows[0].Index;
        //        if (currentIndex < dataGrid.RowCount - 1)
        //        {
        //            // Select next item
        //            currentIndex++;
        //            dataGrid.Rows[currentIndex].Selected = true;
        //            // Verify if next item is visible
        //            if (dataGrid.Rows[currentIndex].Displayed == false)
        //            {
        //                dataGrid.FirstDisplayedScrollingRowIndex += 1;
        //            }
        //            else
        //            {
        //                // Verify if row is only partially displayed then scroll another line
        //                Rectangle rectangle = dataGrid.GetRowDisplayRectangle(currentIndex, true);
        //                if (rectangle.Height < dataGrid.Rows[currentIndex].Height)
        //                {
        //                    dataGrid.FirstDisplayedScrollingRowIndex += 1;
        //                }
        //            }
        //        }
        //        return currentIndex;
        //    }
        //    /// <summary>
        //    /// Verify if the dataGrid has at least one row
        //    /// </summary>
        //    /// <param name="dataGrid"></param>
        //    /// <returns>True if it has at least one row, False otherwise</returns>
        //    private static bool VerifyDataGridSelect(DataGridView dataGrid)
        //    {
        //        if (dataGrid.Rows == null || dataGrid.Rows.Count < 1)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //    /// <summary>
        //    /// Works for ComboBoxes populated by ComboBoxItem
        //    /// </summary>
        //    /// <param name="cb"></param>
        //    /// <param name="value"></param>
        //    public static void SelectByValue(this ComboBox cb, object value)
        //    {
        //        foreach(ComboBoxItem item in cb.Items)
        //        {
        //            if ( item.Value == value || (item.Value != null && item.Value.Equals(value)))
        //            {
        //                cb.SelectedItem = item;
        //                break;
        //            }
        //        }
        //    }

        //    /// <summary>
        //    /// Works for ComboBoxes populated by ComboBoxItem
        //    /// </summary>
        //    /// <param name="cb"></param>
        //    public static T SelectedValue<T>(this ComboBox cb)
        //    {
        //        return (T)((ComboBoxItem)cb.SelectedItem).Value;
        //    }

        //    /// <summary>
        //    /// Works for ComboBoxes populated by ComboBoxItem
        //    /// </summary>
        //    /// <param name="cb"></param>
        //    public static T SelectedTag<T>(this ComboBox cb)
        //    {
        //        return (T)((ComboBoxItem)cb.SelectedItem).Tag;
        //    }
        //}
    }
}
