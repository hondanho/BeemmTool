using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
	public class SimplaRadioButton : Control
	{
		public delegate void CheckedChangedEventHandler(object sender);

		public enum ColorSchemes
		{
			Green,
			Blue,
			White,
			Red
		}

		private Rectangle R1;

		private LinearGradientBrush G1;

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
				InvalidateControls();
				CheckedChangedEvent?.Invoke(this);
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

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 16;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			Invalidate();
		}

		protected override void OnClick(EventArgs e)
		{
			if (!_Checked)
			{
				Checked = true;
			}
			base.OnClick(e);
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			InvalidateControls();
		}

		private void InvalidateControls()
		{
			if (!base.IsHandleCreated || !_Checked)
			{
				return;
			}
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = base.Parent.Controls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Control control = (Control)enumerator.Current;
					if (control != this && control is SimplaRadioButton)
					{
						((SimplaRadioButton)control).Checked = false;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		public SimplaRadioButton()
		{
			State = MouseState.None;
			SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, value: true);
			BackColor = Color.Transparent;
			ForeColor = Color.Black;
			base.Size = new Size(150, 16);
			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			checked
			{
				Rectangle rect = new Rectangle(0, 0, base.Height - 1, base.Height - 1);
				Rectangle rect2 = new Rectangle(3, 3, base.Height - 7, base.Height - 7);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				graphics.Clear(BackColor);
				LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(40, 40, 40), Color.FromArgb(30, 30, 30), 90f);
				graphics.FillRectangle(brush, rect);
				graphics.DrawRectangle(new Pen(Color.FromArgb(56, 56, 56)), rect);
				if (Checked)
				{
					switch (ColorScheme)
					{
					case ColorSchemes.Green:
					{
						LinearGradientBrush brush5 = new LinearGradientBrush(rect2, Color.FromArgb(121, 185, 0), Color.FromArgb(94, 165, 1), 90f);
						graphics.FillRectangle(brush5, rect2);
						graphics.DrawRectangle(new Pen(Color.FromArgb(159, 207, 1)), rect2);
						break;
					}
					case ColorSchemes.Blue:
					{
						LinearGradientBrush brush4 = new LinearGradientBrush(rect2, Color.FromArgb(0, 124, 186), Color.FromArgb(0, 97, 166), 90f);
						graphics.FillRectangle(brush4, rect2);
						graphics.DrawRectangle(new Pen(Color.FromArgb(0, 161, 207)), rect2);
						break;
					}
					case ColorSchemes.White:
					{
						LinearGradientBrush brush3 = new LinearGradientBrush(rect2, Color.FromArgb(245, 245, 245), Color.FromArgb(246, 246, 246), 90f);
						graphics.FillRectangle(brush3, rect2);
						graphics.DrawRectangle(new Pen(Color.FromArgb(254, 254, 254)), rect2);
						break;
					}
					case ColorSchemes.Red:
					{
						LinearGradientBrush brush2 = new LinearGradientBrush(rect2, Color.FromArgb(185, 0, 0), Color.FromArgb(170, 0, 0), 90f);
						graphics.FillRectangle(brush2, rect2);
						graphics.DrawRectangle(new Pen(Color.FromArgb(209, 1, 1)), rect2);
						break;
					}
					}
				}
				Font font = new Font("Tahoma", 10f, FontStyle.Bold);
				Brush brush6 = new SolidBrush(Color.FromArgb(200, 200, 200));
				graphics.DrawString(Text, font, brush6, new Point(19, 8), new StringFormat
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
}
