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
using DataAccessLayer;
using ValueObject;
using BusinessLogicLayer;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class FrmPhong : DevExpress.XtraEditors.XtraForm
    {
        public FrmPhong()
        {
            InitializeComponent();
        }

        BUSPhong bus = new BUSPhong();
        ObjPhong obj = new ObjPhong();
        private bool IsInsert = true;
        dbConnect db = new dbConnect();
        //Hiển thị phòng
        private void HienThi()
        {
            dgvPhong.DataSource = bus.GetData();
        }

        //Khoá textbox
        private void KhoaText()
        {
            txtMaPhong.Enabled = false;
            txtLoaiPhong.Enabled = false;
            txtHienTrang.Enabled = false;
            txtSDTPhong.Enabled = false;
            txtSLMax.Enabled = false;
            txtGia.Enabled = false;
        }

        //Mở khóa textbox
        private void MoKhoaText()
        {
            txtMaPhong.Enabled = true;
            txtLoaiPhong.Enabled = true;
            txtHienTrang.Enabled = true;
            txtSDTPhong.Enabled = true;
            txtSLMax.Enabled = true;
            txtGia.Enabled = true;
        }

        //Xoá giá trị textbox
        void XoaText()
        {
            txtMaPhong.Text = String.Empty;
            txtLoaiPhong.Text = String.Empty;
            txtHienTrang.Text = String.Empty;
            txtSLMax.Text = String.Empty;
            txtSDTPhong.Text = String.Empty;
            txtGia.Text = String.Empty;
        }

        //Mã tự tăng
        private void dgvPhong_Click(object sender, EventArgs e)
        {
            try
            {
                KhoaText();
                txtMaPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtLoaiPhong.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtSLMax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txtSDTPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtHienTrang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
            }
            catch
            {
            }
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
        }
        BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
        private void FrmPhongExc_Load(object sender, EventArgs e)
        {
            txtLoaiPhong.Properties.DataSource = busLoaiPhong.getData();
            txtLoaiPhong.Properties.DisplayMember = "LPHG_TENLOAI";
            txtLoaiPhong.Properties.ValueMember = "LPHG_MALOAI";

            HienThi();
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            KhoaText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaText();
            MoKhoaText();
            IsInsert = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoKhoaText();
            IsInsert = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            obj.PHG_MaPhong = txtMaPhong.Text;
            obj.LPHG_MaLoai = txtLoaiPhong.EditValue.ToString();
            obj.PHG_SLMax = txtSLMax.Text;
            obj.PHG_HienTrang = txtHienTrang.Text;
            obj.PHG_SDTPhong = txtSDTPhong.Text;
            obj.PHG_Gia = txtGia.Text;
            try
            {
                if (IsInsert == true)
                {
                    if (txtMaPhong.Text == "")
                    {
                        XtraMessageBox.Show("Mã phòng không được để trống. Vui lòng điền thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (XtraMessageBox.Show("Bạn có muốn hủy thông tin phòng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtMaPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtHienTrang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                obj.PHG_MaPhong = txtMaPhong.Text;
                obj.PHG_HienTrang = "Không sử dụng";

                try
                {

                    bus.UpdateTrangThai(obj);
                    HienThi();
                }
                catch
                {
                    XtraMessageBox.Show("Khách hàng này đang trong thời hạn hợp đồng, Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //Code xóa phòng

            //if (XtraMessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    txtMaPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            //    try
            //    {
            //        bus.Delete(txtMaPhong.Text);
            //        XtraMessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        KhoaText();
            //        HienThi();
            //        XoaText();
            //    }
            //    catch
            //    {
            //        XtraMessageBox.Show("Lỗi dữ liệu, Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void dgvPhong_Click_1(object sender, EventArgs e)
        {
            //try
            //{
            //    txtMaPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            //    txtLoaiPhong.EditValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            //    txtSLMax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
            //    txtGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
            //    txtSDTPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
            //    txtHienTrang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            //}
            //catch
            //{
            //}
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            LoadGrid();
        }


        void LoadGrid()
        {
            txtMaPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PHG_MAPHONG").ToString();
            txtLoaiPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LPHG_TENLOAI").ToString();
            txtSLMax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PHG_SLMAX").ToString();
            txtGia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PHG_GIA").ToString();
            txtSDTPhong.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PHG_SDTPHONG").ToString();
            txtHienTrang.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PHG_HIENTRANG").ToString();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (IsInsert == true)
            {
                txtLoaiPhong.Text = String.Empty;
                txtHienTrang.Text = String.Empty;
                txtSLMax.Text = String.Empty;
                txtSDTPhong.Text = String.Empty;
                txtGia.Text = String.Empty;
            }
            else
            {
                HienThi();
                KhoaText();
                LoadGrid();
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dgvPhong.ShowRibbonPrintPreview();
        }
    }
}