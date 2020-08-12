using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace BEMMTOOL
{
	[DefaultEvent("CheckedChanged")]
	public class SimplaCheckBox : Control
	{
		public delegate void CheckedChangedEventHandler(object sender);

		public enum ColorSchemes
		{
			Green,
			Blue,
			White,
			Red
		}

		private MouseState State;

		private bool _Checked;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CheckedChangedEventHandler CheckedChangedEvent;

		private ColorSchemes _ColorScheme;

		public bool Checked
		{
			get
			{
				return _Checked;
			}
			set
			{
				_Checked = value;
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

		public event CheckedChangedEventHandler CheckedChanged
		{
			[CompilerGenerated]
			add
			{
				CheckedChangedEventHandler checkedChangedEventHandler = CheckedChangedEvent;
				CheckedChangedEventHandler checkedChangedEventHandler2;
				do
				{
					checkedChangedEventHandler2 = checkedChangedEventHandler;
					CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Combine(checkedChangedEventHandler2, value);
					checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
				}
				while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				CheckedChangedEventHandler checkedChangedEventHandler = CheckedChangedEvent;
				CheckedChangedEventHandler checkedChangedEventHandler2;
				do
				{
					checkedChangedEventHandler2 = checkedChangedEventHandler;
					CheckedChangedEventHandler value2 = (CheckedChangedEventHandler)Delegate.Remove(checkedChangedEventHandler2, value);
					checkedChangedEventHandler = Interlocked.CompareExchange(ref CheckedChangedEvent, value2, checkedChangedEventHandler2);
				}
				while ((object)checkedChangedEventHandler != checkedChangedEventHandler2);
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			State = MouseState.Over;
			Invalidate();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			State = MouseState.Down;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			State = MouseState.None;
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			State = MouseState.Over;
			Invalidate();
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Invalidate();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 16;
		}

		protected override void OnClick(EventArgs e)
		{
			_Checked = !_Checked;
			CheckedChangedEvent?.Invoke(this);
			base.OnClick(e);
		}

		public SimplaCheckBox()
		{
			State = MouseState.None;
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, value: true);
			BackColor = Color.Transparent;
			ForeColor = Color.Black;
			base.Size = new Size(145, 16);
			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = checked(new Rectangle(0, 0, base.Height - 1, base.Height - 1));
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			graphics.Clear(Color.Transparent);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.FromArgb(40, 40, 40), Color.FromArgb(30, 30, 30), 90f);
			graphics.FillRectangle(linearGradientBrush, linearGradientBrush.Rectangle);
			graphics.DrawRectangle(new Pen(Color.FromArgb(56, 56, 56)), rect);
			if (Checked)
			{
				Font font = new Font("Marlett", 20f, FontStyle.Regular);
				switch (ColorScheme)
				{
				case ColorSchemes.Green:
					graphics.DrawString("a", font, new SolidBrush(Color.FromArgb(159, 207, 1)), -9f, -7f);
					break;
				case ColorSchemes.Blue:
					graphics.DrawString("a", font, new SolidBrush(Color.FromArgb(0, 161, 207)), -9f, -7f);
					break;
				case ColorSchemes.White:
					graphics.DrawString("a", font, new SolidBrush(Color.FromArgb(254, 254, 254)), -9f, -7f);
					break;
				case ColorSchemes.Red:
					graphics.DrawString("a", font, new SolidBrush(Color.FromArgb(209, 1, 1)), -9f, -7f);
					break;
				}
			}
			Font font2 = new Font("Tahoma", 10f, FontStyle.Bold);
			Brush brush = new SolidBrush(Color.FromArgb(200, 200, 200));
			graphics.DrawString(Text, font2, brush, new Point(19, 9), new StringFormat
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Center
			});
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
