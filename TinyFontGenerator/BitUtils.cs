using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication4
{
    public static class BitUtils
    {

        
        public static bool[] GetBits(byte[] aBytes)
        {
            List<bool> bits = new List<bool>();

            foreach (byte currentByte in aBytes)
            {
                bits.AddRange(GetBits(currentByte));
            }

            return bits.ToArray();
        }

        public static bool[] GetBits(byte aByte)
        {
            List<bool> bits = new List<bool>();

            //for (int b = 8; b > 0; b -= 1)
            for (int b = 8; b != 0; b -= 1)
            {
                bits.Add(GetBit(aByte, b));
            }

            return bits.ToArray();
        }

        public static bool GetBit(byte aByte, int aBitNumber)
        {
            return (aByte & (1 << aBitNumber)) != 0;
        }

        public static void SetBit(ref byte aByte, int aBitNumber, bool newValue)
        {
            byte newByte;
            



            if (newValue)
            {
                newByte = (byte)(aByte | (1 << aBitNumber));
            }
            else
            { 
                newByte = (byte)(aByte & ~(1 << aBitNumber));
            } 
            
            aByte = newByte;
        }

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
    }
}
