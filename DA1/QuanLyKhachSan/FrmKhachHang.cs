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
using ValueObject;
using BusinessLogicLayer;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class FrmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        BUSKhachHang bus = new BUSKhachHang();
        ObjKhachHang obj = new ObjKhachHang();

        private bool IsInsert = true;

        //Load dữ liệu
        void HienThi()
        {
            msds.DataSource = bus.getData();
        }
        void Khoa()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            dateNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtCMND.Enabled = false;
            txtQuocTich.Enabled = false;

        }
        void MoKhoa()
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            dateNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtCMND.Enabled = true;
            txtQuocTich.Enabled = true;
        }
        void XoaText()
        {
            txtMaKH.Text = String.Empty;
            txtTenKH.Text = String.Empty;
            dateNgaySinh.Text = String.Empty;
            txtSDT.Text = String.Empty;
            txtCMND.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
            txtQuocTich.Text = String.Empty;
        }

        //Mã tự tăng
        string MaTuTang()
        {
            string ma = "";
            if (gridView1.RowCount <= 0)
            {
                ma = "KH00001";
            }
            else
            {
                int k;
                ma = "KH";
                k = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.RowCount - 1, gridColumn1).ToString().Substring(2, 5));
                k = k + 1;
                if (k < 10)
                {
                    ma = ma + "0000";
                }
                else if (k < 100)
                {
                    ma = ma + "000";
                }
                else if (k < 1000)
                {
                    ma = ma + "00";
                }
                else if (k < 10000)
                {
                    ma = ma + "0";
                }
                ma = ma + k.ToString();
            }
            return ma;

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            Khoa();
            btnDangKy.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            HienThi();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                XoaText();
                txtMaKH.Text = MaTuTang();
                MoKhoa();
                IsInsert = true;
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnDangKy.Enabled = false;
            }
            catch
            { }
            
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                LoadGrid();
                Khoa();
            }
            catch
            { }
            
        }

        private void msds_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnDangKy.Enabled = true;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
            obj.KH_MaKH = txtMaKH.Text;
            obj.KH_TenKH = function.upperfirstword(txtTenKH.Text);
            obj.KH_NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            obj.KH_QuocTich = function.upperfirstword(txtQuocTich.Text);
            obj.KH_SDT = txtSDT.Text;
            obj.KH_CMND = txtCMND.Text;
            obj.KH_DiaChi = function.upperfirst(txtDiaChi.Text);

            
                if (IsInsert == true)
                {
                    if (txtMaKH.Text == "")
                    {
                        XtraMessageBox.Show("Mã khách hàng không được để trống. Vui lòng điền thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bus.Insert(obj);
                        XtraMessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThi();
                        XoaText();
                        Khoa();
                    }
                }
                else
                {
                    bus.Update(obj);
                    XtraMessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    XoaText();
                    Khoa();
                }
            }
            catch
            {
                XtraMessageBox.Show("Thông tin khách hàng không được để trống, vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            MoKhoa();
            IsInsert = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    bus.Delete(txtMaKH.Text);
                    XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XoaText();
                    Khoa();
                    HienThi();
                }
                catch
                {

                }
            }
        }

        void LoadGrid()
        {
            txtMaKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_MAKH").ToString();
            txtTenKH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_TENKH").ToString();
            dateNgaySinh.Text = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_NGAYSINH").ToString()).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtQuocTich.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_QUOCTICH").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_SDT").ToString();
            txtCMND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_CMND").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "KH_DIACHI").ToString();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (IsInsert == true)
            {
                txtTenKH.Text = String.Empty;
                dateNgaySinh.Text = String.Empty;
                txtSDT.Text = String.Empty;
                txtCMND.Text = String.Empty;
                txtDiaChi.Text = String.Empty;
                txtQuocTich.Text = String.Empty;
            }
            else
            {
                HienThi();
                Khoa();
                LoadGrid();
                btnLuu.Enabled = false;
                btnDangKy.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            msds.ShowRibbonPrintPreview();
        }
    }
}