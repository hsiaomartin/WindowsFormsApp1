using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int count = 0;
        Pen blackPen = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel_timer_interval.Text = trackBar1.Value + "ms";
        }
        public void DrawLineInt(int degree)
        {
            Graphics GPS = this.CreateGraphics();
            // Create pen.
            GPS.Clear(this.BackColor);

            // Create coordinates of points that define line.
            int length = 60;
            int x1 = 200;
            int y1 = 175;
            int x2 = x1 + (int)(length * (Math.Cos(degree * 3.1415926535 / 180)));
            int y2 = y1 + (int)(length * (Math.Sin(degree * 3.1415926535 / 180)));
           // label1.Text = degree + "°"+x2+" "+y2+" "+ Math.Cos(degree )+ " "+ Math.Sin(degree);
            toolStripStatusLabel_Degree_value.Text = degree + "°";


            // Draw line to screen.
            GPS.DrawEllipse(blackPen, x1-length, y1-length, length*2, length*2);
            GPS.DrawLine(blackPen, x1, y1, x2, y2);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DrawLineInt((count>=360?count=0:count++));

            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            toolStripStatusLabel_timer_interval.Text = trackBar1.Value+" ms ";
        }

        private void Time_Start_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Time_Start_checkBox.Checked)
                timer1.Start();
            else
                timer1.Stop();
        }
    }
}
