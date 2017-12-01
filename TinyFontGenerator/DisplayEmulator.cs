using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication4
{
    public partial class DisplayEmulator : Form
    {

        Graphics BitmapGraphics = null;
        Bitmap screenBitmap = null;

        public DisplayEmulator(byte[] aBytes, bool aInvert)
        {
            InitializeComponent();
            this.ClientSize = new Size(400, 240);
            screenBitmap = new Bitmap(400, 240);
            screenBitmap.SetResolution(96, 96);
            BitmapGraphics = Graphics.FromImage(screenBitmap);
            BitmapGraphics.Clear(Color.LightGray);
            BitmapGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            BitmapGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            BitmapGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic; 
            SetBits(aBytes, aInvert);
        }

        public void SetBits(byte[] aBytes, bool aInvert)
        {
            bool[] bits = BitUtils.GetBits(aBytes);

            int currentBit = 0;
            for (int y = 0; y < 240; y += 1)
            {
                for (int x = 0; x < 400; x += 1)
                {
                    if (bits.Length > currentBit)
                    {
                        //((Bitmap)BackgroundImage).SetPixel(x, y, bits[currentBit] ? Color.LightGray : Color.Black);
                        screenBitmap.SetPixel(x, y, BitUtils.GetBit(aBytes[currentBit / 8], 7 - (currentBit % 8)) ? Color.LightGray : Color.Black);
                        

                       /* if (bits[currentBit])
                        {
                            System.Diagnostics.Debug.Write("@");
                        }
                        else
                        {
                            System.Diagnostics.Debug.Write("%");
                        }*/

                        currentBit += 1;

                    }
                } 
            } 
             

        }

        private void DisplayEmulator_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(416, 278);
        }

        private void DisplayEmulator_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
             
            e.Graphics.DrawImage(screenBitmap, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }
         
         
    }
}
