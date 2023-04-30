using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Service
{
    public static class ProductService
    {
        public static ProductModel GetDetail(int categoryId, int productId)
        {
            return ProductDB.GetDetail(categoryId, productId);
        }
        public static bool Insert(ProductModel model)
        {
            return ProductDB.Insert(model) > 0;
        }
        public static bool Update(ProductModel model)
        {
            return ProductDB.Update(model) > 0;
        }
        public static bool Delete(ProductModel model)
        {
            return ProductDB.Delete(model.CategoryId,model.Id) > 0;
        }
        public static List<ProductModel> GetPageData(string categoryId, string productname)
        {
            return ProductListDB.GetPageData(categoryId, productname);
        }
    }
}
