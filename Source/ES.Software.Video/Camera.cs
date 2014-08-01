using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Vision.Motion;

namespace ES.Software.Video
{
    class Camera
    {
		//Declare class variables:
		private Grayscale objGrayscale = null;                                                                                                                                        //AForge filter object, used to convert image from color to gray scale.
        private VideoCaptureDevice videosource = null;                                                                                                                                //Video device to be used.
        private Pen p = new Pen(Color.Black, 2);                                                                                                                                      //Black pen with with line width 2.
		private Pen objPenGreen2 = new Pen(Color.Green, 2);                                                                                                                           //Green pen with with line width 2.
        private SolidBrush[] sb = { new SolidBrush(Color.FromArgb(50, Color.Blue)), new SolidBrush(Color.FromArgb(70, Color.Red)), new SolidBrush(Color.FromArgb(70, Color.Green)) }; //Declare brush object.
		private MotionDetection MD = new MotionDetection();                                                                                                                           //Creating object, responsible for motion detection.
        public delegate void FrameEventHandler(object Camera, Bitmap image);                                                                                                          //Public delegate. It describeswhat parameters return by event.
        public event FrameEventHandler FrameEvent;                                                                                                                                    //Public event for the class.
		private int curr_FramesSecond=DateTime.Now.Second;                                                                                                                            //Save current second for frame.
		private int curr_FramesAmount=0;                                                                                                                                              //Updating frames amount.
		private int curr_FramesAmountToShow=0;                                                                                                                                        //Updating frames amount / second, that will be show.
		public int conf_DisplayVideoTyype=0;                                                                                                                                          //Define what video to display.
		private MotionDetector objMotionDetector = new MotionDetector(new TwoFramesDifferenceDetector( ),new MotionAreaHighlighting( ) );                                             //Create motion detector.
		private float current_MotionLevel = 0;                                                                                                                                        //Amount of motion, which is provided MotionLevel property.
		private MotionDetector objSimpleBackgroundModelingDetector = new MotionDetector(new SimpleBackgroundModelingDetector( ),new MotionAreaHighlighting());
		private MotionDetector objCustomFrameDifferenceDetector = new MotionDetector(new CustomFrameDifferenceDetector( ),new MotionAreaHighlighting() );
		private MotionDetector objMotionAreaHighlighting = new MotionDetector(new TwoFramesDifferenceDetector( ),new MotionAreaHighlighting());
		private MotionDetector objMotionBorderHighlighting = new MotionDetector(new TwoFramesDifferenceDetector(),new MotionBorderHighlighting( ) );
		private static IMotionDetector objTwoFramesDifferenceDetector = new TwoFramesDifferenceDetector();//Create instance of motion detection algorithm
		private static GridMotionAreaProcessing objGridMotionAreaProcessing = new GridMotionAreaProcessing(16,16 );//Create instance of motion processing algorithm
		private MotionDetector objMotionDetector2 = new MotionDetector(objTwoFramesDifferenceDetector, objGridMotionAreaProcessing );// create motion detector
		private static BlobCountingObjectsProcessing objBlobCountingObjectsProcessing = new BlobCountingObjectsProcessing( );// create instance of motion processing algorithm
		private MotionDetector objMotionDetector3 = new MotionDetector( objTwoFramesDifferenceDetector, objBlobCountingObjectsProcessing ); // create motion detector
		private int current_MotionObjectsCount = 0;
		
		/// <summary>
		///New frame event handler.
		/// </summary>
        private void videosource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
			//0 - Default video display type, it will simple show video, that got fromcamera:
			if (conf_DisplayVideoTyype == 0)
			{
				VideoSourceViewDefaultVideo(eventArgs);
			}
			
			//1 - View default video with added some information about it:
			if (conf_DisplayVideoTyype == 1)
			{
				VideoSourceViewDefaultVideoWithAdditionalInfo(eventArgs);
			}
			
