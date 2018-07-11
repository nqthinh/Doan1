using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLyKhachSan
{
    public partial class FrmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        public static bool IsLogin = false;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string chuoi1 = txtTaiKhoan.Text;
            string chuoi2 = txtMatKhau.Text;

            //chuoi1 = chuoi1.Trim(); //cắt khoảng trắng đầu cuối
            //chuoi2 = chuoi2.Trim(); //cắt khoảng trắng đầu cuối

            if (txtTaiKhoan.Text.Trim() == "admin" && txtMatKhau.Text.Trim() == "admin")
            {
                IsLogin = true;
                XtraMessageBox.Show("Đăng nhập thành công");
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
            else
            {
                XtraMessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu. Nhập lại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult alert;

            alert = XtraMessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (alert == DialogResult.Yes)
            {
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }
    }
}