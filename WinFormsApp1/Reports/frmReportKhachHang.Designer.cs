namespace ChamSocKhachHang.Reports
{
    partial class frmReportKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            cbNhanVien = new ComboBox();
            btnLoc = new Button();
            cbSapXep = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Bottom;
            reportViewer1.LocalReport.ReportEmbeddedResource = "rptKhachHang.rdlc";
            reportViewer1.Location = new Point(0, 113);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1016, 407);
            reportViewer1.TabIndex = 0;
            // 
            // cbNhanVien
            // 
            cbNhanVien.FormattingEnabled = true;
            cbNhanVien.Location = new Point(132, 20);
            cbNhanVien.Name = "cbNhanVien";
            cbNhanVien.Size = new Size(202, 28);
            cbNhanVien.TabIndex = 1;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = Color.Transparent;
            btnLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoc.ForeColor = SystemColors.MenuHighlight;
            btnLoc.Location = new Point(607, 21);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(70, 29);
            btnLoc.TabIndex = 2;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            btnLoc.Click += btnLoc_Click_1;
            // 
            // cbSapXep
            // 
            cbSapXep.FormattingEnabled = true;
            cbSapXep.Location = new Point(447, 21);
            cbSapXep.Name = "cbSapXep";
            cbSapXep.Size = new Size(121, 28);
            cbSapXep.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 4;
            label1.Text = "Tìm nhân viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(356, 24);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 5;
            label2.Text = "Sắp xếp";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(132, 70);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên khách hàng";
            txtSearch.Size = new Size(202, 27);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 7;
            label3.Text = "Tìm khách hàng";
            // 
            // frmReportKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1016, 520);
            Controls.Add(label3);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbSapXep);
            Controls.Add(btnLoc);
            Controls.Add(cbNhanVien);
            Controls.Add(reportViewer1);
            Name = "frmReportKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê tình trạng khách hàng";
            Load += frmReportKhachHang_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ComboBox cbNhanVien;
        private Button btnLoc;
        private ComboBox cbSapXep;
        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Label label3;
    }
}