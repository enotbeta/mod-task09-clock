using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace clocks
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            Timer aTimer = new Timer { Interval = 1000 };
            aTimer.Tick += aTimer_Tick;
            aTimer.Start();
        }
        private void aTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1000;
            Height = 1000;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int r = 250;
            Graphics g = e.Graphics;
            Point middle = new Point(Width / 2, Height / 2);
            g.TranslateTransform(middle.X, middle.Y);
            
            
            DateTime dt = DateTime.Now;
            Pen cir_pen = new Pen(Color.Black, 10);
            Point first = new Point(-250, -250);
            Point second = new Point(500, 500);
            g.DrawEllipse(cir_pen, first.X, first.Y, second.X, second.Y);
            GraphicsState gs = g.Save();

            for (int i = 0; i < 12; i++)
            {
                int lineLength = 30;
                g.RotateTransform(15);
                g.DrawLine(
                    new Pen(Color.Black, 2),
                    new Point(0, -r + lineLength / 3),
                    new Point(0, -r)
               );
                g.RotateTransform(15);
                g.DrawLine(
                    new Pen(Color.Black, 2),
                    new Point(0, -r + lineLength),
                    new Point(0, -r)
                );
            }
            g.Restore(gs);

            g.RotateTransform(dt.Hour * 30 + dt.Minute / 2);
            g.DrawLine(new Pen(new SolidBrush(Color.Brown), 4), 0, 0, 0, -100);
            g.Restore(gs);
            

            g.RotateTransform(dt.Minute * 6);
            g.DrawLine(new Pen(new SolidBrush(Color.OrangeRed), 4), 0, 0, 0, -150);
            g.Restore(gs);
            
            
            g.RotateTransform(dt.Second * 6);
            g.DrawLine(new Pen(new SolidBrush(Color.BlueViolet), 4), 0, 0, 0, -250);
            g.Restore(gs);
            
            
        }



    }
}
