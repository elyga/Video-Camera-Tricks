using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace ES.Software.Video
{
    class MotionDetection
    {
		//Declare and set local variables:
		static public int max_bound_s = 30;                                                   //max boud
        bool first_motion_data = false;                                                       //First motion data.
        public delegate void MotionEventHandler(object MotionDetection, EventArgs eventArgs); //Public delegates.      
        public event MotionEventHandler MotionEvent;                                          //Public event for the class.
		public int threshold = 15;                                                            //Threshold for rate of change of frame.
		bool normalized = false;                                                              //Check if rate of change has normalized before triggring event.
		int loop = 0;                                                                         //loop
		int max_bound = max_bound_s;                                                          //max bound
        public int average_motion_percentage = 0;                                             //average motion percentage over 100 pixels
        int total = 0;                                                                        //total motion
        int motion_percentage = 0;                                                            //percentile motion       
        byte[,] ref_data = null;                                                              //refrence bitmap data
        public static byte each_pixel_threshold = 40;                                         //threshold sensity for change in value of each pixel
		
		//Motion zone values:
		public ArrayList motion_pixel_x=new ArrayList();
		public ArrayList motion_pixel_y=new ArrayList();
		public int motion_smallest_x=0;
		public int motion_smallest_y=0;
		
		/// <summary>
		/// Event firing method.
		/// </summary>
        public void OnMotionEvent(object MotionDetection, EventArgs eventArgs)
        {
            // Check if there are any Subscribers
            if (MotionEvent != null)
            {
                // Call the Event
                MotionEvent(MotionDetection, eventArgs);
            }
        }
        
		/// <summary>
		/// Process an image.
		/// </summary>
        public int Process(Bitmap image)
        {
			//Checking or we have first motion (default image) for compare:
            if (!first_motion_data)
            {
                ImageMatrix temp = new ImageMatrix(image);
                ref_data = temp.function;
                first_motion_data = true;
                return 0;
            }
            int width = image.Width;
            int height = image.Height;
            int value = each_pixel_threshold;
            int total_pixels = width * height;
            int pixel_motion = 0;

			//Get next image matrix:
            byte[,] current_data = new ImageMatrix(image).function;
			
			//Before processing need clean arrays:
			motion_pixel_x=new ArrayList();
			motion_pixel_y=new ArrayList();

			//Looping image matrix:
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
					//Checking pixel threshold and compare with each pixel threshold:
                    if (Math.Abs(current_data[i, j] - ref_data[i, j]) > value)
                    {
						//If difference is bigger as specified, fix this as motion:
                        pixel_motion++;
						
						//Add this pixel to currrent motion array:
						motion_pixel_x.Add(i);
						motion_pixel_y.Add(j);
						
						//Add smallest x and y:
						//if (motion_smallest_x==0) motion_smallest_x=i;
						//if (motion_smallest_y==0) motion_smallest_y=j;
						motion_smallest_x=i;
						motion_smallest_y=j;
                    }
                }
            }
			
			//Make current picture as default (it will be used in next comparation):
            Array.Copy(current_data, ref_data, current_data.Length);
			
			//Calculate percents of changes:
            motion_percentage = (pixel_motion * 100) / total_pixels;
			
			//Invoke event generation method:
            motionevent();
			
			//Checking or motion event occured:
            if (motion_percentage < 9)
            {
                normalized = false;
            }

			//Return motion percentage:
            return motion_percentage;
        }

		/// <summary>
		/// Method, that generates event:
		/// </summary>
        public void motionevent()
        {
            if (loop < max_bound)
            {
                total += motion_percentage;
                loop++;
            }
            else
            {
                loop = 0;
                average_motion_percentage = total / max_bound;
                max_bound = max_bound_s;
                total = 0;
                if (!normalized)
                {
                    if (average_motion_percentage > threshold)
                    {
                        OnMotionEvent(this, new EventArgs());
                    }
                    normalized = true;
                }
            }
        }

		/// <summary>
		/// Reallocates an array with a new size, and copies the contents
		/// of the old array to the new array.
        /// Arguments:
        ///   oldArray  the old array, to be reallocated.
        ///   newSize   the new array size.
        /// Returns     A new array with the same contents.
		/// </summary>
		private int[] ResizeArray (System.Array oldArray, int newSize) 
		{
		   int oldSize = oldArray.Length;
		   System.Type elementType = oldArray.GetType().GetElementType();
		   System.Array newArray = System.Array.CreateInstance(elementType,newSize);
		   int preserveLength = System.Math.Min(oldSize,newSize);
		   if (preserveLength > 0)
			  System.Array.Copy (oldArray,newArray,preserveLength);
		   return (int[])newArray; 
		}
    }
}
