using System.ComponentModel;
using System.Windows.Forms;

namespace BEMMTOOL
{
    partial class loading
    {
        private IContainer components;
        private PictureBox PictureBox1;
        private Timer Timer1;
        private Label lbltime;

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

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PictureBox1 = new System.Windows.Forms.PictureBox();
            Timer1 = new System.Windows.Forms.Timer(components);
            lbltime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            PictureBox1.Image = BEEMTOOL.Properties.Resources.loading_PictureBox1_Image;
            PictureBox1.Location = new System.Drawing.Point(0, 0);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new System.Drawing.Size(598, 359);
            PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            PictureBox1.Click += new System.EventHandler(PictureBox1_Click);
            lbltime.AutoSize = true;
            lbltime.Location = new System.Drawing.Point(12, 9);
            lbltime.Name = "lbltime";
            lbltime.Size = new System.Drawing.Size(13, 13);
            lbltime.TabIndex = 1;
            lbltime.Text = "3";
            lbltime.Visible = false;
            AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(598, 359);
            Controls.Add(lbltime);
            Controls.Add(PictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = BEEMTOOL.Properties.Resources.Icon;
            Name = "loading";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "B E M M TOOL";
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
