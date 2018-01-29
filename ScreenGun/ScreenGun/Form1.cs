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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public Form2 F2 = null;
        public static int SetValueX;
        public static int SetValueY;
        public static int SetValueWidth;
        public static int SetValueHeight;

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void SetValue(int LeftX, int TopY,int RightX,int BottomY) {
            SetValueX = LeftX;
            SetValueY = TopY;
            SetValueHeight = BottomY - TopY;
            SetValueWidth = RightX - LeftX;

            label1.Text = "(" + LeftX.ToString() + "," + TopY.ToString() + ") "+
                "(" + RightX.ToString() + "," + BottomY.ToString() + ")";
            label2.Text = SetValueHeight.ToString()+","+SetValueWidth.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(F2 ==null)
            {
                F2 = new Form2(this);
                F2.Owner = this;
            }
            F2.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(SetValueWidth, SetValueHeight);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CopyFromScreen(new Point(SetValueX,SetValueY),new Point(0, 0),new Size(SetValueWidth, SetValueHeight));
            IntPtr intPtr = graphics.GetHdc();
            graphics.ReleaseHdc(intPtr);
            
            bmp.SetResolution(SetValueWidth, SetValueHeight);
            this.pictureBox1.Image = bmp;

            if (bmp != null)
            {
                bmp.Save("c:\\myBitmap.jpg");
               
            }
            
        }

    }
}
