using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Common;
using Database;

namespace Database
{
    public static class ProductListDB
    {
        public const string DIR = "Screen";
        public const string SCREEN_NAME = "ProductList";
        public const string SQL_DIR = DIR + "\\" + SCREEN_NAME + "\\";
        public static List<ProductModel> GetPageData(string categoryId, string productname)
        {
            List<ProductModel> lstData = new List<ProductModel>();
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();

                DBParam dbParam = new DBParam();
                dbParam["CategoryId"] = categoryId;
                dbParam["ProductName"] = productname;

                string sql = Utils.GetSql(SQL_DIR + "GetPageData.sql");
                lstData = connection.Select<ProductModel>(sql, dbParam);
                return lstData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