			//2 - View default video with simple motion detection logic:
			if (conf_DisplayVideoTyype == 2)
			{
				VideoSourceViewDefaultVideoWithSimpleMotionDetection(eventArgs);
			}
			
			//3 - View grayscale video:
			if (conf_DisplayVideoTyype == 3)
			{
				//VideoSourceViewDefaultVideoInGrayScale(eventArgs);
				VideoSourceViewDefaultVideoInGrayScale2(eventArgs);
			}
			
			//4 - Two frames difference motion detector:
			if (conf_DisplayVideoTyype == 4)
			{
				MotionTwoFramesDifferenceDetector(eventArgs);
			}
			
			//5 - Simple background modeling motion detector:
			if (conf_DisplayVideoTyype == 5)
			{
				MotionSimpleBackgroundModelingDetector(eventArgs);
			}
			
			//6 - Custom frame difference motion detector:
			if (conf_DisplayVideoTyype == 6)
			{
				CustomFrameDifferenceMotionDetector(eventArgs);
			}
			
			//7 - Motion area highlighting:
			if (conf_DisplayVideoTyype == 7)
			{
				MotionAreaHighlighting(eventArgs);
			}
			
			//8 - Motion border highlighting:
			if (conf_DisplayVideoTyype == 8)
			{
				MotionBorderHighlighting(eventArgs);
			}
			
			//9 - Grid motion area processing:
			if (conf_DisplayVideoTyype == 9)
			{
				GridMotionAreaProcessing(eventArgs);
			}
			
			//10 - Blob counting objects processing:
			if (conf_DisplayVideoTyype == 10)
			{
				BlobCountingObjectsProcessing(eventArgs);
			}
        }
		
		/// <summary>
		/// PROPERTY, that will return speed in Frm/sec.
		/// </summary>
		public int FramesAmountSec
		{
			get { return curr_FramesAmountToShow; }
		}
		
		/// <summary>
		/// PROPERTY, that will return motion level.
		/// </summary>
		public float MotionLevel
		{
			get { return current_MotionLevel; }
		}

		/// <summary>
		/// PROPERTY, return objects in motion amount.
		/// </summary>
		public int MotionObjectsCount
		{
			get { return current_MotionObjectsCount; }
		}
		
		/// <summary>
		/// Set default brush parameters.
		/// </summary>
        public void Restore_brush()
        {
            sb[0] = new SolidBrush(Color.FromArgb(50, Color.Blue));
            sb[1] = new SolidBrush(Color.FromArgb(70, Color.Red));
            sb[2] = new SolidBrush(Color.FromArgb(70, Color.Green));
        }

		/// <summary>
		/// This method updating brush style by enetred integer number.
		/// </summary>
        public void Update_brush(int i)
        {
            //brushes_updated = true;
            if (i == 1)
            {
                sb[0] = new SolidBrush(Color.Blue);
            }
            else if (i == 2)
            {
                sb[1] = new SolidBrush(Color.Red);
            }
            else
            {
                sb[2] = new SolidBrush(Color.YellowGreen);
            }
        }

		/// <summary>
		/// Camera class constructor.
		/// </summary>
        public Camera(string MonikerString)
        {
            //Set what camera as video source will be used:
			videosource = new VideoCaptureDevice(MonikerString);
			
			//Declare motion event method:
			MD.MotionEvent += new MotionDetection.MotionEventHandler(MD_MotionEvent);

			//Set processing threshold:
			MD.threshold = 15;
			
			//Construct filter object:
			objGrayscale = new Grayscale(0.2125, 0.7154, 0.0721);
        }

		/// <summary>
		/// Event firing method.
		/// </summary>
        // constructor
        public void OnFraneEvent(object Camera, Bitmap image)
        {
            // Check if there are any Subscribers
            if (FrameEvent != null)
            {
                // Call the Event. Disposing event:
                FrameEvent(Camera, image);
            }
        }

		/// <summary>
		/// Motion event in picture occured.
		/// </summary>
        void MD_MotionEvent(object MotionDetection, EventArgs eventArgs)
        {

		}

