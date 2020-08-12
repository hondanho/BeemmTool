using BEMMTOOL.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using static BEMMTOOL.My.MyProject;

namespace BEMMTOOL
{
	public partial class naptienvaomay : Form
	{
		public naptienvaomay()
		{
			base.Load += naptienvaomay_Load;
			InitializeComponent();
		}


		private void btnbatdau_Click(object sender, EventArgs e)
		{
			if (Operators.CompareString(TextBox1.Text, "", TextCompare: false) == 0)
			{
				Interaction.MsgBox("Vui lòng nhập code gia hạn");
				return;
			}
			RestClient restClient = new RestClient("https://loginbemmteam-f306.restdb.io/rest/system_log/" + TextBox1.Text);
			RestRequest restRequest = new RestRequest(Method.GET);
			restRequest.AddHeader("cache-control", "no-cache");
			restRequest.AddHeader("x-apikey", "0488cfbda23f7b9950524d3d882cd1be71d9f");
			restRequest.AddHeader("content-type", "application/json");
			IRestResponse restResponse = restClient.Execute(restRequest);
			string content = restResponse.Content;
			string text = content.ToString();
			if (Operators.CompareString(text, "[]", TextCompare: false) == 0)
			{
				Interaction.MsgBox("Mã code không đúng");
				return;
			}
			JObject jObject = JObject.Parse(text);
			string left = (string?)jObject.SelectToken("_id");
			if (Operators.CompareString(left, TextBox1.Text, TextCompare: false) == 0)
			{
				MySettingsProperty.Settings.ngaychinh = 100;
				Button1.Visible = true;
				MySettingsProperty.Settings.accesskey = TextBox1.Text;
				Button1.Text = "BẠN ĐÃ LÀ VIP";
				Interaction.MsgBox("Cập nhật Vip Thành công hãy bấm vào ô trang thái FREE để cập nhật sang VIP");
			}
			else
			{
				Interaction.MsgBox("Mã code không đúng");
			}
		}

		private string Tachso(string x)
		{
			string text = "";
			int length = x.Length;
			for (int i = 1; i <= length; i = checked(i + 1))
			{
				if (Versioned.IsNumeric(Strings.Mid(x, i, 1)))
				{
					text += Strings.Mid(x, i, 1);
				}
			}
			return text;
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			Process.Start("https://m.me/bemmteam?ref=MUACODEVIP");
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://m.me/bemmteam");
		}

		private void naptienvaomay_Load(object sender, EventArgs e)
		{
			if (MySettingsProperty.Settings.ngaychinh > 0)
			{
				Button1.Visible = true;
				TextBox1.Text = MySettingsProperty.Settings.accesskey;
				Button1.Text = "BẠN ĐÃ LÀ VIP";
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		}
	}
}
