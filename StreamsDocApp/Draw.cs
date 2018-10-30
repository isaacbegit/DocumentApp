using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace StreamsDocApp
{
	internal static class Draw
	{
		private static GraphicsPath CreateRoundPath;

		private static Rectangle CreateCreateRoundangle;

		public static GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
		{
			Draw.CreateCreateRoundangle = new Rectangle(x, y, width, height);
			return Draw.CreateRound(Draw.CreateCreateRoundangle, slope);
		}

		public static GraphicsPath CreateRound(Rectangle r, int slope)
		{
			Draw.CreateRoundPath = new GraphicsPath(FillMode.Winding);
			Draw.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
			Draw.CreateRoundPath.AddArc(checked(r.Right - slope), r.Y, slope, slope, 270f, 90f);
			Draw.CreateRoundPath.AddArc(checked(r.Right - slope), checked(r.Bottom - slope), slope, slope, 0f, 90f);
			Draw.CreateRoundPath.AddArc(r.X, checked(r.Bottom - slope), slope, slope, 90f, 90f);
			Draw.CreateRoundPath.CloseFigure();
			return Draw.CreateRoundPath;
		}

		public static SolidBrush GetBrush(Color c)
		{
			return new SolidBrush(c);
		}

		public static Pen GetPen(Color c)
		{
			return new Pen(new SolidBrush(c));
		}

		public static void InnerGlow(Graphics G, System.Drawing.Rectangle Rectangle, Color[] Colors)
		{
			int num = 1;
			int num1 = 0;
			Color[] colors = Colors;
			for (int i = 0; i < checked((int)colors.Length); i = checked(i + 1))
			{
				Color color = colors[i];
				G.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb((int)color.R, (int)color.B, (int)color.G))), checked(Rectangle.X + num1), checked(Rectangle.Y + num1), checked(Rectangle.Width - num), checked(Rectangle.Height - num));
				num = checked(num + 2);
				num1 = checked(num1 + 1);
			}
		}

		public static void InnerGlowRounded(Graphics G, System.Drawing.Rectangle Rectangle, int Degree, Color[] Colors)
		{
			int num = 1;
			int num1 = 0;
			Color[] colors = Colors;
			for (int i = 0; i < checked((int)colors.Length); i = checked(i + 1))
			{
				Color color = colors[i];
				G.DrawPath(new Pen(new SolidBrush(Color.FromArgb((int)color.R, (int)color.B, (int)color.G))), Draw.CreateRound(checked(Rectangle.X + num1), checked(Rectangle.Y + num1), checked(Rectangle.Width - num), checked(Rectangle.Height - num), Degree));
				num = checked(num + 2);
				num1 = checked(num1 + 1);
			}
		}

		public static TextureBrush NoiseBrush(Color[] colors)
		{
			Bitmap bitmap = new Bitmap(128, 128);
			Random random = new Random(128);
			int width = checked(bitmap.Width - 1);
			for (int i = 0; i <= width; i = checked(i + 1))
			{
				int height = checked(bitmap.Height - 1);
				for (int j = 0; j <= height; j = checked(j + 1))
				{
					bitmap.SetPixel(i, j, colors[random.Next(checked((int)colors.Length))]);
				}
			}
			TextureBrush textureBrush = new TextureBrush(bitmap);
			bitmap.Dispose();
			return textureBrush;
		}

		public static GraphicsPath RoundRect(System.Drawing.Rectangle Rectangle, int Curve)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int curve = checked(Curve * 2);
			System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(Rectangle.X, Rectangle.Y, curve, curve);
			graphicsPath.AddArc(rectangle, -180f, 90f);
			rectangle = new System.Drawing.Rectangle(checked(checked(Rectangle.Width - curve) + Rectangle.X), Rectangle.Y, curve, curve);
			graphicsPath.AddArc(rectangle, -90f, 90f);
			rectangle = new System.Drawing.Rectangle(checked(checked(Rectangle.Width - curve) + Rectangle.X), checked(checked(Rectangle.Height - curve) + Rectangle.Y), curve, curve);
			graphicsPath.AddArc(rectangle, 0f, 90f);
			rectangle = new System.Drawing.Rectangle(Rectangle.X, checked(checked(Rectangle.Height - curve) + Rectangle.Y), curve, curve);
			graphicsPath.AddArc(rectangle, 90f, 90f);
			Point point = new Point(Rectangle.X, checked(checked(Rectangle.Height - curve) + Rectangle.Y));
			Point point1 = new Point(Rectangle.X, checked(Curve + Rectangle.Y));
			graphicsPath.AddLine(point, point1);
			return graphicsPath;
		}

		public static GraphicsPath RoundRect(int X, int Y, int Width, int Height, int Curve)
		{
			Rectangle rectangle = new Rectangle(X, Y, Width, Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			int curve = checked(Curve * 2);
			Rectangle rectangle1 = new Rectangle(rectangle.X, rectangle.Y, curve, curve);
			graphicsPath.AddArc(rectangle1, -180f, 90f);
			rectangle1 = new Rectangle(checked(checked(rectangle.Width - curve) + rectangle.X), rectangle.Y, curve, curve);
			graphicsPath.AddArc(rectangle1, -90f, 90f);
			rectangle1 = new Rectangle(checked(checked(rectangle.Width - curve) + rectangle.X), checked(checked(rectangle.Height - curve) + rectangle.Y), curve, curve);
			graphicsPath.AddArc(rectangle1, 0f, 90f);
			rectangle1 = new Rectangle(rectangle.X, checked(checked(rectangle.Height - curve) + rectangle.Y), curve, curve);
			graphicsPath.AddArc(rectangle1, 90f, 90f);
			Point point = new Point(rectangle.X, checked(checked(rectangle.Height - curve) + rectangle.Y));
			Point point1 = new Point(rectangle.X, checked(Curve + rectangle.Y));
			graphicsPath.AddLine(point, point1);
			return graphicsPath;
		}
	}
}