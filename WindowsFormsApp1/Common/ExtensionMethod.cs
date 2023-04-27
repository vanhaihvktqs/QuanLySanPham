using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dic = System.Collections.Generic.Dictionary<string, string>;
using DicList = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Common
{
    public static class ExtensionMethod
    {
        public static DicList ToDicList(this DataTable datatable)
        {
            DicList listData = new DicList();
            DataColumnCollection columns = datatable.Columns;
            if(datatable.Rows.Count == 0)
            {
                return new DicList();
            }
            foreach(DataRow rowData in datatable.Rows)
            {
                Dic dic = new Dic();
                foreach(DataColumn column in columns)
                {
                    string columnName = column.ColumnName;
                    string value = rowData.GetValue(columnName);
                    dic.Add(columnName, value);
                }
                listData.Add(dic);
            }
            return listData;
        }

        public static string GetValue(this DataRow rowData, string column)
        {
            try
            {
                object value = rowData[column];
                if (value == null) return "";
                return value.ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}
