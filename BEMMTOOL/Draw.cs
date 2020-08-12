using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BEMMTOOL
{
	[StandardModule]
	internal sealed class Draw
	{
		public static GraphicsPath RoundRect(Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			checked
			{
				int num = Curve * 2;
				graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, num, num), -180f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Y, num, num), -90f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.Width - num + Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 0f, 90f);
				graphicsPath.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - num + Rectangle.Y, num, num), 90f, 90f);
				graphicsPath.AddLine(new Point(Rectangle.X, Rectangle.Height - num + Rectangle.Y), new Point(Rectangle.X, Curve + Rectangle.Y));
				return graphicsPath;
			}
		}

		public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
		{
			Rectangle rectangle = new Rectangle(X, Y, Width, Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			checked
			{
				int num = Curve * 2;
				graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Y, num, num), -180f, 90f);
				graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Y, num, num), -90f, 90f);
				graphicsPath.AddArc(new Rectangle(rectangle.Width - num + rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 0f, 90f);
				graphicsPath.AddArc(new Rectangle(rectangle.X, rectangle.Height - num + rectangle.Y, num, num), 90f, 90f);
				graphicsPath.AddLine(new Point(rectangle.X, rectangle.Height - num + rectangle.Y), new Point(rectangle.X, Curve + rectangle.Y));
				return graphicsPath;
			}
		}
	}
}
