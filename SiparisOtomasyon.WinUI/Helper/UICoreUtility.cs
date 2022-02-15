﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyon.WinUI.Helper
{
    using Core.Utility;
    public static class UICoreUtility
    {
        public static void Successmessage(string Message)
        {
            MessageBox.Show(Message, CoreHelper.AppNameVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Errormessage(string message)
        {
            MessageBox.Show(message, CoreHelper.AppNameVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult DialogMessage(string message)
        {
            return MessageBox.Show(message, CoreHelper.AppNameVersion, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// Datagridview için column mappingde kullanılacak.
        /// </summary>
        /// <param name="name">Colon Name</param>
        /// <param name="dataPropertyName">datasource içerisinde data index</param>
        /// <param name="headerText">Gridview header kısmında gözükecek isim</param>
        /// <returns></returns>
        public static DataGridViewTextBoxColumn generateDataGridViewTextBoxcolumn(string name, string dataPropertyName, string headerText)
        {
            return new DataGridViewTextBoxColumn()
            {
                Name = name,
                DataPropertyName = dataPropertyName,
                HeaderText = headerText
            };
        }
        /// <summary>
        /// Form üzerindeki controllerin sıfırlanması işlemidir.
        /// </summary>
        /// <param name="formControls"></param>
        public static void FormClear(Control formControls = null)
        {

            foreach (var control in formControls.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
                else if (control is NumericUpDown)
                {
                    (control as NumericUpDown).Value = 0;
                }
                else if (control is Panel)
                {
                    FormClear(control as Panel);
                }
                else if (control is MaskedTextBox)
                {
                    (control as MaskedTextBox).Clear();

                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).SelectedIndex = -1;
                }
                else if (control is CheckBox)
                {
                    (control as CheckBox).Checked = false;
                }
                else if (control is GroupBox)
                {
                    FormClear(control as GroupBox);
                }
                else if (control is DateTimePicker)
                {
                    (control as DateTimePicker).Value = DateTime.Now;
                }

                //Yukardaki kontrolü switch case ile yapabiliriz. 
                //switch (control)
                //{
                //    case MaskedTextBox mt;
                //    case TextBox c: {control as TextBox).Clear();
                //    break; }
                //}

            }
        }
    }

}
