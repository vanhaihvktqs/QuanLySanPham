using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Database;
using WindowsFormsApp1.Model;
using Dic = System.Collections.Generic.Dictionary<string, string>;

namespace WindowsFormsApp1.Service
{
    public static class CategoryManagementService
    {
        public const  string DIR = "Sql\\Table\\";
        public const string TABLE = "Category\\";
        public const string FILE = DIR + TABLE;
        public static List<CategoryModel> GetAllCategory()
        {
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();
                string sql = Utils.GetSql(FILE + "SelectItems.sql");
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
