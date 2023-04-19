using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafica
{
    public partial class Form1 : Form
    {
        Graphics foglio;
        Pen penna;
        Point centro1, centro2;
        List<Point> centro;
        List<Point> inizioLinea;
        List<Point> fineLinea;
        int raggio;
        public Form1()
        {
            InitializeComponent();
            penna = new Pen(Color.Black, 1);
            raggio = 30;
            centro = new List<Point>();
            inizioLinea = new List<Point>();
            fineLinea = new List<Point>();
            centro1.X = -1;
            centro2.X = -1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foglio = e.Graphics;
            penna.Color = Color.Red;
            for (int i = 0; i < inizioLinea.Count; i++)
            {
                foglio.DrawLine(penna, inizioLinea[i], fineLinea[i]);
            }
            penna.Color = Color.Black;
            foreach (Point p in centro)
            {
                foglio.DrawEllipse(penna, p.X, p.Y, 1, 1);
                penna.Width = 3;
                foglio.DrawEllipse(penna, p.X - raggio, p.Y - raggio, raggio * 2, raggio * 2);
                penna.Width = 1;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (PosizioneValida(e.X, e.Y))
                centro.Add(e.Location);
            else if (centro1.X == -1)
            {
                centro1 = DispositivoPremuto(e.X, e.Y);
            }
            else
            {
                centro2 = DispositivoPremuto(e.X, e.Y);
                if (centro2.X != -1)
                {
                    inizioLinea.Add(centro1);
                    fineLinea.Add(centro2);
                    centro1.X = -1;
                    centro2.X = -1;
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Invalidate();
        }

        private bool PosizioneValida(int x, int y)
        {
            int xMiddle, yMiddle, xRight, xLeft, yUp, yDown;

            foreach (Point p in centro)
            {
                xMiddle = p.X;
                yMiddle = p.Y;
                xRight = xMiddle - (3 * raggio);
                xLeft = xMiddle + (3 * raggio);
                yUp = yMiddle + (3 * raggio);
                yDown = yMiddle - (3 * raggio);
                if (x >= xRight && x <= xLeft && y <= yUp && y >= yDown)
                    return false;
            }
            return true;
        }

        private Point DispositivoPremuto(int x, int y)
        {
            int xMiddle, yMiddle, xRight, xLeft, yUp, yDown;

            foreach (Point p in centro)
            {
                xMiddle = p.X;
                yMiddle = p.Y;
                xRight = xMiddle - raggio;
                xLeft = xMiddle + raggio;
                yUp = yMiddle + raggio;
                yDown = yMiddle - raggio;
                if (x >= xRight && x <= xLeft && y <= yUp && y >= yDown)
                    return p;
            }
            return new Point(-1, -1);
        }
    }
}