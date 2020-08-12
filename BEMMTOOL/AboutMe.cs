using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public partial class AboutMe : Form
	{
		public AboutMe()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Process.Start("http://fb.com/hi.akhu.ne");
		}
	}
}
