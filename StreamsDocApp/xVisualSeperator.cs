using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace StreamsDocApp
{
	public class xVisualSeperator : Control
	{
		private xVisualSeperator.LineStyle _Style;

		public xVisualSeperator.LineStyle Style
		{
			get
			{
				return this._Style;
			}
			set
			{
				this._Style = value;
				this.Invalidate();
			}
		}

		public xVisualSeperator()
		{
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(205, 205, 205);
			this._Style = xVisualSeperator.LineStyle.Horizontal;
			this.Size = new System.Drawing.Size(174, 3);
			this.DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(this.Width, this.Height);
			Graphics graphic = Graphics.FromImage(bitmap);
			base.OnPaint(e);
			this.Size = this.Size;
			this._Style = this.Style;
			graphic.Clear(this.BackColor);
			graphic.SmoothingMode = SmoothingMode.HighQuality;
			switch (this._Style)
			{
				case xVisualSeperator.LineStyle.Horizontal:
				{
					graphic.DrawLine(Draw.GetPen(Color.Black), 0, 0, checked(this.Width - 1), checked(this.Height - 3));
					graphic.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 0, 1, checked(this.Width - 1), checked(this.Height - 2));
					break;
				}
				case xVisualSeperator.LineStyle.Vertical:
				{
					graphic.DrawLine(Draw.GetPen(Color.Black), 0, 0, 0, checked(this.Height - 1));
					graphic.DrawLine(Draw.GetPen(Color.FromArgb(99, 97, 94)), 1, 0, 1, checked(this.Height - 1));
					break;
				}
			}
			Graphics graphics = e.Graphics;
			object[] objectValue = new object[] { RuntimeHelpers.GetObjectValue(bitmap.Clone()), 0, 0 };
			NewLateBinding.LateCall(graphics, null, "DrawImage", objectValue, null, null, null, true);
			graphic.Dispose();
			bitmap.Dispose();
		}

		public enum LineStyle
		{
			Horizontal,
			Vertical
		}
	}
}