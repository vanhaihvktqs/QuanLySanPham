using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dic = System.Collections.Generic.Dictionary<string, string>;
using DicList = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;
using Model;
using System.Windows.Forms;
using System.Reflection;

namespace Common
{
    public static class ExtensionMethod
    {
        public static DicList ToDicList(this DataTable datatable)
        {
            DicList listData = new DicList();
            DataColumnCollection columns = datatable.Columns;
            if (datatable.Rows.Count == 0)
            {
                return new DicList();
            }
            foreach (DataRow rowData in datatable.Rows)
            {
                Dic dic = new Dic();
                foreach (DataColumn column in columns)
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

        public static void Binding<T>(this ComboBox cmb, IEnumerable<T> listData, string feildValue, string feildDisplay, bool createItemAll = false)
        {
            List<clsDataBinding> lstDataBinding = new List<clsDataBinding>();
            if (createItemAll)
            {
                clsDataBinding dataBinding = new clsDataBinding();

                dataBinding.Value = null;
                dataBinding.Display = "Tất cả";
                lstDataBinding.Add(dataBinding);
            }
            foreach (T data in listData)
            {
                clsDataBinding dataBinding = new clsDataBinding();
                PropertyInfo infoDisplay = data.GetType().GetProperty(feildDisplay);
                PropertyInfo infoValue = data.GetType().GetProperty(feildValue);
                dataBinding.Value = infoValue.GetValue(data);
                dataBinding.Display = infoDisplay.GetValue(data).ToString();
                lstDataBinding.Add(dataBinding);
            }

            cmb.DataSource = lstDataBinding;
            cmb.DisplayMember = "Display";
            cmb.ValueMember = "Value";
        }
    }
}
