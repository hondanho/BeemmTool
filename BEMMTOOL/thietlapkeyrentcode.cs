using BEMMTOOL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public partial class thietlapkeyrentcode : Form
	{
		public thietlapkeyrentcode()
		{
			base.Load += thietlapkeyrentcode_Load;
			InitializeComponent();
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://rentcode.co/register?referal=OY8FF");
		}

		private void btnbatdau_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(TextBox1.Text, "", TextCompare: false) == 0)
			{
				Interaction.MsgBox("Vui lòng nhập Key API rentcode");
				return;
			}
			string text = HttpUtility.UrlEncode(TextBox1.Text);
			string requestUriString = "https://api.rentcode.net/api/v2/balance?apiKey=" + text;
			HttpWebResponse httpWebResponse = null;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			string json = streamReader.ReadToEnd();
			JObject jObject = JObject.Parse(json);
			string left = (string?)jObject.SelectToken("success");
			if (Operators.CompareString(left, "True", TextCompare: false) == 0)
			{
				MyProject.MySettingsProperty.Settings.keyapi = text;
				MyProject.MySettingsProperty.Settings.keyapi = text;
				MyProject.MySettingsProperty.Settings.keyapi = text;
				MyProject.MySettingsProperty.Settings.keyapi = text;
				MyProject.MySettingsProperty.Settings.keyapi = text;
				Button1.Visible = true;
				Application.Restart();
			}
			else
			{
				Interaction.MsgBox("Mã Key API sai");
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		}

		private void thietlapkeyrentcode_Load(object sender, EventArgs e)
		{
			if (Strings.Len(MyProject.MySettingsProperty.Settings.keyapi) > 5)
			{
				Button1.Visible = true;
				TextBox1.Text = MyProject.MySettingsProperty.Settings.keyapi;
			}
			else
			{
				Button1.Visible = false;
			}
		}

		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Button1.Visible = false;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			MyProject.MySettingsProperty.Settings.ngaychinh = 0;
		}
	}
}
