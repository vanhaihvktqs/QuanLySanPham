using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;
using Service;

namespace WindowsFormsApp1
{
    public partial class ProductDetail : BaseForm
    {
        ProductModel _Model;
        byte[] imageData;
        public ProductDetail(ProductModel Model = null)
        {
            InitializeComponent();
            _Model = Model;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            picImage.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image img = null;
                using (Stream stream = File.OpenRead(ofd.FileName))
                {
                    img = Image.FromStream(stream);
                }
                if (img != null)
                {
                    imageData = Utils.ImageToByte(img);
                    picImage.Image = img;
                }
            }
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            List<CategoryModel> listCategory = CategoryService.GetAllCategory();
            cbCategory.Binding(listCategory, "Id", "Name");
            if (_Model == null) return;
            imageData = _Model.Image;
            picImage.Image = Utils.ByteToImage(_Model.Image);
            cbCategory.SelectedValue = _Model.CategoryId;
            txtName.Text = _Model.Name;
            txtDescription.Text = _Model.Description;
            txtPrice.Text = _Model.Price.ToString();
            txtQuantity.Text = _Model.Price.ToString();
            cbCategory.Enabled = false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!"0123456789".Contains(e.KeyChar)) return;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string val = txt.Text.Trim().Replace(",", "");
            if (val == "") txt.Text = "0";
            if (!int.TryParse(val, out int iVal))
            {
                txt.Text = "0";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductModel model = _Model;
            bool insertFlag = model == null;
            if (model == null)
            {
                model = new ProductModel();
                model.CategoryId = (int)cbCategory.SelectedValue;
            }
            model.Name = txtName.Text;
            model.Description = txtDescription.Text;
            double price = 0;
            double.TryParse(txtPrice.Text.Replace(",", ""), out price);
            model.Price = price;
            int quantity = 1;
            int.TryParse(txtQuantity.Text.Replace(",", ""), out quantity);
            model.Image = imageData;
            model.Quantity = quantity;
            try
            {
                bool flag = insertFlag ? ProductService.Insert(model) : ProductService.Update(model);
                if (flag)
                {
                    ShowSuccess("Save info completed!");
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowError("Save info error!");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}
