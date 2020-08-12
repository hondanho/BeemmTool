using BEMMTOOL.My;
using KAutoHelper;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace BEMMTOOL
{
    public partial class trangchu : Form
    {
       
        public trangchu()
        {
            base.Load += Trangchu_Load;
            InitializeComponent();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_01f2, IL_0308, IL_03ce, IL_03d0, IL_03d7, IL_03da, IL_03db, IL_03e8, IL_040a
            int num2 = default(int);
            int num3 = default(int);
            try
            {
                int num = 1;
                listtaikhoan.Text = MyProject.MySettingsProperty.Settings.taikhoanverify;
                num = 2;
                listtaikhoantiktok.Text = MyProject.MySettingsProperty.Settings.listtiktok;
                num = 3;
                txtsubid.Text = MyProject.MySettingsProperty.Settings.subid;
                num = 4;
                txtsubid2.Text = MyProject.MySettingsProperty.Settings.subid;
                num = 5;
                txtlikepage.Text = MyProject.MySettingsProperty.Settings.pageid;
                num = 6;
                txtlikepage2.Text = MyProject.MySettingsProperty.Settings.pageid;
                num = 7;
                checknu.Checked = true;
                num = 8;
                checknu2.Checked = true;
                num = 9;
                keytiktok.Text = MyProject.MySettingsProperty.Settings.keyapi;
                num = 10;
                if (Operators.CompareString(MyProject.MySettingsProperty.Settings.keyapi, "", TextCompare: false) == 0)
                {
                    num = 11;
                    lblstt4.Text = "Vui lòng thêm key rentcode";
                }
                else
                {
                    num = 13;
                    lblstt4.Text = MyProject.MySettingsProperty.Settings.keyapi;
                }
                ProjectData.ClearProjectError();
                num2 = -2;
                num = 16;
                RestClient restClient = new RestClient("https://loginbemmteam-f306.restdb.io/rest/system_log/" + MyProject.MySettingsProperty.Settings.accesskey);
                num = 17;
                RestRequest restRequest = new RestRequest(Method.GET);
                num = 18;
                restRequest.AddHeader("cache-control", "no-cache");
                num = 19;
                restRequest.AddHeader("x-apikey", "0488cfbda23f7b9950524d3d882cd1be71d9f");
                num = 20;
                restRequest.AddHeader("content-type", "application/json");
                num = 21;
                IRestResponse restResponse = restClient.Execute(restRequest);
                num = 22;
                string content = restResponse.Content;
                num = 23;
                string text = content.ToString();
                num = 24;
                if (Operators.CompareString(text, "[]", TextCompare: false) == 0)
                {
                    num = 25;
                    lblxu.Text = "FREE";
                    num = 26;
                    MyProject.MySettingsProperty.Settings.ngaychinh = 0;
                }
                else
                {
                    num = 29;
                    JObject jObject = JObject.Parse(text);
                    num = 30;
                    string left = (string?)jObject.SelectToken("_id");
                    num = 31;
                    if (Operators.CompareString(left, MyProject.MySettingsProperty.Settings.accesskey, TextCompare: false) == 0)
                    {
                        num = 32;
                        lblxu.Text = "VIP";
                        num = 33;
                        lblxu.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        num = 35;
                        lblxu.Text = "FREE";
                        num = 36;
                        lblxu.ForeColor = Color.Ivory;
                        num = 37;
                        MyProject.MySettingsProperty.Settings.ngaychinh = 0;
                    }
                    num = 39;
                    if (MyProject.MySettingsProperty.Settings.ngaychinh == 0)
                    {
                        num = 40;
                        lblxu.Text = "FREE";
                        num = 41;
                        lblxu.ForeColor = Color.Ivory;
                    }
                    else
                    {
                        num = 43;
                        lblxu.Text = "VIP";
                        num = 44;
                        lblxu.ForeColor = Color.Yellow;
                    }
                }
            }
            catch (Exception obj) when (obj is Exception && num2 != 0 && num3 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_0408: Could not find block for branch target IL_03d0*/
                ;
            }
            if (num3 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void SimplaButton1_Click(object sender, EventArgs e)
        {
            btnthanhtoanverify.Text = "ĐANG THANH TOÁN";
            btnthanhtoanverify.Enabled = false;
            if (Operators.CompareString(lblxuthanhtoan.Text, lblxu.Text, TextCompare: false) > 0)
            {
                Interaction.MsgBox("Không đủ tiền vui lòng nạp thêm");
                btnthanhtoanverify.Text = "THANH TOÁN";
                btnthanhtoanverify.Enabled = true;
                txttinnhan.Text = "";
                txttinnhanmain.Text = "";
                txtsdt.Text = "";
                return;
            }
            Timer9.Start();
            string requestUriString = "https://api.rentcode.net/api/v2/order/request?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi + "&ServiceProviderId=" + iddv.Text;
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string text = streamReader.ReadToEnd();
            rtverify.Text = text;
            JObject jObject = JObject.Parse(text);
            oderid.Text = (string?)jObject.SelectToken("id");
            txttrangthai.Text = (string?)jObject.SelectToken("success");
            lblxuthanhtoan.Visible = false;
            PNTINNHAN.Visible = true;
            PictureBox2.Visible = true;
            if (Operators.CompareString(txttrangthai.Text, "True", TextCompare: false) == 0)
            {
                Timer2.Start();
                btnthanhtoanverify.Text = "ĐANG CHỜ TIN NHẮN";
                return;
            }
            Timer2.Stop();
            lbltime.Text = Conversions.ToString(2);
            lblstt5.Text = "Không lấy được";
            lblxuthanhtoan.Visible = true;
            PNTINNHAN.Visible = false;
            PictureBox2.Visible = false;
            btnthanhtoanverify.Text = "THANH TOÁN";
            btnthanhtoanverify.Enabled = true;
            loadingverify.Value = 0;
            lblxu.Text += lblxuthanhtoan.Text;
        }

        private void Facebok_CheckedChanged(object sender)
        {
            lblxuthanhtoan.Text = Conversions.ToString(1400);
            iddv.Text = Conversions.ToString(3);
            SimplaButton1.Text = "FACEBOOK";
        }

        private void Gmail_CheckedChanged(object sender)
        {
            lblxuthanhtoan.Text = Conversions.ToString(1000);
            iddv.Text = Conversions.ToString(40);
            SimplaButton1.Text = "GMAIL - GOOGLE";
        }

        private void Instagram_CheckedChanged(object sender)
        {
            lblxuthanhtoan.Text = Conversions.ToString(1000);
            iddv.Text = Conversions.ToString(33);
            SimplaButton1.Text = "INSTAGRAM";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Interval = 1000;
            checked
            {
                if (loadingverify.Value == 0)
                {
                    loadingverify.Value += 1;
                }
                else if (loadingverify.Value == 300)
                {
                    lblxu.Text += lblxuthanhtoan.Text;
                    Timer1.Stop();
                    Interaction.MsgBox("Lỗi không lấy được mã code, bạn được hoàn lại tiền");
                    txtsdt.Text = "";
                    lblxuthanhtoan.Visible = true;
                    PNTINNHAN.Visible = false;
                    PictureBox2.Visible = false;
                    btnthanhtoanverify.Text = "THANH TOÁN";
                    btnthanhtoanverify.Enabled = true;
                    loadingverify.Value = 0;
                }
                else
                {
                    loadingverify.Value += 1;
                    btnkiemtra.PerformClick();
                }
            }
        }

        private void Txttinnhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            txttinnhan.Text = txttinnhanmain.Text;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Operators.CompareString(txttinnhanmain.Text, "", TextCompare: false) == 0)
            {
                string value = Conversions.ToString((int)Interaction.MsgBox("Bạn vẫn chưa có tin nhắn nếu bạn nhấn hoàn thành sẽ không lấy lại được bạn chắc chứ ? ", MsgBoxStyle.YesNo));
                if (Conversions.ToDouble(value) == 6.0)
                {
                    Timer2.Stop();
                    lbltime.Text = Conversions.ToString(2);
                    Timer1.Stop();
                    VIEWSDT.Visible = false;
                    lblxuthanhtoan.Visible = true;
                    PNTINNHAN.Visible = false;
                    PictureBox2.Visible = false;
                    btnthanhtoanverify.Text = "THANH TOÁN";
                    btnthanhtoanverify.Enabled = true;
                    lblgiohan.Text = Conversions.ToString(0);
                    loadingverify.Value = 0;
                }
            }
            else if (Operators.CompareString(txttinnhanmain.Text, "null", TextCompare: false) == 0)
            {
                string value2 = Conversions.ToString((int)Interaction.MsgBox("Bạn vẫn chưa có tin nhắn nếu bạn nhấn hoàn thành sẽ không lấy lại được bạn chắc chứ ? ", MsgBoxStyle.YesNo));
                if (Conversions.ToDouble(value2) == 6.0)
                {
                    Timer1.Stop();
                    lblxuthanhtoan.Visible = true;
                    PNTINNHAN.Visible = false;
                    PictureBox2.Visible = false;
                    btnthanhtoanverify.Text = "THANH TOÁN";
                    btnthanhtoanverify.Enabled = true;
                    loadingverify.Value = 0;
                }
            }
            else
            {
                Timer1.Stop();
                lblxuthanhtoan.Visible = true;
                PNTINNHAN.Visible = false;
                PictureBox2.Visible = false;
                btnthanhtoanverify.Text = "THANH TOÁN";
                btnthanhtoanverify.Enabled = true;
                txttinnhan.Text = "";
                loadingverify.Value = 0;
            }
        }

        private void BTNKIEMTRA_Click(object sender, EventArgs e)
        {
            string requestUriString = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string text = streamReader.ReadToEnd();
            rtverify.Text = text;
            JObject jObject = JObject.Parse(text);
            txttinnhanmain.Text = (string?)jObject.SelectToken("message");
            txtsdt.Text = (string?)jObject.SelectToken("phoneNumber");
            txttinnhan.Text = txttinnhanmain.Text;
            if (Operators.CompareString(txttinnhanmain.Text, "null", TextCompare: false) != 0 && Operators.CompareString(txttinnhanmain.Text, "", TextCompare: false) != 0)
            {
                Timer1.Stop();
                loadingverify.Value = 0;
                PictureBox2.Visible = false;
                btnthanhtoanverify.Text = "ĐÃ NHẬN CODE";
                lblgiohan.Text = Conversions.ToString(0);
                Timer1.Stop();
                loadingverify.Value = 0;
            }
        }

        private void Btnaddho_Click(object sender, EventArgs e)
        {
            listho.Items.Add(txtho.Text);
            txtho.Text = "";
        }

        private void Btnaddten_Click(object sender, EventArgs e)
        {
            listten.Items.Add(txtten.Text);
            txtten.Text = "";
        }

        private void Btnxoaho_Click(object sender, EventArgs e)
        {
            listho.Items.Remove(RuntimeHelpers.GetObjectValue(listho.SelectedItem));
        }

        private void Btnxoaten_Click(object sender, EventArgs e)
        {
            listten.Items.Remove(RuntimeHelpers.GetObjectValue(listten.SelectedItem));
        }

        private void Btnbatdau_Click(object sender, EventArgs e)
        {
            if (Operators.CompareString(txtmatkhau.Text, "", TextCompare: false) == 0)
            {
                Interaction.MsgBox("Vui lòng nhập mật khẩu");
                return;
            }
            if (Strings.Len(MyProject.MySettingsProperty.Settings.keyapi) < 5)
            {
                Interaction.MsgBox("Cần có Key APi Rentcode để xác minh số điện thoại");
                return;
            }
            txtaddtaikhoan.Text = "";
            Timer10.Start();
            Panel1.Enabled = false;
            SimplaButton1.Text = "FACEBOOK";
            lblstt5.Visible = false;
            lblstt.Visible = false;
            btnbatdau.Enabled = false;
            lblstt4.Visible = false;
            lblxacnhan.Text = Conversions.ToString(1);
            lblstt2.Visible = true;
            string requestUriString = "https://api.rentcode.net/api/v2/order/request?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi + "&ServiceProviderId=3";
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string text = streamReader.ReadToEnd();
            rtverify.Text = text;
            JObject jObject = JObject.Parse(text);
            oderid.Text = (string?)jObject.SelectToken("id");
            txttrangthai.Text = (string?)jObject.SelectToken("success");
            lblxuthanhtoan.Visible = false;
            PNTINNHAN.Visible = true;
            PictureBox2.Visible = true;
            if (Operators.CompareString(txttrangthai.Text, "True", TextCompare: false) == 0)
            {
                Timer7.Start();
                btnthanhtoanverify.Text = "ĐANG CHỜ TIN NHẮN";
                Random random = new Random();
                int count = listho.Items.Count;
                object objectValue = RuntimeHelpers.GetObjectValue(listho.Items[random.Next(count)]);
                int count2 = listten.Items.Count;
                object objectValue2 = RuntimeHelpers.GetObjectValue(listten.Items[random.Next(count2)]);
                string text2 = objectValue2.ToString();
                string text3 = objectValue.ToString();
                TextBox2.Text = text3;
                TextBox3.Text = text2;
            }
            else
            {
                Timer7.Stop();
                lbltime.Text = Conversions.ToString(2);
                lblstt5.Text = "Lỗi không quét được Key API rentcode của bạn";
                lblxuthanhtoan.Visible = true;
                PNTINNHAN.Visible = false;
                PictureBox2.Visible = false;
                btnthanhtoanverify.Text = "THANH TOÁN";
                btnthanhtoanverify.Enabled = true;
                btndunglai.Enabled = true;
                btndunglai.PerformClick();
                loadingverify.Value = 0;
                btndunglai.PerformClick();
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            Timer3.Interval = 1000;
            if (Conversions.ToDouble(lbltime3.Text) == 30.0)
            {
                lbltime3.Text = Conversions.ToString(Conversions.ToDouble(lbltime3.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime3.Text) == 1.0)
            {
                lblstt.Visible = false;
                LBLSTT1.Visible = true;
                lbltime3.Visible = false;
                lblstt2.Visible = false;
                lblstt5.Visible = false;
                lblxacnhan.Text = Conversions.ToString(1);
                Timer3.Stop();
                lbltime3.Text = Conversions.ToString(30);
                btnbatdau.Enabled = true;
                lblstt5.Text = "LỖI TẠO ACC";
                lblstt5.Visible = false;
                btnbatdau.PerformClick();
                btnbatdau.Enabled = false;
                lblsttsubid.Text = "SUB ID DONE";
                lblsttsubid.ForeColor = Color.Blue;
                lblsttok.Text = "TẠO NICK THÀNH CÔNG ";
                lblsttok.ForeColor = Color.Lime;
            }
            else
            {
                lbltime3.Text = Conversions.ToString(Conversions.ToDouble(lbltime3.Text) - 1.0);
            }
        }

        private string Tachso(string x)
        {
            //Discarded unreachable code: IL_006b, IL_009d, IL_009f, IL_00a6, IL_00a9, IL_00aa, IL_00b7, IL_00d9
            int num = default(int);
            string result = string.Empty;
            int num3 = default(int);
            try
            {
                ProjectData.ClearProjectError();
                num = -2;
                int num2 = 2;
                string text = "";
                num2 = 3;
                int length = x.Length;
                for (int i = 1; i <= length; i = checked(i + 1))
                {
                    num2 = 4;
                    if (Versioned.IsNumeric(Strings.Mid(x, i, 1)))
                    {
                        num2 = 5;
                        text += Strings.Mid(x, i, 1);
                    }
                    num2 = 6;
                }
                num2 = 7;
                result = text;
                ProjectData.ClearProjectError();
                num = -3;
            }
            catch (Exception obj) when (obj is Exception && num != 0 && num3 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_00d7: Could not find block for branch target IL_009f*/
                ;
            }
            if (num3 != 0)
            {
                ProjectData.ClearProjectError();
            }
            return result;
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.text";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, listtaikhoan.Text);
            }
        }

        private void btndunglai_Click(object sender, EventArgs e)
        {
            Timer10.Stop();
            lbltime10.Text = Conversions.ToString(70);
            Panel1.Enabled = true;
            lblstt5.Visible = false;
            btnhoanthanh.PerformClick();
            Timer1.Stop();
            lblxuthanhtoan.Visible = true;
            PNTINNHAN.Visible = false;
            PictureBox2.Visible = false;
            btnthanhtoanverify.Text = "THANH TOÁN";
            btnthanhtoanverify.Enabled = true;
            Timer7.Stop();
            loadingverify.Value = 0;
            Timer3.Stop();
            lbltime3.Text = Conversions.ToString(30);
            lbltime3.Visible = false;
            lblstt.Visible = false;
            lblxacnhan.Text = Conversions.ToString(0);
            btndunglai.Enabled = true;
            btnbatdau.Enabled = true;
            LBLSTT1.Visible = false;
            lblstt2.Visible = false;
            lblstt4.Visible = true;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vietpn.com/register?ref=2c1e7609c5cc32488027b55b1265c576");
        }

        private void checksubid_CheckedChanged(object sender)
        {
            if (!checksubid.Checked)
            {
                txtsubid.Enabled = false;
            }
            else if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
            {
                checksubid.Checked = false;
                Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
            }
            else
            {
                txtsubid.Enabled = true;
            }
        }

        private void checkcookie2_CheckedChanged(object sender)
        {
            if (checkcookie2.Checked)
            {
                Interaction.MsgBox("Việc lấy Cookie sẽ dễ bị checkpoin hơn");
            }
        }

        private void btndunglai2_Click(object sender, EventArgs e)
        {
            lblstt5456.Visible = false;
            loadingverify.Value = 0;
            Timer5.Stop();
            lbltime3456.Text = Conversions.ToString(30);
            lblstt456.Visible = false;
            lbltime3456.Visible = false;
            btndunglai2.Enabled = true;
            btnbatdau2.Enabled = true;
            LBLSTT1456.Visible = false;
            lblstt2456.Visible = false;
            lblstt4456.Visible = true;
        }

        private void checksubid2_CheckedChanged(object sender)
        {
            if (!checksubid2.Checked)
            {
                txtsubid2.Enabled = false;
            }
            else if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
            {
                Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                checksubid2.Checked = false;
            }
            else
            {
                txtsubid2.Enabled = true;
            }
        }

        private void btnaddho2_Click(object sender, EventArgs e)
        {
            listho2.Items.Add(txtho2.Text);
            txtho2.Text = "";
        }

        private void btnaddten2_Click(object sender, EventArgs e)
        {
            listten2.Items.Add(txtten2.Text);
            txtten2.Text = "";
        }

        private void btnxoaho2_Click(object sender, EventArgs e)
        {
            listho2.Items.Remove(RuntimeHelpers.GetObjectValue(listho2.SelectedItem));
        }

        private void btnxoaten2_Click(object sender, EventArgs e)
        {
            listten2.Items.Remove(RuntimeHelpers.GetObjectValue(listten2.SelectedItem));
        }

        private void btnbatdau2_Click(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_0615, IL_0816, IL_081f, IL_0832, IL_0842, IL_0856, IL_086a, IL_087a, IL_088a, IL_089f, IL_08ae, IL_08bd, IL_08cd, IL_08dd, IL_08ed, IL_08fd, IL_0908, IL_090d, IL_1092, IL_109b, IL_10b1, IL_10c4, IL_10db, IL_10f2, IL_1105, IL_1118, IL_1130, IL_1142, IL_1154, IL_1167, IL_117a, IL_118d, IL_11a0, IL_11ae, IL_11b3, IL_1389, IL_1455, IL_145e, IL_1474, IL_1487, IL_149e, IL_14b5, IL_14c8, IL_14db, IL_14f3, IL_1505, IL_1517, IL_152a, IL_153d, IL_1550, IL_1563, IL_1571, IL_1576, IL_2d13, IL_2d14, IL_2d3b, IL_2d5e, IL_2d6c, IL_2d7f, IL_2d92, IL_2da5, IL_2db7, IL_2dca, IL_2ddd, IL_2df0, IL_2e03, IL_2e11, IL_2e1f, IL_2e28, IL_2e2d, IL_2e2e, IL_2e41, IL_2e54, IL_2e67, IL_2e79, IL_2e8c, IL_2e9f, IL_2eb2, IL_2ec5, IL_2ed3, IL_2ee1, IL_2eea, IL_2eec, IL_2eee, IL_2f0f, IL_390d, IL_390f, IL_3916, IL_3919, IL_391a, IL_395b, IL_397d
            checked
            {
                int num = default(int);
                int num9 = default(int);
                try
                {
                    ProjectData.ClearProjectError();
                    num = 2;
                    int num2 = 2;
                    MyProject.Forms.thongbao.Show();
                    num2 = 3;
                    lblstt4456.Visible = false;
                    num2 = 4;
                    lblstt2456.Visible = true;
                    num2 = 5;
                    lblstt5456.Visible = false;
                    num2 = 6;
                    lblstt456.Visible = false;
                    num2 = 7;
                    btndunglai2.Enabled = false;
                    num2 = 8;
                    btnbatdau2.Enabled = false;
                    num2 = 9;
                    Random random = new Random();
                    num2 = 10;
                    int count = listho.Items.Count;
                    num2 = 11;
                    object objectValue = RuntimeHelpers.GetObjectValue(listho.Items[random.Next(count)]);
                    num2 = 12;
                    int count2 = listten.Items.Count;
                    num2 = 13;
                    object objectValue2 = RuntimeHelpers.GetObjectValue(listten.Items[random.Next(count2)]);
                    num2 = 14;
                    string text = objectValue2.ToString();
                    num2 = 15;
                    string text2 = objectValue.ToString();
                    num2 = 16;
                    TextBox2.Text = text2;
                    num2 = 17;
                    TextBox3.Text = text;
                    num2 = 18;
                    ChromeOptions chromeOptions = new ChromeOptions();
                    num2 = 19;
                    chromeOptions.AddArgument("--window-position=-32000,-32000");
                    num2 = 20;
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    num2 = 21;
                    chromeDriverService.HideCommandPromptWindow = true;
                    num2 = 22;
                    ChromeOptions chromeOptions2 = new ChromeOptions();
                    num2 = 23;
                    chromeOptions2.AddArguments("--disable-notifications");
                    num2 = 24;
                    chromeOptions2.AddArgument("--disable-blink-features=AutomationControlled");
                    num2 = 25;
                    chromeOptions2.AddArguments("profile.default_content_setting_values.images", Conversions.ToString(2));
                    num2 = 26;
                    chromeOptions2.AddExcludedArgument("enable-automation");
                    num2 = 27;
                    chromeOptions2.AddAdditionalCapability("useAutomationExtension", false);
                    num2 = 28;
                    chromeOptions2.AddUserProfilePreference("profile.password_manager_enabled", false);
                    num2 = 29;
                    chromeOptions2.AddArguments("--disable-notifications");
                    num2 = 30;
                    chromeOptions2.AddUserProfilePreference("credentials_enable_service", false);
                    num2 = 31;
                    chromeOptions2.AddUserProfilePreference("profile.password_manager_enabled", false);
                    num2 = 32;
                    ChromeOptions chromeOptions3 = new ChromeOptions();
                    num2 = 33;
                    chromeOptions3.AddArguments("--blink-settings=imagesEnabled=false");
                    num2 = 34;
                    ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions3);
                    ProjectData.ClearProjectError();
                    num = 3;
                    num2 = 36;
                    chromeDriver.Navigate().GoToUrl("https://temp-mail.org/vi/change");
                    num2 = 37;
                    string str = Conversions.ToString(random.Next(10000, 90000));
                    num2 = 38;
                    string text3 = "bemmteam" + str;
                    num2 = 39;
                    IWebElement webElement = chromeDriver.FindElement(By.XPath("//*[@id='new_mail']"));
                    num2 = 40;
                    webElement.SendKeys(text3);
                    num2 = 41;
                    delay(2);
                    num2 = 42;
                    IWebElement webElement2 = chromeDriver.FindElement(By.XPath("//*[@id='select2-domain-container']"));
                    num2 = 43;
                    webElement2.Click();
                    num2 = 44;
                    delay(2);
                    num2 = 45;
                    string text4 = chromeDriver.FindElement(By.XPath("//*[@id='select2-domain-container']")).Text;
                    num2 = 46;
                    txtmail.Text = text3 + text4;
                    num2 = 47;
                    delay(2);
                    num2 = 48;
                    IWebElement webElement3 = chromeDriver.FindElement(By.XPath("/html/body/main/div[1]/div/div[2]/div[2]/div/div[1]/div/div[2]"));
                    num2 = 49;
                    webElement3.Click();
                    num2 = 50;
                    delay(2);
                    num2 = 51;
                    Thread.Sleep(2000);
                    num2 = 52;
                    IWebElement webElement4 = chromeDriver.FindElement(By.XPath("//*[@id='postbut']"));
                    num2 = 53;
                    webElement4.Click();
                    num2 = 54;
                    if (MyProject.Forms.thongbao != null)
                        MyProject.Forms.thongbao.Close();
                    num2 = 55;
                    base.Visible = false;
                    num2 = 56;
                    if (!checkgialap2.Checked)
                    {
                        goto IL_1607;
                    }
                    num2 = 57;
                    Random random2 = new Random();
                    num2 = 58;
                    int count3 = listhogialap.Items.Count;
                    num2 = 59;
                    object objectValue3 = RuntimeHelpers.GetObjectValue(listhogialap.Items[random.Next(count3)]);
                    num2 = 60;
                    int count4 = listtengialap.Items.Count;
                    num2 = 61;
                    object objectValue4 = RuntimeHelpers.GetObjectValue(listtengialap.Items[random.Next(count4)]);
                    num2 = 62;
                    string str2 = objectValue4.ToString();
                    num2 = 63;
                    string str3 = objectValue3.ToString();
                    num2 = 64;
                    str2 = "'" + str2 + "'";
                    num2 = 65;
                    str3 = "'" + str3 + "'";
                    num2 = 66;
                    string str4 = Strings.Replace(str3, " ", "%s");
                    num2 = 67;
                    string str5 = Strings.Replace(str2, " ", "%s");
                    num2 = 68;
                    str5 = "'" + str5 + "'";
                    num2 = 69;
                    str4 = "'" + str4 + "'";
                    num2 = 70;
                    GETID();
                    num2 = 71;
                    if (Operators.CompareString(txtidgialap.Text, "", TextCompare: false) == 0)
                    {
                        num2 = 72;
                        MyProject.Forms.thongbao.Close();
                        num2 = 73;
                        lblsttloi2.Visible = true;
                        num2 = 74;
                        lblsttok2.Text = "Lỗi không vào được facebook";
                        num2 = 75;
                        lblsttok.ForeColor = Color.Red;
                        num2 = 76;
                        btndunglai2.Enabled = true;
                        num2 = 77;
                        lblstt5456.Visible = true;
                        num2 = 78;
                        lblxacnhan.Text = Conversions.ToString(0);
                        num2 = 79;
                        btnhoanthanh.PerformClick();
                        num2 = 80;
                        Timer5.Start();
                        num2 = 81;
                        lblstt456.Visible = true;
                        num2 = 82;
                        LBLSTT1456.Visible = false;
                        num2 = 83;
                        lbltime3456.Visible = true;
                        num2 = 84;
                        lblstt2456.Visible = false;
                        num2 = 85;
                        base.Visible = true;
                        num2 = 86;
                        Interaction.MsgBox("Không tìm được giả lập");
                    }
                    else
                    {
                        num2 = 89;
                        string text5 = txtidgialap.Text;
                        num2 = 90;
                        ADBHelper.ExecuteCMD("adb -s " + text5 + " shell input keyevent 3 & adb -s " + text5 + " shell pm clear com.facebook.lite & adb -s " + text5 + " shell pm clear com.android.browser && exit");
                        num2 = 91;
                        delay(6);
                        num2 = 92;
                        ADBHelper.ExecuteCMD("adb -s " + text5 + " shell screencap /mnt/sdcard/Download/manhinh.png");
                        num2 = 93;
                        ADBHelper.ExecuteCMD("adb  -s " + text5 + " pull /mnt/sdcard/Download/manhinh.png manhinh.png");
                        num2 = 94;
                        FileStream fileStream = new FileStream(Application.StartupPath + "\\sources\\Data\\fblite.png", FileMode.Open, FileAccess.Read);
                        num2 = 95;
                        FileStream fileStream2 = new FileStream("\\source\\manhinh.png", FileMode.Open, FileAccess.Read);
                        num2 = 96;
                        Bitmap subBitmap = (Bitmap)Image.FromStream(fileStream);
                        num2 = 97;
                        Bitmap mainBitmap = (Bitmap)Image.FromStream(fileStream2);
                        num2 = 98;
                        Point? point = ImageScanOpenCV.FindOutPoint(mainBitmap, subBitmap);
                        num2 = 99;
                        Bitmap bitmap = ImageScanOpenCV.Find(mainBitmap, subBitmap);
                        num2 = 100;
                        ADBHelper.Tap(text5, point.Value.X, point.Value.Y);
                        num2 = 101;
                        fileStream.Close();
                        num2 = 102;
                        fileStream2.Close();
                        num2 = 103;
                        delay(20);
                        num2 = 104;
                        ADBHelper.ExecuteCMD("adb -s " + text5 + " shell screencap /mnt/sdcard/Download/manhinh4.png");
                        num2 = 105;
                        ADBHelper.ExecuteCMD("adb  -s " + text5 + " pull /mnt/sdcard/Download/manhinh4.png manhinh4.png");
                        num2 = 106;
                        FileStream stream = new FileStream(Application.StartupPath + "\\sources\\Data\\regok.png", FileMode.Open, FileAccess.Read);
                        num2 = 107;
                        FileStream stream2 = new FileStream("\\source\\manhinh4.png", FileMode.Open, FileAccess.Read);
                        num2 = 108;
                        Bitmap subBitmap2 = (Bitmap)Image.FromStream(stream);
                        num2 = 109;
                        Bitmap mainBitmap2 = (Bitmap)Image.FromStream(stream2);
                        num2 = 110;
                        Point? point2 = ImageScanOpenCV.FindOutPoint(mainBitmap2, subBitmap2);
                        num2 = 111;
                        bool flag = false;
                        num2 = 129;
                        ADBHelper.Tap(text5, point2.Value.X, point2.Value.Y);
                        num2 = 131;
                        delay(10);
                        num2 = 132;
                        ADBHelper.Tap(text5, 204, 279);
                        num2 = 133;
                        delay(3);
                        num2 = 134;
                        ADBHelper.InputText(text5, str4);
                        num2 = 135;
                        delay(3);
                        num2 = 136;
                        ADBHelper.Tap(text5, 268, 149);
                        num2 = 137;
                        delay(3);
                        num2 = 138;
                        ADBHelper.InputText(text5, str5);
                        num2 = 139;
                        ADBHelper.Tap(text5, 203, 185);
                        num2 = 140;
                        delay(7);
                        num2 = 141;
                        ADBHelper.Tap(text5, 202, 684);
                        num2 = 142;
                        delay(3);
                        num2 = 143;
                        txtmail.Text = Strings.Replace(txtmail.Text, "bemmteam", "");
                        num2 = 144;
                        ADBHelper.InputText(text5, "bemmteam");
                        num2 = 145;
                        int num3 = 1;
                        do
                        {
                            num2 = 146;
                            short num4 = Conversions.ToShort(Strings.Mid(txtmail.Text, num3, 1));
                            num2 = 147;
                            if (num4 == 0)
                            {
                                num2 = 148;
                                ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_0);
                            }
                            else
                            {
                                num2 = 150;
                                if (num4 == 1)
                                {
                                    num2 = 151;
                                    ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_1);
                                }
                                else
                                {
                                    num2 = 153;
                                    if (num4 == 2)
                                    {
                                        num2 = 154;
                                        ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_2);
                                    }
                                    else
                                    {
                                        num2 = 156;
                                        if (num4 == 3)
                                        {
                                            num2 = 157;
                                            ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_3);
                                        }
                                        else
                                        {
                                            num2 = 159;
                                            if (num4 == 4)
                                            {
                                                num2 = 160;
                                                ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_4);
                                            }
                                            else
                                            {
                                                num2 = 162;
                                                if (num4 == 5)
                                                {
                                                    num2 = 163;
                                                    ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_5);
                                                }
                                                else
                                                {
                                                    num2 = 165;
                                                    if (num4 == 6)
                                                    {
                                                        num2 = 166;
                                                        ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_6);
                                                    }
                                                    else
                                                    {
                                                        num2 = 168;
                                                        if (num4 == 7)
                                                        {
                                                            num2 = 169;
                                                            ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_7);
                                                        }
                                                        else
                                                        {
                                                            num2 = 171;
                                                            if (num4 == 8)
                                                            {
                                                                num2 = 172;
                                                                ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_8);
                                                            }
                                                            else
                                                            {
                                                                num2 = 174;
                                                                if (num4 == 9)
                                                                {
                                                                    num2 = 175;
                                                                    ADBHelper.Key(text5, ADBKeyEvent.KEYCODE_9);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            num2 = 177;
                            num3++;
                        }
                        while (num3 <= 5);
                        num2 = 178;
                        string text6 = Strings.Mid(txtmail.Text, 1, 5);
                        num2 = 179;
                        txtmail.Text = Strings.Replace(txtmail.Text, text6, "");
                        num2 = 180;
                        ADBHelper.InputText(text5, "'" + txtmail.Text + "'");
                        num2 = 181;
                        txtmail.Text = "bemmteam" + text6 + txtmail.Text;
                        num2 = 182;
                        delay(3);
                        num2 = 183;
                        ADBHelper.Tap(text5, 200, 196);
                        num2 = 184;
                        delay(3);
                        num2 = 185;
                        ADBHelper.Tap(text5, 86, 169);
                        num2 = 186;
                        ADBHelper.Tap(text5, 203, 567);
                        num2 = 187;
                        ADBHelper.Tap(text5, 200, 681);
                        num2 = 188;
                        ADBHelper.Tap(text5, 200, 681);
                        num2 = 189;
                        ADBHelper.Tap(text5, 200, 681);
                        num2 = 190;
                        delay(2);
                        num2 = 191;
                        ADBHelper.Tap(text5, 200, 209);
                        num2 = 192;
                        delay(4);
                        num2 = 193;
                        if (checknam.Checked)
                        {
                            num2 = 194;
                            ADBHelper.Tap(text5, 384, 179);
                        }
                        else
                        {
                            num2 = 196;
                            ADBHelper.Tap(text5, 385, 148);
                        }
                        num2 = 198;
                        delay(4);
                        num2 = 199;
                        SENDTEXT(text5, txtmatkhau2.Text);
                        num2 = 200;
                        delay(2);
                        num2 = 201;
                        ADBHelper.Tap(text5, 204, 243);
                        num2 = 202;
                        delay(10);
                        num2 = 203;
                        ADBHelper.Tap(text5, 97, 679);
                        num2 = 204;
                        Thread.Sleep(30000);
                        num2 = 205;
                        string text7 = chromeDriver.FindElement(By.XPath("/html/body/main/div[1]/div/div[2]/div[2]/div/div[1]/div/div[4]/ul/li[3]/div[2]/span/a")).Text;
                        num2 = 206;
                        text7 = Tachso(text7);
                        num2 = 207;
                        if (Strings.Len(text7) > 3)
                        {
                            num2 = 208;
                            ADBHelper.ExecuteCMD("adb -s " + text5 + " shell screencap /mnt/sdcard/Download/manhinh1.png");
                            num2 = 209;
                            ADBHelper.ExecuteCMD("adb  -s " + text5 + " pull /mnt/sdcard/Download/manhinh1.png manhinh1.png");
                            num2 = 210;
                            FileStream fileStream3 = new FileStream(Application.StartupPath + "\\sources\\Data\\code.png", FileMode.Open, FileAccess.Read);
                            num2 = 211;
                            FileStream fileStream4 = new FileStream("\\source\\manhinh1.png", FileMode.Open, FileAccess.Read);
                            num2 = 212;
                            Bitmap subBitmap3 = (Bitmap)Image.FromStream(fileStream3);
                            num2 = 213;
                            Bitmap mainBitmap3 = (Bitmap)Image.FromStream(fileStream4);
                            num2 = 214;
                            Point? point3 = ImageScanOpenCV.FindOutPoint(mainBitmap3, subBitmap3);
                            num2 = 215;
                            ADBHelper.Tap(text5, 73, 492);
                            num2 = 216;
                            ADBHelper.Tap(text5, point3.Value.X + 10, point3.Value.Y + 10);
                            num2 = 217;
                            fileStream3.Close();
                            num2 = 218;
                            fileStream4.Close();
                            num2 = 219;
                            delay(2);
                            num2 = 220;
                            ADBHelper.InputText(text5, text7);
                            num2 = 221;
                            string text8 = ADBHelper.ExecuteCMD("adb -s " + text5 + " shell screencap /mnt/sdcard/Download/manhinh2.png");
                            num2 = 222;
                            string text9 = ADBHelper.ExecuteCMD("adb  -s " + text5 + " pull /mnt/sdcard/Download/manhinh2.png manhinh2.png");
                            num2 = 223;
                            FileStream fileStream5 = new FileStream(Application.StartupPath + "\\sources\\Data\\ok.png", FileMode.Open, FileAccess.Read);
                            num2 = 224;
                            FileStream fileStream6 = new FileStream("\\source\\manhinh2.png", FileMode.Open, FileAccess.Read);
                            num2 = 225;
                            delay(2);
                            num2 = 226;
                            Bitmap subBitmap4 = (Bitmap)Image.FromStream(fileStream5);
                            num2 = 227;
                            Bitmap mainBitmap4 = (Bitmap)Image.FromStream(fileStream6);
                            num2 = 228;
                            Point? point4 = ImageScanOpenCV.FindOutPoint(mainBitmap4, subBitmap4);
                            num2 = 229;
                            bool flag2 = false;
                            num2 = 247;
                            ADBHelper.Tap(text5, point4.Value.X, point4.Value.Y);
                            num2 = 248;
                            ADBHelper.Tap(text5, point4.Value.X, point4.Value.Y);
                            num2 = 249;
                            ADBHelper.Tap(text5, point4.Value.X, point4.Value.Y);
                            num2 = 251;
                            fileStream5.Close();
                            num2 = 252;
                            fileStream6.Close();
                            num2 = 271;
                            delay(10);
                            num2 = 272;
                            ADBHelper.ExecuteCMD("adb -s " + text5 + " shell screencap /mnt/sdcard/Download/manhinh3.png");
                            num2 = 273;
                            ADBHelper.ExecuteCMD("adb  -s " + text5 + " pull /mnt/sdcard/Download/manhinh3.png manhinh3.png");
                            num2 = 274;
                            FileStream fileStream7 = new FileStream(Application.StartupPath + "\\sources\\Data\\hoanthanh.png", FileMode.Open, FileAccess.Read);
                            num2 = 275;
                            FileStream fileStream8 = new FileStream("\\source\\manhinh3.png", FileMode.Open, FileAccess.Read);
                            num2 = 276;
                            Bitmap subBitmap5 = (Bitmap)Image.FromStream(fileStream7);
                            num2 = 277;
                            Bitmap mainBitmap5 = (Bitmap)Image.FromStream(fileStream8);
                            num2 = 278;
                            Point? point5 = ImageScanOpenCV.FindOutPoint(mainBitmap5, subBitmap5);
                            num2 = 279;
                            bool flag3 = false;
                            num2 = 297;
                            ADBHelper.Tap(text5, point5.Value.X, point5.Value.Y);
                            num2 = 298;
                            txtaddtaikhoan2.Text = txtmail.Text + "|" + txtmatkhau2.Text;
                            num2 = 300;
                            fileStream8.Close();
                            num2 = 301;
                            fileStream7.Close();
                            num2 = 302;
                            chromeDriver.Quit();
                            goto IL_1607;
                        }
                        ProjectData.ClearProjectError();
                        num = -4;
                        num2 = 255;
                        MyProject.Forms.thongbao.Close();
                        num2 = 256;
                        lblsttloi2.Visible = true;
                        num2 = 257;
                        lblsttok2.Text = "LỖI KHÔNG TẠO DƯỢC";
                        num2 = 258;
                        lblsttok2.ForeColor = Color.Red;
                        num2 = 259;
                        btndunglai2.Enabled = true;
                        num2 = 260;
                        lblstt5456.Visible = true;
                        num2 = 261;
                        lblxacnhan.Text = Conversions.ToString(0);
                        num2 = 262;
                        btnhoanthanh.PerformClick();
                        num2 = 263;
                        Timer5.Start();
                        num2 = 264;
                        lblstt2456.Visible = true;
                        num2 = 265;
                        LBLSTT1456.Visible = false;
                        num2 = 266;
                        lbltime3.Visible = true;
                        num2 = 267;
                        lblstt2456.Visible = false;
                        num2 = 268;
                        base.Visible = true;
                    }
                    goto end_IL_0001;
                IL_1607:
                    num2 = 304;
                    ChromeDriver chromeDriver2 = new ChromeDriver(chromeDriverService, chromeOptions2);
                    num2 = 305;
                    chromeDriver2.Navigate().GoToUrl("https://facebook.com/reg/");
                    num2 = 306;
                    if (checkgialap2.Checked)
                    {
                        num2 = 307;
                        chromeDriver2.Navigate().GoToUrl("https://www.facebook.com/login");
                        num2 = 308;
                        IWebElement webElement5 = chromeDriver2.FindElement(By.XPath("//*[@id='email']"));
                        num2 = 309;
                        webElement5.SendKeys(txtmail.Text);
                        num2 = 310;
                        IWebElement webElement6 = chromeDriver2.FindElement(By.XPath("//*[@id='pass']"));
                        num2 = 311;
                        webElement6.SendKeys(txtmatkhau2.Text);
                        num2 = 312;
                        IWebElement webElement7 = chromeDriver2.FindElement(By.XPath("//*[@id='loginbutton']"));
                        num2 = 313;
                        webElement7.Click();
                        num2 = 314;
                        delay(5);
                    }
                    num2 = 316;
                    if (!checkgialap2.Checked)
                    {
                        num2 = 317;
                        if (checkcapcha2.Checked)
                        {
                            num2 = 318;
                            Random random3 = new Random();
                            num2 = 319;
                            string str6 = Conversions.ToString(random3.Next(10000, 90000));
                            num2 = 320;
                            string text10 = "vuotcpc" + str6 + "@gmail.com";
                            num2 = 321;
                            IWebElement webElement8 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_n']"));
                            num2 = 322;
                            webElement8.SendKeys("Nguyễn");
                            num2 = 323;
                            IWebElement webElement9 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_p']"));
                            num2 = 324;
                            webElement9.SendKeys("Thành");
                            num2 = 325;
                            IWebElement webElement10 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_s']"));
                            num2 = 326;
                            webElement10.SendKeys(text10);
                            num2 = 327;
                            Thread.Sleep(2000);
                            num2 = 328;
                            IWebElement webElement11 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_v']"));
                            num2 = 329;
                            webElement11.SendKeys(text10);
                            num2 = 330;
                            if (!checknam2.Checked)
                            {
                                num2 = 331;
                                IWebElement webElement12 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_10']/span[2]/label"));
                                num2 = 332;
                                webElement12.Click();
                            }
                            else
                            {
                                num2 = 334;
                                IWebElement webElement13 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_10']/span[1]/label"));
                                num2 = 335;
                                webElement13.Click();
                            }
                            num2 = 337;
                            IWebElement webElement14 = chromeDriver2.FindElement(By.XPath("//*[@id='year']/option[22]"));
                            num2 = 338;
                            webElement14.Click();
                            num2 = 339;
                            IWebElement webElement15 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_x']"));
                            num2 = 340;
                            webElement15.SendKeys("thanhcutequatroi");
                            num2 = 341;
                            IWebElement webElement16 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_14']"));
                            num2 = 342;
                            Thread.Sleep(5000);
                            num2 = 343;
                            webElement16.Click();
                            num2 = 344;
                            Thread.Sleep(7000);
                            num2 = 345;
                            IWebElement webElement17 = chromeDriver2.FindElement(By.XPath("//*[@id='checkpointSubmitButton']"));
                            num2 = 346;
                            webElement17.Click();
                            num2 = 347;
                            Thread.Sleep(3000);
                            num2 = 348;
                            chromeDriver2.Navigate().GoToUrl("https://facebook.com/reg/");
                            num2 = 349;
                            Thread.Sleep(4000);
                        }
                        num2 = 351;
                        IWebElement webElement18 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_n']"));
                        num2 = 352;
                        webElement18.SendKeys(TextBox2.Text);
                        num2 = 353;
                        IWebElement webElement19 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_p']"));
                        num2 = 354;
                        webElement19.SendKeys(TextBox3.Text);
                        num2 = 355;
                        IWebElement webElement20 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_s']"));
                        num2 = 356;
                        webElement20.SendKeys(txtmail.Text);
                        num2 = 357;
                        Thread.Sleep(2000);
                        num2 = 358;
                        IWebElement webElement21 = chromeDriver2.FindElement(By.XPath(" //*[@id='u_0_v']"));
                        num2 = 359;
                        webElement21.SendKeys(txtmail.Text);
                        num2 = 360;
                        if (!checknam2.Checked)
                        {
                            num2 = 361;
                            IWebElement webElement22 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_10']/span[2]/label"));
                            num2 = 362;
                            webElement22.Click();
                        }
                        else
                        {
                            num2 = 364;
                            IWebElement webElement23 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_10']/span[1]/label"));
                            num2 = 365;
                            webElement23.Click();
                        }
                        num2 = 367;
                        IWebElement webElement24 = chromeDriver2.FindElement(By.XPath("//*[@id='year']/option[22]"));
                        num2 = 368;
                        webElement24.Click();
                        num2 = 369;
                        IWebElement webElement25 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_x']"));
                        num2 = 370;
                        webElement25.SendKeys(txtmatkhau2.Text);
                        num2 = 371;
                        IWebElement webElement26 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_14']"));
                        num2 = 372;
                        Thread.Sleep(5000);
                        num2 = 373;
                        webElement26.Click();
                        num2 = 374;
                        Thread.Sleep(20000);
                        num2 = 375;
                        IWebElement webElement27 = chromeDriver2.FindElement(By.XPath("//*[@id='code_in_cliff']"));
                        num2 = 376;
                        webElement27.SendKeys("");
                        num2 = 377;
                        Thread.Sleep(30000);
                        num2 = 378;
                        chromeDriver.Navigate().GoToUrl("https://temp-mail.org/vi/");
                        num2 = 379;
                        Thread.Sleep(5000);
                        num2 = 380;
                        string text11 = chromeDriver.FindElement(By.XPath("/html/body/main/div[1]/div/div[2]/div[2]/div/div[1]/div/div[4]/ul/li[3]/div[2]/span/a")).Text;
                        num2 = 381;
                        text11 = Tachso(text11);
                        num2 = 382;
                        IWebElement webElement28 = chromeDriver2.FindElement(By.XPath("//*[@id='code_in_cliff']"));
                        num2 = 383;
                        Thread.Sleep(2000);
                        num2 = 384;
                        webElement28.SendKeys(text11);
                        num2 = 385;
                        TextBox4.Text = text11;
                        num2 = 386;
                        string pageSource = chromeDriver2.PageSource;
                        num2 = 387;
                        string text12 = "";
                        num2 = 388;
                        string value = Conversions.ToString(Strings.InStr(pageSource, "Tiếp tục") - 7);
                        num2 = 389;
                        Richnguon2.Text = pageSource;
                        num2 = 390;
                        int num5 = Conversions.ToInteger(value);
                        for (int i = num5; i <= 1000000000; i++)
                        {
                            num2 = 391;
                            lblkytu2.Text = Strings.Mid(pageSource, i, 1);
                            num2 = 392;
                            if (Operators.CompareString(lblkytu2.Text, ">", TextCompare: false) == 0)
                            {
                                num2 = 393;
                                i = 1000000000;
                                num2 = 394;
                                text12 = Strings.Mid(text12, 1, 5);
                            }
                            else
                            {
                                num2 = 396;
                                text12 += lblkytu2.Text;
                            }
                            num2 = 398;
                        }
                        num2 = 399;
                        txtaddtaikhoan2.Text = txtmail.Text + "|" + txtmatkhau2.Text;
                        num2 = 400;
                        IWebElement webElement29 = chromeDriver2.FindElement(By.Id(text12));
                        num2 = 401;
                        Thread.Sleep(5000);
                        num2 = 402;
                        webElement29.Click();
                        num2 = 403;
                        Thread.Sleep(10000);
                    }
                    num2 = 405;
                    if (Check2FA2.Checked)
                    {
                        num2 = 406;
                        ChromeOptions chromeOptions4 = new ChromeOptions();
                        num2 = 407;
                        chromeOptions4.AddArgument("--window-position=-32000,-32000");
                        num2 = 408;
                        ChromeDriver chromeDriver3 = new ChromeDriver(chromeDriverService, chromeOptions4);
                        num2 = 409;
                        chromeDriver3.Navigate().GoToUrl("https://gauth.apps.gbraad.nl/#main");
                        ProjectData.ClearProjectError();
                        num = 4;
                        num2 = 411;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/security/2fac/setup/intro/?ref=wizard");
                        num2 = 412;
                        Thread.Sleep(3000);
                        ProjectData.ClearProjectError();
                        num = 5;
                        num2 = 414;
                        IWebElement webElement30 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div/div/div/div[1]/div/table/tbody/tr/td[2]/div/div[3]/a"));
                        num2 = 415;
                        webElement30.Click();
                        num2 = 416;
                        Thread.Sleep(3000);
                        num2 = 417;
                        IWebElement webElement31 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/article/div[1]/div/input"));
                        num2 = 418;
                        Thread.Sleep(1000);
                        num2 = 419;
                        webElement31.SendKeys(txtmatkhau2.Text);
                        num2 = 420;
                        IWebElement webElement32 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/article/button"));
                        num2 = 421;
                        webElement32.Click();
                        num2 = 422;
                        Thread.Sleep(3000);
                        num2 = 423;
                        string text13 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/form/div[2]/div/table/tbody/tr/td/div/div[2]/div[2]")).Text;
                        num2 = 424;
                        Thread.Sleep(3000);
                        num2 = 425;
                        IWebElement webElement33 = chromeDriver2.FindElement(By.XPath("//*[@id='qr_confirm_button']"));
                        num2 = 426;
                        webElement33.Click();
                        num2 = 427;
                        IWebElement webElement34 = chromeDriver3.FindElement(By.XPath("//*[@id='edit']"));
                        num2 = 428;
                        webElement34.Click();
                        num2 = 429;
                        Thread.Sleep(1000);
                        num2 = 430;
                        IWebElement webElement35 = chromeDriver3.FindElement(By.XPath("//*[@id='accounts']/li[2]/p[2]/a"));
                        num2 = 431;
                        webElement35.Click();
                        num2 = 432;
                        Thread.Sleep(1000);
                        num2 = 433;
                        IWebElement webElement36 = chromeDriver3.FindElement(By.XPath("//*[@id='addButton']"));
                        num2 = 434;
                        webElement36.Click();
                        num2 = 435;
                        Thread.Sleep(1000);
                        num2 = 436;
                        IWebElement webElement37 = chromeDriver3.FindElement(By.XPath("//*[@id='keySecret']"));
                        num2 = 437;
                        webElement37.SendKeys(text13);
                        num2 = 438;
                        IWebElement webElement38 = chromeDriver3.FindElement(By.XPath("//*[@id='addKeyButton']"));
                        num2 = 439;
                        webElement38.Click();
                        num2 = 440;
                        Thread.Sleep(3000);
                        num2 = 441;
                        string text14 = chromeDriver3.FindElement(By.XPath("//*[@id='accounts']/li[2]/h3")).Text;
                        num2 = 442;
                        IWebElement webElement39 = chromeDriver2.FindElement(By.XPath("//*[@id='type_code_container']"));
                        num2 = 443;
                        webElement39.SendKeys(text14);
                        num2 = 444;
                        Thread.Sleep(2000);
                        num2 = 445;
                        IWebElement webElement40 = chromeDriver2.FindElement(By.XPath("//*[@id='submit_code_button']"));
                        num2 = 446;
                        webElement40.Click();
                        num2 = 447;
                        txtaddtaikhoan.Text = txtaddtaikhoan.Text + "|" + text13;
                        num2 = 448;
                        chromeDriver3.Quit();
                    }
                    num2 = 450;
                    chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/gettingstarted/?_rdr");
                    num2 = 451;
                    IWebElement webElement41 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/div[1]/table/tbody/tr/td[3]/a]"));
                    num2 = 452;
                    webElement41.Click();
                    num2 = 453;
                    if (checktoken2.Checked)
                    {
                        ProjectData.ClearProjectError();
                        num = 6;
                        num2 = 455;
                        chromeDriver2.Navigate().GoToUrl("https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed");
                        num2 = 456;
                        string pageSource2 = chromeDriver2.PageSource;
                        num2 = 457;
                        string text15 = "";
                        num2 = 458;
                        string value2 = Conversions.ToString(Strings.InStr(pageSource2, "EAAA"));
                        num2 = 459;
                        Richnguon.Text = pageSource2;
                        num2 = 460;
                        int num6 = Conversions.ToInteger(value2);
                        for (int j = num6; j <= 1000000000; j++)
                        {
                            num2 = 461;
                            lblkytu.Text = Strings.Mid(pageSource2, j, 1);
                            num2 = 462;
                            if (Operators.CompareString(lblkytu.Text, "\\", TextCompare: false) == 0)
                            {
                                num2 = 463;
                                j = 1000000000;
                            }
                            else
                            {
                                num2 = 465;
                                text15 += lblkytu.Text;
                            }
                            num2 = 467;
                        }
                        num2 = 468;
                        txtaddtaikhoan2.Text = txtaddtaikhoan2.Text + "|" + text15;
                    }
                    else
                    {
                        num2 = 470;
                        if (checkcookie2.Checked)
                        {
                            num2 = 471;
                            string requestUriString = "https://vnlike.net/cookie/get.php?u=" + txtmail.Text + "&p=" + txtmatkhau2.Text;
                            num2 = 472;
                            HttpWebResponse httpWebResponse = null;
                            num2 = 473;
                            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                            num2 = 474;
                            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            num2 = 475;
                            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                            num2 = 476;
                            string json = streamReader.ReadToEnd();
                            num2 = 477;
                            JObject jObject = JObject.Parse(json);
                            num2 = 478;
                            string text16 = (string?)jObject.SelectToken("cookie");
                            num2 = 479;
                            txtcookie2.Text = text16;
                            num2 = 480;
                            txtaddtaikhoan2.Text = txtaddtaikhoan2.Text + "|" + text16;
                        }
                    }
                    num2 = 483;
                    listtaikhoan2.Text = txtaddtaikhoan2.Text + Environment.NewLine + listtaikhoan2.Text;
                    num2 = 484;
                    if (checkhs2.Checked)
                    {
                        ProjectData.ClearProjectError();
                        num = 7;
                        num2 = 486;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/profile_picture/");
                        num2 = 487;
                        Thread.Sleep(3000);
                        num2 = 488;
                        IWebElement webElement42 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/li[1]/input"));
                        num2 = 489;
                        Thread.Sleep(3000);
                        num2 = 490;
                        Random random4 = new Random();
                        num2 = 491;
                        string str7 = Conversions.ToString(random4.Next(1, 51));
                        num2 = 492;
                        string text17 = Application.StartupPath + "\\sources\\Avata\\" + str7 + ".jpg";
                        num2 = 493;
                        webElement42.SendKeys(text17);
                        num2 = 494;
                        Thread.Sleep(3000);
                        num2 = 495;
                        IWebElement webElement43 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/li[2]/input"));
                        num2 = 496;
                        webElement43.Click();
                        num2 = 497;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/");
                        num2 = 498;
                        Thread.Sleep(10000);
                        ProjectData.ClearProjectError();
                        num = 8;
                        num2 = 500;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/settings/subscribe/?");
                        num2 = 501;
                        Thread.Sleep(3000);
                        num2 = 502;
                        IWebElement webElement44 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/div[1]/div[3]/div[1]/table/tbody/tr/td[2]/table/tbody/tr/td/div[1]/a"));
                        num2 = 503;
                        webElement44.Click();
                        num2 = 504;
                        Thread.Sleep(5000);
                        ProjectData.ClearProjectError();
                        num = 9;
                        num2 = 506;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/privacyx/selector/?redirect_uri=https%3A%2F%2Fmbasic.facebook.com%2Feditprofile.php%3Ftype%3Dbasic%26edit%3Dbirthday&content_id=8787510733&content_type=1&selected_param=275425949243301&autosave=1");
                        num2 = 507;
                        Thread.Sleep(3000);
                        num2 = 508;
                        IWebElement webElement45 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div[1]/table/tbody/tr/td[3]/a/img"));
                        num2 = 509;
                        webElement45.Click();
                        ProjectData.ClearProjectError();
                        num = 10;
                        num2 = 511;
                        Thread.Sleep(5000);
                        num2 = 512;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/privacyx/selector/?redirect_uri=https%3A%2F%2Fmbasic.facebook.com%2Feditprofile.php%3Ftype%3Dbasic%26edit%3Dbirthday&content_id=8787805733&content_type=1&selected_param=275425949243301&autosave=1");
                        num2 = 513;
                        Thread.Sleep(3000);
                        num2 = 514;
                        IWebElement webElement46 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div[1]/table/tbody/tr/td[3]/a/img"));
                        num2 = 515;
                        webElement46.Click();
                        ProjectData.ClearProjectError();
                        num = 11;
                        num2 = 517;
                        Thread.Sleep(5000);
                        num2 = 518;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/editprofile.php?type=basic&edit=gender");
                        num2 = 519;
                        Thread.Sleep(3000);
                        num2 = 520;
                        IWebElement webElement47 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/div[1]/form/table/tbody/tr[2]/td/table[2]/tbody/tr/td/label"));
                        num2 = 521;
                        webElement47.Click();
                        num2 = 522;
                        IWebElement webElement48 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/div[1]/form/input[5]"));
                        num2 = 523;
                        webElement48.Click();
                        ProjectData.ClearProjectError();
                        num = 12;
                        num2 = 525;
                        chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/profile/questions/view/");
                        num2 = 526;
                        Thread.Sleep(3000);
                        num2 = 527;
                        IWebElement webElement49 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 528;
                        webElement49.SendKeys("Thành Phố");
                        num2 = 529;
                        IWebElement webElement50 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 530;
                        webElement50.Click();
                        num2 = 531;
                        Thread.Sleep(2000);
                        num2 = 532;
                        IWebElement webElement51 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 533;
                        webElement51.Click();
                        num2 = 534;
                        Thread.Sleep(2000);
                        num2 = 535;
                        IWebElement webElement52 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 536;
                        webElement52.SendKeys("Thành Phố");
                        num2 = 537;
                        IWebElement webElement53 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 538;
                        webElement53.Click();
                        num2 = 539;
                        Thread.Sleep(2000);
                        num2 = 540;
                        IWebElement webElement54 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 541;
                        webElement54.Click();
                        num2 = 542;
                        Thread.Sleep(2000);
                        num2 = 543;
                        IWebElement webElement55 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 544;
                        webElement55.SendKeys("thpt");
                        num2 = 545;
                        IWebElement webElement56 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 546;
                        webElement56.Click();
                        num2 = 547;
                        Thread.Sleep(2000);
                        num2 = 548;
                        IWebElement webElement57 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 549;
                        webElement57.Click();
                        num2 = 550;
                        Thread.Sleep(2000);
                        num2 = 551;
                        IWebElement webElement58 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 552;
                        webElement58.SendKeys("HUTECH");
                        num2 = 553;
                        IWebElement webElement59 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 554;
                        webElement59.Click();
                        num2 = 555;
                        Thread.Sleep(2000);
                        num2 = 556;
                        IWebElement webElement60 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 557;
                        webElement60.Click();
                        num2 = 558;
                        Thread.Sleep(2000);
                        num2 = 559;
                        IWebElement webElement61 = chromeDriver2.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 560;
                        webElement61.Click();
                        num2 = 561;
                        Thread.Sleep(5000);
                    }
                    num2 = 563;
                    chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/" + txtsubid.Text);
                    num2 = 564;
                    Thread.Sleep(3000);
                    num2 = 565;
                    Richnguon.Text = chromeDriver2.PageSource;
                    num2 = 566;
                    int num7 = Strings.InStr(Richnguon.Text, "Thêm bạn bè");
                    num2 = 567;
                    if (num7 > 1)
                    {
                        num2 = 568;
                        if (checksubid.Checked)
                        {
                            ProjectData.ClearProjectError();
                            num = 13;
                            num2 = 570;
                            IWebElement webElement62 = chromeDriver2.FindElement(By.XPath("//*[@id='root']/div[1]/div[1]/div[3]/table/tbody/tr/td[1]/a"));
                            num2 = 571;
                            webElement62.Click();
                        }
                        else
                        {
                            num2 = 573;
                            if (Operators.CompareString(txtsubid.Text, "", TextCompare: false) == 0)
                            {
                                num2 = 574;
                                lblsttsubid.Visible = true;
                            }
                        }
                    }
                    num2 = 577;
                    chromeDriver2.Navigate().GoToUrl("https://mbasic.facebook.com/" + txtlikepage.Text);
                    num2 = 578;
                    Thread.Sleep(3000);
                    num2 = 579;
                    Richnguon.Text = chromeDriver2.PageSource;
                    num2 = 580;
                    int num8 = Strings.InStr(Richnguon.Text, "Thích");
                    num2 = 581;
                    if (num8 > 1)
                    {
                        num2 = 582;
                        if (checklikepage.Checked)
                        {
                            ProjectData.ClearProjectError();
                            num = 14;
                            num2 = 584;
                            IWebElement webElement63 = chromeDriver2.FindElement(By.XPath("//*[@id='sub_profile_pic_content']/div/div[2]/table/tbody/tr/td[1]/a"));
                            num2 = 585;
                            webElement63.Click();
                        }
                        else
                        {
                            num2 = 587;
                            if (Operators.CompareString(txtlikepage.Text, "", TextCompare: false) != 0)
                            {
                            }
                        }
                    }
                    num2 = 590;
                    StreamWriter streamWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath + "\\sources\\account\\nickthanhcong.txt", append: true);
                    num2 = 591;
                    streamWriter.WriteLine("\r\n" + txtaddtaikhoan2.Text);
                    num2 = 592;
                    streamWriter.Close();
                    num2 = 593;
                    lblsttsubid2.Visible = true;
                    num2 = 594;
                    lblsttok2.Visible = true;
                    num2 = 595;
                    sttchinh2.Visible = true;
                    num2 = 596;
                    chromeDriver2.Quit();
                    num2 = 597;
                    chromeDriver.Quit();
                    num2 = 598;
                    btndunglai2.Enabled = true;
                    num2 = 599;
                    lblsttloi2.Visible = false;
                    num2 = 600;
                    Timer5.Start();
                    num2 = 601;
                    lblstt456.Visible = true;
                    num2 = 602;
                    LBLSTT1456.Visible = false;
                    num2 = 603;
                    lbltime3456.Visible = true;
                    num2 = 604;
                    lblstt2456.Visible = false;
                    num2 = 605;
                    base.Visible = true;
                end_IL_0001:;
                }
                catch (Exception obj) when (unchecked(obj is Exception && num != 0 && num9 == 0))
                {
                    ProjectData.SetProjectError((Exception)obj);
                    /*Error near IL_397b: Could not find block for branch target IL_390f*/
                    ;
                }
                if (num9 != 0)
                {
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            Timer5.Interval = 1000;
            if (Conversions.ToDouble(lbltime3456.Text) == 30.0)
            {
                lbltime3456.Text = Conversions.ToString(Conversions.ToDouble(lbltime3456.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime3456.Text) == 1.0)
            {
                lblstt456.Visible = false;
                LBLSTT1456.Visible = true;
                lbltime3456.Visible = false;
                lblstt2456.Visible = false;
                lblstt5456.Visible = false;
                Timer5.Stop();
                lbltime3456.Text = Conversions.ToString(30);
                btnbatdau2.Enabled = true;
                lblstt5456.Text = "LỖI TẠO ACC";
                lblstt5456.Visible = false;
                btnbatdau2.PerformClick();
                btnbatdau2.Enabled = false;
                lblsttsubid2.Text = "SUB ID DONE";
                lblsttsubid2.ForeColor = Color.Blue;
                lblsttok2.Text = "TẠO NICK THÀNH CÔNG ";
                lblsttok2.ForeColor = Color.Lime;
            }
            else
            {
                lbltime3456.Text = Conversions.ToString(Conversions.ToDouble(lbltime3456.Text) - 1.0);
            }
        }

        private void btnsave2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.text";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, listtaikhoan2.Text);
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Versioned.IsNumeric(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        [Obsolete]
        private void btnbatdausub_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(lblxu.Text) < 2000.0)
            {
                Interaction.MsgBox("Số tiền không đủ vui lòng nạp thêm");
                return;
            }
            int num = 1;
            checked
            {
                do
                {
                    ChromeOptions chromeOptions = new ChromeOptions();
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;
                    ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService);
                    DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
                    desiredCapabilities.SetCapability("os_version", "13");
                    desiredCapabilities.SetCapability("device", "iPhone 11 Pro Max");
                    desiredCapabilities.SetCapability("real_mobile", "true");
                    desiredCapabilities.SetCapability("browserstack.local", "false");
                    desiredCapabilities.SetCapability("browserstack.user", "toolgame1");
                    desiredCapabilities.SetCapability("browserstack.key", "UfDBiYfYhLPfn6Sabk9Y");
                    desiredCapabilities.SetCapability("browserstack.networkLog", "true");
                    desiredCapabilities.SetCapability("name", "REG FB B E M M TEAM : VUI LONG KHONG TAT TRINH DUYET NAY ");
                    IWebDriver webDriver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), desiredCapabilities);
                    webDriver.Navigate().GoToUrl("https://accounts.google.com/signup/v2/webcreateaccount?continue=https%3A%2F%2Faccounts.google.com%2FManageAccount%3Fnc%3D1&dsh=S1963969507%3A1585723352072639&gmb=exp&biz=false&flowName=GlifWebSignIn&flowEntry=SignUp");
                    ChromeOptions chromeOptions2 = new ChromeOptions();
                    Timer10.Stop();
                    lbltime10.Text = Conversions.ToString(70);
                    string text = "";
                    string url = "https://" + MyProject.MySettingsProperty.Settings.usename + ":" + MyProject.MySettingsProperty.Settings.accesskey + "@api.browserstack.com/automate/builds.json";
                    chromeDriver.Navigate().GoToUrl(url);
                    string text2 = chromeDriver.FindElement(By.XPath("/html/body/pre")).Text;
                    string text3 = text2;
                    string text4 = "";
                    string value = Conversions.ToString(Strings.InStr(text3, "hashed_id") + 12);
                    int num2 = Conversions.ToInteger(value);
                    for (int i = num2; i <= 1000; i++)
                    {
                        lblkytu.Text = Strings.Mid(text3, i, 1);
                        if (Operators.CompareString(lblkytu.Text, "}", TextCompare: false) == 0)
                        {
                            i = 1000;
                            text4 = Strings.Mid(text4, 1, Strings.Len(text4) - 1);
                        }
                        else
                        {
                            text4 += lblkytu.Text;
                        }
                    }
                    string url2 = "https://" + MyProject.MySettingsProperty.Settings.usename + ":" + MyProject.MySettingsProperty.Settings.accesskey + "@api.browserstack.com/automate/builds/" + text4 + "/sessions.json";
                    chromeDriver.Navigate().GoToUrl(url2);
                    string text5 = chromeDriver.FindElement(By.XPath("/html/body/pre")).Text;
                    string text6 = text5;
                    string text7 = "";
                    string value2 = Conversions.ToString(Strings.InStr(text6, "hashed_id") + 12);
                    int num3 = Conversions.ToInteger(value2);
                    for (int j = num3; j <= 1000000000; j++)
                    {
                        lblkytu.Text = Strings.Mid(text6, j, 1);
                        if (Operators.CompareString(lblkytu.Text, ",", TextCompare: false) == 0)
                        {
                            j = 1000000000;
                            text7 = Strings.Mid(text7, 1, Strings.Len(text7) - 1);
                        }
                        else
                        {
                            text7 += lblkytu.Text;
                        }
                    }
                    string url3 = "https://" + MyProject.MySettingsProperty.Settings.usename + ":" + MyProject.MySettingsProperty.Settings.accesskey + "@api.browserstack.com/automate/sessions/" + text7 + ".json";
                    chromeDriver.Navigate().GoToUrl(url3);
                    string text8 = chromeDriver.FindElement(By.XPath("/html/body/pre")).Text;
                    string text9 = text8;
                    string text10 = "";
                    string value3 = Conversions.ToString(Strings.InStr(text9, "public_url") + 13);
                    int num4 = Conversions.ToInteger(value3);
                    for (int k = num4; k <= 1000000; k++)
                    {
                        lblkytu.Text = Strings.Mid(text9, k, 1);
                        if (Operators.CompareString(lblkytu.Text, ",", TextCompare: false) == 0)
                        {
                            k = 1000000;
                            text10 = Strings.Mid(text10, 1, Strings.Len(text10) - 1);
                        }
                        else
                        {
                            text10 += lblkytu.Text;
                        }
                    }
                    chromeDriver.Quit();
                    chromeOptions2.AddArguments("--app=" + text10);
                    ChromeDriver chromeDriver2 = new ChromeDriver(chromeDriverService, chromeOptions2);
                    IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='lastName']"));
                    webElement.SendKeys(TextBox2.Text);
                    num++;
                }
                while (num <= 10);
            }
        }

        private void btntienhanhtangsub_Click(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_0011, IL_0014, IL_0028, IL_004a
            int num = default(int);
            int num2 = default(int);
            try
            {
                Interaction.MsgBox("Tạm khóa");
            }
            catch (Exception obj) when (obj is Exception && num != 0 && num2 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_0048: Could not find block for branch target IL_0014*/
                ;
            }
            if (num2 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void Timer7_Tick(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_0567, IL_0768, IL_0771, IL_0781, IL_0795, IL_07a9, IL_07b9, IL_07c9, IL_07de, IL_07ed, IL_07fc, IL_080c, IL_081c, IL_082c, IL_083c, IL_0847, IL_084c, IL_10bd, IL_10c6, IL_10d9, IL_10f0, IL_1107, IL_111a, IL_112d, IL_1145, IL_1157, IL_1169, IL_117c, IL_118f, IL_11a2, IL_11b5, IL_11c3, IL_11c8, IL_1388, IL_1454, IL_1467, IL_147e, IL_1495, IL_14a8, IL_14bb, IL_14d3, IL_14e5, IL_14f7, IL_150a, IL_151d, IL_1530, IL_1543, IL_1551, IL_155a, IL_155f, IL_3022, IL_3023, IL_303f, IL_3056, IL_305c, IL_3078, IL_308f, IL_3092, IL_3093, IL_30ff, IL_3100, IL_3127, IL_3151, IL_315f, IL_3172, IL_3189, IL_31a0, IL_31b3, IL_31c6, IL_31de, IL_31f0, IL_3202, IL_3215, IL_3228, IL_323b, IL_324e, IL_325c, IL_326d, IL_3270, IL_3271, IL_327f, IL_3280, IL_3282, IL_32a1, IL_3d4f, IL_3d51, IL_3d58, IL_3d5b, IL_3d5c, IL_3da1, IL_3dc3
            checked
            {
                int num = default(int);
                int num9 = default(int);
                try
                {
                    ProjectData.ClearProjectError();
                    num = 2;
                    int num2 = 2;
                    Timer7.Interval = 1000;
                    num2 = 3;
                    if (Conversions.ToDouble(lbltime.Text) == 2.0)
                    {
                        num2 = 4;
                        string requestUriString = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                        num2 = 5;
                        HttpWebResponse httpWebResponse = null;
                        num2 = 6;
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                        num2 = 7;
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        num2 = 8;
                        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                        num2 = 9;
                        string text = streamReader.ReadToEnd();
                        num2 = 10;
                        rtverify.Text = text;
                        num2 = 11;
                        JObject jObject = JObject.Parse(text);
                        num2 = 12;
                        txttinnhanmain.Text = (string?)jObject.SelectToken("message");
                        num2 = 13;
                        txtsdt.Text = (string?)jObject.SelectToken("phoneNumber");
                        num2 = 14;
                        lbltime.Text = Conversions.ToString(Conversions.ToDouble(lbltime.Text) - 1.0);
                    }
                    else
                    {
                        num2 = 16;
                        if (Conversions.ToDouble(lbltime.Text) == 1.0)
                        {
                            num2 = 17;
                            lblgiohan.Text = Conversions.ToString(Conversions.ToDouble(lblgiohan.Text) + 1.0);
                            num2 = 18;
                            if (Operators.CompareString(txtsdt.Text, "null", TextCompare: false) == 0)
                            {
                                num2 = 19;
                                VIEWSDT.Visible = true;
                                num2 = 20;
                                txtsdt.Enabled = false;
                                num2 = 21;
                                loadingverify.Value = 0;
                                goto IL_3283;
                            }
                            num2 = 23;
                            if (Operators.CompareString(txtsdt.Text, "", TextCompare: false) == 0)
                            {
                                num2 = 24;
                                VIEWSDT.Visible = true;
                                num2 = 25;
                                txtsdt.Enabled = false;
                                num2 = 26;
                                loadingverify.Value = 0;
                                goto IL_3283;
                            }
                            num2 = 28;
                            if (!(Conversions.ToDouble(txtsdt.Text) > 1000.0))
                            {
                                goto IL_3283;
                            }
                            num2 = 29;
                            Timer10.Stop();
                            num2 = 30;
                            lbltime10.Text = Conversions.ToString(70);
                            num2 = 31;
                            txtsdt.Enabled = true;
                            num2 = 32;
                            VIEWSDT.Visible = false;
                            num2 = 33;
                            Timer7.Stop();
                            num2 = 34;
                            lbltime.Text = Conversions.ToString(2);
                            num2 = 35;
                            Timer1.Start();
                            num2 = 36;
                            btnthanhtoanverify.Text = "ĐANG CHỜ TIN NHẮN";
                            num2 = 37;
                            loadingverify.Value += 1;
                            num2 = 38;
                            base.Visible = false;
                            num2 = 39;
                            if (!checkgialap.Checked)
                            {
                                goto IL_15e2;
                            }
                            num2 = 40;
                            Random random = new Random();
                            num2 = 41;
                            int count = listhogialap.Items.Count;
                            num2 = 42;
                            object objectValue = RuntimeHelpers.GetObjectValue(listhogialap.Items[random.Next(count)]);
                            num2 = 43;
                            int count2 = listtengialap.Items.Count;
                            num2 = 44;
                            object objectValue2 = RuntimeHelpers.GetObjectValue(listtengialap.Items[random.Next(count2)]);
                            num2 = 45;
                            string str = objectValue2.ToString();
                            num2 = 46;
                            string str2 = objectValue.ToString();
                            num2 = 47;
                            str = "'" + str + "'";
                            num2 = 48;
                            str2 = "'" + str2 + "'";
                            num2 = 49;
                            string str3 = Strings.Replace(str2, " ", "%s");
                            num2 = 50;
                            string str4 = Strings.Replace(str, " ", "%s");
                            num2 = 51;
                            str4 = "'" + str4 + "'";
                            num2 = 52;
                            str3 = "'" + str3 + "'";
                            num2 = 53;
                            GETID();
                            num2 = 54;
                            if (Operators.CompareString(txtidgialap.Text, "", TextCompare: false) == 0)
                            {
                                num2 = 55;
                                lblsttloi.Visible = true;
                                num2 = 56;
                                lblsttok.Text = "Lỗi không vào được facebook";
                                num2 = 57;
                                lblsttok.ForeColor = Color.Red;
                                num2 = 58;
                                btndunglai.Enabled = true;
                                num2 = 59;
                                lblstt5.Visible = true;
                                num2 = 60;
                                lblxacnhan.Text = Conversions.ToString(0);
                                num2 = 61;
                                btnhoanthanh.PerformClick();
                                num2 = 62;
                                Timer3.Start();
                                num2 = 63;
                                lblstt.Visible = true;
                                num2 = 64;
                                LBLSTT1.Visible = false;
                                num2 = 65;
                                lbltime3.Visible = true;
                                num2 = 66;
                                lblstt2.Visible = false;
                                num2 = 67;
                                base.Visible = true;
                                num2 = 68;
                                Interaction.MsgBox("Không tìm được giả lập");
                            }
                            else
                            {
                                num2 = 71;
                                string text2 = txtidgialap.Text;
                                num2 = 72;
                                ADBHelper.ExecuteCMD("adb -s " + text2 + " shell input keyevent 3 & adb -s " + text2 + " shell pm clear com.facebook.lite & adb -s " + text2 + " shell pm clear com.android.browser && exit");
                                num2 = 73;
                                delay(6);
                                num2 = 74;
                                ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh.png");
                                num2 = 75;
                                ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh.png manhinh.png");
                                num2 = 76;
                                FileStream fileStream = new FileStream(Application.StartupPath + "\\sources\\Data\\fblite.png", FileMode.Open, FileAccess.Read);
                                num2 = 77;
                                FileStream fileStream2 = new FileStream("\\source\\manhinh.png", FileMode.Open, FileAccess.Read);
                                num2 = 78;
                                Bitmap subBitmap = (Bitmap)Image.FromStream(fileStream);
                                num2 = 79;
                                Bitmap mainBitmap = (Bitmap)Image.FromStream(fileStream2);
                                num2 = 80;
                                Point? point = ImageScanOpenCV.FindOutPoint(mainBitmap, subBitmap);
                                num2 = 81;
                                Bitmap bitmap = ImageScanOpenCV.Find(mainBitmap, subBitmap);
                                num2 = 82;
                                ADBHelper.Tap(text2, point.Value.X, point.Value.Y);
                                num2 = 83;
                                fileStream.Close();
                                num2 = 84;
                                fileStream2.Close();
                                num2 = 85;
                                delay(20);
                                num2 = 86;
                                ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh4.png");
                                num2 = 87;
                                ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh4.png manhinh4.png");
                                num2 = 88;
                                FileStream fileStream3 = new FileStream(Application.StartupPath + "\\sources\\Data\\regok.png", FileMode.Open, FileAccess.Read);
                                num2 = 89;
                                FileStream fileStream4 = new FileStream("\\source\\manhinh4.png", FileMode.Open, FileAccess.Read);
                                num2 = 90;
                                Bitmap subBitmap2 = (Bitmap)Image.FromStream(fileStream3);
                                num2 = 91;
                                Bitmap mainBitmap2 = (Bitmap)Image.FromStream(fileStream4);
                                num2 = 92;
                                Point? point2 = ImageScanOpenCV.FindOutPoint(mainBitmap2, subBitmap2);
                                num2 = 93;
                                bool flag = false;
                                num2 = 110;
                                ADBHelper.Tap(text2, point2.Value.X, point2.Value.Y);
                                num2 = 112;
                                fileStream3.Close();
                                num2 = 113;
                                fileStream4.Close();
                                num2 = 114;
                                delay(10);
                                num2 = 115;
                                ADBHelper.Tap(text2, 204, 279);
                                num2 = 116;
                                delay(3);
                                num2 = 117;
                                ADBHelper.InputText(text2, str3);
                                num2 = 118;
                                delay(3);
                                num2 = 119;
                                ADBHelper.Tap(text2, 268, 149);
                                num2 = 120;
                                delay(3);
                                num2 = 121;
                                ADBHelper.InputText(text2, str4);
                                num2 = 122;
                                delay(5);
                                num2 = 123;
                                ADBHelper.Tap(text2, 203, 185);
                                num2 = 124;
                                delay(7);
                                num2 = 125;
                                ADBHelper.Tap(text2, 297, 162);
                                num2 = 126;
                                short num3 = 1;
                                do
                                {
                                    num2 = 127;
                                    ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_DEL);
                                    num2 = 128;
                                    num3 = (short)unchecked(num3 + 1);
                                }
                                while (num3 <= 15);
                                num2 = 129;
                                delay(7);
                                num2 = 130;
                                short num4 = 1;
                                do
                                {
                                    num2 = 131;
                                    string value = Strings.Mid(txtsdt.Text, num4, 1);
                                    num2 = 132;
                                    if (Conversions.ToDouble(value) == 0.0)
                                    {
                                        num2 = 133;
                                        ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_0);
                                    }
                                    else
                                    {
                                        num2 = 135;
                                        if (Conversions.ToDouble(value) == 1.0)
                                        {
                                            num2 = 136;
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_1);
                                        }
                                        else
                                        {
                                            num2 = 138;
                                            if (Conversions.ToDouble(value) == 2.0)
                                            {
                                                num2 = 139;
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_2);
                                            }
                                            else
                                            {
                                                num2 = 141;
                                                if (Conversions.ToDouble(value) == 3.0)
                                                {
                                                    num2 = 142;
                                                    ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_3);
                                                }
                                                else
                                                {
                                                    num2 = 144;
                                                    if (Conversions.ToDouble(value) == 4.0)
                                                    {
                                                        num2 = 145;
                                                        ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_4);
                                                    }
                                                    else
                                                    {
                                                        num2 = 147;
                                                        if (Conversions.ToDouble(value) == 5.0)
                                                        {
                                                            num2 = 148;
                                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_5);
                                                        }
                                                        else
                                                        {
                                                            num2 = 150;
                                                            if (Conversions.ToDouble(value) == 6.0)
                                                            {
                                                                num2 = 151;
                                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_6);
                                                            }
                                                            else
                                                            {
                                                                num2 = 153;
                                                                if (Conversions.ToDouble(value) == 7.0)
                                                                {
                                                                    num2 = 154;
                                                                    ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_7);
                                                                }
                                                                else
                                                                {
                                                                    num2 = 156;
                                                                    if (Conversions.ToDouble(value) == 8.0)
                                                                    {
                                                                        num2 = 157;
                                                                        ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_8);
                                                                    }
                                                                    else
                                                                    {
                                                                        num2 = 159;
                                                                        if (Conversions.ToDouble(value) == 9.0)
                                                                        {
                                                                            num2 = 160;
                                                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_9);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    num2 = 162;
                                    num4 = (short)unchecked(num4 + 1);
                                }
                                while (num4 <= 10);
                                num2 = 163;
                                delay(3);
                                num2 = 164;
                                ADBHelper.Tap(text2, 200, 196);
                                num2 = 165;
                                delay(3);
                                num2 = 166;
                                ADBHelper.Tap(text2, 86, 169);
                                num2 = 167;
                                ADBHelper.Tap(text2, 203, 567);
                                num2 = 168;
                                ADBHelper.Tap(text2, 200, 681);
                                num2 = 169;
                                ADBHelper.Tap(text2, 200, 681);
                                num2 = 170;
                                ADBHelper.Tap(text2, 200, 681);
                                num2 = 171;
                                delay(2);
                                num2 = 172;
                                ADBHelper.Tap(text2, 200, 209);
                                num2 = 173;
                                delay(4);
                                num2 = 174;
                                if (checknam.Checked)
                                {
                                    num2 = 175;
                                    ADBHelper.Tap(text2, 384, 179);
                                }
                                else
                                {
                                    num2 = 177;
                                    ADBHelper.Tap(text2, 385, 148);
                                }
                                num2 = 179;
                                delay(4);
                                num2 = 180;
                                SENDTEXT(text2, txtmatkhau.Text);
                                num2 = 181;
                                delay(2);
                                num2 = 182;
                                ADBHelper.Tap(text2, 204, 243);
                                num2 = 183;
                                delay(10);
                                num2 = 184;
                                ADBHelper.Tap(text2, 97, 679);
                                num2 = 185;
                                delay(2);
                                num2 = 186;
                                ADBHelper.Tap(text2, 319, 221);
                                num2 = 187;
                                delay(2);
                                num2 = 188;
                                ADBHelper.Tap(text2, 154, 408);
                                num2 = 189;
                                delay(2);
                                num2 = 190;
                                ADBHelper.Tap(text2, 198, 395);
                                num2 = 191;
                                Thread.Sleep(30000);
                                num2 = 192;
                                string requestUriString2 = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                                num2 = 193;
                                HttpWebResponse httpWebResponse2 = null;
                                num2 = 194;
                                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString2);
                                num2 = 195;
                                httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                                num2 = 196;
                                StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream());
                                num2 = 197;
                                string text3 = streamReader2.ReadToEnd();
                                num2 = 198;
                                rtverify.Text = text3;
                                num2 = 199;
                                JObject jObject2 = JObject.Parse(text3);
                                num2 = 200;
                                string text4 = (string?)jObject2.SelectToken("message");
                                num2 = 201;
                                if (Strings.Len(text4) > 6)
                                {
                                    num2 = 202;
                                    string str5 = Tachso(text4);
                                    num2 = 203;
                                    str5 = Strings.Mid(str5, 1, 5);
                                    num2 = 204;
                                    ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh1.png");
                                    num2 = 205;
                                    ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh1.png manhinh1.png");
                                    num2 = 206;
                                    FileStream fileStream5 = new FileStream(Application.StartupPath + "\\sources\\Data\\code.png", FileMode.Open, FileAccess.Read);
                                    num2 = 207;
                                    FileStream fileStream6 = new FileStream("\\source\\manhinh1.png", FileMode.Open, FileAccess.Read);
                                    num2 = 208;
                                    Bitmap subBitmap3 = (Bitmap)Image.FromStream(fileStream5);
                                    num2 = 209;
                                    Bitmap mainBitmap3 = (Bitmap)Image.FromStream(fileStream6);
                                    num2 = 210;
                                    Point? point3 = ImageScanOpenCV.FindOutPoint(mainBitmap3, subBitmap3);
                                    num2 = 211;
                                    ADBHelper.Tap(text2, 48, 430);
                                    num2 = 212;
                                    ADBHelper.Tap(text2, point3.Value.X + 10, point3.Value.Y + 10);
                                    num2 = 213;
                                    fileStream5.Close();
                                    num2 = 214;
                                    fileStream6.Close();
                                    num2 = 215;
                                    delay(2);
                                    num2 = 216;
                                    ADBHelper.InputText(text2, str5);
                                    num2 = 217;
                                    string text5 = ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh2.png");
                                    num2 = 218;
                                    string text6 = ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh2.png manhinh2.png");
                                    num2 = 219;
                                    FileStream fileStream7 = new FileStream(Application.StartupPath + "\\sources\\Data\\ok.png", FileMode.Open, FileAccess.Read);
                                    num2 = 220;
                                    FileStream fileStream8 = new FileStream("\\source\\manhinh2.png", FileMode.Open, FileAccess.Read);
                                    num2 = 221;
                                    delay(2);
                                    num2 = 222;
                                    Bitmap subBitmap4 = (Bitmap)Image.FromStream(fileStream7);
                                    num2 = 223;
                                    Bitmap mainBitmap4 = (Bitmap)Image.FromStream(fileStream8);
                                    num2 = 224;
                                    Point? point4 = ImageScanOpenCV.FindOutPoint(mainBitmap4, subBitmap4);
                                    num2 = 225;
                                    bool flag2 = false;
                                    num2 = 242;
                                    ADBHelper.Tap(text2, point4.Value.X, point4.Value.Y);
                                    num2 = 243;
                                    ADBHelper.Tap(text2, point4.Value.X, point4.Value.Y);
                                    num2 = 244;
                                    ADBHelper.Tap(text2, point4.Value.X, point4.Value.Y);
                                    num2 = 246;
                                    fileStream7.Close();
                                    num2 = 247;
                                    fileStream8.Close();
                                    num2 = 265;
                                    delay(10);
                                    num2 = 266;
                                    ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh3.png");
                                    num2 = 267;
                                    ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh3.png manhinh3.png");
                                    num2 = 268;
                                    FileStream fileStream9 = new FileStream(Application.StartupPath + "\\sources\\Data\\hoanthanh.png", FileMode.Open, FileAccess.Read);
                                    num2 = 269;
                                    FileStream fileStream10 = new FileStream("\\source\\manhinh3.png", FileMode.Open, FileAccess.Read);
                                    num2 = 270;
                                    Bitmap subBitmap5 = (Bitmap)Image.FromStream(fileStream9);
                                    num2 = 271;
                                    Bitmap mainBitmap5 = (Bitmap)Image.FromStream(fileStream10);
                                    num2 = 272;
                                    Point? point5 = ImageScanOpenCV.FindOutPoint(mainBitmap5, subBitmap5);
                                    num2 = 273;
                                    bool flag3 = false;
                                    num2 = 290;
                                    ADBHelper.Tap(text2, point5.Value.X, point5.Value.Y);
                                    num2 = 291;
                                    txtaddtaikhoan.Text = txtsdt.Text + "|" + txtmatkhau.Text;
                                    num2 = 293;
                                    fileStream10.Close();
                                    num2 = 294;
                                    fileStream9.Close();
                                    goto IL_15e2;
                                }
                                ProjectData.ClearProjectError();
                                num = -4;
                                num2 = 250;
                                lblsttloi.Visible = true;
                                num2 = 251;
                                lblsttok.Text = "LỖI KHÔNG TẠO DƯỢC";
                                num2 = 252;
                                lblsttok.ForeColor = Color.Red;
                                num2 = 253;
                                btndunglai.Enabled = true;
                                num2 = 254;
                                lblstt5.Visible = true;
                                num2 = 255;
                                lblxacnhan.Text = Conversions.ToString(0);
                                num2 = 256;
                                btnhoanthanh.PerformClick();
                                num2 = 257;
                                Timer3.Start();
                                num2 = 258;
                                lblstt.Visible = true;
                                num2 = 259;
                                LBLSTT1.Visible = false;
                                num2 = 260;
                                lbltime3.Visible = true;
                                num2 = 261;
                                lblstt2.Visible = false;
                                num2 = 262;
                                base.Visible = true;
                            }
                        }
                    }
                    goto end_IL_0001;
                IL_15e2:
                    num2 = 296;
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    num2 = 297;
                    chromeDriverService.HideCommandPromptWindow = true;
                    num2 = 298;
                    ChromeOptions chromeOptions = new ChromeOptions();
                    num2 = 299;
                    chromeOptions.AddArguments("--disable-notifications");
                    num2 = 300;
                    chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
                    num2 = 301;
                    chromeOptions.AddArguments("profile.default_content_setting_values.images", Conversions.ToString(2));
                    num2 = 302;
                    chromeOptions.AddExcludedArgument("enable-automation");
                    num2 = 303;
                    chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                    num2 = 304;
                    ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                    num2 = 305;
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                    num2 = 306;
                    chromeOptions.AddArguments("--disable-notifications");
                    num2 = 307;
                    chromeDriver.Navigate().GoToUrl("https://facebook.com/reg/");
                    num2 = 308;
                    Timer10.Stop();
                    num2 = 309;
                    lbltime10.Text = Conversions.ToString(70);
                    num2 = 310;
                    string text7 = "";
                    num2 = 311;
                    if (checkcapcha.Checked)
                    {
                        num2 = 312;
                        Random random2 = new Random();
                        num2 = 313;
                        string str6 = Conversions.ToString(random2.Next(10000, 90000));
                        num2 = 314;
                        string text8 = "vuotcpc" + str6 + "@gmail.com";
                        num2 = 315;
                        IWebElement webElement = chromeDriver.FindElement(By.XPath("//*[@id='u_0_n']"));
                        num2 = 316;
                        webElement.SendKeys("Nguyễn");
                        num2 = 317;
                        delay(1);
                        num2 = 318;
                        IWebElement webElement2 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_p']"));
                        num2 = 319;
                        webElement2.SendKeys("Thành");
                        num2 = 320;
                        delay(1);
                        num2 = 321;
                        IWebElement webElement3 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_s']"));
                        num2 = 322;
                        webElement3.SendKeys(text8);
                        num2 = 323;
                        Thread.Sleep(2000);
                        num2 = 324;
                        IWebElement webElement4 = chromeDriver.FindElement(By.XPath(" //*[@id='u_0_v']"));
                        num2 = 325;
                        webElement4.SendKeys(text8);
                        num2 = 326;
                        delay(1);
                        num2 = 327;
                        if (!checknam.Checked)
                        {
                            num2 = 328;
                            IWebElement webElement5 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_10']/span[2]/label"));
                            num2 = 329;
                            webElement5.Click();
                            num2 = 330;
                            delay(1);
                        }
                        else
                        {
                            num2 = 332;
                            IWebElement webElement6 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_10']/span[1]/label"));
                            num2 = 333;
                            webElement6.Click();
                            num2 = 334;
                            delay(1);
                        }
                        num2 = 336;
                        IWebElement webElement7 = chromeDriver.FindElement(By.XPath("//*[@id='year']/option[22]"));
                        num2 = 337;
                        webElement7.Click();
                        num2 = 338;
                        delay(1);
                        num2 = 339;
                        IWebElement webElement8 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_x']"));
                        num2 = 340;
                        webElement8.SendKeys("thanhcutequatroi");
                        num2 = 341;
                        delay(3);
                        num2 = 342;
                        IWebElement webElement9 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_14']"));
                        num2 = 343;
                        Thread.Sleep(3000);
                        num2 = 344;
                        webElement9.Click();
                        num2 = 345;
                        Thread.Sleep(7000);
                        num2 = 346;
                        IWebElement webElement10 = chromeDriver.FindElement(By.XPath("//*[@id='checkpointSubmitButton']"));
                        num2 = 347;
                        webElement10.Click();
                        num2 = 348;
                        Thread.Sleep(3000);
                        num2 = 349;
                        chromeDriver.Navigate().GoToUrl("https://facebook.com/reg/");
                    }
                    num2 = 351;
                    string value2 = Conversions.ToString(0);
                    num2 = 352;
                    if (checkgialap.Checked)
                    {
                        num2 = 353;
                        if (Check2FA.Checked)
                        {
                            num2 = 354;
                            value2 = Conversions.ToString(1);
                        }
                        else
                        {
                            num2 = 356;
                            if (checkhs.Checked)
                            {
                                num2 = 357;
                                value2 = Conversions.ToString(1);
                            }
                            else
                            {
                                num2 = 359;
                                if (checktoken.Checked)
                                {
                                    num2 = 360;
                                    value2 = Conversions.ToString(1);
                                }
                                else
                                {
                                    num2 = 362;
                                    if (checkcookie.Checked)
                                    {
                                        num2 = 363;
                                        value2 = Conversions.ToString(1);
                                    }
                                    else
                                    {
                                        num2 = 365;
                                        value2 = Conversions.ToString(0);
                                    }
                                }
                            }
                        }
                    }
                    num2 = 368;
                    if (Conversions.ToDouble(value2) == 0.0)
                    {
                        num2 = 369;
                        IWebElement webElement11 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_n']"));
                        num2 = 370;
                        webElement11.SendKeys(TextBox2.Text);
                        num2 = 371;
                        IWebElement webElement12 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_p']"));
                        num2 = 372;
                        webElement12.SendKeys(TextBox3.Text);
                        num2 = 373;
                        IWebElement webElement13 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_s']"));
                        num2 = 374;
                        webElement13.SendKeys(txtsdt.Text);
                        num2 = 375;
                        if (checknam.Checked)
                        {
                            num2 = 376;
                            IWebElement webElement14 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_10']/span[2]/label"));
                            num2 = 377;
                            webElement14.Click();
                        }
                        else
                        {
                            num2 = 379;
                            IWebElement webElement15 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_10']/span[1]/label"));
                            num2 = 380;
                            webElement15.Click();
                        }
                        num2 = 382;
                        IWebElement webElement16 = chromeDriver.FindElement(By.XPath("//*[@id='year']/option[22]"));
                        num2 = 383;
                        webElement16.Click();
                        num2 = 384;
                        IWebElement webElement17 = chromeDriver.FindElement(By.XPath("//*[@id='day']/option[9]"));
                        num2 = 385;
                        webElement17.Click();
                        num2 = 386;
                        IWebElement webElement18 = chromeDriver.FindElement(By.XPath("//*[@id='month']/option[13]"));
                        num2 = 387;
                        webElement18.Click();
                        num2 = 388;
                        IWebElement webElement19 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_x']"));
                        num2 = 389;
                        webElement19.SendKeys(txtmatkhau.Text);
                        num2 = 390;
                        IWebElement webElement20 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_14']"));
                        num2 = 391;
                        Thread.Sleep(10000);
                        num2 = 392;
                        webElement20.Click();
                        num2 = 393;
                        Thread.Sleep(10000);
                        num2 = 394;
                        IWebElement webElement21 = chromeDriver.FindElement(By.XPath("//*[@id='code_in_cliff']"));
                        num2 = 395;
                        webElement21.SendKeys("");
                        num2 = 396;
                        Thread.Sleep(30000);
                        num2 = 397;
                        text7 = Tachso(txttinnhantaoclone.Text);
                        num2 = 398;
                        string requestUriString3 = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                        num2 = 399;
                        HttpWebResponse httpWebResponse3 = null;
                        num2 = 400;
                        HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(requestUriString3);
                        num2 = 401;
                        httpWebResponse3 = (HttpWebResponse)httpWebRequest3.GetResponse();
                        num2 = 402;
                        StreamReader streamReader3 = new StreamReader(httpWebResponse3.GetResponseStream());
                        num2 = 403;
                        string text9 = streamReader3.ReadToEnd();
                        num2 = 404;
                        rtverify.Text = text9;
                        num2 = 405;
                        JObject jObject3 = JObject.Parse(text9);
                        num2 = 406;
                        string x = (string?)jObject3.SelectToken("message");
                        num2 = 407;
                        text7 = Tachso(x);
                        num2 = 408;
                        IWebElement webElement22 = chromeDriver.FindElement(By.XPath("//*[@id='code_in_cliff']"));
                        num2 = 409;
                        webElement22.SendKeys(text7);
                        num2 = 410;
                        TextBox4.Text = text7;
                        num2 = 411;
                        string pageSource = chromeDriver.PageSource;
                        num2 = 412;
                        string text10 = "";
                        num2 = 413;
                        string text11 = Conversions.ToString(Strings.InStr(pageSource, "Tiếp tục") - 7);
                        num2 = 414;
                        if (Conversions.ToDouble(text11) == 0.0)
                        {
                            num2 = 415;
                            text11 = Conversions.ToString(Strings.InStr(pageSource, ">Continue<") - 6);
                        }
                        else
                        {
                            num2 = 417;
                            if (Operators.CompareString(text11, "", TextCompare: false) == 0)
                            {
                                num2 = 418;
                                text11 = Conversions.ToString(Strings.InStr(pageSource, ">Continue<") - 6);
                            }
                        }
                        num2 = 420;
                        Richnguon.Text = pageSource;
                        num2 = 421;
                        int num5 = Conversions.ToInteger(text11);
                        for (int i = num5; i <= 1000000000; i++)
                        {
                            num2 = 422;
                            lblkytu.Text = Strings.Mid(pageSource, i, 1);
                            num2 = 423;
                            if (Operators.CompareString(lblkytu.Text, ">", TextCompare: false) == 0)
                            {
                                num2 = 424;
                                i = 1000000000;
                                num2 = 425;
                                text10 = Strings.Mid(text10, 1, 5);
                            }
                            else
                            {
                                num2 = 427;
                                text10 += lblkytu.Text;
                            }
                            num2 = 429;
                        }
                        num2 = 430;
                        IWebElement webElement23 = chromeDriver.FindElement(By.Id(text10));
                        num2 = 431;
                        Thread.Sleep(2000);
                        num2 = 432;
                        webElement23.Click();
                        num2 = 433;
                        txtaddtaikhoan.Text = txtsdt.Text + "|" + txtmatkhau.Text;
                        num2 = 434;
                        loadingtaofbverify.Value = 0;
                        num2 = 435;
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        num2 = 437;
                        chromeDriver.Navigate().GoToUrl("https://www.facebook.com/login");
                        num2 = 438;
                        IWebElement webElement24 = chromeDriver.FindElement(By.XPath("//*[@id='email']"));
                        num2 = 439;
                        webElement24.SendKeys(txtsdt.Text);
                        num2 = 440;
                        IWebElement webElement25 = chromeDriver.FindElement(By.XPath("//*[@id='pass']"));
                        num2 = 441;
                        delay(3);
                        num2 = 442;
                        webElement25.SendKeys(txtmatkhau.Text);
                        num2 = 443;
                        IWebElement webElement26 = chromeDriver.FindElement(By.XPath("//*[@id='loginbutton']"));
                        num2 = 444;
                        webElement26.Click();
                        num2 = 445;
                        delay(10);
                    }
                    num2 = 447;
                    if (Check2FA.Checked)
                    {
                        num2 = 448;
                        ChromeOptions chromeOptions2 = new ChromeOptions();
                        num2 = 449;
                        chromeOptions2.AddArgument("--window-position=-32000,-32000");
                        num2 = 450;
                        ChromeDriver chromeDriver2 = new ChromeDriver(chromeDriverService, chromeOptions2);
                        num2 = 451;
                        chromeDriver2.Navigate().GoToUrl("https://gauth.apps.gbraad.nl/#main");
                        ProjectData.ClearProjectError();
                        num = 3;
                        num2 = 453;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/security/2fac/setup/intro/?ref=wizard");
                        num2 = 454;
                        Thread.Sleep(3000);
                        ProjectData.ClearProjectError();
                        num = 4;
                        num2 = 456;
                        IWebElement webElement27 = chromeDriver.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div/div/div/div[1]/div/table/tbody/tr/td[2]/div/div[3]/a"));
                        num2 = 457;
                        webElement27.Click();
                        num2 = 458;
                        Thread.Sleep(3000);
                        num2 = 459;
                        IWebElement webElement28 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/article/div[1]/div/input"));
                        num2 = 460;
                        Thread.Sleep(1000);
                        num2 = 461;
                        webElement28.SendKeys(txtmatkhau.Text);
                        num2 = 462;
                        IWebElement webElement29 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/article/button"));
                        num2 = 463;
                        webElement29.Click();
                        num2 = 464;
                        Thread.Sleep(3000);
                        ProjectData.ClearProjectError();
                        num = 5;
                        num2 = 466;
                        string text12 = chromeDriver.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/form/div[2]/div/table/tbody/tr/td/div/div[2]/div[2]")).Text;
                        num2 = 467;
                        Thread.Sleep(3000);
                        num2 = 468;
                        IWebElement webElement30 = chromeDriver.FindElement(By.XPath("//*[@id='qr_confirm_button']"));
                        num2 = 469;
                        webElement30.Click();
                        num2 = 470;
                        IWebElement webElement31 = chromeDriver2.FindElement(By.XPath("//*[@id='edit']"));
                        num2 = 471;
                        webElement31.Click();
                        num2 = 472;
                        Thread.Sleep(1000);
                        num2 = 473;
                        IWebElement webElement32 = chromeDriver2.FindElement(By.XPath("//*[@id='accounts']/li[2]/p[2]/a"));
                        num2 = 474;
                        webElement32.Click();
                        num2 = 475;
                        Thread.Sleep(1000);
                        num2 = 476;
                        IWebElement webElement33 = chromeDriver2.FindElement(By.XPath("//*[@id='addButton']"));
                        num2 = 477;
                        webElement33.Click();
                        num2 = 478;
                        Thread.Sleep(1000);
                        num2 = 479;
                        IWebElement webElement34 = chromeDriver2.FindElement(By.XPath("//*[@id='keySecret']"));
                        num2 = 480;
                        webElement34.SendKeys(text12);
                        num2 = 481;
                        IWebElement webElement35 = chromeDriver2.FindElement(By.XPath("//*[@id='addKeyButton']"));
                        num2 = 482;
                        webElement35.Click();
                        num2 = 483;
                        Thread.Sleep(3000);
                        num2 = 484;
                        string text13 = chromeDriver2.FindElement(By.XPath("//*[@id='accounts']/li[2]/h3")).Text;
                        num2 = 485;
                        IWebElement webElement36 = chromeDriver.FindElement(By.XPath("//*[@id='type_code_container']"));
                        num2 = 486;
                        webElement36.SendKeys(text13);
                        num2 = 487;
                        Thread.Sleep(2000);
                        num2 = 488;
                        IWebElement webElement37 = chromeDriver.FindElement(By.XPath("//*[@id='submit_code_button']"));
                        num2 = 489;
                        webElement37.Click();
                        num2 = 490;
                        txtaddtaikhoan.Text = txtaddtaikhoan.Text + "|" + text12;
                        num2 = 491;
                        chromeDriver2.Quit();
                    }
                    num2 = 493;
                    if (checktoken.Checked)
                    {
                        ProjectData.ClearProjectError();
                        num = 6;
                        num2 = 495;
                        chromeDriver.Navigate().GoToUrl("https://m.facebook.com/composer/ocelot/async_loader/?publisher=feed");
                        num2 = 496;
                        string pageSource2 = chromeDriver.PageSource;
                        num2 = 497;
                        string text14 = "";
                        num2 = 498;
                        string value3 = Conversions.ToString(Strings.InStr(pageSource2, "EAAA"));
                        num2 = 499;
                        Richnguon.Text = pageSource2;
                        num2 = 500;
                        int num6 = Conversions.ToInteger(value3);
                        for (int j = num6; j <= 1000000000; j++)
                        {
                            num2 = 501;
                            lblkytu.Text = Strings.Mid(pageSource2, j, 1);
                            num2 = 502;
                            if (Operators.CompareString(lblkytu.Text, "\\", TextCompare: false) == 0)
                            {
                                num2 = 503;
                                j = 1000000000;
                            }
                            else
                            {
                                num2 = 505;
                                text14 += lblkytu.Text;
                            }
                            num2 = 507;
                        }
                        num2 = 508;
                        txtaddtaikhoan.Text = txtaddtaikhoan.Text + "|" + text14;
                    }
                    else
                    {
                        num2 = 510;
                        if (checkcookie.Checked)
                        {
                            ProjectData.ClearProjectError();
                            num = 7;
                            num2 = 512;
                            string requestUriString4 = "https://vnlike.net/cookie/get.php?u=" + txtsdt.Text + "&p=" + txtmatkhau.Text;
                            num2 = 513;
                            HttpWebResponse httpWebResponse4 = null;
                            num2 = 514;
                            HttpWebRequest httpWebRequest4 = (HttpWebRequest)WebRequest.Create(requestUriString4);
                            num2 = 515;
                            httpWebResponse4 = (HttpWebResponse)httpWebRequest4.GetResponse();
                            num2 = 516;
                            StreamReader streamReader4 = new StreamReader(httpWebResponse4.GetResponseStream());
                            num2 = 517;
                            string json = streamReader4.ReadToEnd();
                            num2 = 518;
                            JObject jObject4 = JObject.Parse(json);
                            num2 = 519;
                            string text15 = (string?)jObject4.SelectToken("cookie");
                            num2 = 520;
                            txtcookie.Text = text15;
                            num2 = 521;
                            txtaddtaikhoan.Text = txtaddtaikhoan.Text + "|" + text15;
                        }
                    }
                    num2 = 524;
                    listtaikhoan.Text = txtaddtaikhoan.Text + Environment.NewLine + listtaikhoan.Text;
                    num2 = 525;
                    if (checkhs.Checked)
                    {
                        ProjectData.ClearProjectError();
                        num = 8;
                        num2 = 527;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/profile_picture/");
                        num2 = 528;
                        Thread.Sleep(3000);
                        num2 = 529;
                        IWebElement webElement38 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/li[1]/input"));
                        num2 = 530;
                        Thread.Sleep(3000);
                        num2 = 531;
                        Random random3 = new Random();
                        num2 = 532;
                        string str7 = Conversions.ToString(random3.Next(1, 51));
                        num2 = 533;
                        string text16 = Application.StartupPath + "\\Avata\\" + str7 + ".jpg";
                        num2 = 534;
                        webElement38.SendKeys(text16);
                        num2 = 535;
                        Thread.Sleep(3000);
                        num2 = 536;
                        IWebElement webElement39 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/li[2]/input"));
                        num2 = 537;
                        webElement39.Click();
                        num2 = 538;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/");
                        num2 = 539;
                        Thread.Sleep(10000);
                        ProjectData.ClearProjectError();
                        num = 9;
                        num2 = 541;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/settings/subscribe/?");
                        num2 = 542;
                        Thread.Sleep(3000);
                        num2 = 543;
                        IWebElement webElement40 = chromeDriver.FindElement(By.XPath("//*[@id='root']/div[1]/div[3]/div[1]/table/tbody/tr/td[2]/table/tbody/tr/td/div[1]/a"));
                        num2 = 544;
                        webElement40.Click();
                        num2 = 545;
                        Thread.Sleep(5000);
                        ProjectData.ClearProjectError();
                        num = 10;
                        num2 = 547;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/privacyx/selector/?redirect_uri=https%3A%2F%2Fmbasic.facebook.com%2Feditprofile.php%3Ftype%3Dbasic%26edit%3Dbirthday&content_id=8787510733&content_type=1&selected_param=275425949243301&autosave=1");
                        num2 = 548;
                        Thread.Sleep(3000);
                        num2 = 549;
                        IWebElement webElement41 = chromeDriver.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div[1]/table/tbody/tr/td[3]/a/img"));
                        num2 = 550;
                        webElement41.Click();
                        num2 = 551;
                        Thread.Sleep(5000);
                        ProjectData.ClearProjectError();
                        num = 11;
                        num2 = 553;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/privacyx/selector/?redirect_uri=https%3A%2F%2Fmbasic.facebook.com%2Feditprofile.php%3Ftype%3Dbasic%26edit%3Dbirthday&content_id=8787805733&content_type=1&selected_param=275425949243301&autosave=1");
                        num2 = 554;
                        Thread.Sleep(3000);
                        num2 = 555;
                        IWebElement webElement42 = chromeDriver.FindElement(By.XPath("//*[@id='root']/table/tbody/tr/td/div/div[1]/table/tbody/tr/td[3]/a/img"));
                        num2 = 556;
                        webElement42.Click();
                        num2 = 557;
                        Thread.Sleep(5000);
                        ProjectData.ClearProjectError();
                        num = 12;
                        num2 = 559;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/editprofile.php?type=basic&edit=gender");
                        num2 = 560;
                        Thread.Sleep(3000);
                        num2 = 561;
                        IWebElement webElement43 = chromeDriver.FindElement(By.XPath("//*[@id='root']/div[1]/form/table/tbody/tr[2]/td/table[2]/tbody/tr/td/label"));
                        num2 = 562;
                        webElement43.Click();
                        num2 = 563;
                        IWebElement webElement44 = chromeDriver.FindElement(By.XPath("//*[@id='root']/div[1]/form/input[5]"));
                        num2 = 564;
                        webElement44.Click();
                        ProjectData.ClearProjectError();
                        num = 13;
                        num2 = 566;
                        chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/profile/questions/view/");
                        num2 = 567;
                        Thread.Sleep(3000);
                        num2 = 568;
                        IWebElement webElement45 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 569;
                        webElement45.SendKeys("Thành Phố");
                        num2 = 570;
                        IWebElement webElement46 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 571;
                        webElement46.Click();
                        num2 = 572;
                        Thread.Sleep(2000);
                        num2 = 573;
                        IWebElement webElement47 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 574;
                        webElement47.Click();
                        num2 = 575;
                        Thread.Sleep(2000);
                        num2 = 576;
                        IWebElement webElement48 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 577;
                        webElement48.SendKeys("Thành Phố");
                        num2 = 578;
                        IWebElement webElement49 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 579;
                        webElement49.Click();
                        num2 = 580;
                        Thread.Sleep(2000);
                        num2 = 581;
                        IWebElement webElement50 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 582;
                        webElement50.Click();
                        num2 = 583;
                        Thread.Sleep(2000);
                        num2 = 584;
                        IWebElement webElement51 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 585;
                        webElement51.SendKeys("thpt");
                        num2 = 586;
                        IWebElement webElement52 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 587;
                        webElement52.Click();
                        num2 = 588;
                        Thread.Sleep(2000);
                        num2 = 589;
                        IWebElement webElement53 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 590;
                        webElement53.Click();
                        num2 = 591;
                        Thread.Sleep(2000);
                        num2 = 592;
                        IWebElement webElement54 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_1']"));
                        num2 = 593;
                        webElement54.SendKeys("HUTECH");
                        num2 = 594;
                        IWebElement webElement55 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/table/tbody/tr/td[2]/input"));
                        num2 = 595;
                        webElement55.Click();
                        num2 = 596;
                        Thread.Sleep(2000);
                        num2 = 597;
                        IWebElement webElement56 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 598;
                        webElement56.Click();
                        num2 = 599;
                        Thread.Sleep(2000);
                        num2 = 600;
                        IWebElement webElement57 = chromeDriver.FindElement(By.XPath("//*[@id='u_0_0']/div/form/div[1]/div/button[1]/span"));
                        num2 = 601;
                        webElement57.Click();
                        num2 = 602;
                        Thread.Sleep(5000);
                    }
                    num2 = 604;
                    chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/" + txtsubid.Text);
                    num2 = 605;
                    Thread.Sleep(3000);
                    num2 = 606;
                    Richnguon.Text = chromeDriver.PageSource;
                    num2 = 607;
                    int num7 = Strings.InStr(Richnguon.Text, "Thêm bạn bè");
                    num2 = 608;
                    if (num7 > 1)
                    {
                        num2 = 609;
                        if (checksubid.Checked)
                        {
                            ProjectData.ClearProjectError();
                            num = 14;
                            num2 = 611;
                            IWebElement webElement58 = chromeDriver.FindElement(By.XPath("//*[@id='root']/div[1]/div[1]/div[3]/table/tbody/tr/td[1]/a"));
                            num2 = 612;
                            webElement58.Click();
                        }
                        else
                        {
                            num2 = 614;
                            if (Operators.CompareString(txtsubid.Text, "", TextCompare: false) == 0)
                            {
                                num2 = 615;
                                lblsttsubid.Visible = true;
                            }
                        }
                    }
                    num2 = 618;
                    chromeDriver.Navigate().GoToUrl("https://mbasic.facebook.com/" + txtlikepage.Text);
                    num2 = 619;
                    Thread.Sleep(3000);
                    num2 = 620;
                    Richnguon.Text = chromeDriver.PageSource;
                    num2 = 621;
                    int num8 = Strings.InStr(Richnguon.Text, "Thích");
                    num2 = 622;
                    if (num8 > 1)
                    {
                        num2 = 623;
                        if (checklikepage.Checked)
                        {
                            ProjectData.ClearProjectError();
                            num = 15;
                            num2 = 625;
                            IWebElement webElement59 = chromeDriver.FindElement(By.XPath("//*[@id='sub_profile_pic_content']/div/div[2]/table/tbody/tr/td[1]/a"));
                            num2 = 626;
                            webElement59.Click();
                        }
                        else
                        {
                            num2 = 628;
                            if (Operators.CompareString(txtlikepage.Text, "", TextCompare: false) != 0)
                            {
                            }
                        }
                    }
                    num2 = 631;
                    StreamWriter streamWriter = MyProject.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath + "\\account\\nickthanhcong.txt", append: true);
                    num2 = 632;
                    streamWriter.WriteLine("\r\n" + txtaddtaikhoan.Text);
                    num2 = 633;
                    streamWriter.Close();
                    num2 = 634;
                    sttchinh.Visible = true;
                    num2 = 635;
                    chromeDriver.Quit();
                    num2 = 636;
                    btndunglai.Enabled = true;
                    num2 = 637;
                    lblxacnhan.Text = Conversions.ToString(0);
                    num2 = 638;
                    btnhoanthanh.PerformClick();
                    num2 = 639;
                    Timer3.Start();
                    num2 = 640;
                    lblstt.Visible = true;
                    num2 = 641;
                    LBLSTT1.Visible = false;
                    num2 = 642;
                    lbltime3.Visible = true;
                    num2 = 643;
                    lblstt2.Visible = false;
                    num2 = 644;
                    base.Visible = true;
                    num2 = 645;
                    lblsttloi.Visible = false;
                    num2 = 646;
                    MyProject.MySettingsProperty.Settings.taikhoanverify = listtaikhoan.Text;
                    goto end_IL_0001;
                IL_3283:
                    num2 = 678;
                    lbltime.Text = Conversions.ToString(2);
                end_IL_0001:;
                }
                catch (Exception obj) when (unchecked(obj is Exception && num != 0 && num9 == 0))
                {
                    ProjectData.SetProjectError((Exception)obj);
                    /*Error near IL_3dc1: Could not find block for branch target IL_3d51*/
                    ;
                }
                if (num9 != 0)
                {
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void Timer8_Tick(object sender, EventArgs e)
        {
            Timer8.Interval = 1000;
            if (Conversions.ToDouble(lbltime.Text) == 2.0)
            {
                lblgiohan.Text = Conversions.ToString(Conversions.ToDouble(lblgiohan.Text) + 1.0);
                if (Conversions.ToDouble(lblgiohan.Text) == 240.0)
                {
                    Timer8.Stop();
                    lbltime.Text = Conversions.ToString(2);
                    Timer1.Stop();
                    Interaction.MsgBox("Không lấy được số điện thoại");
                    lblxuthanhtoan.Visible = true;
                    PNTINNHAN.Visible = false;
                    PictureBox2.Visible = false;
                    btnthanhtoanverify.Text = "THANH TOÁN";
                    btnthanhtoanverify.Enabled = true;
                    lblgiohan.Text = Conversions.ToString(0);
                    loadingverify.Value = 0;
                }
                else
                {
                    string requestUriString = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                    HttpWebResponse httpWebResponse = null;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                    string text = streamReader.ReadToEnd();
                    rtverify.Text = text;
                    JObject jObject = JObject.Parse(text);
                    txttinnhanmain.Text = (string?)jObject.SelectToken("message");
                    txtsdt.Text = (string?)jObject.SelectToken("phoneNumber");
                    lbltime.Text = Conversions.ToString(Conversions.ToDouble(lbltime.Text) - 1.0);
                }
            }
            else if (Conversions.ToDouble(lbltime.Text) == 1.0)
            {
                lblgiohan.Text = Conversions.ToString(Conversions.ToDouble(lblgiohan.Text) + 1.0);
                if (Operators.CompareString(txtsdt.Text, "null", TextCompare: false) == 0)
                {
                    VIEWSDT.Visible = true;
                    txtsdt.Enabled = false;
                    loadingverify.Value = 0;
                }
                else if (Operators.CompareString(txtsdt.Text, "", TextCompare: false) == 0)
                {
                    VIEWSDT.Visible = true;
                    txtsdt.Enabled = false;
                    loadingverify.Value = 0;
                }
                else if (Conversions.ToDouble(txtsdt.Text) > 1000.0)
                {
                    txtsdt.Enabled = true;
                    VIEWSDT.Visible = false;
                    Timer8.Stop();
                    lbltime.Text = Conversions.ToString(2);
                    Timer1.Start();
                    btnthanhtoanverify.Text = "ĐANG CHỜ TIN NHẮN";
                    loadingverify.Value = checked(loadingverify.Value + 1);
                    base.Visible = false;
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-notifications");
                    ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                    chromeDriver.Navigate().GoToUrl("https://accounts.google.com/signup/v2/webcreateaccount?continue=https%3A%2F%2Faccounts.google.com%2FManageAccount%3Fnc%3D1&dsh=S-1576291323%3A1584359893770497&gmb=exp&biz=false&flowName=GlifWebSignIn&flowEntry=SignUp");
                    IWebElement webElement = chromeDriver.FindElement(By.XPath("//*[@id='lastName']"));
                    webElement.SendKeys(TextBox2.Text);
                    IWebElement webElement2 = chromeDriver.FindElement(By.XPath("//*[@id='firstName']"));
                    webElement2.SendKeys(TextBox3.Text);
                }
                lbltime.Text = Conversions.ToString(2);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MyProject.Forms.naptienvaomay.ShowDialog();
        }

        private void lblxu_Click(object sender, EventArgs e)
        {
            string value = Conversions.ToString(MyProject.MySettingsProperty.Settings.ngaychinh);
            if (Conversions.ToDouble(value) == 0.0)
            {
                lblxu.Text = "FREE";
                lblxu.ForeColor = Color.Ivory;
            }
            else
            {
                lblxu.Text = "VIP";
                lblxu.ForeColor = Color.Yellow;
            }
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("Http://fb.com/hi.akhu.ne");
        }

        private void checklikepage_CheckedChanged(object sender)
        {
            if (!checklikepage.Checked)
            {
                txtlikepage.Enabled = false;
            }
            else if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
            {
                Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                checklikepage.Checked = false;
            }
            else
            {
                txtlikepage.Enabled = true;
            }
        }

        private void checklikepage2_CheckedChanged(object sender)
        {
            if (!checklikepage2.Checked)
            {
                txtlikepage2.Enabled = false;
            }
            else if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
            {
                Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                checklikepage2.Checked = false;
            }
            else
            {
                txtlikepage2.Enabled = true;
            }
        }

        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao2.ShowDialog();
        }

        private void checktoken_CheckedChanged(object sender)
        {
        }

        private void checktoken2_CheckedChanged(object sender)
        {
            if (checktoken2.Checked)
            {
                Interaction.MsgBox("Việc lấy token sẽ dễ bị checkpoin hơn");
            }
        }

        private void LinkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao2.ShowDialog();
        }

        private void txtfoder_TextChanged(object sender, EventArgs e)
        {
        }

        private void SimplaButton3_Click(object sender, EventArgs e)
        {
            MyProject.MySettingsProperty.Settings.matkhau = txtmatkhau.Text;
            MyProject.MySettingsProperty.Settings.subid = txtsubid.Text;
            MyProject.MySettingsProperty.Settings.pageid = txtlikepage.Text;
            Interaction.MsgBox("Lưu các thiết lập thành công");
        }

        private void SimplaButton2_Click(object sender, EventArgs e)
        {
            MyProject.MySettingsProperty.Settings.matkhau = txtmatkhau2.Text;
            MyProject.MySettingsProperty.Settings.subid = txtsubid2.Text;
            MyProject.MySettingsProperty.Settings.pageid = txtlikepage2.Text;
            Interaction.MsgBox("Lưu các thiết lập thành công");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MyProject.Forms.AboutMe.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MyProject.Forms.thietlapkeyrentcode.ShowDialog();
        }

        private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://FB.COM/BEMMTEAM");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            MyProject.Forms.thongbaochinh.ShowDialog();
        }

        private void LinkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao3.ShowDialog();
        }

        private void LinkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao3.ShowDialog();
        }

        private void SimplaRadioButton1_CheckedChanged(object sender)
        {
        }

        private void SimplaTheme1_Click(object sender, EventArgs e)
        {
        }

        private void Timer9_Tick(object sender, EventArgs e)
        {
            Timer9.Interval = 1000;
            if (Conversions.ToDouble(lbltime9.Text) == 150.0)
            {
                lbltime9.Text = Conversions.ToString(Conversions.ToDouble(lbltime9.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime9.Text) == 1.0)
            {
                Timer2.Stop();
                lbltime.Text = Conversions.ToString(2);
                Timer1.Stop();
                lblxuthanhtoan.Visible = true;
                PNTINNHAN.Visible = false;
                PictureBox2.Visible = false;
                btnthanhtoanverify.Text = "THANH TOÁN";
                btnthanhtoanverify.Enabled = true;
                lblgiohan.Text = Conversions.ToString(0);
                loadingverify.Value = 0;
                Timer9.Stop();
                lbltime9.Text = Conversions.ToString(150);
            }
            else
            {
                lbltime9.Text = Conversions.ToString(Conversions.ToDouble(lbltime9.Text) - 1.0);
            }
        }

        private void Timer10_Tick(object sender, EventArgs e)
        {
            Timer10.Interval = 1000;
            if (Conversions.ToDouble(lbltime10.Text) == 70.0)
            {
                lbltime10.Text = Conversions.ToString(Conversions.ToDouble(lbltime10.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime10.Text) == 1.0)
            {
                btndunglai.Enabled = true;
                btndunglai.PerformClick();
                Timer10.Stop();
                lbltime10.Text = Conversions.ToString(70);
                btnbatdau.PerformClick();
            }
            else
            {
                lbltime10.Text = Conversions.ToString(Conversions.ToDouble(lbltime10.Text) - 1.0);
            }
        }

        private void LinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://gauth.apps.gbraad.nl/#main");
        }

        private void btnlaymaxacnhan_Click(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_0221, IL_0235, IL_0257
            int num = default(int);
            int num2 = default(int);
            try
            {
                if (MyProject.MySettingsProperty.Settings.ngaychinh == 0)
                {
                    Interaction.MsgBox("Vui lòng thuê tool để sử dụng");
                }
                else if (Operators.CompareString(txtkey.Text, "", TextCompare: false) == 0)
                {
                    Interaction.MsgBox("Vui lòng nhập mã KEY ");
                }
                else
                {
                    MyProject.Forms.thongbao.Show();
                    btnlaymaxacnhan.Text = "ĐANG LẤY MÃ XÁC THỰC";
                    Timer11.Stop();
                    lbltime11.Text = Conversions.ToString(30);
                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-notifications");
                    ChromeOptions chromeOptions2 = new ChromeOptions();
                    chromeOptions2.AddArgument("--window-position=-32000,-32000");
                    ProjectData.ClearProjectError();
                    num = 2;
                    ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions2);
                    chromeDriver.Navigate().GoToUrl("https://gauth.apps.gbraad.nl/#main");
                    Thread.Sleep(3000);
                    IWebElement webElement = chromeDriver.FindElement(By.XPath("//*[@id='edit']"));
                    webElement.Click();
                    Thread.Sleep(1000);
                    IWebElement webElement2 = chromeDriver.FindElement(By.XPath("//*[@id='accounts']/li[2]/p[2]/a"));
                    webElement2.Click();
                    Thread.Sleep(1000);
                    IWebElement webElement3 = chromeDriver.FindElement(By.XPath("//*[@id='addButton']"));
                    webElement3.Click();
                    Thread.Sleep(1000);
                    IWebElement webElement4 = chromeDriver.FindElement(By.XPath("//*[@id='keySecret']"));
                    webElement4.SendKeys(txtkey.Text);
                    IWebElement webElement5 = chromeDriver.FindElement(By.XPath("//*[@id='addKeyButton']"));
                    webElement5.Click();
                    Thread.Sleep(5000);
                    txtcode.Text = chromeDriver.FindElement(By.XPath("//*[@id='accounts']/li[2]/h3")).Text;
                    Timer11.Start();
                    btnlaymaxacnhan.Text = "LẤY MÃ XÁC THỰC";
                    MyProject.Forms.thongbao.Close();
                    chromeDriver.Quit();
                }
            }
            catch (Exception obj) when (obj is Exception && num != 0 && num2 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_0255: Could not find block for branch target IL_0221*/
                ;
            }
            if (num2 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void Timer11_Tick(object sender, EventArgs e)
        {
            Timer11.Interval = 1000;
            if (Conversions.ToDouble(lbltime11.Text) == 30.0)
            {
                lbltime11.Text = Conversions.ToString(Conversions.ToDouble(lbltime11.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime11.Text) == 1.0)
            {
                Timer11.Stop();
                lbltime11.Text = Conversions.ToString(30);
                Interaction.MsgBox("Hết hạn vui lòng bấm lấy mã xác thực lại nếu muốn lấy lại");
                txtcode.Text = "";
            }
            else
            {
                lbltime11.Text = Conversions.ToString(Conversions.ToDouble(lbltime11.Text) - 1.0);
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            int count = listho.Items.Count;
            object objectValue = RuntimeHelpers.GetObjectValue(listho.Items[count]);
        }

        private void BTNXOALIST_Click(object sender, EventArgs e)
        {
            listtaikhoan.Text = "";
            MyProject.MySettingsProperty.Settings.taikhoanverify = listtaikhoan.Text;
            MyProject.MySettingsProperty.Settings.taikhoanverify = listtaikhoan.Text;
            MyProject.MySettingsProperty.Settings.taikhoanverify = listtaikhoan.Text;
        }

        [Obsolete]
        private void btnwebmmobie_Click_1(object sender, EventArgs e)
        {
        }

        public object delay(int n)
        {
            short millisecondsTimeout = (short)((Conversions.ToDouble(thoigianngu.Text) == 1.0) ? 1000 : ((Conversions.ToDouble(thoigianngu.Text) != 2.0) ? 2000 : 2000));
            for (int i = 1; i <= n; i = checked(i + 1))
            {
                Thread.Sleep(millisecondsTimeout);
            }
            object result = default(object);
            return result;
        }

        private void checkgialap_CheckedChanged(object sender)
        {
            if (checkgialap.Checked)
            {
                Interaction.MsgBox("Mật khẩu mặc định của giả lập để tránh lỗi là thanhcute");
                txtmatkhau.Text = "thanhcute";
                txtmatkhau.Enabled = false;
            }
            else
            {
                txtmatkhau.Enabled = true;
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
        }

        public object GETID()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = process.StartInfo;
            startInfo.FileName = "adb";
            startInfo.Arguments = "devices";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo = null;
            process.Start();
            RichTextBox3.Text = process.StandardOutput.ReadToEnd();
            RichTextBox3.Text = Strings.Replace(RichTextBox3.Text, "List of devices attached", "");
            string[] lines = RichTextBox3.Lines;
            string[] array = lines;
            foreach (string text in array)
            {
                string text2 = text;
                string value = Conversions.ToString(Strings.InStr(text2, "device"));
                if (Conversions.ToDouble(value) > 4.0)
                {
                    string expression = text2;
                    expression = Strings.Replace(expression, "device", "");
                    expression = Strings.Replace(expression, " ", "");
                    expression = Strings.Replace(expression, "\r\n", "");
                    expression = Strings.Replace(expression, "\t", "");
                    expression = Strings.Replace(expression, "\r\n", "");
                    txtidgialap.Text = expression;
                    break;
                }
            }
            object result = default(object);
            return result;
        }

        private void LinkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Interaction.MsgBox("Nếu cảm thấy máy chậm thì hãy chỉnh thời gian ngủ lên");
        }

        private void BTNXOALIST_Click_1(object sender, EventArgs e)
        {
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.gialap.ShowDialog();
        }

        private void LinkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao2.ShowDialog();
        }

        private void LinkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.thongbao3.ShowDialog();
        }

        private void LinkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Interaction.MsgBox("Nếu cảm thấy máy chậm thì hãy chỉnh thời gian ngủ lên");
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.EnableMobileEmulation("Pixel 2");
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            chromeOptions.AddArguments("profile.default_content_setting_values.images", Conversions.ToString(2));
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
            chromeDriver.Navigate().GoToUrl("http://instagram.com/");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, options);
            chromeDriver.Navigate().GoToUrl("https://www.facebook.com/help/contact/183000765122339");
            IWebElement webElement = chromeDriver.FindElement(By.XPath("//*[@id='356294444474458']/input"));
            webElement.SendKeys("C:\\Users\\PC\\Documents\\Visual Studio 2019\\Tập Tin\\B E M M TOOL\\B E M M TOOL\\bin\\Debug\\Avata\\10.jpg");
        }

        private void thoigianngu2_SelectedIndexChanged(object sender, EventArgs e)
        {
            thoigianngu.Text = thoigianngu2.Text;
        }

        private void SimplaButton2_Click_1(object sender, EventArgs e)
        {
            MyProject.MySettingsProperty.Settings.matkhau = txtmatkhau2.Text;
            MyProject.MySettingsProperty.Settings.subid = txtsubid2.Text;
            MyProject.MySettingsProperty.Settings.pageid = txtlikepage2.Text;
            Interaction.MsgBox("Lưu các thiết lập thành công");
        }

        private void Button3_Click_2(object sender, EventArgs e)
        {
            listtaikhoan2.Text = "";
            MyProject.MySettingsProperty.Settings.listtaikhoanmail = listtaikhoan2.Text;
        }

        private void LinkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.gialap.ShowDialog();
        }

        private void btnbatdau3_Click(object sender, EventArgs e)
        {
            short num = Conversions.ToShort(Tachso(txtmatkhautiktok2.Text));
            if (Strings.Len(MyProject.MySettingsProperty.Settings.keyapi) < 5)
            {
                Interaction.MsgBox("Cần có Key APi Rentcode để xác minh số điện thoại");
                return;
            }
            if (Strings.Len(txtmatkhautiktok2.Text) < 8)
            {
                Interaction.MsgBox("Mật khẩu phải có 8 ký tự trở lên và có số");
                return;
            }
            txtstt.Visible = true;
            lbllaysodt.Visible = true;
            lblcholenh.Visible = false;
            txtaddtiktok.Text = "";
            Timer13.Start();
            Panel1.Enabled = false;
            SimplaButton1.Text = "FACEBOOK";
            btnbatdau3.Enabled = false;
            lblxacnhan.Text = Conversions.ToString(1);
            string requestUriString = "https://api.rentcode.net/api/v2/order/request?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi + "&ServiceProviderId=218";
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string text = streamReader.ReadToEnd();
            rtverify.Text = text;
            JObject jObject = JObject.Parse(text);
            oderid.Text = (string?)jObject.SelectToken("id");
            txttrangthai.Text = (string?)jObject.SelectToken("success");
            lblxuthanhtoan.Visible = false;
            PNTINNHAN.Visible = true;
            PictureBox2.Visible = true;
            if (Operators.CompareString(txttrangthai.Text, "True", TextCompare: false) == 0)
            {
                Timer12.Start();
                lbllaysodt.Visible = false;
                return;
            }
            Timer12.Stop();
            lbltime.Text = Conversions.ToString(2);
            lblloitiktok.Text = "Lỗi không quét được Key API rentcode của bạn";
            lblxuthanhtoan.Visible = true;
            PNTINNHAN.Visible = false;
            PictureBox2.Visible = false;
            btnthanhtoanverify.Text = "THANH TOÁN";
            btnthanhtoanverify.Enabled = true;
            btndunglai3.Enabled = true;
            btndunglai3.PerformClick();
            loadingverify.Value = 0;
            btndunglai3.PerformClick();
        }

        private void Timer12_Tick(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_11a1, IL_11b5, IL_11d7
            int num = default(int);
            int num7 = default(int);
            try
            {
                ProjectData.ClearProjectError();
                num = 2;
                Timer12.Interval = 1000;
                short num2 = 2;
                checked
                {
                    if (num2 == 2)
                    {
                        txtstt.Text = "Tiến hành lấy số điện thoại";
                        string requestUriString = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                        HttpWebResponse httpWebResponse = null;
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                        string text = streamReader.ReadToEnd();
                        rtverify.Text = text;
                        JObject jObject = JObject.Parse(text);
                        txttinnhanmain.Text = (string?)jObject.SelectToken("message");
                        txtsdt.Text = (string?)jObject.SelectToken("phoneNumber");
                        num2 = (short)(num2 - 1);
                        if (Operators.CompareString(txtsdt.Text, "", TextCompare: false) == 0)
                        {
                            num2 = 2;
                            Timer12.Start();
                        }
                        else
                        {
                            Timer13.Stop();
                            lbltime13.Text = Conversions.ToString(70);
                            txtsdt.Enabled = true;
                            Timer12.Stop();
                            lbltime.Text = Conversions.ToString(2);
                            Timer1.Start();
                            GETID();
                            string text2 = txtidgialap.Text;
                            if (Operators.CompareString(text2, "", TextCompare: false) == 0)
                            {
                                lblloitiktok.Text = "Không tìm được giả lập";
                                lbltime4.Text = Conversions.ToString(30);
                                lbltime13.Text = Conversions.ToString(70);
                                txtstt.Visible = false;
                                btndunglai3.PerformClick();
                                btndunglai3.Enabled = true;
                                lblxacnhan.Text = Conversions.ToString(0);
                                btnhoanthanh.PerformClick();
                                Timer12.Start();
                            }
                            else
                            {
                                txtstt.Text = "Mở Tiktok";
                                Hide();
                                ADBHelper.ExecuteCMD("adb -s " + text2 + " shell input keyevent 3 & adb -s " + text2 + " shell pm clear com.ss.android.ugc.trill.go & adb -s " + text2 + " shell pm clear com.android.browser && exit");
                                delay(6);
                                ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh.png");
                                ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh.png manhinh.png");
                                FileStream fileStream = new FileStream(Application.StartupPath + "\\sources\\Data\\tiktok.png", FileMode.Open, FileAccess.Read);
                                FileStream fileStream2 = new FileStream("\\source\\manhinh.png", FileMode.Open, FileAccess.Read);
                                Bitmap subBitmap = (Bitmap)Image.FromStream(fileStream);
                                Bitmap mainBitmap = (Bitmap)Image.FromStream(fileStream2);
                                Point? point = ImageScanOpenCV.FindOutPoint(mainBitmap, subBitmap);
                                Bitmap bitmap = ImageScanOpenCV.Find(mainBitmap, subBitmap);
                                ADBHelper.Tap(text2, point.Value.X, point.Value.Y);
                                fileStream.Close();
                                fileStream2.Close();
                                txtstt.Text = "Đăng ký";
                                delay(10);
                                ADBHelper.Tap(text2, 347, 678);
                                delay(2);
                                ADBHelper.Tap(text2, 200, 519);
                                delay(2);
                                ADBHelper.Tap(text2, 200, 519);
                                delay(2);
                                ADBHelper.Swipe(text2, 265, 152, 265, 213);
                                ADBHelper.Swipe(text2, 265, 152, 265, 213);
                                ADBHelper.Swipe(text2, 265, 152, 265, 213);
                                ADBHelper.Swipe(text2, 265, 152, 265, 213);
                                delay(1);
                                ADBHelper.Tap(text2, 361, 667);
                                delay(2);
                                int num3 = 1;
                                do
                                {
                                    switch (Conversions.ToShort(Strings.Mid(txtsdt.Text, num3, 1)))
                                    {
                                        case 0:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_0);
                                            break;
                                        case 1:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_1);
                                            break;
                                        case 2:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_2);
                                            break;
                                        case 3:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_3);
                                            break;
                                        case 4:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_4);
                                            break;
                                        case 5:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_5);
                                            break;
                                        case 6:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_6);
                                            break;
                                        case 7:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_7);
                                            break;
                                        case 8:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_8);
                                            break;
                                        case 9:
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_9);
                                            break;
                                    }
                                    num3++;
                                }
                                while (num3 <= 10);
                                delay(1);
                                ADBHelper.Tap(text2, 361, 667);
                                txtstt.Text = "Đợi code";
                                delay(40);
                                string text3 = "";
                                string requestUriString2 = "https://api.rentcode.net/api/v2/order/" + oderid.Text + "/check?apiKey=" + MyProject.MySettingsProperty.Settings.keyapi;
                                HttpWebResponse httpWebResponse2 = null;
                                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString2);
                                httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                                StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream());
                                string text4 = streamReader2.ReadToEnd();
                                rtverify.Text = text4;
                                JObject jObject2 = JObject.Parse(text4);
                                string x = (string?)jObject2.SelectToken("message");
                                text3 = Tachso(x);
                                if (Operators.CompareString(text3, "", TextCompare: false) == 0)
                                {
                                    Timer13.Stop();
                                    lbltime13.Text = Conversions.ToString(70);
                                    btnhoanthanh.PerformClick();
                                    Timer1.Stop();
                                    base.Visible = true;
                                    txtstt.Visible = false;
                                    Show();
                                    Timer12.Stop();
                                    loadingverify.Value = 0;
                                    Timer4.Start();
                                    lbltime4.Text = Conversions.ToString(30);
                                    lbltime4.Visible = true;
                                    lblstt1tiktok.Visible = true;
                                    pnthanhcongtiktok.Visible = false;
                                    pnloitiktok.Visible = true;
                                    lblxacnhan.Text = Conversions.ToString(0);
                                    btndunglai3.Enabled = true;
                                    btnbatdau3.Enabled = true;
                                    lblloitiktok.Text = "Không có code";
                                    lblloitiktok.Visible = true;
                                }
                                else
                                {
                                    ADBHelper.InputText(text2, text3);
                                    delay(1);
                                    ADBHelper.Tap(text2, 361, 667);
                                    delay(4);
                                    SENDTEXT(text2, txtmatkhautiktok2.Text);
                                    delay(4);
                                    ADBHelper.Tap(text2, 364, 671);
                                    delay(4);
                                    ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_APP_SWITCH);
                                    delay(4);
                                    ADBHelper.Swipe(text2, 223, 637, 388, 636);
                                    ADBHelper.Swipe(text2, 223, 637, 388, 636);
                                    ADBHelper.Swipe(text2, 223, 637, 388, 636);
                                    ADBHelper.Swipe(text2, 223, 637, 388, 636);
                                    ADBHelper.Swipe(text2, 196, 330, 385, 316);
                                    ADBHelper.Swipe(text2, 196, 330, 385, 316);
                                    ADBHelper.Swipe(text2, 196, 330, 385, 316);
                                    delay(4);
                                    ADBHelper.Tap(text2, point.Value.X, point.Value.Y);
                                    delay(4);
                                    delay(1);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    delay(3);
                                    ADBHelper.Tap(text2, 230, 682);
                                    delay(3);
                                    int num4 = 1;
                                    do
                                    {
                                        switch (Conversions.ToShort(Strings.Mid(txtsdt.Text, num4, 1)))
                                        {
                                            case 0:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_0);
                                                break;
                                            case 1:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_1);
                                                break;
                                            case 2:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_2);
                                                break;
                                            case 3:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_3);
                                                break;
                                            case 4:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_4);
                                                break;
                                            case 5:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_5);
                                                break;
                                            case 6:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_6);
                                                break;
                                            case 7:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_7);
                                                break;
                                            case 8:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_8);
                                                break;
                                            case 9:
                                                ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_9);
                                                break;
                                        }
                                        num4++;
                                    }
                                    while (num4 <= 10);
                                    delay(1);
                                    ADBHelper.Tap(text2, 361, 667);
                                    delay(2);
                                    SENDTEXT(text2, txtmatkhautiktok2.Text);
                                    ADBHelper.Tap(text2, 350, 679);
                                    ADBHelper.Tap(text2, 350, 679);
                                    delay(1);
                                    ADBHelper.Tap(text2, 361, 667);
                                    ADBHelper.Tap(text2, 361, 681);
                                    delay(1);
                                    ADBHelper.ExecuteCMD("adb -s " + text2 + " shell screencap /mnt/sdcard/Download/manhinh2.png");
                                    ADBHelper.ExecuteCMD("adb  -s " + text2 + " pull /mnt/sdcard/Download/manhinh2.png manhinh2.png");
                                    txtstt.Text = "Kiểm tra Reg";
                                    FileStream fileStream3 = new FileStream(Application.StartupPath + "\\sources\\Data\\oktiktok.png", FileMode.Open, FileAccess.Read);
                                    FileStream fileStream4 = new FileStream("\\source\\manhinh2.png", FileMode.Open, FileAccess.Read);
                                    Bitmap subBitmap2 = (Bitmap)Image.FromStream(fileStream3);
                                    Bitmap mainBitmap2 = (Bitmap)Image.FromStream(fileStream4);
                                    Point? point2 = ImageScanOpenCV.FindOutPoint(mainBitmap2, subBitmap2);
                                    ADBHelper.Tap(text2, point2.Value.X, point2.Value.Y);
                                    fileStream3.Close();
                                    fileStream4.Close();
                                    bool flag = false;
                                    txtaddtiktok.Text = txtsdt.Text + "|" + txtmatkhautiktok2.Text;
                                    listtaikhoantiktok.Text = txtaddtiktok.Text + Environment.NewLine + listtaikhoantiktok.Text;
                                    MyProject.MySettingsProperty.Settings.listtiktok = listtaikhoantiktok.Text;
                                    if (checksubtiktok.Checked)
                                    {
                                        txtstt.Text = "SUB ID";
                                        delay(2);
                                        ADBHelper.Tap(text2, 39, 681);
                                        delay(2);
                                        ADBHelper.Tap(text2, 379, 35);
                                        delay(2);
                                        ADBHelper.Tap(text2, 86, 32);
                                        delay(2);
                                        SENDTEXT(text2, txtsubidtiktok.Text);
                                        delay(1);
                                        ADBHelper.Tap(text2, 361, 35);
                                        delay(2);
                                        ADBHelper.Tap(text2, 101, 101);
                                        delay(2);
                                        ADBHelper.Tap(text2, 332, 76);
                                    }
                                    delay(3);
                                    ADBHelper.Tap(text2, 39, 681);
                                    if (checklove.Checked)
                                    {
                                        txtstt.Text = "LOVE ID";
                                        delay(2);
                                        ADBHelper.Tap(text2, 53, 343);
                                        delay(2);
                                        ADBHelper.Tap(text2, 379, 487);
                                        int num5 = Conversions.ToInteger(txtvideo.Text);
                                        for (int i = 1; i <= num5; i++)
                                        {
                                            ADBHelper.Swipe(text2, 197, 532, 198, 94);
                                            delay(2);
                                            ADBHelper.Tap(text2, 379, 487);
                                            if (checkcmt.Checked)
                                            {
                                                txtstt.Text = "CMT ID";
                                                Random random = new Random();
                                                object objectValue = RuntimeHelpers.GetObjectValue(listcmt.Items[random.Next(listcmt.Items.Count)]);
                                                string text5 = objectValue.ToString();
                                                delay(2);
                                                SENDTEXT(text2, text5);
                                                delay(2);
                                                ADBHelper.Tap(text2, 381, 677);
                                                delay(2);
                                                ADBHelper.Tap(text2, 187, 258);
                                            }
                                        }
                                    }
                                    ADBHelper.Tap(text2, 38, 681);
                                    if (checkten.Checked)
                                    {
                                        txtstt.Text = "CHANGE TÊN";
                                        delay(2);
                                        ADBHelper.Tap(text2, 20, 40);
                                        delay(2);
                                        ADBHelper.Tap(text2, 20, 40);
                                        delay(2);
                                        ADBHelper.Tap(text2, 20, 40);
                                        delay(2);
                                        ADBHelper.Tap(text2, 20, 40);
                                        ADBHelper.Tap(text2, 20, 40);
                                        ADBHelper.Tap(text2, 20, 40);
                                        ADBHelper.Tap(text2, 347, 680);
                                        delay(2);
                                        ADBHelper.Tap(text2, 53, 73);
                                        delay(2);
                                        ADBHelper.Tap(text2, 93, 507);
                                        delay(2);
                                        ADBHelper.Tap(text2, 279, 189);
                                        ADBHelper.Swipe(text2, 279, 189, 390, 188);
                                        short num6 = 1;
                                        do
                                        {
                                            ADBHelper.Key(text2, ADBKeyEvent.KEYCODE_DEL);
                                            num6 = (short)unchecked(num6 + 1);
                                        }
                                        while (num6 <= 20);
                                        Random random2 = new Random();
                                        int count = listtengialap.Items.Count;
                                        object objectValue2 = RuntimeHelpers.GetObjectValue(listtengialap.Items[random2.Next(count)]);
                                        string str = objectValue2.ToString();
                                        int count2 = listhogialap.Items.Count;
                                        object objectValue3 = RuntimeHelpers.GetObjectValue(listhogialap.Items[random2.Next(count2)]);
                                        string str2 = objectValue3.ToString();
                                        string text6 = str2 + " " + str;
                                        SENDTEXT(text2, text6);
                                        delay(2);
                                        ADBHelper.Tap(text2, 373, 34);
                                        ADBHelper.Tap(text2, 373, 34);
                                        delay(2);
                                        ADBHelper.Tap(text2, 373, 34);
                                    }
                                    Show();
                                    Timer13.Stop();
                                    lbltime13.Text = Conversions.ToString(70);
                                    btnhoanthanh.PerformClick();
                                    Timer1.Stop();
                                    base.Visible = true;
                                    lbltime4.Visible = true;
                                    lblstt1tiktok.Visible = true;
                                    Timer12.Stop();
                                    loadingverify.Value = 0;
                                    Timer4.Start();
                                    lbltime4.Text = Conversions.ToString(30);
                                    pnthanhcongtiktok.Visible = true;
                                    pnloitiktok.Visible = false;
                                    txtstt.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception obj) when (obj is Exception && num != 0 && num7 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_11d5: Could not find block for branch target IL_11a1*/
                ;
            }
            if (num7 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void AttackerMP_Validating(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtvideo.Text, out decimal result))
            {
                int num = Convert.ToInt32(Math.Round(result));
                txtvideo.Text = num.ToString();
            }
            else
            {
                txtvideo.Text = "";
            }
        }

        private void Timer13_Tick(object sender, EventArgs e)
        {
            Timer13.Interval = 1000;
            if (Conversions.ToDouble(lbltime13.Text) == 70.0)
            {
                lbltime13.Text = Conversions.ToString(Conversions.ToDouble(lbltime13.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime13.Text) == 1.0)
            {
                btndunglai3.Enabled = true;
                btndunglai3.PerformClick();
                Timer13.Stop();
                lbltime13.Text = Conversions.ToString(70);
                btnbatdau3.PerformClick();
            }
            else
            {
                lbltime13.Text = Conversions.ToString(Conversions.ToDouble(lbltime13.Text) - 1.0);
            }
        }

        private void btndunglai3_Click(object sender, EventArgs e)
        {
            Timer13.Stop();
            lbltime13.Text = Conversions.ToString(70);
            lbllaysodt.Visible = false;
            lblcholenh.Visible = true;
            btnhoanthanh.PerformClick();
            Timer1.Stop();
            lblstt1tiktok.Visible = false;
            lbltime4.Visible = false;
            Timer12.Stop();
            loadingverify.Value = 0;
            Timer4.Stop();
            lbltime4.Text = Conversions.ToString(30);
            lblxacnhan.Text = Conversions.ToString(0);
            btndunglai3.Enabled = true;
            btnbatdau3.Enabled = true;
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            lbllaysodt.Visible = false;
            lblcholenh.Visible = false;
            Timer4.Interval = 1000;
            if (Conversions.ToDouble(lbltime4.Text) == 30.0)
            {
                lbltime4.Text = Conversions.ToString(Conversions.ToDouble(lbltime4.Text) - 1.0);
            }
            else if (Conversions.ToDouble(lbltime4.Text) == 1.0)
            {
                Timer4.Stop();
                lbltime4.Text = Conversions.ToString(30);
                btnbatdau3.Enabled = true;
                lblloitiktok.Visible = false;
                btnbatdau3.PerformClick();
                btnbatdau3.Enabled = false;
            }
            else
            {
                lbltime4.Text = Conversions.ToString(Conversions.ToDouble(lbltime4.Text) - 1.0);
            }
        }

        private void TxtHStof_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) | (Operators.CompareString(Conversions.ToString(e.KeyChar), ".", TextCompare: false) == 0));
        }

        public object SENDTEXT(string ido, string text)
        {
            text = Strings.LCase(text);
            int num = Strings.Len(text);
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                switch (Strings.Mid(text, i, 1))
                {
                    case "q":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_Q);
                        break;
                    case "w":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_W);
                        break;
                    case "e":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_E);
                        break;
                    case "r":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_R);
                        break;
                    case "t":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_T);
                        break;
                    case "y":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_Y);
                        break;
                    case "u":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_U);
                        break;
                    case "i":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_I);
                        break;
                    case "o":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_O);
                        break;
                    case "p":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_P);
                        break;
                    case "a":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_A);
                        break;
                    case "s":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_S);
                        break;
                    case "d":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_D);
                        break;
                    case "f":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_F);
                        break;
                    case "g":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_G);
                        break;
                    case "h":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_H);
                        break;
                    case "j":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_J);
                        break;
                    case "k":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_K);
                        break;
                    case "l":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_L);
                        break;
                    case "z":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_Z);
                        break;
                    case "x":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_X);
                        break;
                    case "c":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_C);
                        break;
                    case "v":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_V);
                        break;
                    case "b":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_B);
                        break;
                    case "n":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_N);
                        break;
                    case "m":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_M);
                        break;
                    case "0":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_0);
                        break;
                    case "1":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_1);
                        break;
                    case "2":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_2);
                        break;
                    case "3":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_3);
                        break;
                    case "4":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_4);
                        break;
                    case "5":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_5);
                        break;
                    case "6":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_6);
                        break;
                    case "7":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_7);
                        break;
                    case "8":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_8);
                        break;
                    case "9":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_9);
                        break;
                    case " ":
                        ADBHelper.Key(ido, ADBKeyEvent.KEYCODE_SPACE);
                        break;
                }
            }
            object result = default(object);
            return result;
        }

        private void AttackerMP_Validating(object sender, CancelEventArgs e)
        {
        }

        private void Button8_Click(object sender, EventArgs e)
        {
        }

        private void checkcmt_CheckedChanged(object sender)
        {
            if (checkcmt.Checked)
            {
                if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
                {
                    Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                    checkcmt.Checked = false;
                }
                else
                {
                    Interaction.MsgBox("CMT không được viết có dấu");
                }
            }
        }

        private void btnaddcmttiktok_Click(object sender, EventArgs e)
        {
            listcmt.Items.Add(txtcmt.Text);
            txtcmt.Text = "";
        }

        private void btnxoacmttiktok_Click(object sender, EventArgs e)
        {
            listcmt.Items.Remove(RuntimeHelpers.GetObjectValue(listcmt.SelectedItem));
        }

        private void txtmatkhautiktok_TextChanged(object sender, EventArgs e)
        {
            Interaction.MsgBox("Mật khẩu phải có 8 ký tự trở lên và có số");
        }

        private void checksubtiktok_CheckedChanged(object sender)
        {
            if (checksubtiktok.Checked)
            {
                checklove.Enabled = true;
                return;
            }
            checklove.Enabled = false;
            checklove.Checked = false;
        }

        private void checklove_CheckedChanged(object sender)
        {
            if (checklove.Checked)
            {
                if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
                {
                    Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                    checklove.Checked = false;
                }
                else
                {
                    checkcmt.Enabled = true;
                }
            }
            else
            {
                checkcmt.Enabled = false;
            }
        }

        private void btnsavetiktok_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.text";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, listtaikhoantiktok.Text);
            }
        }

        private void btnxoatiktok_Click(object sender, EventArgs e)
        {
            listtaikhoantiktok.Text = "";
            MyProject.MySettingsProperty.Settings.listtiktok = "";
        }

        private void LinkLabel6_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyProject.Forms.gialap.ShowDialog();
        }

        private void checkgialap2_CheckedChanged(object sender)
        {
            if (checkgialap2.Checked)
            {
                Interaction.MsgBox("Mật khẩu mặc định của giả lập để tránh lỗi là thanhcute");
                txtmatkhau2.Text = "thanhcute";
                txtmatkhau2.Enabled = false;
            }
            else
            {
                txtmatkhau2.Enabled = true;
            }
        }

        private void Button8_Click_1(object sender, EventArgs e)
        {
            RestClient restClient = new RestClient("https://loginbemmteam-f306.restdb.io/rest/system_log/");
            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("cache-control", "no-cache");
            restRequest.AddHeader("x-apikey", "0488cfbda23f7b9950524d3d882cd1be71d9f");
            restRequest.AddHeader("content-type", "application/json");
            IRestResponse restResponse = restClient.Execute(restRequest);
            string content = restResponse.Content;
            Interaction.MsgBox(content.ToString());
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            Interaction.MsgBox(date);
        }

        private void checksubtiktok2_CheckedChanged(object sender)
        {
            if (checksubtiktok2.Checked)
            {
                checklove2.Enabled = true;
                return;
            }
            checklove2.Enabled = false;
            checklove2.Checked = false;
        }

        private void checklove2_CheckedChanged(object sender)
        {
            if (checklove2.Checked)
            {
                if (Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
                {
                    Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                    checklove2.Checked = false;
                }
                else
                {
                    checkcmt2.Enabled = true;
                }
            }
            else
            {
                checkcmt2.Enabled = false;
                checkcmt2.Checked = false;
            }
        }

        private void btnaddcmttiktok2_Click(object sender, EventArgs e)
        {
            listcmt2.Items.Add(txtcmt2.Text);
            txtcmt2.Text = "";
        }

        private void btnxoacmttiktok2_Click(object sender, EventArgs e)
        {
            listcmt2.Items.Remove(RuntimeHelpers.GetObjectValue(listcmt2.SelectedItem));
        }

        private void btnbatdau4_Click(object sender, EventArgs e)
        {
            //Discarded unreachable code: IL_0a25, IL_0a32, IL_0a45, IL_0a58, IL_0a6b, IL_0a7d, IL_0a96, IL_0aa9, IL_0aae, IL_128d, IL_1294, IL_16ba, IL_16bc, IL_16c3, IL_16c6, IL_16c7, IL_16d4, IL_16f6
            int num4 = default(int);
            int num7 = default(int);
            try
            {
                int num = 1;
                GETID();
                num = 2;
                string text = txtidgialap.Text;
                num = 3;
                Hide();
                num = 4;
                ADBHelper.ExecuteCMD("adb -s " + text + " shell input keyevent 3 & adb -s " + text + " shell pm clear com.ss.android.ugc.trill.go & adb -s " + text + " shell pm clear com.android.browser && exit");
                num = 5;
                delay(6);
                num = 6;
                ADBHelper.ExecuteCMD("adb -s " + text + " shell screencap /mnt/sdcard/Download/manhinh.png");
                num = 7;
                ADBHelper.ExecuteCMD("adb  -s " + text + " pull /mnt/sdcard/Download/manhinh.png manhinh.png");
                num = 8;
                FileStream fileStream = new FileStream(Application.StartupPath + "\\sources\\Data\\tiktok.png", FileMode.Open, FileAccess.Read);
                num = 9;
                FileStream fileStream2 = new FileStream("\\source\\manhinh.png", FileMode.Open, FileAccess.Read);
                num = 10;
                Bitmap subBitmap = (Bitmap)Image.FromStream(fileStream);
                num = 11;
                Bitmap mainBitmap = (Bitmap)Image.FromStream(fileStream2);
                num = 12;
                Point? point = ImageScanOpenCV.FindOutPoint(mainBitmap, subBitmap);
                num = 13;
                Bitmap bitmap = ImageScanOpenCV.Find(mainBitmap, subBitmap);
                num = 14;
                ADBHelper.Tap(text, point.Value.X, point.Value.Y);
                num = 15;
                fileStream.Close();
                num = 16;
                fileStream2.Close();
                num = 17;
                ADBHelper.Tap(text, 350, 679);
                num = 18;
                ADBHelper.Tap(text, 350, 679);
                num = 19;
                ADBHelper.Tap(text, 350, 679);
                num = 20;
                ADBHelper.Tap(text, 350, 679);
                num = 21;
                ADBHelper.Tap(text, 350, 679);
                num = 22;
                ADBHelper.Tap(text, 350, 679);
                num = 23;
                ADBHelper.Tap(text, 350, 679);
                num = 24;
                delay(3);
                num = 25;
                ADBHelper.Tap(text, 230, 682);
                num = 26;
                delay(3);
                num = 27;
                short num2 = 1;
                checked
                {
                    do
                    {
                        num = 28;
                        string value = Strings.Mid(txttaikhoan2.Text, num2, 1);
                        num = 29;
                        if (Conversions.ToDouble(value) == 0.0)
                        {
                            num = 30;
                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_0);
                        }
                        else
                        {
                            num = 32;
                            if (Conversions.ToDouble(value) == 1.0)
                            {
                                num = 33;
                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_1);
                            }
                            else
                            {
                                num = 35;
                                if (Conversions.ToDouble(value) == 2.0)
                                {
                                    num = 36;
                                    ADBHelper.Key(text, ADBKeyEvent.KEYCODE_2);
                                }
                                else
                                {
                                    num = 38;
                                    if (Conversions.ToDouble(value) == 3.0)
                                    {
                                        num = 39;
                                        ADBHelper.Key(text, ADBKeyEvent.KEYCODE_3);
                                    }
                                    else
                                    {
                                        num = 41;
                                        if (Conversions.ToDouble(value) == 4.0)
                                        {
                                            num = 42;
                                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_4);
                                        }
                                        else
                                        {
                                            num = 44;
                                            if (Conversions.ToDouble(value) == 5.0)
                                            {
                                                num = 45;
                                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_5);
                                            }
                                            else
                                            {
                                                num = 47;
                                                if (Conversions.ToDouble(value) == 6.0)
                                                {
                                                    num = 48;
                                                    ADBHelper.Key(text, ADBKeyEvent.KEYCODE_6);
                                                }
                                                else
                                                {
                                                    num = 50;
                                                    if (Conversions.ToDouble(value) == 7.0)
                                                    {
                                                        num = 51;
                                                        ADBHelper.Key(text, ADBKeyEvent.KEYCODE_7);
                                                    }
                                                    else
                                                    {
                                                        num = 53;
                                                        if (Conversions.ToDouble(value) == 8.0)
                                                        {
                                                            num = 54;
                                                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_8);
                                                        }
                                                        else
                                                        {
                                                            num = 56;
                                                            if (Conversions.ToDouble(value) == 9.0)
                                                            {
                                                                num = 57;
                                                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_9);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        num = 59;
                        num2 = (short)unchecked(num2 + 1);
                    }
                    while (num2 <= 10);
                    num = 60;
                    delay(1);
                    num = 61;
                    ADBHelper.Tap(text, 361, 667);
                    num = 62;
                    delay(2);
                    num = 63;
                    SENDTEXT(text, txtmatkhautiktok2.Text);
                    num = 64;
                    ADBHelper.Tap(text, 350, 679);
                    num = 65;
                    ADBHelper.Tap(text, 350, 679);
                    num = 66;
                    delay(1);
                    num = 67;
                    delay(4);
                    num = 68;
                    ADBHelper.Key(text, ADBKeyEvent.KEYCODE_APP_SWITCH);
                    num = 69;
                    delay(4);
                    num = 70;
                    ADBHelper.Swipe(text, 223, 637, 388, 636);
                    num = 71;
                    ADBHelper.Swipe(text, 223, 637, 388, 636);
                    num = 72;
                    ADBHelper.Swipe(text, 223, 637, 388, 636);
                    num = 73;
                    ADBHelper.Swipe(text, 223, 637, 388, 636);
                    num = 74;
                    ADBHelper.Swipe(text, 196, 330, 385, 316);
                    num = 75;
                    ADBHelper.Swipe(text, 196, 330, 385, 316);
                    num = 76;
                    ADBHelper.Swipe(text, 196, 330, 385, 316);
                    num = 77;
                    delay(4);
                    num = 78;
                    ADBHelper.Tap(text, point.Value.X, point.Value.Y);
                    num = 79;
                    delay(4);
                    num = 80;
                    delay(1);
                    num = 81;
                    ADBHelper.Tap(text, 350, 679);
                    num = 82;
                    ADBHelper.Tap(text, 350, 679);
                    num = 83;
                    ADBHelper.Tap(text, 350, 679);
                    num = 84;
                    ADBHelper.Tap(text, 350, 679);
                    num = 85;
                    ADBHelper.Tap(text, 350, 679);
                    num = 86;
                    ADBHelper.Tap(text, 350, 679);
                    num = 87;
                    ADBHelper.Tap(text, 350, 679);
                    num = 88;
                    delay(3);
                    num = 89;
                    ADBHelper.Tap(text, 230, 682);
                    num = 90;
                    delay(3);
                    num = 91;
                    int num3 = 1;
                    do
                    {
                        num = 92;
                        string value2 = Strings.Mid(txttaikhoan2.Text, num3, 1);
                        num = 93;
                        if (Conversions.ToDouble(value2) == 0.0)
                        {
                            num = 94;
                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_0);
                        }
                        else
                        {
                            num = 96;
                            if (Conversions.ToDouble(value2) == 1.0)
                            {
                                num = 97;
                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_1);
                            }
                            else
                            {
                                num = 99;
                                if (Conversions.ToDouble(value2) == 2.0)
                                {
                                    num = 100;
                                    ADBHelper.Key(text, ADBKeyEvent.KEYCODE_2);
                                }
                                else
                                {
                                    num = 102;
                                    if (Conversions.ToDouble(value2) == 3.0)
                                    {
                                        num = 103;
                                        ADBHelper.Key(text, ADBKeyEvent.KEYCODE_3);
                                    }
                                    else
                                    {
                                        num = 105;
                                        if (Conversions.ToDouble(value2) == 4.0)
                                        {
                                            num = 106;
                                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_4);
                                        }
                                        else
                                        {
                                            num = 108;
                                            if (Conversions.ToDouble(value2) == 5.0)
                                            {
                                                num = 109;
                                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_5);
                                            }
                                            else
                                            {
                                                num = 111;
                                                if (Conversions.ToDouble(value2) == 6.0)
                                                {
                                                    num = 112;
                                                    ADBHelper.Key(text, ADBKeyEvent.KEYCODE_6);
                                                }
                                                else
                                                {
                                                    num = 114;
                                                    if (Conversions.ToDouble(value2) == 7.0)
                                                    {
                                                        num = 115;
                                                        ADBHelper.Key(text, ADBKeyEvent.KEYCODE_7);
                                                    }
                                                    else
                                                    {
                                                        num = 117;
                                                        if (Conversions.ToDouble(value2) == 8.0)
                                                        {
                                                            num = 118;
                                                            ADBHelper.Key(text, ADBKeyEvent.KEYCODE_8);
                                                        }
                                                        else
                                                        {
                                                            num = 120;
                                                            if (Conversions.ToDouble(value2) == 9.0)
                                                            {
                                                                num = 121;
                                                                ADBHelper.Key(text, ADBKeyEvent.KEYCODE_9);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        num = 123;
                        num3++;
                    }
                    while (num3 <= 10);
                    num = 124;
                    delay(1);
                    num = 125;
                    ADBHelper.Tap(text, 361, 667);
                    num = 126;
                    delay(2);
                    num = 127;
                    SENDTEXT(text, txtmatkhautiktok2.Text);
                    num = 128;
                    ADBHelper.Tap(text, 350, 679);
                    num = 129;
                    ADBHelper.Tap(text, 350, 679);
                    num = 130;
                    delay(1);
                    num = 131;
                    ADBHelper.Tap(text, 361, 667);
                    num = 132;
                    ADBHelper.Tap(text, 361, 681);
                    num = 133;
                    delay(5);
                    num = 134;
                    ADBHelper.ExecuteCMD("adb -s " + text + " shell screencap /mnt/sdcard/Download/manhinh2.png");
                    num = 135;
                    ADBHelper.ExecuteCMD("adb  -s " + text + " pull /mnt/sdcard/Download/manhinh2.png manhinh2.png");
                    num = 136;
                    txtstt.Text = "Kiểm tra Reg";
                    num = 137;
                    FileStream fileStream3 = new FileStream(Application.StartupPath + "\\sources\\Data\\oktiktok.png", FileMode.Open, FileAccess.Read);
                    num = 138;
                    FileStream fileStream4 = new FileStream("\\source\\manhinh2.png", FileMode.Open, FileAccess.Read);
                    num = 139;
                    Bitmap subBitmap2 = (Bitmap)Image.FromStream(fileStream3);
                    num = 140;
                    Bitmap mainBitmap2 = (Bitmap)Image.FromStream(fileStream4);
                    num = 141;
                    Point? point2 = ImageScanOpenCV.FindOutPoint(mainBitmap2, subBitmap2);
                    ProjectData.ClearProjectError();
                    num4 = -2;
                    num = 143;
                    ADBHelper.Tap(text, point2.Value.X, point2.Value.Y);
                    num = 144;
                    fileStream3.Close();
                    num = 145;
                    fileStream4.Close();
                    num = 146;
                    bool flag = false;
                    num = 156;
                    listtaikhoandone.Text = txtadd.Text + Environment.NewLine + listtaikhoandone.Text;
                    num = 157;
                    if (checksubtiktok2.Checked)
                    {
                        num = 158;
                        delay(2);
                        num = 159;
                        ADBHelper.Tap(text, 39, 681);
                        num = 160;
                        delay(2);
                        num = 161;
                        ADBHelper.Tap(text, 379, 35);
                        num = 162;
                        delay(2);
                        num = 163;
                        ADBHelper.Tap(text, 86, 32);
                        num = 164;
                        delay(2);
                        num = 165;
                        SENDTEXT(text, txtsubidtiktok2.Text);
                        num = 166;
                        delay(1);
                        num = 167;
                        ADBHelper.Tap(text, 361, 35);
                        num = 168;
                        delay(2);
                        num = 169;
                        ADBHelper.Tap(text, 101, 101);
                        num = 170;
                        delay(2);
                        num = 171;
                        ADBHelper.Tap(text, 332, 76);
                    }
                    num = 173;
                    delay(3);
                    num = 174;
                    ADBHelper.Tap(text, 39, 681);
                    num = 175;
                    if (checklove2.Checked)
                    {
                        num = 176;
                        delay(2);
                        num = 177;
                        ADBHelper.Tap(text, 53, 343);
                        num = 178;
                        delay(2);
                        num = 179;
                        ADBHelper.Tap(text, 379, 487);
                        num = 180;
                        int num5 = Conversions.ToInteger(txtvideo2.Text);
                        for (int i = 1; i <= num5; i++)
                        {
                            num = 181;
                            ADBHelper.Swipe(text, 197, 532, 198, 94);
                            num = 182;
                            delay(2);
                            num = 183;
                            ADBHelper.Tap(text, 379, 487);
                            num = 184;
                            if (checkcmt2.Checked)
                            {
                                num = 185;
                                Random random = new Random();
                                num = 186;
                                object objectValue = RuntimeHelpers.GetObjectValue(listcmt2.Items[random.Next(listcmt2.Items.Count)]);
                                num = 187;
                                string text2 = objectValue.ToString();
                                num = 188;
                                delay(2);
                                num = 189;
                                SENDTEXT(text, text2);
                                num = 190;
                                delay(2);
                                num = 191;
                                ADBHelper.Tap(text, 381, 677);
                                num = 192;
                                delay(2);
                                num = 193;
                                ADBHelper.Tap(text, 187, 258);
                            }
                            num = 195;
                        }
                    }
                    num = 197;
                    ADBHelper.Tap(text, 38, 681);
                    num = 198;
                    if (checktuongtac.Checked)
                    {
                        num = 199;
                        delay(2);
                        num = 200;
                        ADBHelper.Tap(text, 18, 38);
                        num = 201;
                        ADBHelper.Tap(text, 18, 38);
                        num = 202;
                        ADBHelper.Tap(text, 18, 38);
                        num = 203;
                        ADBHelper.Tap(text, 18, 38);
                        num = 204;
                        ADBHelper.Tap(text, 18, 38);
                        num = 205;
                        ADBHelper.Tap(text, 18, 38);
                        num = 206;
                        ADBHelper.Tap(text, 18, 38);
                        num = 207;
                        ADBHelper.Tap(text, 18, 38);
                        num = 208;
                        delay(2);
                        num = 209;
                        ADBHelper.Tap(text, 120, 680);
                        num = 210;
                        ADBHelper.Tap(text, 120, 680);
                        num = 211;
                        delay(2);
                        num = 212;
                        ADBHelper.Tap(text, 99, 169);
                        num = 213;
                        if (checklove2.Checked)
                        {
                            num = 214;
                            delay(2);
                            num = 215;
                            ADBHelper.Tap(text, 53, 343);
                            num = 216;
                            delay(2);
                            num = 217;
                            ADBHelper.Tap(text, 379, 487);
                            num = 218;
                            int num6 = Conversions.ToInteger(txtvideo23.Text);
                            for (int j = 1; j <= num6; j++)
                            {
                                num = 219;
                                ADBHelper.Swipe(text, 197, 532, 198, 94);
                                num = 220;
                                delay(2);
                                num = 221;
                                ADBHelper.Tap(text, 379, 487);
                                num = 222;
                                if (checkcmt2.Checked)
                                {
                                    num = 223;
                                    Random random2 = new Random();
                                    num = 224;
                                    object objectValue2 = RuntimeHelpers.GetObjectValue(listcmt2.Items[random2.Next(listcmt2.Items.Count)]);
                                    num = 225;
                                    string text3 = objectValue2.ToString();
                                    num = 226;
                                    delay(2);
                                    num = 227;
                                    SENDTEXT(text, text3);
                                    num = 228;
                                    delay(2);
                                    num = 229;
                                    ADBHelper.Tap(text, 381, 677);
                                    num = 230;
                                    delay(2);
                                    num = 231;
                                    ADBHelper.Tap(text, 187, 258);
                                }
                                num = 233;
                            }
                        }
                        num = 235;
                        ADBHelper.Tap(text, 38, 681);
                    }
                    num = 238;
                    listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, txtadd.Text, "");
                    num = 239;
                    Show();
                    num = 240;
                    btnbatdau4.Enabled = true;
                    num = 241;
                    lblstttiktok.Visible = false;
                    num = 242;
                    lbltime14.Visible = true;
                    num = 243;
                    lbltime14.Text = Conversions.ToString(30);
                    num = 244;
                    loadone.Visible = true;
                    num = 245;
                    Timer14.Start();
                    num = 246;
                    if (Operators.CompareString(listtaikhoan4.Text, "", TextCompare: false) == 0)
                    {
                        num = 247;
                        Show();
                        num = 248;
                        btnbatdau4.Enabled = false;
                        num = 249;
                        btndunglai4.Enabled = false;
                        num = 250;
                        lblstttiktok.Visible = true;
                        num = 251;
                        lbltime14.Visible = false;
                        num = 252;
                        Timer14.Stop();
                        num = 253;
                        lbltime14.Text = Conversions.ToString(30);
                        num = 254;
                        txtmaukhautiktok2.Text = "ĐÃ XONG";
                        num = 255;
                        txttaikhoan2.Text = "ĐÃ XONG";
                        num = 256;
                        Timer14.Stop();
                        num = 257;
                        lbltime14.Text = Conversions.ToString(30);
                        num = 258;
                        btnbatdau4.Enabled = false;
                        num = 259;
                        btndunglai4.Enabled = false;
                    }
                }
            }
            catch (Exception obj) when (obj is Exception && num4 != 0 && num7 == 0)
            {
                ProjectData.SetProjectError((Exception)obj);
                /*Error near IL_16f4: Could not find block for branch target IL_16bc*/
                ;
            }
            if (num7 != 0)
            {
                ProjectData.ClearProjectError();
            }
        }

        private void btndunglai4_Click(object sender, EventArgs e)
        {
            Show();
            btnbatdau4.Enabled = true;
            lblstttiktok.Visible = true;
            lbltime14.Visible = false;
            Timer14.Stop();
            lbltime14.Text = Conversions.ToString(30);
        }

        private void Timer14_Tick(object sender, EventArgs e)
        {
            Timer14.Interval = 1000;
            checked
            {
                if (Conversions.ToDouble(lbltime14.Text) == 30.0)
                {
                    List<string> list = new List<string>();
                    string[] lines = listtaikhoan4.Lines;
                    foreach (string text in lines)
                    {
                        if (!text.Trim().Equals(string.Empty))
                        {
                            list.Add(text);
                        }
                    }
                    listtaikhoan4.Lines = list.ToArray();
                    listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, " ", "");
                    listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\r\n", "");
                    listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\t", "");
                    listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\r\n", "");
                    string[] lines2 = listtaikhoan4.Lines;
                    string[] array = lines2;
                    int num = 0;
                    if (num < array.Length)
                    {
                        string text2 = array[num];
                        txttaikhoan2.Text = "";
                        txtmaukhautiktok2.Text = "";
                        string text3 = text2;
                        short num2 = (short)Strings.Len(text3);
                        for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1))
                        {
                            string text4 = Strings.Mid(text3, num3, 1);
                            if (Operators.CompareString(text4, "|", TextCompare: false) == 0)
                            {
                                break;
                            }
                            txttaikhoan2.Text += text4;
                        }
                        txtmaukhautiktok2.Text = Strings.Replace(text3, txttaikhoan2.Text + "|", "");
                        txtadd.Text = text3;
                        if (Operators.CompareString(listtaikhoan4.Text, "", TextCompare: false) == 0)
                        {
                            Show();
                            btnbatdau4.Enabled = false;
                            btndunglai4.Enabled = false;
                            lblstttiktok.Visible = true;
                            lbltime14.Visible = false;
                            Timer14.Stop();
                            lbltime14.Text = Conversions.ToString(30);
                            txtmaukhautiktok2.Text = "ĐÃ XONG";
                            txttaikhoan2.Text = "ĐÃ XONG";
                            Timer14.Stop();
                            lbltime14.Text = Conversions.ToString(30);
                            btnbatdau4.Enabled = false;
                            btndunglai4.Enabled = false;
                            return;
                        }
                    }
                    lbltime14.Text = Conversions.ToString(Conversions.ToDouble(lbltime14.Text) - 1.0);
                }
                else if (Conversions.ToDouble(lbltime14.Text) == 1.0)
                {
                    btnbatdau4.Enabled = true;
                    btnbatdau4.PerformClick();
                    btnbatdau4.Enabled = false;
                    Timer14.Stop();
                    lbltime14.Text = Conversions.ToString(30);
                }
                else
                {
                    lbltime14.Text = Conversions.ToString(Conversions.ToDouble(lbltime14.Text) - 1.0);
                }
            }
        }

        private void SimplaButton6_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            string[] lines = listtaikhoan4.Lines;
            foreach (string text in lines)
            {
                if (!text.Trim().Equals(string.Empty))
                {
                    list.Add(text);
                }
            }
            listtaikhoan4.Lines = list.ToArray();
            listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, " ", "");
            listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\r\n", "");
            listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\t", "");
            listtaikhoan4.Text = Strings.Replace(listtaikhoan4.Text, "\r\n", "");
            string[] lines2 = listtaikhoan4.Lines;
            string[] array = lines2;
            int num = 0;
            checked
            {
                if (num < array.Length)
                {
                    string text2 = array[num];
                    txttaikhoan2.Text = "";
                    txtmaukhautiktok2.Text = "";
                    string text3 = text2;
                    short num2 = (short)Strings.Len(text3);
                    for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1))
                    {
                        string text4 = Strings.Mid(text3, num3, 1);
                        if (Operators.CompareString(text4, "|", TextCompare: false) == 0)
                        {
                            break;
                        }
                        txttaikhoan2.Text += text4;
                    }
                    txtmaukhautiktok2.Text = Strings.Replace(text3, txttaikhoan2.Text + "|", "");
                    txtadd.Text = text3;
                    Interaction.MsgBox("Thêm thành công");
                    btnbatdau4.Enabled = true;
                    btndunglai4.Enabled = true;
                }
                if (Operators.CompareString(listtaikhoan4.Text, "", TextCompare: false) == 0)
                {
                    Show();
                    btnbatdau4.Enabled = false;
                    btndunglai4.Enabled = false;
                    lblstttiktok.Visible = true;
                    lbltime14.Visible = false;
                    Timer14.Stop();
                    lbltime14.Text = Conversions.ToString(30);
                    txtmaukhautiktok2.Text = "ĐÃ XONG";
                    txttaikhoan2.Text = "ĐÃ XONG";
                }
            }
        }

        private void checkcmt2_CheckedChanged(object sender)
        {
            if (checkcmt2.Checked && Operators.CompareString(lblxu.Text, "FREE", TextCompare: false) == 0)
            {
                Interaction.MsgBox("Nâng cấp VIP để sử dụng chức năng này");
                checkcmt2.Checked = false;
            }
        }

        private void Button8_Click_3(object sender, EventArgs e)
        {
            MyProject.MySettingsProperty.Settings.ngaychinh = 0;
            MyProject.MySettingsProperty.Settings.keyapi = "";
        }

        private void Button8_Click_2(object sender, EventArgs e)
        {
            MyProject.MySettingsProperty.Settings.ngaychinh = 0;
            MyProject.MySettingsProperty.Settings.keyapi = "";
        }
    }
}
