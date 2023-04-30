using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Model;
using Common;
using Dic = System.Collections.Generic.Dictionary<string, string>;

namespace Service
{
    public static class CategoryService
    {
        public static List<CategoryModel> GetAllCategory()
        {
            try
            {
                List<CategoryModel> lstCategory = CategoryDB.GetAllCategory();
                return lstCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
