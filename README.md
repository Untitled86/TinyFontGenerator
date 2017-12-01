# TinyFontGenerator
Generates fonts for netMF devices using Windows fonts.  Includes support for kerning (letter spacing), etc.  Fonts render identically on netMF devices and Windows PCs.

This utility generates code and classes for the data to render the fonts from C#.

Eventually I moved to a much more efficient setup.  I store my fonts in the internal flash on the microprocessor (to save RAM).  My native code passes requests to render fonts to my C++ code (which is compiled into my microprocessor's natvie code).

Here's what that looks like...

Utility to load fonts into flash...
```
using System;
using Microsoft.SPOT;
using System.IO;
using Core.Hardware;
using Core.Utils;

namespace Core.UI
{
    public class FontLoader
    {
        public bool HasLanguagesFile()
        {
            return System.IO.File.Exists(Environment.RootFolder + "Languages.dat");
        }

        public bool HasLanguagesInFlash()
        {
            byte[] unicodeBuffer = new byte[2]; 
            
            InternalFlash.Read(unicodeBuffer, 66, 0, unicodeBuffer.Length);
            
            ushort characterPointer = BitUtils.ToUShort(unicodeBuffer);

            if (characterPointer == ushort.MaxValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LoadToFlash()
        {
            if (System.IO.File.Exists(Environment.RootFolder + "Languages.dat"))
            {
                bool skipInternalFlash = false;

                if (System.IO.File.Exists(Environment.RootFolder + "SkipExternalFlash.flag"))
                {
                    skipInternalFlash = true;
                }

                FileStream fs = System.IO.File.OpenRead(Environment.RootFolder + "Languages.dat");
                byte[] fontBuffer1 = new byte[512];
                byte[] fontBuffer2 = new byte[512];
                byte[] unicodeBuffer = new byte[2];
                uint unicodeAddress = 0;
                byte[] unicodeIndexBuffer = new byte[2];
                uint flashAddress = 0;

                Drawing.DrawRectangle(0, 140, 10, 54, true, Drawing.PixelColor.White);
                Display.Update(Display.Buffer);

                InternalFlash.EraseSectors();

                uint smallFontStartAddress = 2304000;

                fs.Read(unicodeBuffer, 0, unicodeBuffer.Length);
                ushort characterCount = BitUtils.ToUShort(unicodeBuffer);

                if (!skipInternalFlash)
                {
                    for (uint i = smallFontStartAddress; i < 64000000; i += 256000)
                    { 
                        ExternalFlash.ErasePage(i); 
                    }
                }

                Drawing.DrawRectangle(0, 140, 20, 54, true, Drawing.PixelColor.White);
                Display.Update(Display.Buffer);

                float pp = 379f / (float)characterCount;
                int c = 0;

                for (ushort i = 0; i < characterCount; i += 1) //This is how many characters there are.
                {
                    try
                    {

                        if (c == 15)
                        {
                            Drawing.DrawRectangle(0, 140, (int)(20 + (i * pp)), 54, true, Drawing.PixelColor.White);
                            Display.Update(Display.Buffer);
                            c = 0;
                        }
                        c += 1;

                        //Writes the unicode and index into font data to internal flash
                        fs.Read(unicodeBuffer, 0, unicodeBuffer.Length);
                        unicodeAddress = (uint)BitUtils.ToUShort(unicodeBuffer) * 2;
                        unicodeIndexBuffer = BitUtils.GetBytes(i); 
                        InternalFlash.Write(unicodeIndexBuffer, unicodeAddress, 0, 2); 

                        //Writes the font data to external flash
                        fs.Read(fontBuffer1, 0, fontBuffer1.Length);
                        fs.Read(fontBuffer2, 0, fontBuffer2.Length);

                        flashAddress = (uint)(smallFontStartAddress + (i * (uint)1024));

                        if (!skipInternalFlash)
                        {
                            ExternalFlash.WritePage(flashAddress, fontBuffer1, 10, true);
                            ExternalFlash.WritePage(flashAddress + 512, fontBuffer2, 10, true);
                        } 

                    }
                    catch (Exception ex)
                    {
                        //Debug.Print(ex.ToString());
                    }
                    //Debug.Print("i: " + i.ToString() + " = " + flashAddress);

                }
                fs.Close();


                System.IO.File.Delete(Environment.RootFolder + "Languages.dat"); 
            }
        }
    }
}
```



Utility that draws fonts, I have small/medium/large like this...
```
using System;
using Microsoft.SPOT;
using Core.Hardware;
using Microsoft.SPOT.Hardware;
using GHI.OSHW.Hardware.LowLevel;

namespace Core.Utils
{
    public static class TinyFont
    { 
        public static void DrawString(ref byte[] aBytes, String aValue, int aX, int aY, bool aInvert)
        {
            FontUtils.DrawFromFlash(FontUtils.FontSize.Tiny, ref aBytes, aValue, aX, aY, aInvert);
            return;
        }
    }     
}
```



Utility that calls C++ code (note I dropped my font code into the netMF framework's SPI library, hack but it works) ...
```
using System;
using Microsoft.SPOT;
using Core.Hardware;
using Microsoft.SPOT.Hardware;
using Core.Text;

namespace Core.Utils
{
    public static class FontUtils
    {

        private static SPI.Configuration spiConfig = new Microsoft.SPOT.Hardware.SPI.Configuration(Core.Hardware.MCU.Pins.GPIO_NONE, true, 0, 0, false, true, 72, Microsoft.SPOT.Hardware.SPI.SPI_module.SPI2, Cpu.Pin.GPIO_NONE, false, 0, 0);

        private static void InitSPI()
        {
            if (Environment.SPI == null)
            {
                Environment.SPI = new SPI(spiConfig);
            }
            else if (Environment.SPI.Config != spiConfig)
            {
                Environment.SPI.Config = spiConfig;
            }
        }

        private static int charIndex = 0;
        private static char currentChar;

        public static void DrawFromFlash(FontSize aSize, ref byte[] aBytes, string aValue, int aX, int aY, bool aInvert)
        { 
            try
            {
                if (
                        (aValue.Length > 0) 
                        && 
                        (
                            ((ushort)aValue[aValue.Length - 1] >= 0x0591) &&
                            ((ushort)aValue[aValue.Length - 1] <= 0x05F4)
                        )
                    )
                {
                    for (charIndex = aValue.Length -1; charIndex > -1; charIndex -= 1)
                    {
                        currentChar = aValue[charIndex];
                        aX += DrawFromFlash(aSize, ref aBytes, currentChar, aX, aY, aInvert);
                    }
                }
                else
                {
                    for (charIndex = 0; charIndex < aValue.Length; charIndex += 1)
                    {
                        currentChar = aValue[charIndex];
                        aX += DrawFromFlash(aSize, ref aBytes, currentChar, aX, aY, aInvert);
                    }
                }
            }
            catch (Exception ex)
            {
                //Sometimes errors are thrown when chars are missing or flash is empty.
            }
        }

        public enum FontSize : int
        {
            Tiny = 0,
            Small = 1,
            Large = 2
        }


        static byte[] shortBuffer = new byte[2];
        static byte[] fontDataBuffer1 = new byte[512];
        static byte[] fontDataBuffer2 = new byte[512];
        static byte[] fontDataBufferLarge = new byte[794];
        static byte[] fontDataBufferSmall = new byte[164];
        static byte[] fontDataBufferTiny = new byte[66];
        static byte[] tempShortBytes;

        public static int MeasureString(FontSize aFontSize, string aString)
        {
            int totalSize = 0;

            for (int i = 0; i < aString.Length; i += 1)
            {
                totalSize += MeasureChar(aFontSize, aString[i])[0];
            }

            return totalSize;
        }

        //Returns font width and height.
        public static int[] MeasureChar(FontSize aFontSize, char c)
        {
            byte[] fontData = fontDataBufferTiny; //Asigned for compiler to prevent warning, gets reassigned below

            InternalFlash.Read(shortBuffer, (uint)((ushort)c * 2), 0, shortBuffer.Length);
            uint pos = (uint)Utils.BitUtils.ToUShort(shortBuffer) * (uint)1024;

            uint smallFontStartAddress = 2304000;

            if (aFontSize == FontSize.Large)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                return new int[] { fontDataBuffer1[230], fontDataBuffer1[231] };
            }
            else if (aFontSize == FontSize.Small)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                return new int[] { fontDataBuffer1[66], fontDataBuffer1[67] };
            }
            else if (aFontSize == FontSize.Tiny)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                return new int[] { fontDataBuffer1[0], fontDataBuffer1[1] };
            }

            return new int[] {-1, -1};
        }


        //Returns font width and draws to buffer
        public static int DrawFromFlash(FontSize aFontSize, ref byte[] aBytes, char c, int aX, int aY, bool aInvert)
        {  
            byte[] fontData = fontDataBufferTiny; //Asigned for compiler to prevent warning, gets reassigned below

            InternalFlash.Read(shortBuffer, (uint)((ushort)c * 2), 0, shortBuffer.Length);
            uint pos = (uint)Utils.BitUtils.ToUShort(shortBuffer) * (uint)1024;

            uint smallFontStartAddress = 2304000;

            if (aFontSize == FontSize.Large)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                fontDataBuffer2 = ExternalFlash.ReadPage(smallFontStartAddress + pos + 512);
                fontData = fontDataBufferLarge;
                Array.Copy(fontDataBuffer1, 230, fontData, 0, 512 - 230);
                Array.Copy(fontDataBuffer2, 0, fontData, 512 - 230, fontDataBuffer2.Length);
            }
            else if (aFontSize == FontSize.Small)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                fontData = fontDataBufferSmall;
                Array.Copy(fontDataBuffer1, 66, fontData, 0, 164);
            }
            else if (aFontSize == FontSize.Tiny)
            {
                fontDataBuffer1 = ExternalFlash.ReadPage(smallFontStartAddress + pos);
                fontData = fontDataBufferTiny;
                Array.Copy(fontDataBuffer1, 0, fontData, 0, 66);
            }



            int characterSize = (int)System.Math.Round(((fontData[1] * fontData[0]) + 6) / 8);
            
            if (aFontSize == FontSize.Large)
            {
                if (characterSize > 794)
                {
                    throw new Exception("Invalid character");
                }
            }
            else if (aFontSize == FontSize.Small)
            {
                if (characterSize > 164)
                {
                    throw new Exception("Invalid character");
                }
            }
            else if (aFontSize == FontSize.Tiny)
            {
                if (characterSize > 66)
                {
                    throw new Exception("Invalid character");
                }
            }

            byte[] aInvertXYAndCharData = new byte[characterSize + 7];

            Array.Copy(fontData, 2, aInvertXYAndCharData, 7, characterSize);

            aInvertXYAndCharData[0] = (byte)(aInvert ? 0xFF : 0x00);

            tempShortBytes = BitUtils.GetBytes((ushort)aX);
            aInvertXYAndCharData[1] = tempShortBytes[0];
            aInvertXYAndCharData[2] = tempShortBytes[1];

            tempShortBytes = BitUtils.GetBytes((ushort)aY);
            aInvertXYAndCharData[3] = tempShortBytes[0];
            aInvertXYAndCharData[4] = tempShortBytes[1];

            aInvertXYAndCharData[5] = fontData[0];

            aInvertXYAndCharData[6] = fontData[1];

            InitSPI();
            Environment.SPI.WriteRead(aBytes, aInvertXYAndCharData);

            return fontData[0];
        }
    }
}
```

C++ code...
```
 void DrawChar(UINT8* aBytes, UINT8* aInvertXYAndCharData)
 {

	 UINT32 currentX = 0;
	 UINT32 currentY = 0;
	 UINT32 currentFontBit = 0;
	 UINT32 currentScreenBit = 0;
	 UINT32 currentFontBitIndex = 0;
	 UINT32 currentFontByteIndex = 0;
	 BYTE currentFontByte = (BYTE)0x00;

	 BOOL aInvert = aInvertXYAndCharData[0] == 0xFF;
	 UINT32 aX = (UINT32)((UINT16)aInvertXYAndCharData[1] << 0) + ((UINT16)aInvertXYAndCharData[2] << 8);
	 UINT32 aY = (UINT32)((UINT16)aInvertXYAndCharData[3] << 0) + ((UINT16)aInvertXYAndCharData[4] << 8);
	 UINT32 currentCharWidth = (UINT32)aInvertXYAndCharData[5];
	 UINT32 fontHeight = (UINT32)aInvertXYAndCharData[6];

	 UINT32 adjustedX = 400 - aX;

	 currentFontBit = 0;
	 currentScreenBit = 0;

	 for (UINT32 y = 0; y < fontHeight; y += 1)
	 {
		 currentScreenBit = (GetScreenBufferIndex(1, y + aY + currentY) * 8) + aX + currentX;

		 for (UINT32 x = 0; x < currentCharWidth; x += 1)
		 {
			 currentFontBitIndex = currentFontBit / 8;

			 if (currentFontByteIndex != currentFontBitIndex)
			 {
				 currentFontByteIndex = currentFontBitIndex;
				 currentFontByte = aInvertXYAndCharData[7 + currentFontByteIndex];
			 }



			 bool fontbit = (currentFontByte & (1 << currentFontBit % 8)) != 0;

			 if (fontbit)
			 {
				 if (fontbit != aInvert)
				 {
					 aBytes[currentScreenBit / 8] |= (BYTE)(1 << 7 - (currentScreenBit % 8));
				 }
				 else
				 {
					 aBytes[currentScreenBit / 8] &= (BYTE)(~(1 << 7 - (currentScreenBit % 8)));
				 }
			 }
			 else
			 {
				 if (!aInvert)
				 {
					 aBytes[currentScreenBit / 8] &= (BYTE)(~(1 << 7 - (currentScreenBit % 8)));
				 }
				 else
				 {
					 aBytes[currentScreenBit / 8] &= (BYTE)(~(0 << 7 - (currentScreenBit % 8)));
				 }
			 }

			 currentScreenBit += 1;
			 currentFontBit += 1;

		 }
	 }

 }

void SetByteOfPixels(UINT8* aScreenBuffer, UINT16 aX, UINT16 aY, BOOL aFill, BOOL aBlack, BOOL aInvert)
{
	UINT32 screenByte = GetScreenBufferIndex((aX / 8) + 1, aY);

	BYTE tempSetPixelByte = aScreenBuffer[screenByte];

	if (aInvert)
	{
		aScreenBuffer[screenByte] = (BYTE)~aScreenBuffer[screenByte];
	}
	else
	{
		if (aBlack)
		{
			aScreenBuffer[screenByte] = (BYTE)0x00;
		}
		else
		{
			aScreenBuffer[screenByte] = (BYTE)0xFF;
		}
	}
}

void SetPixel(UINT8* aScreenBuffer, UINT16 aX, UINT16 aY, BOOL aFill, BOOL aBlack, BOOL aInvert)
{
	UINT32 screenByte = GetScreenBufferIndex((aX / 8) + 1, aY);
	UINT32 screenPixelPos = 0;
	UINT32 screenBit = 0;
    UINT32 setPixelLastScreenByte = -1;
	BYTE tempSetPixelByte = 0x00;

	if (setPixelLastScreenByte != screenByte)
	{
		screenBit = aX % 8;
		tempSetPixelByte = aScreenBuffer[screenByte];
	}

	if (aInvert)
	{
		BOOL bitV = (aScreenBuffer[screenByte] & (1 << (screenBit % 8))) != 0;

		if (bitV)
		{
			aScreenBuffer[screenByte] = (BYTE)(tempSetPixelByte & ~(1 << 7 - (screenBit % 8)));
		}
		else
		{
			aScreenBuffer[screenByte] = (BYTE)(tempSetPixelByte | (1 << 7 - (screenBit % 8)));
		}
	}
	else
	{
		if (aBlack)
		{
			aScreenBuffer[screenByte] = (BYTE)(tempSetPixelByte & ~(1 << 7 - (screenBit % 8)));
		}
		else
		{
			aScreenBuffer[screenByte] = (BYTE)(tempSetPixelByte | (1 << 7 - (screenBit % 8)));
		}
	}
}
```
