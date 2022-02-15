using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyon.WinUI.Helper
{
    using Model;
    public static class UIExtension
    {

        //Combobox'a seçiniz yazısı gelmesi için bu extension metodu yazıyoruz.
        public static void SetDataSourceFirstItems<TValue, TData>(this ComboBox combo, IEnumerable<TData> datasource, string displayMember, string valueMember, string firstItemText)
            where TValue : struct
            where TData : class
        {

            List<KeyValue<TValue, TData>> newDatasources = new List<KeyValue<TValue, TData>>();
            newDatasources.Add(new KeyValue<TValue, TData>() { Key = firstItemText, Value = null, Data = null }); //Value= null çünkü database value herhangi bir value  gitmemesi için.

            //Reflection ile yaptık. Reflection ile nesnenin herşeyine ulaşabiliriz.
            foreach (var item in datasource)
            {
                var key = (string)typeof(TData).GetProperty(displayMember).GetValue(item);
                var value = (TValue)typeof(TData).GetProperty(valueMember).GetValue(item);

                newDatasources.Add(new KeyValue<TValue, TData>() { Key = key, Value = value, Data = item });
            }

            combo.DataSource = newDatasources;
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";
        }

        /// <summary>
        /// Combobox'un value değerini alabilmek için kullanılan metot.
        /// Liste içindeki indexi bulup onunda value değerini geri dönüyorum.
        /// </summary>
        /// <typeparam name="TValue"></typeparam> //Value Tipi
        /// <typeparam name="TData"></typeparam> // Datanın Tipi
        /// <param name="combo"></param>
        /// <returns></returns>
        public static TValue? GetValue<TValue, TData>(this ComboBox combo)
            where TValue:struct
            where TData: class
        {
            return ((combo.DataSource as List<KeyValue<TValue,TData>>)[combo.SelectedIndex]).Value;
        }


        /// <summary>
        /// KategoriId ve Supplierd null geldiği durumlar için.
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="value"></param>
        public static void SetSelectedValue(this ComboBox combo, object value)
        {
            if (value != null)
                combo.SelectedValue = value;
        }

    }
}
