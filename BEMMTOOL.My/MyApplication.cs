using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;

namespace BEMMTOOL.My
{
	internal class MyApplication : WindowsFormsApplicationBase
	{
		[STAThread]
		internal static void Main(string[] Args)
		{
			try
			{
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
			}
			finally
			{
			}
			MyProject.Application.Run(Args);
		}

		public MyApplication()
			: base(AuthenticationMode.ApplicationDefined)
		{
			base.IsSingleInstance = true;
			base.EnableVisualStyles = true;
			base.SaveMySettingsOnExit = true;
			base.ShutdownStyle = ShutdownMode.AfterAllFormsClose;
		}

		protected override void OnCreateMainForm()
		{
			base.MainForm = MyProject.Forms.trangchu;
		}

		protected override void OnCreateSplashScreen()
		{
			base.SplashScreen = MyProject.Forms.loading;
		}
	}
}
