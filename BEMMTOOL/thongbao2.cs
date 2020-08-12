using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public partial class thongbao2 : Form
	{
		public thongbao2()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Process.Start("https://drive.google.com/open?id=1NvPs63VQxOrMHbC-KHD2F51OyPFabyL4");
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(Application.StartupPath + "\\sources\\Avata");
		}
	}
}
