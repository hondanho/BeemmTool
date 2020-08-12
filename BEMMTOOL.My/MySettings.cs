using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Threading;
using static BEMMTOOL.My.MyProject;

namespace BEMMTOOL.My
{
	internal class MyComputer : Microsoft.VisualBasic.Devices.Computer
    {
		public MyComputer()
		{
		}
	}

	internal sealed class MySettings : ApplicationSettingsBase
	{
		private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());
		private static bool addedHandler;
		private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

		public static MySettings Default
		{
			get
			{
				if (!addedHandler)
				{
					object obj = addedHandlerLockObject;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(obj, ref lockTaken);
						if (!addedHandler)
						{
							MyProject.Application.Shutdown += delegate
							{
								if (MyProject.Application.SaveMySettingsOnExit)
								{
									MySettingsProperty.Settings.Save();
								}
							};
							addedHandler = true;
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(obj);
						}
					}
				}
				return defaultInstance;
			}
		}

		[UserScopedSetting]
		public string ho
		{
			get
			{
				return Conversions.ToString(this["ho"]);
			}
			set
			{
				this["ho"] = value;
			}
		}

		[UserScopedSetting]
		public string ten
		{
			get
			{
				return Conversions.ToString(this["ten"]);
			}
			set
			{
				this["ten"] = value;
			}
		}

		[UserScopedSetting]
		public string matkhau
		{
			get
			{
				return Conversions.ToString(this["matkhau"]);
			}
			set
			{
				this["matkhau"] = value;
			}
		}

		[UserScopedSetting]
		public string subid
		{
			get
			{
				return Conversions.ToString(this["subid"]);
			}
			set
			{
				this["subid"] = value;
			}
		}

		[UserScopedSetting]
		public string pageid
		{
			get
			{
				return Conversions.ToString(this["pageid"]);
			}
			set
			{
				this["pageid"] = value;
			}
		}

		[UserScopedSetting]
		public string folder
		{
			get
			{
				return Conversions.ToString(this["folder"]);
			}
			set
			{
				this["folder"] = value;
			}
		}

		[UserScopedSetting]
		public string usename
		{
			get
			{
				return Conversions.ToString(this["usename"]);
			}
			set
			{
				this["usename"] = value;
			}
		}

		[UserScopedSetting]
		public string accesskey
		{
			get
			{
				return Conversions.ToString(this["accesskey"]);
			}
			set
			{
				this["accesskey"] = value;
			}
		}

		[UserScopedSetting]
		public string time
		{
			get
			{
				return Conversions.ToString(this["time"]);
			}
			set
			{
				this["time"] = value;
			}
		}

		[UserScopedSetting]
		public string taikhoanverify
		{
			get
			{
				return Conversions.ToString(this["taikhoanverify"]);
			}
			set
			{
				this["taikhoanverify"] = value;
			}
		}

		[UserScopedSetting]
		public string keyapi
		{
			get
			{
				return Conversions.ToString(this["keyapi"]);
			}
			set
			{
				this["keyapi"] = value;
			}
		}

		[UserScopedSetting]
		public string ngay
		{
			get
			{
				return Conversions.ToString(this["ngay"]);
			}
			set
			{
				this["ngay"] = value;
			}
		}

		[UserScopedSetting]
		public string ngayhethan
		{
			get
			{
				return Conversions.ToString(this["ngayhethan"]);
			}
			set
			{
				this["ngayhethan"] = value;
			}
		}

		[UserScopedSetting]
		public int ngaymua
		{
			get
			{
				return Conversions.ToInteger(this["ngaymua"]);
			}
			set
			{
				this["ngaymua"] = value;
			}
		}

		[UserScopedSetting]
		public string thangmua
		{
			get
			{
				return Conversions.ToString(this["thangmua"]);
			}
			set
			{
				this["thangmua"] = value;
			}
		}

		[UserScopedSetting]
		public string ngaydamuane
		{
			get
			{
				return Conversions.ToString(this["ngaydamuane"]);
			}
			set
			{
				this["ngaydamuane"] = value;
			}
		}

		[UserScopedSetting]
		public string listtaikhoanmail
		{
			get
			{
				return Conversions.ToString(this["listtaikhoanmail"]);
			}
			set
			{
				this["listtaikhoanmail"] = value;
			}
		}

		[UserScopedSetting]
		public int ngaychinh
		{
			get
			{
				return Conversions.ToInteger(this["ngaychinh"]);
			}
			set
			{
				this["ngaychinh"] = value;
			}
		}

		[UserScopedSetting]
		public string listtiktok
		{
			get
			{
				return Conversions.ToString(this["listtiktok"]);
			}
			set
			{
				this["listtiktok"] = value;
			}
		}

		private static void AutoSaveSettings(object sender, EventArgs e)
		{
			if (MyProject.Application.SaveMySettingsOnExit)
			{
                MyProject.MySettingsProperty.Settings.Save();
			}
		}
	}
}
