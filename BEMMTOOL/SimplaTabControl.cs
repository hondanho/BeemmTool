using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaTabControl : TabControl
	{
		public enum ColorSchemes
		{
			DarkGray,
			Green,
			Blue,
			White,
			Red
		}

		private Color mainBackground;

		private Color topBackground;

		private Color activeTabColor;

		private ColorSchemes _ColorScheme;

		private Color _textColor;

		public ColorSchemes ColorScheme
		{
			get
			{
				return _ColorScheme;
			}
			set
			{
				_ColorScheme = value;
				Invalidate();
			}
		}

		public SimplaTabControl()
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			DoubleBuffered = true;
			BackColor = Color.FromArgb(34, 34, 34);
			topBackground = Color.FromArgb(34, 34, 34);
			mainBackground = Color.FromArgb(34, 34, 34);
			ForeColor = Color.White;
			_textColor = ForeColor;
			activeTabColor = Color.FromArgb(20, 20, 20);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			base.OnPaint(e);
			try
			{
				base.SelectedTab.BackColor = mainBackground;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			graphics.Clear(topBackground);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			switch (ColorScheme)
			{
			case ColorSchemes.DarkGray:
				activeTabColor = Color.FromArgb(10, 10, 10);
				_textColor = Color.White;
				break;
			case ColorSchemes.Green:
				activeTabColor = Color.FromArgb(94, 165, 1);
				_textColor = Color.White;
				break;
			case ColorSchemes.Blue:
				activeTabColor = Color.FromArgb(0, 97, 166);
				_textColor = Color.White;
				break;
			case ColorSchemes.White:
				activeTabColor = Color.FromArgb(245, 245, 245);
				_textColor = Color.FromArgb(36, 36, 36);
				break;
			case ColorSchemes.Red:
				activeTabColor = Color.FromArgb(170, 0, 0);
				_textColor = Color.White;
				break;
			}
			checked
			{
				int num = base.TabPages.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Rectangle rectangle = new Rectangle(GetTabRect(i).X + 3, GetTabRect(i).Y, GetTabRect(i).Width - 5, GetTabRect(i).Height);
					graphics.FillRectangle(new SolidBrush(mainBackground), rectangle);
					graphics.DrawString(base.TabPages[i].Text, new Font("Tahoma", 9f, FontStyle.Bold), new SolidBrush(ForeColor), rectangle, new StringFormat
					{
						LineAlignment = StringAlignment.Center,
						Alignment = StringAlignment.Center
					});
				}
				graphics.FillRectangle(new SolidBrush(mainBackground), 0, base.ItemSize.Height, base.Width, base.Height);
				if (base.SelectedIndex != -1)
				{
					Rectangle rectangle2 = new Rectangle(GetTabRect(base.SelectedIndex).X + 3, GetTabRect(base.SelectedIndex).Y, GetTabRect(base.SelectedIndex).Width - 5, GetTabRect(base.SelectedIndex).Height);
					graphics.FillPath(new SolidBrush(activeTabColor), Draw.RoundRect(rectangle2, 4));
					graphics.DrawPath(new Pen(new SolidBrush(Color.FromArgb(20, 20, 20))), Draw.RoundRect(rectangle2, 4));
					graphics.DrawString(base.TabPages[base.SelectedIndex].Text, new Font("Tahoma", 9f, FontStyle.Bold), new SolidBrush(_textColor), rectangle2, new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
				}
				e.Graphics.DrawImage(bitmap, new Point(0, 0));
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
	}
}
