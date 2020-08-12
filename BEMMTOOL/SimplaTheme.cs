using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaTheme : ContainerControl
	{
		private Point MouseP;

		private bool Cap;

		private int MoveHeight;

		private int pos;

		public SimplaTheme()
		{
			MouseP = new Point(0, 0);
			Cap = false;
			MoveHeight = 40;
			pos = 0;
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.FromArgb(25, 25, 25);
			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//Discarded unreachable code: IL_01e3, IL_01f7, IL_0219
			int num = default(int);
			int num2 = default(int);
			try
			{
				ProjectData.ClearProjectError();
				num = 2;
				Bitmap bitmap = new Bitmap(base.Width, base.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				checked
				{
					Rectangle rect = new Rectangle(0, 0, base.Width - 1, 40);
					Rectangle rect2 = new Rectangle(0, 40, base.Width, base.Height);
					base.OnPaint(e);
					graphics.Clear(Color.Fuchsia);
					graphics.SetClip(Draw.RoundRect(new Rectangle(0, 0, base.Width, base.Height), 9));
					SolidBrush brush = new SolidBrush(Color.FromArgb(34, 34, 34));
					graphics.FillRectangle(brush, rect2);
					LinearGradientBrush brush2 = new LinearGradientBrush(rect, Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90f);
					graphics.FillRectangle(brush2, rect);
					graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(56, 56, 56))), 0, 40, base.Width - 1, 40);
					graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(42, 42, 42))), 0, 41, base.Width - 1, 41);
					graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(12, 12, 12))), new Rectangle(0, 0, base.Width - 1, base.Height - 1));
					Font font = new Font("Calibri (Body)", 15f, FontStyle.Bold);
					graphics.DrawString(FindForm().Text, font, new SolidBrush(Color.FromArgb(225, 225, 225)), 3f, 18f);
					NewLateBinding.LateCall(e.Graphics, null, "DrawImage", new object[3]
					{
						bitmap.Clone(),
						0,
						0
					}, null, null, null, IgnoreReturn: true);
					graphics.Dispose();
					bitmap.Dispose();
				}
			}
			catch (Exception obj) when (obj is Exception && num != 0 && num2 == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				/*Error near IL_0217: Could not find block for branch target IL_01e3*/;
			}
			if (num2 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ((e.Button == MouseButtons.Left) & new Rectangle(0, 0, base.Width, MoveHeight).Contains(e.Location))
			{
				Cap = true;
				MouseP = e.Location;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			Cap = false;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (Cap)
			{
				base.Parent.Location = Control.MousePosition - (Size)MouseP;
			}
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.ParentForm.FormBorderStyle = FormBorderStyle.None;
			base.ParentForm.TransparencyKey = Color.Fuchsia;
			Dock = DockStyle.Fill;
		}
	}
}