		/// <summary>
		///Stop the camera source.
		/// </summary>
        public void Stop_Camera()
        {
            if (videosource.IsRunning)
            {
                videosource.Stop();
            }
        }

		/// <summary>
		///Start the camera source.
		/// </summary>
        public void Start_Camera()
        {
            if (!videosource.IsRunning)
            {
                videosource.NewFrame += new NewFrameEventHandler(videosource_NewFrame);
                videosource.Start();
            }
        }

		/// <summary>
		/// This method calculating speed.
		/// </summary>
		private void UpdateSpeedParameters()
		{
			//Calculate speed (Frames/second):
			if (curr_FramesSecond==DateTime.Now.Second){curr_FramesAmount++;}else
			{
				curr_FramesAmountToShow=curr_FramesAmount;
				curr_FramesAmount=1;
				curr_FramesSecond=DateTime.Now.Second;
			}
		}

		/// <summary>
		/// This method will generate and view simple video,
		/// that got from camera.
		/// </summary>
        void VideoSourceViewDefaultVideo(NewFrameEventArgs eventArgs)
        {
			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			
			//Update speed parameters:
			UpdateSpeedParameters();
			
			//Event firing method:
            OnFraneEvent(this, Image);
		}

		/// <summary>
		/// This method will generate and view simple video,
		/// that got from camera with additional information about this video.
		/// </summary>
        void VideoSourceViewDefaultVideoWithAdditionalInfo(NewFrameEventArgs eventArgs)
        {
			//Declare and set local variables:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Bitmap Image_percentile_motion=new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			int curr_percentile_motion=0;
			int curr_percentile_motion_diffrence=0;
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);
			
			//Calculate speed (Frames/second):
			if (curr_FramesSecond==DateTime.Now.Second){curr_FramesAmount++;}else
			{
				curr_FramesAmountToShow=curr_FramesAmount;
				curr_FramesAmount=1;
				curr_FramesSecond=DateTime.Now.Second;
			}
			
