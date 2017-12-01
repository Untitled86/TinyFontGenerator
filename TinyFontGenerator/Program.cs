using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication4
{
    static class Program
    {

        public static byte Reverse(byte inByte)
        {
            byte result = 0x00;
            byte mask = 0x00;

            for (mask = 0x80;
                                Convert.ToInt32(mask) > 0;
                                mask >>= 1)
            {
                result >>= 1;
                byte tempbyte = (byte)(inByte & mask);
                if (tempbyte != 0x00)
                    result |= 0x80;
            }
            return (result);
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
         
         /*  bool[] data = new bool[96000];

           Bitmap bitmap = new Bitmap(@"C:\users\brien\desktop\untitled3.bmp");

           int currentDataPos = 0;
           for (int y = 0; y < bitmap.Height; y += 1)
           {
               for (int x = 0; x < bitmap.Width; x += 1)
               {
                   bool v = bitmap.GetPixel(x, y).B == 255;
                   data[currentDataPos] = !v;
                   currentDataPos += 1;
               }
           }

           byte[] arr1 = Array.ConvertAll(data, b => b ? (byte)1 : (byte)0);

           int bytes = data.Length / 8;
           if ((data.Length % 8) != 0) bytes++;
           byte[] arr2 = new byte[bytes];
           int bitIndex = 0, byteIndex = 0;
           for (int i = 0; i < data.Length; i++)
           {
               if (data[i])
               {
                   arr2[byteIndex] |= (byte)(((byte)1) << bitIndex);
               }
               bitIndex++;
               if (bitIndex == 8)
               {
                   bitIndex = 0;
                   byteIndex++;
               }
           }

           FileStream fs = new FileStream(@"C:\users\brien\tmp2.txt", FileMode.Create);
           BinaryWriter bw = new BinaryWriter(fs);
           foreach (byte dataByte in arr2) 
           {
               bw.Write(Encoding.UTF8.GetBytes((int)Reverse(dataByte) + ","));
           }
           bw.Flush();
           fs.Flush();
           fs.Close();
           bw.Dispose();
           fs.Dispose();



           FileStream fs2 = new FileStream(@"C:\users\brien\tmp4.bin", FileMode.Create);
           BinaryWriter bw2 = new BinaryWriter(fs2);
           foreach (byte dataByte in arr2)
           {
               bw2.Write(Reverse(dataByte));
           }
           bw2.Flush();
           fs2.Flush();
           fs2.Close();
           bw2.Dispose();
           fs2.Dispose();

           Console.WriteLine("ASD");*/


            Application.Run(new Form1());
        }
    }
}
