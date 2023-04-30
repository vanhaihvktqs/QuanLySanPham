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
    public static class ProductDB
    {
        public const string DIR = "Table";
        public const string TABLE_NAME = "Product";
        public const string SQL_DIR = DIR + "\\" + TABLE_NAME + "\\";
        public static ProductModel GetDetail(int categoryId, int productId)
        {
            ProductModel model = null;
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();

                DBParam dbParam = new DBParam();
                dbParam["Id"] = categoryId.ToString();
                dbParam["CategoryId"] = productId.ToString();

                string sql = Utils.GetSql(SQL_DIR + "SelectItems.sql");
                var lstInfo = connection.Select<ProductModel>(sql, dbParam);
                if (lstInfo.Count > 0)
                {
                    model = lstInfo.FirstOrDefault();
                }
                return model;
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
        public static int Insert(ProductModel model)
        {
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();
                string sql = Utils.GetSql(SQL_DIR + "InsertItems.sql");
                int newId = GetMaxId(model.CategoryId) + 1;
                DBParam dbParam = new DBParam();
                dbParam["Id"] = newId;
                dbParam["CategoryId"] = model.CategoryId;
                dbParam["Name"] = model.Name;
                dbParam["Image"] = model.Image;
                dbParam["Price"] = model.Price;
                dbParam["Quantity"] = model.Quantity;
                dbParam["Description"] = model.Description;
                dbParam["CreateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                return connection.Execute(sql, dbParam);
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
        public static int Update(ProductModel model)
        {
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();
                string sql = Utils.GetSql(SQL_DIR + "UpdateItems.sql");

                DBParam dbParam = new DBParam();
                dbParam["Id"] = model.Id;
                dbParam["CategoryId"] = model.CategoryId;
                dbParam["Name"] = model.Name;
                dbParam["Image"] = model.Image;
                dbParam["Price"] = model.Price;
                dbParam["Quantity"] = model.Quantity;
                dbParam["Description"] = model.Description;
                dbParam["UpdateTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                return connection.Execute(sql, dbParam);
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
        public static int Delete(int categoryId, int productId)
        {
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();

                DBParam dbParam = new DBParam();
                dbParam["Id"] = categoryId.ToString();
                dbParam["CategoryId"] = productId.ToString();

                string sql = Utils.GetSql(SQL_DIR + "DeleteItems.sql");
                return connection.Execute(sql, dbParam);
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
        private static int GetMaxId(int categoryId)
        {
            ProductModel model = null;
            MySqlDB connection = new MySqlDB();
            try
            {
                connection.Open();

                DBParam dicParam = new DBParam();
                dicParam["CategoryId"] = categoryId.ToString();

                string sql = Utils.GetSql(SQL_DIR + "GetMaxId.sql");
                var lstInfo = connection.Select<ProductModel>(sql, dicParam);
                if (lstInfo.Count > 0)
                {
                    model = lstInfo.FirstOrDefault();
                    return model.Id;
                }
                else
                {
                    return 0;
                }
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
