using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{
    partial class DONATE
    {
        private IContainer components;
        private PictureBox PictureBox1;
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
            PictureBox1 = new System.Windows.Forms.PictureBox();
            Button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            PictureBox1.Image = BEEMTOOL.Properties.Resources.DONATE_PictureBox1_Image;
            PictureBox1.Location = new System.Drawing.Point(-1, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(398, 273);
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            Button1.Location = new System.Drawing.Point(298, 34);
            Button1.Name = "Button1";
            Button1.Size = new System.Drawing.Size(75, 23);
            Button1.TabIndex = 1;
            Button1.Text = "Button1";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += new System.EventHandler(Button1_Click);
            AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(396, 274);
            Controls.Add(Button1);
            Controls.Add(PictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Icon = BEEMTOOL.Properties.Resources.Icon;
            Name = "DONATE";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Thích thì cho không thích thì cũng phải cho";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
