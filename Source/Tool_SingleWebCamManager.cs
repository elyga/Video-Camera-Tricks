using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using AForge.Video;
using AForge.Video.DirectShow;
using ES.Software.Video;

namespace ES.Software.Arduino_Windows_Client
{
    public partial class AppForm
    {
		//Configuration parameters:
		//private string conf_DefaultCameraName="D-Link DSB-C320";
		private string conf_DefaultCameraName="USB Video Device";
	
		//Single web cam manager form variables:
		private System.Windows.Forms.PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
		private System.Windows.Forms.ComboBox comboBoxVideoCamsListA = new System.Windows.Forms.ComboBox();
		private System.Windows.Forms.GroupBox groupBoxSingleWebCamManager = new System.Windows.Forms.GroupBox();
		private System.Windows.Forms.Button buttonSingleWebCamManagerOK = new System.Windows.Forms.Button();
        private FilterInfoCollection videosources = null;// to store list of video devices
        private Camera camera = null;

		//Text box for text information:
		private TextBox objLogInformation = new TextBox();

		/// <summary>
		/// Single web cam manager setup method.
		/// </summary>
		private void  SingleWebCamManagerSetup()
		{
            // 
            // comboBoxVideoCamsListA
            // 
			this.comboBoxVideoCamsListA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoCamsListA.FormattingEnabled = true;
            this.comboBoxVideoCamsListA.Location = new System.Drawing.Point(5, 20);
            this.comboBoxVideoCamsListA.Name = "comboBoxVideoCamsListA";
            this.comboBoxVideoCamsListA.Size = new System.Drawing.Size(180, 20);
            this.comboBoxVideoCamsListA.TabIndex = 2;
			this.comboBoxVideoCamsListA.Items.Add("--- Choose video device ---");
			this.comboBoxVideoCamsListA.SelectedIndex = 0;

            // 
            // buttonSingleWebCamManagerOK
            // 
            this.buttonSingleWebCamManagerOK.Location = new System.Drawing.Point(190, 20);
            this.buttonSingleWebCamManagerOK.Name = "buttonSingleWebCamManagerOK";
            this.buttonSingleWebCamManagerOK.Size = new System.Drawing.Size(40, 21);
            this.buttonSingleWebCamManagerOK.TabIndex = 0;
            this.buttonSingleWebCamManagerOK.Text = "Start";
            this.buttonSingleWebCamManagerOK.UseVisualStyleBackColor = true;
			this.buttonSingleWebCamManagerOK.Click += new System.EventHandler(this.buttonSingleWebCamManagerOK_Click);
			
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(5, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
			
			//Add text box for information writing:
			//this.objLogInformation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objLogInformation.Location = new System.Drawing.Point(5, this.menuStrip1.Height + this.toolStrip1.Height + this.pictureBox1.Height + 5);
			this.objLogInformation.Multiline = true;
			this.objLogInformation.Name = "objLogInformation";
			this.objLogInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.objLogInformation.Size = new System.Drawing.Size(300, 150);//Width and Hight
			this.objLogInformation.TabIndex = 0;
			this.objLogInformation.Visible = true;

            // 
            // groupBoxSingleWebCamManager
            // 
            this.groupBoxSingleWebCamManager.Controls.Add(this.comboBoxVideoCamsListA);
            this.groupBoxSingleWebCamManager.Controls.Add(this.buttonSingleWebCamManagerOK);
			this.groupBoxSingleWebCamManager.Controls.Add(this.pictureBox1);
			this.groupBoxSingleWebCamManager.Controls.Add(this.objLogInformation);
            //this.groupBoxSingleWebCamManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSingleWebCamManager.Location = new System.Drawing.Point(5, this.menuStrip1.Height + this.toolStrip1.Height+5);;
            this.groupBoxSingleWebCamManager.Name = "groupBoxSingleWebCamManager";
            this.groupBoxSingleWebCamManager.Size = new System.Drawing.Size(446, 348);
            this.groupBoxSingleWebCamManager.TabIndex = 0;
            this.groupBoxSingleWebCamManager.TabStop = false;
            this.groupBoxSingleWebCamManager.Text = "Single web camera manager";
			this.groupBoxSingleWebCamManager.Visible = true;
		}

		/// <summary>
		/// Resize event.
		/// </summary>
		private void groupBoxSingleWebCamManager_Resize()
		{
			//Set main textarea size:
			this.groupBoxSingleWebCamManager.Width  = this.Width - 15;
			this.groupBoxSingleWebCamManager.Height = this.Height - this.menuStrip1.Height - this.toolStrip1.Height - this.statusStrip1.Height - 45;
			
			//Set text box size:
			if (this.groupBoxSingleWebCamManager.Width > 10) this.objLogInformation.Width = this.groupBoxSingleWebCamManager.Width - 10;
			this.objLogInformation.Height = this.groupBoxSingleWebCamManager.Height - this.pictureBox1.Height - 60;
		}

		/// <summary>
		/// Handling click event.
		/// </summary>
		private void SingleWebCamManager_Click(object sender, EventArgs e)
		{
			//Hide all controls:
			HideAllControls();

			//Make this control visible:
			this.groupBoxSingleWebCamManager.Visible = true;
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsViewRealVideo_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=0;
			}
		}

		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsViewRealVideoWithInfo_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=1;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsRealVideoWithSimpleMotionDetectionMenuItem_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=2;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsGrayScaleVideo_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=3;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsMotionTwoFramesDifferenceDetector_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=4;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsMotionSimpleBackgroundModelingDetector_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=5;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsCustomFrameDifferenceMotionDetector_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=6;
			}
		}

		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsMotionAreaHighlighting_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=7;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsMotionBorderHighlighting_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=8;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsGridMotionAreaProcessing_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=9;
			}
		}
		
		/// <summary>
		/// Tool click handling.
		/// </summary>
		private void toolsBlobCountingObjectsProcessing_Click(object sender, EventArgs e)
		{
			//Check or camera not null:
			if ((camera == null) || (this.comboBoxVideoCamsListA.Enabled==true))
			{
				MessageBox.Show("Choose video first and start it.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				camera.conf_DisplayVideoTyype=10;
			}
		}

		/// <summary>
		/// This method will generate cam list and put
		/// it to combo box.
		/// </summary>
		private void GetCamList()
		{
			//Declare and set local variables:
			int i = 0;
		
            //Getting camera info:
            videosources = new AForge.Video.DirectShow.FilterInfoCollection(AForge.Video.DirectShow.FilterCategory.VideoInputDevice);

			//Checking or we have some information:
            if (videosources.Count != 0)
            {
				//Looping all devices:
                foreach (AForge.Video.DirectShow.FilterInfo videosource in videosources)
                {
					comboBoxVideoCamsListA.Items.Add(videosource.Name);
                }
            }
            else
            {
                SysDebugLog("ERROR","No camera Device Found.");
            }

			//Automatic choosing specified camera:
			if (conf_DefaultCameraName.Trim()!="")
			{
				if (comboBoxVideoCamsListA.Items.Count != 0)
				{
					//Looping items and trying select required cam:
					foreach(object ibjItem in comboBoxVideoCamsListA.Items)
					{
						if (ibjItem.ToString()==conf_DefaultCameraName.Trim())
						{
							comboBoxVideoCamsListA.SelectedIndex=i;
						}
						i++;
					}
				}
			}
		}
		
		/// <summary>
		/// Handling OK button click.
		/// </summary>
        private void buttonSingleWebCamManagerOK_Click(object sender, EventArgs e)
        {
			//Check or selected device:
			if (this.comboBoxVideoCamsListA.SelectedIndex > 0)
			{
				//Check button status:
				if (buttonSingleWebCamManagerOK.Text=="Start")
				{
					//Disable select:
					this.comboBoxVideoCamsListA.Enabled=false;
				
					//Set new text to button:
					buttonSingleWebCamManagerOK.Text="Stop";
					
					//Prepare camera:
					camera = new Camera(videosources[comboBoxVideoCamsListA.SelectedIndex-1].MonikerString);//Creating new camera object.
					camera.FrameEvent += new Camera.FrameEventHandler(camera_FrameEvent);                   //Declaring event function, that will be invoked, when new picture from camera will arrive.
					camera.Start_Camera();                                                                  //Invokes main Camera class method, that will begin picture capture from camera.
				}
				else if (buttonSingleWebCamManagerOK.Text=="Stop")
				{
					//Disable select:
					this.comboBoxVideoCamsListA.Enabled=true;
				
					//Set new text to button:
					buttonSingleWebCamManagerOK.Text="Start";
					
					//Stop camera:
					camera.Stop_Camera();
				}
			}
			else
			{
				MessageBox.Show("Choose video device.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		/// <summary>
		/// Method, to get latest data from internet.
		/// </summary>
		private void SysDebugLog2(string inMsgType,string inMsg)
		{
			//Declare and set local variables.
			DateTime dt = DateTime.Now;
			DateTimeFormatInfo dfi = new DateTimeFormatInfo();//NOTE: required "using System.Globalization;"
			dfi.MonthDayPattern = "yyyy.MM.dd HH:mm:ss";

			//Add new entry to log:
			this.objLogInformation.Text = inMsgType + "\t" + dt.ToString("m",dfi) + "\t" + inMsg +"\r\n" + this.objLogInformation.Text;

			//if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "INFO: status changed to " + status + "\r\n";// need in future some modification, maybe - just skip now
		}

		/// <summary>
		/// Camera frame event.
		/// This event will appear every time, when new image appears.
		/// </summary>
		private void camera_FrameEvent(object Camera, Bitmap image)
		{
			//Add latest image to picture box:
			pictureBox1.Image = image;
			
			//Add current speed to log:
			//SysDebugLog2("INFO","Speed: " + camera.FramesAmountSec.ToString() + " Frm/Sec");
			
			//Add current motion level to log:
			if ((camera.conf_DisplayVideoTyype==4) || (camera.conf_DisplayVideoTyype==5) || (camera.conf_DisplayVideoTyype==6) || (camera.conf_DisplayVideoTyype==10))
			{
				this.objLogInformation.Text =  "Speed: " + camera.FramesAmountSec.ToString() + " Frm/Sec";
				this.objLogInformation.Text += "\r\nCurrent motion level: " + camera.MotionLevel.ToString();
				this.objLogInformation.Text += "\r\nCurrent objects in motion: " + camera.MotionObjectsCount.ToString();
			}
		}
    }
}