			//Close image:
			Image_percentile_motion = (Bitmap)Image.Clone(cloneRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			//Get motion percentile:
			curr_percentile_motion = MD.Process(Image_percentile_motion);
			
			//Get percentile motion diffrence:
			curr_percentile_motion_diffrence=MD.average_motion_percentage;
					
			//Creates a new Graphics from the specified Image:
			Graphics g = Graphics.FromImage(Image);
			
			//Add to camera picture black rectangle:
			//g.DrawRectangle(objPenGreen2, 10, 10, 100, 100);//Add rectangle.

			//Add text with information about Frames/Second:
			g.DrawString("Speed: " + curr_FramesAmountToShow.ToString() + " Frm/sec",new Font("Verdana",12),new SolidBrush(Color.Black),5,5);//Color.Tomato

			//Percentile motion show:
			g.DrawString("Percentile motion: " + curr_percentile_motion.ToString() + " %" ,new Font("Verdana",12),new SolidBrush(Color.Black),5,25);
			
			//Percentile motion diffrence show:
			g.DrawString("Percentile motion diffrence: " + curr_percentile_motion_diffrence.ToString() + " %" ,new Font("Verdana",12),new SolidBrush(Color.Black),5,45);
			
			//Show image size:
			g.DrawString("Image size: " + eventArgs.Frame.Width.ToString() + " x " + eventArgs.Frame.Height.ToString(),new Font("Verdana",12),new SolidBrush(Color.Black),5,65);
			
			//Clean graphics object:
			g.Dispose();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// This method will generate and view simple video,
		/// that arounf motion area will put green rectangle.
		/// </summary>
        void VideoSourceViewDefaultVideoWithSimpleMotionDetection(NewFrameEventArgs eventArgs)
        {
			//Declare and set local variables:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Bitmap Image_percentile_motion=new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			int curr_percentile_motion=0;
			int curr_percentile_motion_diffrence=0;
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);
			
			//Calculate speed (Frames/second):
			if (curr_FramesSecond==DateTime.Now.Second){curr_FramesAmount++;}else
			{
				curr_FramesAmountToShow=curr_FramesAmount;
				curr_FramesAmount=1;
				curr_FramesSecond=DateTime.Now.Second;
			}
			
			//Close image:
			Image_percentile_motion = (Bitmap)Image.Clone(cloneRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			//Get motion percentile:
			curr_percentile_motion = MD.Process(Image_percentile_motion);
			
			//Get percentile motion diffrence:
			curr_percentile_motion_diffrence=MD.average_motion_percentage;

			//Creates a new Graphics from the specified Image:
			Graphics g = Graphics.FromImage(Image);

			//Draw motion pixels:
			if (MD.motion_pixel_x.Count > 0)
			{
				//Put rectangle around motion position:
				int x=0;
				int y=0;
				if (MD.motion_smallest_x > 50) { x= MD.motion_smallest_x-50;}
				if (MD.motion_smallest_y > 50) { y= MD.motion_smallest_y-50;}
				g.DrawRectangle(objPenGreen2, x, y, 100, 100);
				
			}

			//Clean graphics object:
			g.Dispose();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// View video in grayscale.
		/// </summary>
        void VideoSourceViewDefaultVideoInGrayScale(NewFrameEventArgs eventArgs)
        {
			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();

			//Prepare grayscale image (slow method):
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);
			Bitmap ImageGray=new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			ImageGray = (Bitmap)Image.Clone(cloneRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			ImageMatrix temp = new ImageMatrix(ImageGray);
			ImageGray = temp.ToImage();
			
			//Event firing method:
            OnFraneEvent(this, ImageGray);
		}

		/// <summary>
		/// View video in grayscale.
		/// </summary>
        void VideoSourceViewDefaultVideoInGrayScale1(NewFrameEventArgs eventArgs)
        {
			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();

			//Prepare grayscale image (slow method):
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);
			Bitmap ImageGray=new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			ImageGray = Extensions.MakeGrayscale3((Bitmap)Image.Clone(cloneRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb));

			//Event firing method:
            OnFraneEvent(this, ImageGray);
		}

		/// <summary>
		/// View video in grayscale.
		/// </summary>
        private void VideoSourceViewDefaultVideoInGrayScale2(NewFrameEventArgs eventArgs)
        {
			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Invoke object:
			Bitmap ImageGray = objGrayscale.Apply((Bitmap)Image.Clone(cloneRect, System.Drawing.Imaging.PixelFormat.Format32bppArgb));
			
			//Event firing method:
            OnFraneEvent(this, ImageGray);
		}
		
		/// <summary>
		/// Two frames difference motion detector.
		/// This type of motion detector is the simplest one and the quickest one. 
		/// The idea of this detector is based on finding amount of difference in 
		/// two consequent frames of video stream. The greater is difference, 
		/// It does not suite very well those tasks, where it is required to precisely 
		/// highlight moving object. However it has recommended itself very well for 
		/// those tasks, which just require motion detection.
		/// </summary>
        private void MotionTwoFramesDifferenceDetector(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			current_MotionLevel=objMotionDetector.ProcessFrame(eventArgs.Frame); 
			//if ( detector.ProcessFrame( videoFrame ) > 0.02 ) //Do some job.

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}

		/// <summary>
		/// Simple background modeling motion detector.
		/// In contrast to the above mentioned motion detector, this motion detector is 
		/// based on finding difference between current video frame and a frame representing 
		/// background. This motion detector tries to use simple techniques of modeling scene's 
		/// background and updating it through time to get into account scene's changes. The 
		/// background modeling feature of this motion detector gives the ability of more precise 
		/// highlighting of motion regions.
		/// </summary>
        private void MotionSimpleBackgroundModelingDetector(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			current_MotionLevel=objSimpleBackgroundModelingDetector.ProcessFrame(eventArgs.Frame); 
			//if ( detector.ProcessFrame( videoFrame ) > 0.02 ) //Do some job.

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// Custom frame difference motion detector.
		/// This class implements motion detection algorithm, which is based on the difference of 
		/// current video frame with predefined background frame, which puts it in-between of the two 
		/// above classes. On the one hand this motion detector is based on simple differencing as 
		/// the two frames difference motion detector, which makes it fast. On the other hand it does 
		/// differencing of current video frame with background frame, which may allow finding moving 
		/// objects, but not areas of changes (like in simple background modeling motion detector). 
		/// However, user needs to specify background frame on his own (or the algorithm will take first 
		/// video frame as a background frame) and the algorithm will never try to update it, which 
		/// means no adaptation to scene changes.
		/// </summary>
        private void CustomFrameDifferenceMotionDetector(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			current_MotionLevel=objCustomFrameDifferenceDetector.ProcessFrame(eventArgs.Frame); 
			//if ( detector.ProcessFrame( videoFrame ) > 0.02 ) //Do some job.

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// Motion area highlighting.
		/// This motion processing algorithm is aimed just to highlight motion areas found by motion detection 
		/// algorithm with specified color. All of the above screenshots demonstrate the work of motion are 
		/// highlighting.
		/// </summary>
        private void MotionAreaHighlighting(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			objMotionAreaHighlighting.ProcessFrame(eventArgs.Frame); 

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// Motion border highlighting.
		/// This motion processing algorithm is aimed to highlight only borders of motion areas found by motion 
		/// detection algorithm. It is supposed to be used only with those motion detection algorithms, which may 
		/// accurately locate moving objects.
		/// </summary>
        private void MotionBorderHighlighting(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			objMotionBorderHighlighting.ProcessFrame(eventArgs.Frame); 

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
		
		/// <summary>
		/// Grid motion area processing
		/// This motion processing algorithm allows to do grid processing of motion frame. This means that entire motion 
		/// frame can be divided by a grid into certain amount of cells and motion level can be calculated for each cell 
		/// individually, so you may know which part of the video frame had more motion. In addition this motion processing 
		/// algorithm provides highlighting, which may be enabled or disable. User may specify threshold for cells' motion 
		/// level to highlight.
		/// </summary>
        private void GridMotionAreaProcessing(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			objMotionDetector2.ProcessFrame(eventArgs.Frame);

			//Check motion level in 5th row 8th column:
			if (objGridMotionAreaProcessing.MotionGrid[5, 8] > 0.15 )
			{
				// ...
			}

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
	
		/// <summary>
		/// Blob counting objects processing
		/// This motion processing algorithm allows counting separate objects in the motion frame, which is provided by motion detection 
		/// algorithm. In addition it may also highlight detected objects with a rectangle of specified color. The algorithm counts and 
		/// highlights only those objects, which size satisfies specified limits - it is possible to configure this motion processing 
		/// algorithm to ignore objects smaller than specified size.
		///
		/// This motion processing algorithm is supposed to be used only with those motion detection algorithms, which may accurately 
		/// locate moving objects.
		/// </summary>
        private void BlobCountingObjectsProcessing(NewFrameEventArgs eventArgs)
        {
			//Process new video frame and set motion level:
			current_MotionLevel=objMotionDetector3.ProcessFrame(eventArgs.Frame);

			//Get objects amount:
			current_MotionObjectsCount = objBlobCountingObjectsProcessing.ObjectsCount;

			//Prepare image for display:
            Bitmap Image = new Bitmap(eventArgs.Frame.Width, eventArgs.Frame.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			Graphics _copy = Graphics.FromImage(Image);
            _copy.DrawImage(eventArgs.Frame, new Point(0, 0));
            _copy.Dispose();
			Rectangle cloneRect = new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height);

			//Update speed parameters:
			UpdateSpeedParameters();

			//Event firing method:
            OnFraneEvent(this, Image);
		}
	
    }
}
