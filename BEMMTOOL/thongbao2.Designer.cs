using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{
    partial class thongbao2
    {

        private IContainer components;

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            Label2 = new System.Windows.Forms.Label();
            GroupBox7 = new System.Windows.Forms.GroupBox();
            Label8 = new System.Windows.Forms.Label();
            Label7 = new System.Windows.Forms.Label();
            GroupBox1 = new System.Windows.Forms.GroupBox();
            PictureBox1 = new System.Windows.Forms.PictureBox();
            Label3 = new System.Windows.Forms.Label();
            Label1 = new System.Windows.Forms.Label();
            Label6 = new System.Windows.Forms.Label();
            LinkLabel1 = new System.Windows.Forms.LinkLabel();
            GroupBox7.SuspendLayout();
            GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            Label2.AutoSize = true;
            Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label2.ForeColor = System.Drawing.Color.Red;
            Label2.Location = new System.Drawing.Point(12, 340);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(277, 48);
            Label2.TabIndex = 1;
            Label2.Text = "* Chỉ chấp nhận ảnh có file đuôi là .jpg\r\n* Phải đủ 50 ảnh vì random từ 1 đến 50 \r\n* Trong lúc thiết lập không nên bấm bàn phím \r\n";
            GroupBox7.Controls.Add(LinkLabel1);
            GroupBox7.Controls.Add(Label8);
            GroupBox7.Location = new System.Drawing.Point(4, 5);
            GroupBox7.Name = "GroupBox7";
            GroupBox7.Size = new System.Drawing.Size(789, 20);
            GroupBox7.TabIndex = 12;
            GroupBox7.TabStop = false;
            Label8.AutoSize = true;
            Label8.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label8.Location = new System.Drawing.Point(261, 0);
            Label8.Name = "Label8";
            Label8.Size = new System.Drawing.Size(260, 16);
            Label8.TabIndex = 12;
            Label8.Text = "CHUYỂN TẤT CẢ GỒM 50 ẢNH VÀO FOLDER ";
            Label7.AutoSize = true;
            Label7.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label7.Location = new System.Drawing.Point(176, 3);
            Label7.Name = "Label7";
            Label7.Size = new System.Drawing.Size(63, 16);
            Label7.TabIndex = 12;
            Label7.Text = "GIỚI TÍNH";
            GroupBox1.Controls.Add(PictureBox1);
            GroupBox1.Controls.Add(Label3);
            GroupBox1.Location = new System.Drawing.Point(4, 24);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new System.Drawing.Size(789, 313);
            GroupBox1.TabIndex = 13;
            GroupBox1.TabStop = false;
            PictureBox1.Image = BEEMTOOL.Properties.Resources.thongbao2_PictureBox1_Image;
            PictureBox1.Location = new System.Drawing.Point(3, 13);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(783, 294);
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox1.TabIndex = 13;
            PictureBox1.TabStop = false;
            Label3.AutoSize = true;
            Label3.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label3.Location = new System.Drawing.Point(276, 0);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(237, 16);
            Label3.TabIndex = 12;
            Label3.Text = "RENAME 50 ẢNH THEO THỨ TỰ 1 ĐẾN 50\r\n";
            Label1.AutoSize = true;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label1.ForeColor = System.Drawing.Color.Blue;
            Label1.Location = new System.Drawing.Point(437, 340);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(346, 48);
            Label1.TabIndex = 16;
            Label1.Text = "- Hệ thống sẽ tự động thiết lập cơ bản để tránh checkpoint\r\n+ Add 5 bạn bè , Thay avt , chỉnh năm sinh ngày sinh \r\n+ Điền thông tin , bật chế độ người theo dõi";
            Label6.AutoSize = true;
            Label6.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label6.Location = new System.Drawing.Point(640, 457);
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size(0, 16);
            Label6.TabIndex = 17;
            LinkLabel1.AutoSize = true;
            LinkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            LinkLabel1.Location = new System.Drawing.Point(516, -4);
            LinkLabel1.Name = "LinkLabel1";
            LinkLabel1.Size = new System.Drawing.Size(50, 20);
            LinkLabel1.TabIndex = 13;
            LinkLabel1.TabStop = true;
            LinkLabel1.Text = "Avata";
            LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(795, 395);
            Controls.Add(Label6);
            Controls.Add(Label1);
            Controls.Add(Label2);
            Controls.Add(GroupBox1);
            Controls.Add(GroupBox7);
            Controls.Add(Label7);
            Icon = BEEMTOOL.Properties.Resources.Icon;
            MaximizeBox = false;
            Name = "thongbao2";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CÁCH THIẾT LẬP FB";
            GroupBox7.ResumeLayout(false);
            GroupBox7.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label Label2;
        private GroupBox GroupBox7;
        private Label Label8;
        private Label Label7;
        private GroupBox GroupBox1;
        private PictureBox PictureBox1;
        private Label Label3;
        private Label Label1;
        private Label Label6;
        private LinkLabel LinkLabel1;
    }
}
