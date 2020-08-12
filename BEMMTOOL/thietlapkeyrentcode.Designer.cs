using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{

    partial class thietlapkeyrentcode
    {

        private IContainer components;

        private Label Label1;
        private GroupBox GroupBox1;
        private TextBox TextBox1;
        private Button btnbatdau;
        private Label Label2;
        private LinkLabel LinkLabel1;
        private Label Label3;
        private LinkLabel LinkLabel2;
        private Button Button1;

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
                Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            Label1 = new System.Windows.Forms.Label();
            GroupBox1 = new System.Windows.Forms.GroupBox();
            LinkLabel2 = new System.Windows.Forms.LinkLabel();
            Button1 = new System.Windows.Forms.Button();
            btnbatdau = new System.Windows.Forms.Button();
            TextBox1 = new System.Windows.Forms.TextBox();
            Label2 = new System.Windows.Forms.Label();
            LinkLabel1 = new System.Windows.Forms.LinkLabel();
            Label3 = new System.Windows.Forms.Label();
            GroupBox1.SuspendLayout();
            this.SuspendLayout();
            Label1.AutoSize = true;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(9, 0);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(292, 12);
            Label1.TabIndex = 0;
            Label1.Text = "ADD KEY RENTCODE ĐỂ SỬ DỤNG DỊCH VỤ CÓ XÁC MINH SMS ";
            GroupBox1.Controls.Add(LinkLabel2);
            GroupBox1.Controls.Add(Button1);
            GroupBox1.Controls.Add(btnbatdau);
            GroupBox1.Controls.Add(TextBox1);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new System.Drawing.Point(12, 12);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new System.Drawing.Size(311, 121);
            GroupBox1.TabIndex = 1;
            GroupBox1.TabStop = false;
            LinkLabel2.AutoSize = true;
            LinkLabel2.Location = new System.Drawing.Point(219, 67);
            LinkLabel2.Name = "LinkLabel2";
            LinkLabel2.Size = new System.Drawing.Size(73, 13);
            LinkLabel2.TabIndex = 17;
            LinkLabel2.TabStop = true;
            LinkLabel2.Text = "ĐỔI KEY MỚI";
            LinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel2_LinkClicked);
            Button1.BackColor = System.Drawing.Color.Black;
            Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button1.Font = new System.Drawing.Font("UVN Nguyen Du", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Button1.ForeColor = System.Drawing.Color.Lime;
            Button1.Location = new System.Drawing.Point(14, 83);
            Button1.Name = "Button1";
            Button1.Size = new System.Drawing.Size(282, 33);
            Button1.TabIndex = 16;
            Button1.Text = "BẠN ĐÃ ADD KEY THÀNH CÔNG";
            Button1.UseVisualStyleBackColor = false;
            Button1.Visible = false;
            Button1.Click += new System.EventHandler(Button1_Click);
            btnbatdau.BackColor = System.Drawing.Color.Black;
            btnbatdau.Cursor = System.Windows.Forms.Cursors.Hand;
            btnbatdau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnbatdau.Font = new System.Drawing.Font("UVN Nguyen Du", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnbatdau.ForeColor = System.Drawing.Color.Cyan;
            btnbatdau.Location = new System.Drawing.Point(52, 82);
            btnbatdau.Name = "btnbatdau";
            btnbatdau.Size = new System.Drawing.Size(207, 33);
            btnbatdau.TabIndex = 15;
            btnbatdau.Text = "THÊM KEY VÀO TOOL";
            btnbatdau.UseVisualStyleBackColor = false;
            btnbatdau.Click += new System.EventHandler(btnbatdau_Click);
            TextBox1.Location = new System.Drawing.Point(18, 19);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new System.Drawing.Size(274, 45);
            TextBox1.TabIndex = 1;
            TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            Label2.AutoSize = true;
            Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label2.Location = new System.Drawing.Point(5, 137);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(111, 12);
            Label2.TabIndex = 2;
            Label2.Text = "ĐĂNG KÝ RENTCODE Ở ";
            LinkLabel1.AutoSize = true;
            LinkLabel1.Location = new System.Drawing.Point(115, 136);
            LinkLabel1.Name = "LinkLabel1";
            LinkLabel1.Size = new System.Drawing.Size(29, 13);
            LinkLabel1.TabIndex = 16;
            LinkLabel1.TabStop = true;
            LinkLabel1.Text = "ĐÂY";
            LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel1_LinkClicked);
            Label3.AutoSize = true;
            Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label3.Location = new System.Drawing.Point(143, 137);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(185, 12);
            Label3.TabIndex = 17;
            Label3.Text = "QUA REF MÌNH SẼ ĐƯỢC GIẢM 3% TIỀN";
            AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(335, 156);
            Controls.Add(Label3);
            Controls.Add(LinkLabel1);
            Controls.Add(Label2);
            Controls.Add(GroupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = BEEMTOOL.Properties.Resources.Icon;
            MaximizeBox = false;
            Name = "thietlapkeyrentcode";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "THIẾT LẬP KEY RENTCODE";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
