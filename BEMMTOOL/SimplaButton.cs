using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaButton : Control
	{
		public enum ColorSchemes
		{
			DarkGray,
			Green,
			Blue,
			White,
			Red
		}

		private MouseState State;

		private ColorSchemes _ColorScheme;

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

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			State = MouseState.Down;
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			State = MouseState.Over;
			Invalidate();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			State = MouseState.Over;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			State = MouseState.None;
			Invalidate();
		}

		public SimplaButton()
		{
			State = MouseState.None;
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.Transparent;
			ForeColor = Color.FromArgb(205, 205, 205);
			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
				Rectangle rectangle2 = new Rectangle(1, 1, base.Width - 3, base.Height - 3);
				base.OnPaint(e);
				graphics.Clear(BackColor);
				Font font = new Font("Calibri (Body)", 10f, FontStyle.Bold);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				switch (ColorScheme)
				{
				case ColorSchemes.DarkGray:
				{
					LinearGradientBrush brush5 = new LinearGradientBrush(rectangle, Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90f);
					graphics.FillPath(brush5, Draw.RoundRect(rectangle, 4));
					Pen pen9 = new Pen(new SolidBrush(Color.FromArgb(56, 56, 56)));
					graphics.DrawPath(pen9, Draw.RoundRect(rectangle, 4));
					Pen pen10 = new Pen(new SolidBrush(Color.FromArgb(5, 240, 240, 240)));
					graphics.DrawPath(pen10, Draw.RoundRect(rectangle2, 4));
					break;
				}
				case ColorSchemes.Green:
				{
					LinearGradientBrush brush4 = new LinearGradientBrush(rectangle, Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90f);
					graphics.FillPath(brush4, Draw.RoundRect(rectangle, 4));
					Pen pen7 = new Pen(new SolidBrush(Color.FromArgb(159, 207, 1)));
					graphics.DrawPath(pen7, Draw.RoundRect(rectangle, 4));
					Pen pen8 = new Pen(new SolidBrush(Color.FromArgb(30, 240, 240, 240)));
					graphics.DrawPath(pen8, Draw.RoundRect(rectangle2, 4));
					break;
				}
				case ColorSchemes.Blue:
				{
					LinearGradientBrush brush3 = new LinearGradientBrush(rectangle, Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90f);
					graphics.FillPath(brush3, Draw.RoundRect(rectangle, 4));
					Pen pen5 = new Pen(new SolidBrush(Color.FromArgb(0, 161, 207)));
					graphics.DrawPath(pen5, Draw.RoundRect(rectangle, 4));
					Pen pen6 = new Pen(new SolidBrush(Color.FromArgb(10, 240, 240, 240)));
					graphics.DrawPath(pen6, Draw.RoundRect(rectangle2, 4));
					break;
				}
				case ColorSchemes.White:
				{
					LinearGradientBrush brush2 = new LinearGradientBrush(rectangle, Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90f);
					graphics.FillPath(brush2, Draw.RoundRect(rectangle, 4));
					Pen pen3 = new Pen(new SolidBrush(Color.FromArgb(254, 254, 254)));
					graphics.DrawPath(pen3, Draw.RoundRect(rectangle, 4));
					Pen pen4 = new Pen(new SolidBrush(Color.FromArgb(10, 240, 240, 240)));
					graphics.DrawPath(pen4, Draw.RoundRect(rectangle2, 4));
					break;
				}
				case ColorSchemes.Red:
				{
					LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90f);
					graphics.FillPath(brush, Draw.RoundRect(rectangle, 4));
					Pen pen = new Pen(new SolidBrush(Color.FromArgb(209, 1, 1)));
					graphics.DrawPath(pen, Draw.RoundRect(rectangle, 4));
					Pen pen2 = new Pen(new SolidBrush(Color.FromArgb(2, 240, 240, 240)));
					graphics.DrawPath(pen2, Draw.RoundRect(rectangle2, 4));
					break;
				}
				}
				switch (State)
				{
				case MouseState.None:
					if (ColorScheme == ColorSchemes.White)
					{
						graphics.DrawString(Text, font, new SolidBrush(Color.FromArgb(51, 51, 51)), new Rectangle(0, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						LinearGradientBrush brush6 = new LinearGradientBrush(rectangle, Color.FromArgb(235, 235, 235), Color.FromArgb(212, 212, 212), 90f);
						graphics.DrawString(Text, font, brush6, new Rectangle(0, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				case MouseState.Over:
					graphics.DrawString(Text, font, new SolidBrush(Color.Silver), new Rectangle(0, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					break;
				case MouseState.Down:
					graphics.DrawString(Text, font, new SolidBrush(Color.DimGray), new Rectangle(0, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					break;
				}
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
	}
}
