namespace BEMMTOOL
{
    partial class thongbaochinh
    {

        private System.ComponentModel.IContainer components;
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

        private static global::System.Resources.ResourceManager resourceMan;
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BEEMTOOL.BEMMTOOL.thongbaochinh", typeof(thongbaochinh).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        private void InitializeComponent()
        {
            this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            this.WebBrowser1.Location = new System.Drawing.Point(-15, -110);
            this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser1.Name = "WebBrowser1";
            this.WebBrowser1.ScriptErrorsSuppressed = true;
            this.WebBrowser1.ScrollBarsEnabled = false;
            this.WebBrowser1.Size = new System.Drawing.Size(530, 841);
            this.WebBrowser1.TabIndex = 0;
            this.WebBrowser1.Url = new System.Uri("https://relaxnt.weebly.com/new-page.html", System.UriKind.Absolute);
            this.Panel1.Controls.Add(WebBrowser1);
            this.Panel1.Location = new System.Drawing.Point(2, 2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(492, 252);
            this.Panel1.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 254);
            this.Controls.Add(Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = BEEMTOOL.Properties.Resources.Icon;
            this.Name = "thongbaochinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG BÁO";
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.WebBrowser WebBrowser1;
        private System.Windows.Forms.Panel Panel1;
    }
}
