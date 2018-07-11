using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace QuanLyKhachSan
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        //Check form
        Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        //Check form  -- Form tồn tại chưa
        Form Checkform(Type fType)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            /*
            if (FrmDangNhap.IsLogin == true)
            {
                MoKhoaButton();
                btnDangNhap.Enabled = false;               
            }
            else
            {
                KhoaButton();
            }*/

            Form frm = Checkform((typeof(FrmHoaDon)));
                if (frm != null)
                    frm.Activate();
                else
                {
                    FrmTinhTrangPhong frmTTP = new FrmTinhTrangPhong();
                    frmTTP.MdiParent = this;
                    frmTTP.Show();
                }
        }


        //Load form nhân viên
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform(typeof(FrmNhanVien)); //Active
            if (frm != null)
                frm.Activate();
            else
            {
                FrmNhanVien FrmNV = new FrmNhanVien();
                FrmNV.MdiParent = this;
                FrmNV.Show();
            }
        }
        //Load form Dịch vụ
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(FrmDichVu)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmDichVu frmDV = new FrmDichVu();
                frmDV.MdiParent = this;
                frmDV.Show();
            }

        }
        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(FrmPhong)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmPhong frmPhong = new FrmPhong();
                frmPhong.MdiParent = this;
                frmPhong.Show();
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(FrmKhachHang)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmKhachHang frmKH = new FrmKhachHang();
                frmKH.MdiParent = this;
                frmKH.Show();
            }
            
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(FrmTinhTrangPhong)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmTinhTrangPhong frmTrangThai = new FrmTinhTrangPhong();
                frmTrangThai.MdiParent = this;
                frmTrangThai.Show();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = Checkform((typeof(FrmHoaDon)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmHoaDon frmHD = new FrmHoaDon();
                frmHD.MdiParent = this;
                frmHD.Show();

            }

        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(FrmDanhSachHoaDon)));
            if (frm != null)
                frm.Activate();
            else
            {
                FrmDanhSachHoaDon frmDSHD = new FrmDanhSachHoaDon();
                frmDSHD.MdiParent = this;
                frmDSHD.Show();
            }

        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {

            FrmLienHe frm = new FrmLienHe();
            frm.Show();
        }

        #region Mở đóng khóa button
        public void KhoaButton()
        {
            btnNhanVien.Enabled = false;
            btnDoiMatKhau.Enabled = false;
            btnDangXuat.Enabled = false;
            btnDangNhap.Enabled = true;
        }

        public void MoKhoaButton()
        {
            btnNhanVien.Enabled = true;
            btnDoiMatKhau.Enabled = true;
            btnDangXuat.Enabled = true;
        }

        #endregion
        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsFormAlreadyOpen(typeof(FrmDangNhap));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                foreach (Form mdiForm in this.MdiChildren)
                {
                    mdiForm.Close();
                }
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Show();
                this.Hide();
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmDangNhap.IsLogin = false;
                this.Close();
                FrmMain main = new FrmMain();
                main.Show();
            }
        }

        private void btnBaoCaoTuan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = Checkform((typeof(frmDoanhThuDichVu)));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDoanhThuDichVu frmDSHD = new frmDoanhThuDichVu();
                frmDSHD.MdiParent = this;
                frmDSHD.Show();
            }
        }

        private void btnHuongDan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "help.chm"));
        }
    }
}