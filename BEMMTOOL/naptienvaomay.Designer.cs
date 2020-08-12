using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{
    partial class naptienvaomay
    {
        private IContainer components;

        private GroupBox GroupBox1;
        private Button btnbatdau;
        private TextBox TextBox1;
        private Label Label1;
        private Label Label23;
        private Label Label3;
        private Button Button2;
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
            GroupBox1 = new System.Windows.Forms.GroupBox();
            Button1 = new System.Windows.Forms.Button();
            btnbatdau = new System.Windows.Forms.Button();
            TextBox1 = new System.Windows.Forms.TextBox();
            Label1 = new System.Windows.Forms.Label();
            Label23 = new System.Windows.Forms.Label();
            Label3 = new System.Windows.Forms.Label();
            Button2 = new System.Windows.Forms.Button();
            GroupBox1.SuspendLayout();
            SuspendLayout();
            GroupBox1.Controls.Add(Button1);
            GroupBox1.Controls.Add(btnbatdau);
            GroupBox1.Controls.Add(TextBox1);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new System.Drawing.Point(9, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Size = new System.Drawing.Size(311, 106);
            GroupBox1.TabIndex = 2;
            GroupBox1.TabStop = false;
            Button1.BackColor = System.Drawing.Color.Black;
            Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button1.Font = new System.Drawing.Font("UVN Nguyen Du", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Button1.ForeColor = System.Drawing.Color.Lime;
            Button1.Location = new System.Drawing.Point(21, 61);
            Button1.Name = "Button1";
            Button1.Size = new System.Drawing.Size(269, 33);
            Button1.TabIndex = 16;
            Button1.Text = "GIA HẠN TOOL";
            Button1.UseVisualStyleBackColor = false;
            Button1.Visible = false;
            Button1.Click += new System.EventHandler(Button1_Click);
            btnbatdau.BackColor = System.Drawing.Color.Black;
            btnbatdau.Cursor = System.Windows.Forms.Cursors.Hand;
            btnbatdau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnbatdau.Font = new System.Drawing.Font("UVN Nguyen Du", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnbatdau.ForeColor = System.Drawing.Color.Cyan;
            btnbatdau.Location = new System.Drawing.Point(52, 61);
            btnbatdau.Name = "btnbatdau";
            btnbatdau.Size = new System.Drawing.Size(207, 33);
            btnbatdau.TabIndex = 15;
            btnbatdau.Text = "NÂNG CẤP TOOL";
            btnbatdau.UseVisualStyleBackColor = false;
            btnbatdau.Click += new System.EventHandler(btnbatdau_Click);
            TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            TextBox1.Location = new System.Drawing.Point(18, 25);
            TextBox1.Multiline = true;
            TextBox1.Name = "TextBox1";
            TextBox1.Size = new System.Drawing.Size(274, 25);
            TextBox1.TabIndex = 1;
            TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            Label1.AutoSize = true;
            Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label1.Location = new System.Drawing.Point(69, 0);
            Label1.Name = "Label1";
            Label1.Size = new System.Drawing.Size(172, 12);
            Label1.TabIndex = 0;
            Label1.Text = "NHẬP MÃ CODE ĐỂ NÂNG CẤP TOOL";
            Label23.AutoSize = true;
            Label23.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label23.Location = new System.Drawing.Point(16, 115);
            Label23.Name = "Label23";
            Label23.Size = new System.Drawing.Size(296, 16);
            Label23.TabIndex = 16;
            Label23.Text = "Chỉ 50k bạn sẽ được sử dụng full tool trong vòng 30 ngày";
            Label3.AutoSize = true;
            Label3.Font = new System.Drawing.Font("Palatino Linotype", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Label3.Location = new System.Drawing.Point(41, 135);
            Label3.Name = "Label3";
            Label3.Size = new System.Drawing.Size(246, 16);
            Label3.TabIndex = 20;
            Label3.Text = "Bấm vào mua code để truy cập vào ví mua code\r\n";
            Button2.BackColor = System.Drawing.Color.Black;
            Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Button2.Font = new System.Drawing.Font("UVN Nguyen Du", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            Button2.ForeColor = System.Drawing.Color.Blue;
            Button2.Location = new System.Drawing.Point(91, 157);
            Button2.Name = "Button2";
            Button2.Size = new System.Drawing.Size(146, 27);
            Button2.TabIndex = 21;
            Button2.Text = "MUA CODE";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += new System.EventHandler(Button2_Click);
            AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size(328, 188);
            Controls.Add(Button2);
            Controls.Add(Label3);
            Controls.Add(Label23);
            Controls.Add(GroupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = BEEMTOOL.Properties.Resources.Icon;
            MaximizeBox = false;
            Name = "naptienvaomay";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "VIP TOOL";
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
