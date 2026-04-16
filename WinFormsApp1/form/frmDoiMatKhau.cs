using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocKhachHang.form
{
    public partial class frmDoiMatKhau : Form
    {
        public string matKhauCu;
        public string matKhauMoi;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu cũ!");
                txtMatKhauCu.Focus();
                return;
            }

            if (txtMatKhauMoi.Text == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (txtXacNhan.Text != txtMatKhauMoi.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng!");
                txtXacNhan.Focus();
                return;
            }

            matKhauCu = txtMatKhauCu.Text;
            matKhauMoi = txtMatKhauMoi.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hien = chkHienMatKhau.Checked;

            txtMatKhauCu.UseSystemPasswordChar = !hien;
            txtMatKhauMoi.UseSystemPasswordChar = !hien;
            txtXacNhan.UseSystemPasswordChar = !hien;
        }
    }
}
