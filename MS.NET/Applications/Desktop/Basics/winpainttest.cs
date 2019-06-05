using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello World!";
		this.Size = new Size(400, 400);
		this.BackColor = Color.FromArgb(255, 255, 255);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using(var br = new SolidBrush(Color.Red))
			e.Graphics.FillEllipse(br, 100, 100, 200, 200);

		using(var pn = new Pen(Color.Blue, 5))
			e.Graphics.DrawEllipse(pn, 100, 100, 200, 200);
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}
