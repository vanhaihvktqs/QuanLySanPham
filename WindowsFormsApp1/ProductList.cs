using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Service;
using Common;

namespace WindowsFormsApp1
{
    public partial class ProductList : BaseForm
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            List<CategoryModel> listCategory = CategoryService.GetAllCategory();
            cbCategory.Binding(listCategory, "Id", "Name", true);
        }

        private void Search()
        {
            try
            {
                string categoryid = cbCategory.SelectedValue?.ToString();
                string productName = txtProductName.Text;
                List<ProductModel> lstProduct = ProductService.GetPageData(categoryid, productName);
                flpProduct.SuspendLayout();
                flpProduct.Controls.Clear();
                int cnt = 1;
                lstProduct.ForEach(product =>
                {
                    CtrlDetail ctrlDetail = new CtrlDetail(cnt, product);
                    ctrlDetail.ButtonDetail_Clicked += ShowProductDetail;
                    ctrlDetail.ButtonDelete_Clicked += DeleteProduct;
                    flpProduct.Controls.Add(ctrlDetail);
                    cnt++;
                });
                flpProduct.ResumeLayout();
            }
            catch(Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        private void ShowProductDetail(object sender, ProductModel product)
        {
            ProductDetail frmProductDetail = new ProductDetail(product);
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                Search();
            }
        }
        private void DeleteProduct(object sender, ProductModel product)
        {
            if (ProductService.Delete(product))
            {
                Search();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductDetail frmProductDetail = new ProductDetail();
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                Search();
            }
        }
    }
}
