using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Database
{
    public static class CategoryDB
    {
        public const string DIR = "Table";
        public const string TABLE_NAME = "Category";
        public const string SQL_DIR = DIR + "\\" + TABLE_NAME + "\\";
        public static List<CategoryModel> GetAllCategory()
        {
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();
                string sql = Utils.GetSql(SQL_DIR + "SelectItems.sql");
                List<CategoryModel> lstCategory = connection.Select<CategoryModel>(sql);
                return lstCategory;
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
