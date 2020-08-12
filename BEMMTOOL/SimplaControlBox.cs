using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaControlBox : Control
	{
		private MouseState State;

		private int X;

		private Rectangle MinBtn;

		private Rectangle CloseBtn;

		public SimplaControlBox()
		{
			State = MouseState.None;
			MinBtn = new Rectangle(0, 0, 32, 25);
			CloseBtn = new Rectangle(33, 0, 65, 25);
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.Transparent;
			ForeColor = Color.FromArgb(205, 205, 205);
			base.Size = new Size(52, 26);
			DoubleBuffered = true;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ((X > MinBtn.X) & (X < checked(MinBtn.X + 32)))
			{
				FindForm().WindowState = FormWindowState.Minimized;
			}
			else
			{
				FindForm().Close();
			}
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

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			X = e.Location.X;
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rectangle = new Rectangle(0, 0, 64, 25);
			Rectangle rectangle2 = new Rectangle(1, 1, 62, 23);
			base.OnPaint(e);
			graphics.Clear(BackColor);
			Font font = new Font("Marlett", 10f, FontStyle.Bold);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			checked
			{
				switch (State)
				{
				case MouseState.None:
					graphics.DrawString("r", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					graphics.DrawString("0", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Near,
						LineAlignment = StringAlignment.Center
					});
					break;
				case MouseState.Over:
					if ((X > MinBtn.X) & (X < MinBtn.X + 32))
					{
						graphics.DrawString("0", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Near,
							LineAlignment = StringAlignment.Center
						});
						graphics.DrawString("0", font, new SolidBrush(Color.FromArgb(95, Color.Green)), new Rectangle(8, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Near,
							LineAlignment = StringAlignment.Center
						});
						graphics.DrawString("r", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
					}
					else
					{
						graphics.DrawString("r", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
						graphics.DrawString("r", font, new SolidBrush(Color.FromArgb(95, Color.Red)), new Rectangle(17, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Center,
							LineAlignment = StringAlignment.Center
						});
						graphics.DrawString("0", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, base.Width - 1, base.Height - 1), new StringFormat
						{
							Alignment = StringAlignment.Near,
							LineAlignment = StringAlignment.Center
						});
					}
					break;
				case MouseState.Down:
					graphics.DrawString("r", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(17, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					});
					graphics.DrawString("0", font, new SolidBrush(Color.FromArgb(178, 178, 178)), new Rectangle(8, 1, base.Width - 1, base.Height - 1), new StringFormat
					{
						Alignment = StringAlignment.Near,
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
