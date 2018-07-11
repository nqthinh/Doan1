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
using DataAccessLayer;

namespace QuanLyKhachSan
{
    public partial class FrmHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }
        //private bool IsInsertKH = true;
        BUSPhong busPhong = new BUSPhong();
        BUSKhachHang busKhachHang = new BUSKhachHang();
        BUSDichVu busDichVu = new BUSDichVu();
        BUSHoaDon busHoaDon = new BUSHoaDon();
        dbConnect db = new dbConnect();
        BUSNhanVien busNhanVien = new BUSNhanVien();
        ObjKhachHang objKhachHang = new ObjKhachHang();
        ObjHoaDon objHoaDon = new ObjHoaDon();
        private bool IsInsert = true;
        ObjPhong objPhong = new ObjPhong();

       
        public string MaTuTangHD()
        {
            string s, snew;
            int i = 0;
            try
            {
                string str = "select top 1 HD_MAHD from HOADON ORDER BY HD_MAHD DESC";
                s = db.getData(str).Rows[0][0].ToString();
                snew = s.Substring(3).ToString();
                i = int.Parse(snew);
                i++;
                if (i < 10)
                    return "HD0000" + i.ToString();
                else if (i >= 10 && i < 100)
                    return "HD000" + i.ToString();
                else if (i > 100 && i < 1000)
                    return "HD00" + i.ToString();
                else if (i > 1000 && i < 10000)
                    return "HD0" + i.ToString();
                else
                    return "HD" + i.ToString();
            }
            catch
            {
                return "HD00001";
            }
        }
        public string MaTuTangKH()
        {
            string s, snew;
            int i = 0;
            try
            {
                string str = "select top 1 KH_MAKH from KHACHHANG ORDER BY KH_MAKH DESC";
                s = db.getData(str).Rows[0][0].ToString();
                snew = s.Substring(3).ToString();
                i = int.Parse(snew);
                i++;
                if (i < 10)
                    return "KH0000" + i.ToString();
                else if (i >= 10 && i < 100)
                    return "KH000" + i.ToString();
                else if (i > 100 && i < 1000)
                    return "KH00" + i.ToString();
                else if (i > 1000 && i < 10000)
                    return "KH0" + i.ToString();
                else
                    return "KH" + i.ToString();
            }
            catch
            {
                return "KH00001";
            }
        }

        //Load form
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            cbbMaPhong.Properties.DataSource = busPhong.GetData();
            cbbMaPhong.Properties.DisplayMember = "PHG_MAPHONG";
            cbbMaPhong.Properties.ValueMember = "PHG_MAPHONG";

            cbbNhanVien.Properties.DataSource = busNhanVien.getData();
            cbbNhanVien.Properties.DisplayMember = "NV_HOTEN";
            cbbNhanVien.Properties.ValueMember = "NV_MANV";

            
            KhoaDieuKhien();
            HienThiKhachHang();
            btnThemSuaDichVu.Enabled = false;
            btnLamMoiDichVu.Enabled = false;
            btnThanhToan.Enabled = false;

        }
        public void funData(TextBox txtMaKH)
        {
            txtMaKhachHang.Text = txtMaKH.Text;
        }
        //Chọn phòng thì các thuộc tính của phòng sẽ đi theo
        private void cbbMaPhong_EditValueChanged(object sender, EventArgs e)
        {
            txtLoaiPhong.EditValue = cbbMaPhong.GetColumnValue("LPHG_TENLOAI").ToString();
            txtGiaPhong.EditValue = cbbMaPhong.GetColumnValue("PHG_GIA").ToString();
            txtSoDienThoaiPhong.EditValue = cbbMaPhong.GetColumnValue("PHG_SDTPHONG").ToString();
            txtSoLuongToiDa.EditValue = cbbMaPhong.GetColumnValue("PHG_SLMAX").ToString();
            txtHienTrang.EditValue = cbbMaPhong.GetColumnValue("PHG_HIENTRANG").ToString();
        }

        //Khóa các điều khiển phần thông tin khách hàng
        void KhoaDieuKhien()
        {
            txtTenKhachHang.Enabled = false;
            txtSoCMND.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtQuocTich.Enabled = false;
            txtDiaChi.Enabled = false;
            dateNgaySinh.Enabled = false;
        }
        //Mở Khóa các điều khiển phần thông tin khách hàng
        void MoKhoaDieuKhien()
        {
            txtTenKhachHang.Enabled = true;
            txtSoCMND.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtQuocTich.Enabled = true;
            txtDiaChi.Enabled = true;
            dateNgaySinh.Enabled = true;
            txtMaKhachHang.Enabled = false;
        }
        //Xóa các textbox của khách hàng
        void XoaText()
        {
            txtMaKhachHang.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtSoCMND.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
        }
        void HienThiKhachHang()
        {
            dgvDanhSachKhachHangHoaDon.DataSource = busHoaDon.getDataDANGKY();
        }
        void HienThiDichVu()
        {
            dgvDanhSachSuDungDichVu.DataSource = busHoaDon.GetDataSuDungDichVu(txtMaHoaDon.Text);
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
             if (txtHienTrang.Text == "Đang thuê")
                        {
                            XtraMessageBox.Show("Phòng này đã được thuê. Vui lòng chọn phòng khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
             else if (txtHienTrang.Text == "Không sử dụng")
             {
                            XtraMessageBox.Show("Phòng này hiện không được sử dụng. Vui lòng chọn phòng khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
             }
             else if ((txtHienTrang.Text == "Đang sữa chữa"))
             {
                 if (XtraMessageBox.Show("Phòng này đang được sửa chữa bạn có chắc chắn muốn thuê", "Đang chờ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                 {
                     txtHienTrang.Text = "Đang thuê";
                     objPhong.PHG_HienTrang = txtHienTrang.Text;
                     objPhong.PHG_MaPhong = cbbMaPhong.EditValue.ToString();
                     txtMaHoaDon.Text = MaTuTangHD();
                     busPhong.UpdateTrangThai(objPhong); //Cập nhật trạng thái phòng
                     txtMaKhachHang.Text = MaTuTangKH();
                     HienThiKhachHang();
                     MoKhoaDieuKhien();
                     IsInsert = true;
                     btnBatDau.Enabled = false;
                 }
             }
             else
             {
                 txtHienTrang.Text = "Đang thuê";
                 objPhong.PHG_HienTrang = txtHienTrang.Text;
                 objPhong.PHG_MaPhong = cbbMaPhong.EditValue.ToString();
                 txtMaHoaDon.Text = MaTuTangHD();
                 busPhong.UpdateTrangThai(objPhong); //Cập nhật trạng thái phòng
                 txtMaKhachHang.Text = MaTuTangKH();
                 HienThiKhachHang();
                 MoKhoaDieuKhien();
                 IsInsert = true;
                 btnBatDau.Enabled = false;
             }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaText();
            txtMaHoaDon.Text = string.Empty;
            txtMaHoaDon.Text = MaTuTangHD();
            txtMaKhachHang.Text = MaTuTangKH();
            HienThiKhachHang();
            HienThiDichVu();
            btnBatDau.Enabled = true;
            try
            {
                txtHienTrang.Text = "Chưa thuê";
                objPhong.PHG_HienTrang = txtHienTrang.Text;
                busPhong.UpdateTrangThai(objPhong); //Cập nhật trạng thái phòng
            }
            catch { }
        }
        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            MoKhoaDieuKhien();
        }
        private void btnLuuLaiKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
            //Update / Insert khách hàng mới
            objKhachHang.KH_CMND = txtSoCMND.Text;
            objKhachHang.KH_DiaChi = txtDiaChi.Text;
            objKhachHang.KH_MaKH = txtMaKhachHang.Text;
            objKhachHang.KH_TenKH = txtTenKhachHang.Text;
            objKhachHang.KH_NgaySinh = DateTime.ParseExact(dateNgaySinh.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objKhachHang.KH_QuocTich = txtQuocTich.Text;
            objKhachHang.KH_SDT = txtSoDienThoai.Text;

            //Insert / Update hóa đơn

            objHoaDon.HD_MaHoaDon = txtMaHoaDon.Text;
            objHoaDon.HD_NgayThue = DateTime.ParseExact(txtNgayThue.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objHoaDon.HD_NgayHoaDon = DateTime.ParseExact(txtNgayThue.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            objHoaDon.HD_SoLuongKhach = txtSoLuongKhach.Text;
            objHoaDon.PHG_MaPhong = cbbMaPhong.EditValue.ToString();
            objHoaDon.NV_MANV = cbbNhanVien.EditValue.ToString();
            objHoaDon.KH_MaKH = txtMaKhachHang.Text;
            objHoaDon.HD_TrangThaiHoaDon = "Chưa thanh toán";
            
                if(IsInsert == true)
                {
                    busKhachHang.Insert(objKhachHang);
                    busHoaDon.InsertDK(objHoaDon);
                    XtraMessageBox.Show("Đã thêm thông tin đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiKhachHang();
                }
                else
                {
                    busHoaDon.Update(objHoaDon);
                    busKhachHang.Update(objKhachHang);
                    XtraMessageBox.Show("Đã sửa thông tin đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiKhachHang();
                }
            }
            catch
            {
                XtraMessageBox.Show("Thông tin không hợp lệ vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dgvDanhSachKhachHangHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                HienThiDichVu();
            }
            catch{}
        }

        //Load dữ liệu từ grid lên textbox
        void LoadGridHD()
        {
            txtMaHoaDon.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "HD_MAHD").ToString();
            txtNgayThue.Text = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "HD_NGAYTHUE").ToString()).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtSoLuongKhach.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "HD_SOLUONGKHACH").ToString();
            txtMaKhachHang.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_MAKH").ToString();
            txtTenKhachHang.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_TENKH").ToString();
            dateNgaySinh.Text = Convert.ToDateTime(gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_NGAYSINH").ToString()).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtQuocTich.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_QUOCTICH").ToString();
            txtSoDienThoai.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_SDT").ToString();
            txtSoCMND.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_CMND").ToString();
            txtDiaChi.Text = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "KH_DIACHI").ToString();
            cbbMaPhong.EditValue = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "PHG_MAPHONG").ToString();
            cbbNhanVien.EditValue = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "NV_MANV").ToString();
            string trangthai = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "HD_TRANGTHAI").ToString();
            if(trangthai =="Đã thanh toán")
            { 
                btnLamMoiDichVu.Enabled = false;
                btnThemSuaDichVu.Enabled = false;
            }
        }

        //Click vào dòng trên grid
        private void gridView4_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            try
            {
                btnThemSuaDichVu.Enabled = true;
                btnLamMoiDichVu.Enabled = true;
                btnThanhToan.Enabled = true;
                XoaText();
                LoadGridHD();
            }
            catch
            { }
        }
        //Click Thêm cthd
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            FrmSuDungDichVu frm = new FrmSuDungDichVu();
            frm.isinsert = true;
            frm.ID = txtMaHoaDon.Text;
            frm.LamMoi += new EventHandler(btnLamMoiDichVu_Click);
            frm.ShowDialog();
           
        }
        //click Sửa chi tiết hóa đơn
        private void dgvDanhSachSuDungDichVu_DoubleClick(object sender, EventArgs e)
        {
            FrmSuDungDichVu frm = new FrmSuDungDichVu();
            frm.isinsert = false;
            frm.LamMoi += new EventHandler(btnLamMoiDichVu_Click);
            frm.ID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
            frm.ShowDialog();
        }
        //Làm mới dịch vụ sử dụng
        private void btnLamMoiDichVu_Click(object sender, EventArgs e)
        {
            HienThiDichVu();
            HienThiKhachHang();
        }

        //Thanh toán
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(txtMaHoaDon.Text == "")
            {
                XtraMessageBox.Show("Vui lòng chọn hóa đơn thanh toán", "Đang chờ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FrmThanhToan frm = new FrmThanhToan();
                frm.ID = txtMaHoaDon.Text;
                frm.ShowDialog();
            }


        }

        //Hủy hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            objHoaDon.HD_TrangThaiHoaDon = "Đã hủy";
            objHoaDon.HD_NgayTra = DateTime.Now.ToString();
            objHoaDon.HD_MaHoaDon = txtMaHoaDon.Text;
            try
            {
                
                if (XtraMessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn?", "Đang chờ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    busHoaDon.UpdateTrangThai(objHoaDon);
                    HienThiKhachHang();
                    XtraMessageBox.Show("Đã hủy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
            
        }

    }
}