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
using System.Text.RegularExpressions;

namespace QuanLyKhachSan
{
    public partial class FrmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        BUSNhanVien bus = new BUSNhanVien();
        ObjNhanVien obj = new ObjNhanVien();
        BUSCa busca = new BUSCa();
        BUSChucVu buscv = new BUSChucVu();
 
        private bool IsInsert = true;

        //Load dữ liệu nhân viên
        void HienThi()
        {
            dgvNhanVien.DataSource = bus.getData();
            //gridView1.ExpandAllGroups(); 
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            cbbChucVu.Properties.DataSource = buscv.GetData();
            cbbChucVu.Properties.ValueMember = "CV_MACV";
            cbbChucVu.Properties.DisplayMember = "CV_TENCV";
            cbbChucVu.Properties.NullText = "Chọn chức vụ";

            cbbCaLam.Properties.DataSource = busca.GetData();
            cbbCaLam.Properties.ValueMember = "CA_MACA";
            cbbCaLam.Properties.DisplayMember = "CA_TENCA";
            cbbCaLam.Properties.NullText = "Chọn ca làm";

            HienThi();
            btnSuaNV.Enabled = false;
            btnLuuNV.Enabled = false;
            KhoaText();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            LoadGrid();
            KhoaText();
            btnSuaNV.Enabled = true;
            btnLuuNV.Enabled = false;
            btnThemMoi.Enabled = true;
        }

        #region Textbox method
        //Khóa textbox
        void KhoaText()
        {
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            dateNgaySinh.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtCMND.Enabled = false;
            cbbGioiTinh.Enabled = false;
            
            cbbChucVu.Enabled = false;
            cbbCaLam.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        //Mở khóa textbox
        void MoKhoaText()
        {
           
            txtTenNhanVien.Enabled = true;
            dateNgaySinh.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtCMND.Enabled = true;
            cbbGioiTinh.Enabled = true;
            cbbChucVu.Enabled = true;
            cbbCaLam.Enabled = true;
            txtDiaChi.Enabled = true;
            
        }

        //Xóa thông tin textbox
        void XoaText()
        {
 
            txtTenNhanVien.Text = String.Empty;
            dateNgaySinh.Text = String.Empty;
            
            txtSoDienThoai.Text = String.Empty;
            txtCMND.Text = String.Empty;
            cbbGioiTinh.Text = String.Empty;
            cbbChucVu.EditValue = String.Empty;
            cbbCaLam.EditValue = String.Empty;
            txtDiaChi.Text = String.Empty;
        }

        #endregion

        #region Chức năng button
        private void btnThemMoi_Click(object sender, EventArgs e) //THêm
        {
            XoaText();
            txtTenNhanVien.Select();
            txtTenNhanVien.Focus();
            txtMaNhanVien.Text = MaTuTang();
            MoKhoaText();
            IsInsert = true;
            btnLuuNV.Enabled = true;
            btnSuaNV.Enabled = false;
            btnThemMoi.Enabled = false;
        }

        private void btnSuaNV_Click(object sender, EventArgs e) //Sửa
        {
            MoKhoaText();
            IsInsert = false;
            btnLuuNV.Enabled = true;
            btnSuaNV.Enabled = false;
        }

        private void btnLuuNV_Click(object sender, EventArgs e) //Lưu
        {
            try
            {
            obj.NV_MaNV = txtMaNhanVien.Text;
            obj.NV_HoTen = function.upperfirstword(txtTenNhanVien.Text);
            obj.NV_NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            obj.NV_SDT = txtSoDienThoai.Text;
            obj.NV_CMND = txtCMND.Text;
            obj.NV_GioiTinh = cbbGioiTinh.Text; 
            obj.CV_MaCV = cbbChucVu.EditValue.ToString();
            obj.CA_MaCa = cbbCaLam.EditValue.ToString();
            obj.NV_DiaChi = function.upperfirst(txtDiaChi.Text);
                      
                if (IsInsert == true)
                {
                    if (txtMaNhanVien.Text == "")
                    {
                        XtraMessageBox.Show("Mã nhân viên không được để trống. Vui lòng điền thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bus.Insert(obj);
                        XtraMessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThi();
                        XoaText();
                        KhoaText();
                        btnThemMoi.Enabled = true;
                    }
                }
                else
                {
                    bus.Update(obj);
                    XtraMessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                    XoaText();
                    KhoaText();
                    btnThemMoi.Enabled = true;
                }
            }
            catch
            {
                XtraMessageBox.Show("Thông tin nhân viên không được để trống, vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)     //Xóa
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMaNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                try
                {
                    bus.Delete(txtMaNhanVien.Text);
                    XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KhoaText();
                    HienThi();
                    XoaText();
                } 
                catch
                {
                    XtraMessageBox.Show("Dữ liệu nhân viên đã tồn tại, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (IsInsert == true)
            {
                txtTenNhanVien.Text = String.Empty;
                dateNgaySinh.Text = String.Empty;
                
                txtSoDienThoai.Text = String.Empty;
                txtCMND.Text = String.Empty;
                cbbGioiTinh.Text = String.Empty;
                cbbChucVu.EditValue = String.Empty;
                cbbCaLam.EditValue = String.Empty;
                txtDiaChi.Text = String.Empty;
            }
            else
            {
                HienThi();
                KhoaText();
                LoadGrid();
                btnLuuNV.Enabled = false;
                btnThemMoi.Enabled = true;
                btnSuaNV.Enabled = true;
            }
        } //Làm mới
        private void btnIn_Click(object sender, EventArgs e) //In nhân viên
        {
            dgvNhanVien.ShowRibbonPrintPreview();
        }


        #endregion

        #region Các hàm
        void LoadGrid()
        {
            txtMaNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_MANV").ToString();
            txtTenNhanVien.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_HOTEN").ToString();
            cbbGioiTinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_GIOITINH").ToString();
            dateNgaySinh.Text = Convert.ToDateTime(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_NGAYSINH").ToString()).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtSoDienThoai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_SDT").ToString();
            txtCMND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_CMND").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NV_DIACHI").ToString();
            cbbChucVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CV_TENCV").ToString();
            cbbCaLam.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CA_TENCA").ToString();
        }

        //Mã tự tăng
        string MaTuTang()
        {
            string ma = "";
            if (gridView1.RowCount <= 0)
            {
                ma = "NV00001";
            }
            //else if (gridView1.RowCount == 1)
            //{
            //    ma = "NV00002";
            //}
            else
            {
                int k;
                ma = "NV";
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
        #endregion
    }
}