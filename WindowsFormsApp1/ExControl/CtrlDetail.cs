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
using Common;

namespace WindowsFormsApp1
{
    public partial class CtrlDetail : UserControl
    {
        public event EventHandler<ProductModel> ButtonDetail_Clicked;
        public event EventHandler<ProductModel> ButtonDelete_Clicked;
        int _No;
        ProductModel _Model;

        public CtrlDetail(int No, ProductModel Model)
        {
            InitializeComponent();
            _No = No;
            _Model = Model;
        }
        private void Detail_Load(object sender, EventArgs e)
        {
            lblNo.Text = _No.ToString();
            lblCategory.Text = _Model.CategoryName;
            pictureBox1.Image = Utils.ByteToImage(_Model.Image);
            lblName.Text = _Model.Name;
            lblPrice.Text = "Đơn giá: " + _Model.Price.ToString("#,##0") + " vnđ";
            lblQuantity.Text = "Số lượng: " + _Model.Quantity.ToString("#,##0");
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (ButtonDetail_Clicked != null)
            {
                ButtonDetail_Clicked.Invoke(this, _Model);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ButtonDelete_Clicked != null)
            {
                ButtonDelete_Clicked.Invoke(this, _Model);
            }
        }
        private void MouseHover_Event(object sender, EventArgs e)
        {
            this.BackColor = Color.LightYellow;
        }
        private void MouseLeave_Event(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
