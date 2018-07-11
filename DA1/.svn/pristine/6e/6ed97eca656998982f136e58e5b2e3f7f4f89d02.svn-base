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
    public partial class FrmDichVu : DevExpress.XtraEditors.XtraForm
    {
        public FrmDichVu()
        {
            InitializeComponent();
        }
        BUSDichVu bus = new BUSDichVu();
        ObjDichVu obj = new ObjDichVu();

        private bool IsInsert = true;
     

        
        //Hiển thị dịch vụ
        private void HienThi()
        {
            dgvDichVu.DataSource = bus.GetData();
        }

        //Khóa textbox
        private void KhoaText()
        {
            txtTenDichVu.Enabled = false;
            txtGiaDichVu.Enabled = false;
            txtMoTa.Enabled = false;
            txtTrangThai.Enabled = false;
        }

        //Mở khóa textbox
        private void MoKhoaText()
        {
            txtTenDichVu.Enabled = true;
            txtGiaDichVu.Enabled = true;
            txtMoTa.Enabled = true;
            txtTrangThai.Enabled = true;
        }

        //Xóa giá trị textbox
        void XoaText()
        {
            //txtMaDichVu.Text = String.Empty;
            txtTenDichVu.Text = String.Empty;
            txtMoTa.Text = String.Empty;
            txtGiaDichVu.Text = String.Empty;
        }

        //Mã tự tăng
        string MaTuTang()
        {
            string ma = "";
            if (gridView1.RowCount <= 0)
            {
                ma = "DV00001";
            }
            else
            {
                int k;
                ma = "DV";
                k = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.RowCount - 1, gridColumn1).ToString().Substring(2,5));
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

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            HienThi();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            KhoaText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaText();
            txtMaDichVu.Text = MaTuTang();
            MoKhoaText();
            IsInsert = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoKhoaText();
            IsInsert = false;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            obj.DV_MaDichVu = txtMaDichVu.Text;
            obj.DV_TenDichVu = function.upperfirst(txtTenDichVu.Text);
            obj.DV_GiaDichVu = txtGiaDichVu.Text;
            obj.DV_MoTa = function.upperfirst(txtMoTa.Text);
            obj.DV_TrangThai = "Đang cung cấp";
            try
            {
                if (IsInsert == true)
                {
                    if (txtMaDichVu.Text == "")
                    {
                        XtraMessageBox.Show("Mã dịch vụ không được để trống. Vui lòng điền thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bus.Insert(obj);
                       
                        XtraMessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThi();
                        XoaText();
                        KhoaText();
                    }
                }
                else
                {
                    bus.Update(obj);
                     bus.UpdateTrangThai(obj);
                    XtraMessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    XoaText();
                    KhoaText();
                }
            }
            catch
            {
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn ngừng cung cấp dịch vụ này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMaDichVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                obj.DV_MaDichVu = txtMaDichVu.Text;
                obj.DV_TrangThai = "Ngừng cung cấp";
                try
                {
                    bus.UpdateTrangThai(obj);
                    XtraMessageBox.Show("Đã hủy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoaText();
                    HienThi();
                    XoaText();
                }
                catch
                {
                    XtraMessageBox.Show("Thông tin nhập vào không hợp lệ!, Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void dgvDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                KhoaText();
            }
            catch
            {
            }
            btnSua.Enabled = true;
            btnLuuLai.Enabled = true;
            btnThem.Enabled = true;
        }

        void LoadGrid()
        {
            txtMaDichVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            txtTenDichVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            txtGiaDichVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            txtMoTa.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (IsInsert == true)
            {
                txtTenDichVu.Text = String.Empty;
                txtMoTa.Text = String.Empty;
                txtGiaDichVu.Text = String.Empty;
            }
            else
            {
                HienThi();
                KhoaText();
                LoadGrid();
                btnLuuLai.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dgvDichVu.ShowRibbonPrintPreview();
        }
    }
}