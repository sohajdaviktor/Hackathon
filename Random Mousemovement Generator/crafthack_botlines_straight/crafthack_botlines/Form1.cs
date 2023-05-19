namespace crafthack_botlines
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private Random rand;
        private int numLines = 40;
        private Point[] points;
        private int radius = 5;
        private int margin = 100;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            points = new Point[numLines];
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            points[0] = new Point(rand.Next(margin, pictureBox1.Width - margin), rand.Next(margin, pictureBox1.Height - margin));

            for (int i = 1; i < numLines; i++)
            {
                var prevPoint = points[i - 1];


                double prevAngle = i > 1 ? Math.Atan2(points[i - 1].Y - points[i - 2].Y, points[i - 1].X - points[i - 2].X) : 0;

                double angle = prevAngle + (-65 + 130 * rand.NextDouble()) * Math.PI / 180;



                int length = rand.Next(50, 300);

                int x = prevPoint.X + (int)(length * Math.Cos(angle));
                int y = prevPoint.Y + (int)(length * Math.Sin(angle));

                x = Math.Max(Math.Min(x, pictureBox1.Width - margin), margin);
                y = Math.Max(Math.Min(y, pictureBox1.Height - margin), margin);

                points[i] = new Point(x, y);
            }

            for (int i = 1; i < numLines; i++)
            {
                g.DrawLine(Pens.Black, points[i - 1], points[i]);
                g.FillEllipse(Brushes.Red, points[i].X - radius, points[i].Y - radius, radius * 2, radius * 2);
            }
        }
    }


}