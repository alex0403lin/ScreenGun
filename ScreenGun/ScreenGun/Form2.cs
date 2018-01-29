using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenGun
{
    public partial class Form2 : Form
    {
        public Form1 F1;
        private Rectangle rect;
        public static int PositionLeftX;
        public static int PositionTopY;
        public static int PositionRightX;
        public static int PositionBottomY;


        public Form2(Form1 owner1)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            F1 = owner1;
        }



        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
            label1.Text = Cursor.Position.ToString();

            PositionLeftX = Cursor.Position.X;
            PositionTopY = Cursor.Position.Y;
            // "e.X" and "e.Y"為滑鼠座標
            rect = new Rectangle(e.X, e.Y, 0, 0);
            this.Invalidate();
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
            PositionRightX = Cursor.Position.X;
            PositionBottomY = Cursor.Position.Y;
            label1.Text += Cursor.Position.ToString();



        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //滑鼠邊移動邊畫方框
              
                rect= new Rectangle(rect.Left, rect.Top, e.X - rect.Left, e.Y - rect.Top);
            }
            this.Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //Green: 綠色, 可更改為其他顏色; 1: 線寬, 可更改.
            using (Pen pen = new Pen(Color.Blue, 1))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            F1.SetValue(PositionLeftX, PositionTopY, PositionRightX, PositionBottomY);
            F1.Show();
            F1.Focus();
            this.Hide();
        }
    }
}
