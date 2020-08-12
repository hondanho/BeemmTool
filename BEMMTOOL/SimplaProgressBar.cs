using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaProgressBar : Control
	{
		public enum ColorSchemes
		{
			DarkGray,
			Green,
			Blue,
			White,
			Red
		}

		private int OFS;

		private int Speed;

		private int _Maximum;

		private int _Value;

		private bool _ShowPercentage;

		private ColorSchemes _ColorScheme;

		public int Maximum
		{
			get
			{
				return _Maximum;
			}
			set
			{
				if (value < _Value)
				{
					_Value = value;
				}
				_Maximum = value;
				Invalidate();
			}
		}

		public int Value
		{
			get
			{
				if (_Value == 0)
				{
					return 0;
				}
				return _Value;
			}
			set
			{
				int num = value;
				if (num > _Maximum)
				{
					value = _Maximum;
				}
				_Value = value;
				Invalidate();
			}
		}

		public bool ShowPercentage
		{
			get
			{
				return _ShowPercentage;
			}
			set
			{
				_ShowPercentage = value;
				Invalidate();
			}
		}

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

		protected override void CreateHandle()
		{
			base.CreateHandle();
			Thread thread = new Thread(Animate);
			thread.IsBackground = true;
		}

		public void Animate()
		{
			checked
			{
				while (true)
				{
					if (OFS <= base.Width)
					{
						OFS++;
					}
					else
					{
						OFS = 0;
					}
					Invalidate();
					Thread.Sleep(Speed);
				}
			}
		}

		public SimplaProgressBar()
		{
			OFS = 0;
			Speed = 50;
			_Maximum = 100;
			_Value = 0;
			_ShowPercentage = false;
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.Transparent;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			checked
			{
				int num = (int)Math.Round((double)_Value / (double)_Maximum * (double)base.Width);
				graphics.Clear(BackColor);
				graphics.DrawPath(new Pen(new SolidBrush(Color.FromArgb(26, 26, 26))), Draw.RoundRect(new Rectangle(1, 1, base.Width - 3, base.Height - 3), 2));
				SolidBrush brush = new SolidBrush(Color.White);
				if (num != 0)
				{
					switch (ColorScheme)
					{
					case ColorSchemes.DarkGray:
					{
						LinearGradientBrush brush6 = new LinearGradientBrush(new Rectangle(2, 2, num - 5, base.Height - 5), Color.FromArgb(23, 23, 23), Color.FromArgb(17, 17, 17), 90f);
						graphics.FillPath(brush6, Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
						brush = new SolidBrush(Color.White);
						break;
					}
					case ColorSchemes.Green:
					{
						LinearGradientBrush brush5 = new LinearGradientBrush(new Rectangle(2, 2, num - 5, base.Height - 5), Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90f);
						graphics.FillPath(brush5, Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
						brush = new SolidBrush(Color.White);
						break;
					}
					case ColorSchemes.Blue:
					{
						LinearGradientBrush brush4 = new LinearGradientBrush(new Rectangle(2, 2, num - 5, base.Height - 5), Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90f);
						graphics.FillPath(brush4, Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
						brush = new SolidBrush(Color.White);
						break;
					}
					case ColorSchemes.White:
					{
						LinearGradientBrush brush3 = new LinearGradientBrush(new Rectangle(2, 2, num - 5, base.Height - 5), Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90f);
						graphics.FillPath(brush3, Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
						brush = new SolidBrush(Color.FromArgb(20, 20, 20));
						break;
					}
					case ColorSchemes.Red:
					{
						LinearGradientBrush brush2 = new LinearGradientBrush(new Rectangle(2, 2, num - 5, base.Height - 5), Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90f);
						graphics.FillPath(brush2, Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
						brush = new SolidBrush(Color.White);
						break;
					}
					}
				}
				graphics.DrawPath(new Pen(Color.FromArgb(190, 56, 56, 56)), Draw.RoundRect(new Rectangle(0, 0, base.Width - 1, base.Height - 1), 2));
				graphics.DrawPath(new Pen(Color.FromArgb(150, 97, 94, 90)), Draw.RoundRect(new Rectangle(2, 2, num - 5, base.Height - 5), 2));
				if (_ShowPercentage)
				{
					graphics.DrawString(Convert.ToString(Value + "%"), new Font("Tahoma", 9f, FontStyle.Bold), brush, new Rectangle(0, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
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
