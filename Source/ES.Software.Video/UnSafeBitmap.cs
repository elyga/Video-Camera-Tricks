using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

public unsafe class unSafeBitmap
{
	/// <summary>
	/// Pixel data structure.
	/// </summary>
    private struct PixelData
    {
        public byte blue;  //Melyna spalva iki 255.
        public byte green; //Zalia spalva iki 255.
        public byte red;   //Raudona spalva iki 255.
        public byte alpha; //Permatomumas 0 - visiskai permatomas.

        public override string ToString()
        {
            return "(" + alpha.ToString() + ", " + red.ToString() + ", " + green.ToString() + ", " + blue.ToString() + ")";
        }
    }

    private Bitmap workingBitmap = null;
    private int width = 0;
    private BitmapData bitmapData = null;
    private Byte* pBase = null;
	
	/// <summary>
	/// Camera class constructor.
	/// </summary>
    public unSafeBitmap(Bitmap inputBitmap)
    {
        workingBitmap = inputBitmap;
    }

	/// <summary>
	/// LockImage()
	/// </summary>
    public void LockImage()
    {
		//This class draws a rectangle:
        Rectangle bounds = new Rectangle(Point.Empty, workingBitmap.Size);

        width = (int)(bounds.Width * sizeof(PixelData));//The sizeof operator is used to obtain the size in bytes for a value type.
        if (width % 4 != 0) width = 4 * (width / 4 + 1);

        //Lock Image
        bitmapData = workingBitmap.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        pBase = (Byte*)bitmapData.Scan0.ToPointer();
    }

    private PixelData* pixelData = null;

    public Color GetPixel(int x, int y)
    {
        pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
        return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
    }

    public byte GetAverage(int x, int y)
    {
        pixelData = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
        double temp = Convert.ToDouble((pixelData->red + pixelData->blue + pixelData->green)) / 3;
        return (byte)temp;
    }
    public Color GetPixelNext()
    {
        pixelData++;
        return Color.FromArgb(pixelData->alpha, pixelData->red, pixelData->green, pixelData->blue);
    }

    public void SetPixel(int x, int y, Color color)
    {
        PixelData* data = (PixelData*)(pBase + y * width + x * sizeof(PixelData));
        data->alpha = color.A;
        data->red = color.R;
        data->green = color.G;
        data->blue = color.B;
    }

    public void UnlockImage()
    {
        workingBitmap.UnlockBits(bitmapData);
        bitmapData = null;
        pBase = null;
    }

}