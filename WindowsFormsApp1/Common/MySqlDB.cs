using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Model;
using Dic = System.Collections.Generic.Dictionary<string, string>;

namespace WindowsFormsApp1
{
    public class MySqlDB
    {
        MySqlConnectionStringBuilder conn_string;
        MySqlConnection connecttion;
        MySqlTransaction transaction;
        public MySqlDB()
        {
            string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySanPham"].ConnectionString;
            connecttion = new MySqlConnection(connectString);

        }
        public void Open()
        {
            connecttion.Open();
        }
        public void Close()
        {
            if (connecttion != null)
            {
                connecttion.Close();
            }
        }
        public void BeginTransaction()
        {
            if (connecttion == null) return;
            transaction = connecttion.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction == null) return;
            transaction.Commit();
        }
        public void Rollback()
        {
            if (transaction == null) return;
            transaction.Rollback();
        }
        public List<T> Select<T>(string sql, Dic dbParams = null) where T : BaseModel
        {
            DataTable dtRet = new DataTable();
            MySqlCommand command = connecttion.CreateCommand();
            command.CommandText = sql;
            if (dbParams != null)
            {
                foreach (KeyValuePair<string, string> param in dbParams)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(dtRet);
            return ToListModel<T>(dtRet);
        }
        public int Execute(string sql, Dic dbParams)
        {
            MySqlCommand command = connecttion.CreateCommand();
            command.CommandText = sql;
            foreach (KeyValuePair<string, string> param in dbParams)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }
            int iRet = command.ExecuteNonQuery();
            return iRet;
        }

        private T ToModel<T>(DataRow rowData) where T : BaseModel
        {

            T model = Activator.CreateInstance<T>();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;
                string colName = "";
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    ColumnAttribute colAttr = attr as ColumnAttribute;
                    if (colAttr != null)
                    {
                        colName = colAttr.Name;
                    }
                }
                if (string.IsNullOrEmpty(colName))
                {
                    colName = propName;
                }
                prop.SetValue(model, rowData.GetValue(colName));
            }
            return model;
        }
        private List<T> ToListModel<T>(DataTable dataTable) where T : BaseModel
        {
            List<T> lst = new List<T>();
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    T model = ToModel<T>(dataRow);
                    lst.Add(model);
                }
            }
            return lst;
        }
    }
}
