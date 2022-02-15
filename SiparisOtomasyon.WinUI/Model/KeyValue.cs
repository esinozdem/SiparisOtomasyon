using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.WinUI.Model
{
    public class KeyValue<TValue, TData>
         where TValue : struct//value type
        where TData : class//referans tipli nesneler 
    {
        public string Key { get; set; }
        public Nullable<TValue> Value { get; set; } //nullable int? null olabiliyor. Default değeri null olabilir.
        public TData Data { get; set; }
    }
}
