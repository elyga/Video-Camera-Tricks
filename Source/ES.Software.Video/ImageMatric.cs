using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ES.Software.Video
{
	/// <summary>
	/// Static extensions class.
	/// </summary>
    static class Extensions
    {
		private static int[] RGBR = new int[] { 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 12, 12, 12, 12, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 15, 15, 15, 15, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 19, 19, 19, 19, 20, 20, 20, 20, 20, 21, 21, 21, 21, 21, 22, 22, 22, 22, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 25, 25, 25, 25, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 29, 29, 29, 29, 30, 30, 30, 30, 30, 31, 31, 31, 31, 31, 32, 32, 32, 32, 33, 33, 33, 33, 33, 34, 34, 34, 34, 34, 35, 35, 35, 35, 35, 36, 36, 36, 36, 37, 37, 37, 37, 37, 38, 38, 38, 38, 38, 39, 39, 39, 39, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 42, 42, 42, 42, 43, 43, 43, 43, 43, 44, 44, 44, 44, 44, 45, 45, 45, 45, 45, 46, 46, 46, 46, 47, 47, 47, 47, 47, 48, 48, 48, 48, 48, 49, 49, 49, 49, 50, 50, 50, 50, 50, 51, 51, 51, 51, 51, 52, 52, 52, 52, 52, 53, 53, 53, 53, 54, 54, 54, 54 };
		private static int[] RGBG = new int[] { 0, 1, 1, 2, 3, 4, 4, 5, 6, 6, 7, 8, 9, 9, 10, 11, 11, 12, 13, 14, 14, 15, 16, 16, 17, 18, 19, 19, 20, 21, 21, 22, 23, 24, 24, 25, 26, 26, 27, 28, 29, 29, 30, 31, 31, 32, 33, 34, 34, 35, 36, 36, 37, 38, 39, 39, 40, 41, 41, 42, 43, 44, 44, 45, 46, 47, 47, 48, 49, 49, 50, 51, 52, 52, 53, 54, 54, 55, 56, 57, 57, 58, 59, 59, 60, 61, 62, 62, 63, 64, 64, 65, 66, 67, 67, 68, 69, 69, 70, 71, 72, 72, 73, 74, 74, 75, 76, 77, 77, 78, 79, 79, 80, 81, 82, 82, 83, 84, 84, 85, 86, 87, 87, 88, 89, 89, 90, 91, 92, 92, 93, 94, 94, 95, 96, 97, 97, 98, 99, 99, 100, 101, 102, 102, 103, 104, 104, 105, 106, 107, 107, 108, 109, 109, 110, 111, 112, 112, 113, 114, 114, 115, 116, 117, 117, 118, 119, 119, 120, 121, 122, 122, 123, 124, 124, 125, 126, 127, 127, 128, 129, 129, 130, 131, 132, 132, 133, 134, 134, 135, 136, 137, 137, 138, 139, 140, 140, 141, 142, 142, 143, 144, 145, 145, 146, 147, 147, 148, 149, 150, 150, 151, 152, 152, 153, 154, 155, 155, 156, 157, 157, 158, 159, 160, 160, 161, 162, 162, 163, 164, 165, 165, 166, 167, 167, 168, 169, 170, 170, 171, 172, 172, 173, 174, 175, 175, 176, 177, 177, 178, 179, 180, 180, 181, 182, 182 };
		private static int[] RGBB = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18 };
	
		/// <summary>
		/// Converting.
		/// </summary>
        static public string ToThreeDigits(this byte integer)
        {
            int digits = 0;
            int temp = (int)integer;
            do
            {
                temp /= 10;
                digits++;
            }
            while (temp != 0);
            string ThreeDigits = "";
            if (digits == 1)
            {
                ThreeDigits = "00"+Convert.ToString(integer);
            }
            else if (digits == 2)
            {
                ThreeDigits = "0" + Convert.ToString(integer);
            }
            else
            {
                ThreeDigits = Convert.ToString(integer);
            }
            return ThreeDigits;
        }
		
		/// <summary>
		/// Converting bitmap to gray.
		/// Slow and Simple.
		/// </summary>
		public static Bitmap MakeGrayscale1(Bitmap original)
		{
		   //make an empty bitmap the same size as original
		   Bitmap newBitmap = new Bitmap(original.Width, original.Height);

		   for (int i = 0; i < original.Width; i++)
		   {
			  for (int j = 0; j < original.Height; j++)
			  {
				 //get the pixel from the original image
				 Color originalColor = original.GetPixel(i, j);

				 //create the grayscale version of the pixel
				 int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
					 + (originalColor.B * .11));

				 //create the color object
				 Color newColor =  Color.FromArgb(grayScale, grayScale, grayScale);
				 
				 //set the new image's pixel to the grayscale version
				 newBitmap.SetPixel(i, j, newColor);
				}
			}

			return newBitmap;
		}
		
		/// <summary>
		/// Converting bitmap to gray.
		/// Faster and Complicated.
		/// It still iterates through every pixel, but we're going to utilize C#'s 
		/// unsafe keyword to make getting the pixel data much more efficient.
		/// </summary>
		public static Bitmap MakeGrayscale2(Bitmap original)
		{
		   unsafe
		   {
			  //create an empty bitmap the same size as original
			  Bitmap newBitmap = new Bitmap(original.Width, original.Height);

			  //lock the original bitmap in memory
			  BitmapData originalData = original.LockBits(
				 new Rectangle(0, 0, original.Width, original.Height),
				 ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

			  //lock the new bitmap in memory
			  BitmapData newData = newBitmap.LockBits(
				 new Rectangle(0, 0, original.Width, original.Height),
				 ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
		 
			  //set the number of bytes per pixel
			  int pixelSize = 3;

			  for (int y = 0; y < original.Height; y++)
			  {
				 //get the data from the original image
				 byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

				 //get the data from the new image
				 byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

				 for (int x = 0; x < original.Width; x++)
				 {
					//create the grayscale version
					byte grayScale =
					   (byte)((oRow[x * pixelSize] * .11) + //B
					   (oRow[x * pixelSize + 1] * .59) +  //G
					   (oRow[x * pixelSize + 2] * .3)); //R

					//set the new image's pixel to the grayscale version
					nRow[x * pixelSize] = grayScale; //B
					nRow[x * pixelSize + 1] = grayScale; //G
					nRow[x * pixelSize + 2] = grayScale; //R
				 }
			  }

			  //unlock the bitmaps
			  newBitmap.UnlockBits(newData);
			  original.UnlockBits(originalData);

			  return newBitmap;
		   }
		}
		
		/// <summary>
		/// Converting bitmap to static.
		/// Short and Sweet
		/// </summary>
		public static Bitmap MakeGrayscale3(Bitmap original)
		{
		   //create a blank bitmap the same size as original
		   Bitmap newBitmap = new Bitmap(original.Width, original.Height);
		   
		   //get a graphics object from the new image
		   Graphics g = Graphics.FromImage(newBitmap);

		   //create the grayscale ColorMatrix
		   ColorMatrix colorMatrix = new ColorMatrix(
			  new float[][]
			  {
				 new float[] {.3f, .3f, .3f, 0, 0},
				 new float[] {.59f, .59f, .59f, 0, 0},
				 new float[] {.11f, .11f, .11f, 0, 0},
				 new float[] {0, 0, 0, 1, 0},
				 new float[] {0, 0, 0, 0, 1}
			  });

		   //create some image attributes
		   ImageAttributes attributes = new ImageAttributes();

		   //set the color matrix attribute
		   attributes.SetColorMatrix(colorMatrix);

		   //draw the original image on the new image
		   //using the grayscale color matrix
		   g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
			  0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

		   //dispose the Graphics object
		   g.Dispose();
		   return newBitmap;
		}
		
		/*
		/// <summary>
		/// Converting bitmap to gray.
		/// </summary>
		public static Bitmap MakeGrayscale4(Bitmap original)
		{
		   unsafe
		   {
			  //create an empty bitmap the same size as original
			  Bitmap newBitmap = new Bitmap(original.Width, original.Height);

			  //lock the original bitmap in memory
			  BitmapData originalData = original.LockBits(
				 new Rectangle(0, 0, original.Width, original.Height),
				 ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

			  //lock the new bitmap in memory
			  BitmapData newData = newBitmap.LockBits(
				 new Rectangle(0, 0, original.Width, original.Height),
				 ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
		 
			  //set the number of bytes per pixel
			  int pixelSize = 3;

			  for (int y = 0; y < original.Height; y++)
			  {
				 //get the data from the original image
				 byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

				 //get the data from the new image
				 byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

				 for (int x = 0; x < original.Width; x++)
				 {

					//create the grayscale version
					byte grayScale =
					   (byte)((oRow[x * pixelSize] * .11) + //B
					   (oRow[x * pixelSize + 1] * .59) +  //G
					   (oRow[x * pixelSize + 2] * .3)); //R


					//set the new image's pixel to the grayscale version
					nRow[x * pixelSize] = grayScale; //B
					nRow[x * pixelSize + 1] = grayScale; //G
					nRow[x * pixelSize + 2] = grayScale; //R
				 }
			  }

			  //unlock the bitmaps
			  newBitmap.UnlockBits(newData);
			  original.UnlockBits(originalData);

			  return newBitmap;
		   }
		}
		*/
    }


	/// <summary>
	/// Static extensions class.
	/// </summary>
    class ImageMatrix
    {
		//Declare and set class variables:
        public byte[,] function;
        int width;
        int height;

		/// <summary>
		/// ImageMatrix class constructor, if class got bitmap.
		/// </summary>
        public ImageMatrix(Bitmap image)//constructor
        {
            this.width = image.Width;
            this.height = image.Height;

            function = new byte[width, height];//define bounds of function

            //Unsafe bitmap to iterate through the image:
            unSafeBitmap usb = new unSafeBitmap(image);
            usb.LockImage();

			//Looping every pixel and storing average (gray scale):
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    /* Reading average (gray scale) value for each of the pixel
                     * and storing it in function*/
                    this.function[i, j] = usb.GetAverage(i, j);
                }
            }
        }

		/// <summary>
		/// ImageMatrix class constructor, if class got bitmap.
		/// </summary>
        public ImageMatrix(byte[,] matrix)//constructor
        {
            //storing value to member variables
            this.width = matrix.GetLength(0);
            this.height = matrix.GetLength(1);

            //initializing function[,]
            function = new byte[width, height];
            
            //copy this matrix to function array
            Array.Copy(matrix, this.function, matrix.Length);
        }

		/// <summary>
		/// Convert imagematrix to bitmap.
		/// </summary>
        public Bitmap ToImage()
        {
            Bitmap image = new Bitmap(width, height);

            unSafeBitmap usb = new unSafeBitmap(image);//making object for unsafe bitmapping
            usb.LockImage();
            
            //making a grayscale image according to function array
            for(int i=0;i<width;i++)
            {
                for(int j=0;j<height;j++)
                {
                    //writign each pixel on image bitmap.
                    byte Value = function[i, j];
                    Color c = Color.FromArgb(Value, Value, Value);//gray scale image
                    usb.SetPixel(i, j, c);
                }
            }

            //unlock image before returning 
            usb.UnlockImage();

            return image;
        }

		/// <summary>
		/// Convert imagematrix to string.
		/// </summary>
        public override string ToString()
        {
            //writing an image to a text or in matrix format
            StringBuilder sb = new StringBuilder();//to concatinate string to eeach other

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //getting function and making it a string
                    if (j != height - 1)
                    {
                        sb.Append(function[i, j].ToThreeDigits() + ", ");
                    }
                    else
                    {
                        sb.Append(function[i, j].ToThreeDigits());
                    }
                }
                sb.Append("\n\n");
            }
            return sb.ToString();
        }

        public ImageMatrix HorizontalSqueeze(int SqueezeFactor)
        {
            // assignimg new width for squeezing the image horizontally
            int NewWidth = width/SqueezeFactor;
            if(NewWidth*SqueezeFactor != width)
            {
                NewWidth++;// if it's fully divisible than add another horizontal row
            }

            // defining new function this will be new image(horizontally squeezed)
            byte[,] NewFunction = new byte[NewWidth, height];
            
            //iterating through this.function[,] and adding value to newFunction[,];
            for (int i = 0; i < NewWidth; i++)
            {
                int startingPoint = i * SqueezeFactor;
                int horizontalBound = SqueezeFactor + startingPoint;
                if (i == NewWidth - 1)//in the end make sure it's not out of the bound of an defined array!
                {
                    horizontalBound = width;
                }
                for (int j = 0; j < height; j++)
                {
                    double averageFunction = 0;
                    for (int h = startingPoint; h < horizontalBound; h++)
                    {
                        averageFunction += function[h, j];
                    }
                    averageFunction /= SqueezeFactor;
                    NewFunction[i, j] = (byte)averageFunction;
                }
            }

            //return iamgematrix
            ImageMatrix IM = new ImageMatrix(NewFunction);
            return IM;
        }

        public ImageMatrix VerticalSqueeze(int SqueezeFactor)
        {
            // assignimg new width for squeezing the image horizontally
            int NewHeight = height / SqueezeFactor;
            if (NewHeight * SqueezeFactor != height)
            {
                NewHeight++;// if it's fully divisible than add another horizontal row
            }

            // defining new function this will be new image(horizontally squeezed)
            byte[,] NewFunction = new byte[width, NewHeight];

            //iterating through this.function[,] and adding value to newFunction[,];
            for (int i = 0; i < NewHeight; i++)
            {
                int startingPoint = i * SqueezeFactor;
                int verticalBound = SqueezeFactor + startingPoint;
                if (i == NewHeight - 1)//in the end make sure it's not out of the bound of an defined array!
                {
                    verticalBound = height;
                }
                for (int j = 0; j < width; j++)
                {
                    double averageFunction = 0;
                    for (int h = startingPoint; h < verticalBound; h++)
                    {
                        averageFunction += function[j, h];
                    }
                    averageFunction /= SqueezeFactor;
                    NewFunction[j, i] = (byte)averageFunction;
                }
            }

            //return iamgematrix
            ImageMatrix IM = new ImageMatrix(NewFunction);
            return IM;
        }
    }
}