using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_Generator
{
	public class ProgressLoader : Form
	{
		private System.Windows.Forms.Timer animationTimer;
		private int currentAngle = 0;

		public ProgressLoader()
		{
			// Set form properties for transparency
			this.FormBorderStyle = FormBorderStyle.None;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Width = 100;
			this.Height = 100;
			this.BackColor = Color.Lime;
			this.TransparencyKey = Color.Lime;
			this.TopMost = true; // Ensure the form stays on top

			// Double buffering to reduce flicker
			this.DoubleBuffered = true;

			// Initialize the animation timer
			animationTimer = new System.Windows.Forms.Timer();
			animationTimer.Interval = 75; // milliseconds
			animationTimer.Tick += AnimationTimer_Tick;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			animationTimer.Start();
		}

		private void AnimationTimer_Tick(object sender, EventArgs e)
		{
			// Calculate the angle of the animation
			currentAngle += 45;
			if (currentAngle >= 360)
				currentAngle = 0;

			// Invalidate the form to trigger a repaint
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			PaintLoadingCursor(e.Graphics);
		}

		private void PaintLoadingCursor(Graphics graphics)
		{
			// Remove pixelation
			graphics.SmoothingMode = SmoothingMode.AntiAlias;

			// Calculate the size and position of the cursor
			int cursorSize = 30;
			int cursorX = (this.Width / 2) - (cursorSize / 2);
			int cursorY = (this.Height / 2) - (cursorSize / 2);
			int brushWidth = 6;

			// Draw base image
			using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(93, 93, 93), Color.FromArgb(0, 0, 255), LinearGradientMode.Vertical))
			{
				using (Pen pen = new Pen(brush, brushWidth))
				{
					pen.DashStyle = DashStyle.Dot;
					graphics.DrawArc(pen, cursorX, cursorY, cursorSize, cursorSize, 0, 360);
				}
			}

			// Draw the animation effect
			using (SolidBrush brush = new SolidBrush(Color.White))
			{
				using (Pen pen = new Pen(brush, brushWidth))
				{
					pen.DashStyle = DashStyle.Dot;
					graphics.DrawArc(pen, cursorX, cursorY, cursorSize, cursorSize, currentAngle, 90);
				}
			}
		}

		public void StopLoading()
		{
			animationTimer.Stop();
			this.Close();
		}

		public static async Task ShowLoader(Func<Task> action)
		{
			var loader = new ProgressLoader();
			var tcs = new TaskCompletionSource<bool>();

			loader.Shown += async (sender, e) =>
			{
				await Task.Delay(100); // Small delay to ensure loading screen visibility
				try
				{
					await action();
				}
				finally
				{
					loader.StopLoading();
					tcs.SetResult(true);
				}
			};

			var loadingThread = new System.Threading.Thread(() => Application.Run(loader));
			loadingThread.Start();

			await tcs.Task;
		}
	}
}
