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
            pictureBox1.Image = Utils.ByteToImage(_Model.Image);
            lblName.Text = _Model.Name;
            lblDescription.Text = _Model.Description;
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
    }
}
