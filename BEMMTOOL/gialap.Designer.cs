using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{
    partial class gialap
    {
        private IContainer components;
        private Button Button1;
        private Label Label1;
        private LinkLabel LinkLabel1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label6;
        private LinkLabel LinkLabel2;

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
                this.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Location = new System.Drawing.Point(2, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(308, 23);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "TẢI FILE GIẢ LẬP MEMU ĐỂ SỬ DỤNG TOOL BEMMTOOL";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(4, 33);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "B1 : Cài đặt giả lập";
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Location = new System.Drawing.Point(104, 33);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(36, 13);
            this.LinkLabel1.TabIndex = 2;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Memu";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(4, 60);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(159, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "B2 : Mở Multi-MEmu vừa cài đặt";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(4, 90);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(311, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "B3 : Tải File giả lập Memu bằng cách bấm vào nút tải ở trên đầu";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(4, 117);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(227, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "B4 : Import File giả lập vừa tải về và khởi động";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Red;
            this.Label6.Location = new System.Drawing.Point(4, 178);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(307, 13);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "KHÔNG THAY ĐỔI KÍCH THƯỚC HAY BẤT CỨ CÀI ĐẶT NÀO";
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Location = new System.Drawing.Point(89, 146);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(135, 13);
            this.LinkLabel2.TabIndex = 8;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "XEM VIDEO HƯỚNG DẪN";
            // 
            // gialap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 195);
            this.Controls.Add(this.LinkLabel2);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.MaximizeBox = false;
            this.Name = "gialap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cách thiết lập giả lập";
            this.Load += new System.EventHandler(this.gialap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
