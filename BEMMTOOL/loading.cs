using System;
using System.Drawing;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public partial class loading : Form
	{
		public loading()
		{
			base.Load += loading_Load;
			InitializeComponent();
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
		}

		private void loading_Load(object sender, EventArgs e)
		{
			base.TransparencyKey = Color.Wheat;
			BackColor = Color.Wheat;
			Timer1.Start();
		}
	}
}
