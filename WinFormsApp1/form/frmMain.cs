using ChamSocKhachHang.Data;
using ChamSocKhachHang.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocKhachHang.form
{
    public partial class frmMain : Form
    {
        CSKHContext context = new CSKHContext(); // Khởi tạo biến ngữ cảnh CSDL

        frmKhachHang khachHang = null;
        frmNhanVien nhanVien = null;
        frmLichHen lichHen = null;
        frmDichVu dichVu = null;
        frmLichSuChamSoc lichSuChamSoc = null;
        frmDangNhap dangNhap = null;

        string hoVaTenNhanVien = ""; // Hiển thị trên StatusStrip
        string quyenNhanVien = "";
        NhanVien nhanVienDangNhap = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void DangNhap()
        {
        LamLai:
            // Tạo form đăng nhập nếu chưa có hoặc đã dispose
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();

            // ✅ Xóa nội dung cũ trước khi hiển thị
            dangNhap.txtTenDangNhap.Clear();
            dangNhap.txtMatKhau.Clear();
            dangNhap.txtTenDangNhap.Focus();

            // Hiển thị form đăng nhập
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text.Trim();
                string matKhau = dangNhap.txtMatKhau.Text.Trim();

                if (tenDangNhap == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                if (matKhau == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }

                var nv = context.NhanViens
                    .Where(r => r.TenDangNhap == tenDangNhap && r.MatKhau == matKhau)
                    .SingleOrDefault();

                if (nv == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }

                hoVaTenNhanVien = nv.HoTen;
                quyenNhanVien = nv.Quyen;
                nhanVienDangNhap = nv;
                QuyenNhanVien(); // bật quyền cho nhân viên
            }
        }

        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuLichHen.Enabled = false;
            mnuDichVu.Enabled = false;
            mnuLichSuChamSoc.Enabled = false;

            lblTrangThai.Text = "Chưa đăng nhập.";
        }

        public void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;

            // Mọi nhân viên đều được quyền mở các form
            mnuKhachHang.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuLichHen.Enabled = true;
            mnuDichVu.Enabled = true;
            mnuLichSuChamSoc.Enabled = true;

            if (quyenNhanVien == "QuanLy")
                mnuNhanVien.Enabled = true;
            else
                mnuNhanVien.Enabled = false;

            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new frmKhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
                khachHang.Activate();
        }


        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (quyenNhanVien != "QuanLy")
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }

            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.Show();
            }
            else
            {
                nhanVien.Activate();
            }
        }

        private void mnuLichHen_Click(object sender, EventArgs e)
        {
            if (lichHen == null || lichHen.IsDisposed)
            {
                lichHen = new frmLichHen();
                lichHen.MdiParent = this;
                lichHen.Show();
            }
            else
            {
                lichHen.Activate();
            }
        }

        private void mnuDichVu_Click(object sender, EventArgs e)
        {
            if (dichVu == null || dichVu.IsDisposed)
            {
                dichVu = new frmDichVu();
                dichVu.MdiParent = this;
                dichVu.Show();
            }
            else
            {
                dichVu.Activate();
            }
        }

        private void mnuLichSuChamSoc_Click(object sender, EventArgs e)
        {
            if (lichSuChamSoc == null || lichSuChamSoc.IsDisposed)
            {
                lichSuChamSoc = new frmLichSuChamSoc();
                lichSuChamSoc.MdiParent = this;
                lichSuChamSoc.Show();
            }
            else
            {
                lichSuChamSoc.Activate();
            }
        }

        private void lblLienKet_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer.exe";
                info.Arguments = "https://fit.agu.edu.vn";
                Process.Start(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được trang web: " + ex.Message);
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
                child.Close();

            ChuaDangNhap();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (nhanVienDangNhap == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
                return;
            }

            frmDoiMatKhau f = new frmDoiMatKhau();

            if (f.ShowDialog() == DialogResult.OK)
            {
                // kiểm tra mật khẩu cũ
                if (nhanVienDangNhap.MatKhau != f.matKhauCu)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                    return;
                }

                // cập nhật mật khẩu mới
                nhanVienDangNhap.MatKhau = f.matKhauMoi;
                context.SaveChanges();

                MessageBox.Show("Đổi mật khẩu thành công!");
            }
        }

        private void mnuThongKeKhachHang_Click(object sender, EventArgs e)
        {
            frmReportKhachHang frm = new frmReportKhachHang();
            frm.ShowDialog();
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            string aboutText = "✨ HỆ THỐNG QUẢN LÝ SPA & CHĂM SÓC KHÁCH HÀNG ✨\n" +
                               "──────────────────────────────\n\n" +
                               "👤 Sinh viên thực hiện: Lê Thị Huỳnh Như\n" +
                               "🆔 Mã số sinh viên: DTH235719\n" +
                               "📚 Môn học: Lập trình Quản lý\n" +
                               "📅 Năm hoàn thành: 2026\n\n" +
                               "──────────────────────────────\n" +
                               "© 2026 Huỳnh Như ";

            MessageBox.Show(
                aboutText,
                "Thông tin phần mềm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            string helpText = "╔════════════════════════════════╗\n" +
                              "     HƯỚNG DẪN SỬ DỤNG HỆ THỐNG\n" +
                              "╚════════════════════════════════╝\n\n" +
                              "👤 1. QUẢN LÝ TÀI KHOẢN\n" +
                              "   - Đăng nhập hệ thống để bắt đầu làm việc.\n" +
                              "   - Đổi mật khẩu định kỳ để bảo mật thông tin.\n\n" +
                              "👥 2. QUẢN LÝ KHÁCH HÀNG\n" +
                              "   - Thêm mới, chỉnh sửa thông tin hoặc xóa khách hàng.\n" +
                              "   - Tra cứu danh sách khách hàng thân thiết.\n\n" +
                              "📅 3. QUẢN LÝ LỊCH HẸN\n" +
                              "   - Đặt lịch hẹn mới, thay đổi hoặc hủy lịch hẹn.\n\n" +
                              "🛠️ 4. QUẢN LÝ DỊCH VỤ & NHÂN VIÊN (Admin)\n" +
                              "   - Thiết lập danh mục dịch vụ và giá cả.\n" +
                              "   - Quản lý thông tin và phân quyền cho nhân viên.\n\n" +
                              "📜 5. LỊCH SỬ & BÁO CÁO\n" +
                              "   - Theo dõi chi tiết lịch sử chăm sóc khách hàng.\n" +
                              "   - Tổng hợp báo cáo thống kê doanh thu và hoạt động.\n\n" +
                              "--------------------------------------------------------------------\n" +
                              "✉️ Mọi thắc mắc vui lòng liên hệ Bộ phận Kỹ thuật.";

            MessageBox.Show(helpText, "Trung tâm Hỗ trợ Người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
