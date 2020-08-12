using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public partial class gialap : Form
	{
		public gialap()
		{
			InitializeComponent();
		}
		
		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.memuplay.com/");
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Process.Start("https://drive.google.com/file/d/1QO5Q1TJ2XmS39YtlXUlgA8ExwIT06zoX/view?usp=sharing");
		}

		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://youtu.be/_AkH9dsFYtA");
		}

        private void button2_Click(object sender, EventArgs e)
        {
			MessageBox.Show("hello");
        }

        private void gialap_Load(object sender, EventArgs e)
        {

        }
    }
}
