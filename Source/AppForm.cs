using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Data;
using System.Management;
using System.Globalization;
using System.Text;

namespace ES.Software.Arduino_Windows_Client
{
	/// <summary>
	///	Main class, that preparing a form.
	/// </summary>
	//class AppForm : Form
	public partial class AppForm : Form
	{
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// AppForm constructor.
		/// </summary>
        public AppForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
	
		//Private local variables:
		private string conf_DeviceComPortNumberString = "";
		private string conf_curr_partialLine = "";
		private bool   conf_EnableDebugMessagesToLog=false;
		private bool   conf_ArduinoAnsweredHello=false;
	
		//Main menu:
		private MenuStrip menuStrip1 = new MenuStrip();
		private ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem();
		private ToolStripMenuItem fileSaveLogToolStripMenuItem = new ToolStripMenuItem();
		private ToolStripMenuItem fileClearLogToolStripMenuItem = new ToolStripMenuItem();
		private ToolStripMenuItem exitToolStripMenuItem = new ToolStripMenuItem();		

		private ToolStripMenuItem toolsToolStripMenuItem                              = new ToolStripMenuItem();
			private ToolStripMenuItem toolsLogViewerToolStripMenuItem                 = new ToolStripMenuItem();
			private ToolStripMenuItem tools13DiodedPanManagToolStripMenuItem          = new ToolStripMenuItem();
			private ToolStripMenuItem toolsHddEngineControlToolStripMenuItem          = new ToolStripMenuItem();
			private ToolStripMenuItem toolsSingleWebCamManagerToolStripMenuItem       = new ToolStripMenuItem();
			private ToolStripMenuItem toolsViewRealVideo                              = new ToolStripMenuItem();
			private ToolStripMenuItem toolsViewRealVideoWithInfo                      = new ToolStripMenuItem();
			private ToolStripMenuItem toolsRealVideoWithSimpleMotionDetectionMenuItem = new ToolStripMenuItem();
			private ToolStripMenuItem toolsGrayScaleVideo                             = new ToolStripMenuItem();
			private ToolStripMenuItem toolsMotionTwoFramesDifferenceDetector          = new ToolStripMenuItem();
			private ToolStripMenuItem toolsMotionSimpleBackgroundModelingDetector     = new ToolStripMenuItem();
			private ToolStripMenuItem toolsCustomFrameDifferenceMotionDetector        = new ToolStripMenuItem();
			private ToolStripMenuItem toolsMotionAreaHighlighting                     = new ToolStripMenuItem();
			private ToolStripMenuItem toolsMotionBorderHighlighting                   = new ToolStripMenuItem();
			private ToolStripMenuItem toolsGridMotionAreaProcessing                   = new ToolStripMenuItem();
			private ToolStripMenuItem toolsBlobCountingObjectsProcessing              = new ToolStripMenuItem();

		private ToolStripMenuItem helpToolStripMenuItem = new ToolStripMenuItem();
		private ToolStripMenuItem helpAboutToolStripMenuItem = new ToolStripMenuItem();
		
		private ToolStripMenuItem runMsPaintToolStripMenuItem = new ToolStripMenuItem();
	
		//Main controls bar:
		private ToolStrip toolStrip1 = new ToolStrip();
	
		//Main toolbar buttons:
		private ToolStripButton toolStripButton1    = new ToolStripButton();//Save log
		private ToolStripButton toolStripButton2    = new ToolStripButton();//Clear log
		private ToolStripButton toolStripButton3    = new ToolStripButton();//Log viewer
		private ToolStripButton toolStripButton4    = new ToolStripButton();//13 diodes panel manager
		private ToolStripButton toolStripButton5    = new ToolStripButton();//HDD motor control form
		private ToolStripButton toolStripButton6    = new ToolStripButton();//Single web camera manager
		private ToolStripButton toolStripButtonExit = new ToolStripButton();//Exit

		//Main controls:
		private TextBox objTextBox1 = new TextBox();
		
		//Status strip implementation:
		private StatusStrip statusStrip1 = new StatusStrip();
		private ToolStripStatusLabel toolStripStatusLabel1 = new ToolStripStatusLabel();
	
		/// <summary>
		/// Class ES.Software.Test1.AppForm constructor.
		/// This method will be invoked when creating new object.
		/// </summary>
		//public AppForm()
		private void InitializeComponent()
		{
			//Set resources object:
			ResourceManager resources = new ResourceManager("FormsResources",Assembly.GetExecutingAssembly());

			//Configure menu control:
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.toolsToolStripMenuItem, this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(383, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";

			//Main menu: Configure:
			this.fileToolStripMenuItem.Text = "File";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileSaveLogToolStripMenuItem,this.fileClearLogToolStripMenuItem,this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
						
				this.fileSaveLogToolStripMenuItem.Text = "Save log";
				this.fileSaveLogToolStripMenuItem.Name = "fileSaveLogToolStripMenuItem";
				this.fileSaveLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.fileSaveLogToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/floppy.ico")).ToBitmap());
				this.fileSaveLogToolStripMenuItem.Click += new System.EventHandler(this.SaveLog_Click);
				this.fileSaveLogToolStripMenuItem.Visible = false;
				
				this.fileClearLogToolStripMenuItem.Text = "Clear log";
				this.fileClearLogToolStripMenuItem.Name = "fileClearLogToolStripMenuItem";
				this.fileClearLogToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.fileClearLogToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/button-cancel.ico")).ToBitmap());
				this.fileClearLogToolStripMenuItem.Click += new System.EventHandler(this.ClearLog_Click);
				this.fileClearLogToolStripMenuItem.Visible = false;

				this.exitToolStripMenuItem.Text = "Exit";
				this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
				this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
				this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);

			//Adding all submenu to "Tools" menu item:
			this.toolsToolStripMenuItem.Text = "Tools";
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolsViewRealVideo,
			this.toolsViewRealVideoWithInfo,
			
			this.toolsRealVideoWithSimpleMotionDetectionMenuItem,
			this.toolsMotionTwoFramesDifferenceDetector,
			this.toolsMotionSimpleBackgroundModelingDetector,
			this.toolsCustomFrameDifferenceMotionDetector,
			this.toolsMotionAreaHighlighting,
			this.toolsMotionBorderHighlighting,
			this.toolsGridMotionAreaProcessing,
			this.toolsBlobCountingObjectsProcessing,
			
			this.toolsGrayScaleVideo,
			this.toolsLogViewerToolStripMenuItem,
			this.tools13DiodedPanManagToolStripMenuItem,
			this.toolsHddEngineControlToolStripMenuItem,
			this.toolsSingleWebCamManagerToolStripMenuItem});
			
				this.toolsLogViewerToolStripMenuItem.Text = "Log viewer";
				this.toolsLogViewerToolStripMenuItem.Name = "toolsLogViewerToolStripMenuItem";
				this.toolsLogViewerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.toolsLogViewerToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/default-document.ico")).ToBitmap());
				this.toolsLogViewerToolStripMenuItem.Click += new System.EventHandler(this.LogViewer_Click);
				this.toolsLogViewerToolStripMenuItem.Visible = false;

				this.tools13DiodedPanManagToolStripMenuItem.Text = "13 diodes panel manager";
				this.tools13DiodedPanManagToolStripMenuItem.Name = "tools13DiodedPanManagToolStripMenuItem";
				this.tools13DiodedPanManagToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.tools13DiodedPanManagToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/recycle-bin-empty.ico")).ToBitmap());
				this.tools13DiodedPanManagToolStripMenuItem.Click += new System.EventHandler(this.Diodes13PanelManager_Click);
				this.tools13DiodedPanManagToolStripMenuItem.Visible = false;

				this.toolsHddEngineControlToolStripMenuItem.Text = "HDD motor control form";
				this.toolsHddEngineControlToolStripMenuItem.Name = "toolsHddEngineControlToolStripMenuItem";
				this.toolsHddEngineControlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.toolsHddEngineControlToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/hard-disk.ico")).ToBitmap());
				this.toolsHddEngineControlToolStripMenuItem.Click += new System.EventHandler(this.HddEngineControlForm_Click);
				this.toolsHddEngineControlToolStripMenuItem.Visible = false;
				
				this.toolsSingleWebCamManagerToolStripMenuItem.Text = "Single web camera manager";
				this.toolsSingleWebCamManagerToolStripMenuItem.Name = "toolsSingleWebCamManagerToolStripMenuItem";
				this.toolsSingleWebCamManagerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.toolsSingleWebCamManagerToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsSingleWebCamManagerToolStripMenuItem.Click += new System.EventHandler(this.SingleWebCamManager_Click);
				this.toolsSingleWebCamManagerToolStripMenuItem.Visible = false;
				
				this.toolsViewRealVideo.Text = "Real video";
				this.toolsViewRealVideo.Name = "toolsSingleWebCamManagerToolStripMenuItem";
				this.toolsViewRealVideo.Size = new System.Drawing.Size(152, 22);
				this.toolsViewRealVideo.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsViewRealVideo.Click += new System.EventHandler(this.toolsViewRealVideo_Click);
				
				this.toolsViewRealVideoWithInfo.Text = "Real video with additional info";
				this.toolsViewRealVideoWithInfo.Name = "toolsSingleWebCamManagerToolStripMenuItem";
				this.toolsViewRealVideoWithInfo.Size = new System.Drawing.Size(152, 22);
				this.toolsViewRealVideoWithInfo.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsViewRealVideoWithInfo.Click += new System.EventHandler(this.toolsViewRealVideoWithInfo_Click);
				
				this.toolsRealVideoWithSimpleMotionDetectionMenuItem.Text = "Motion Detection Algorithm: Real video with simple motion detection";
				this.toolsRealVideoWithSimpleMotionDetectionMenuItem.Name = "toolsRealVideoWithSimpleMotionDetectionMenuItem";
				this.toolsRealVideoWithSimpleMotionDetectionMenuItem.Size = new System.Drawing.Size(152, 22);
				this.toolsRealVideoWithSimpleMotionDetectionMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsRealVideoWithSimpleMotionDetectionMenuItem.Click += new System.EventHandler(this.toolsRealVideoWithSimpleMotionDetectionMenuItem_Click);
				
				this.toolsMotionTwoFramesDifferenceDetector.Text = "Motion Detection Algorithm: Two frames difference motion detector";
				this.toolsMotionTwoFramesDifferenceDetector.Name = "toolsMotionTwoFramesDifferenceDetector";
				this.toolsMotionTwoFramesDifferenceDetector.Size = new System.Drawing.Size(152, 22);
				this.toolsMotionTwoFramesDifferenceDetector.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsMotionTwoFramesDifferenceDetector.Click += new System.EventHandler(this.toolsMotionTwoFramesDifferenceDetector_Click);
				
				this.toolsMotionSimpleBackgroundModelingDetector.Text = "Motion Detection Algorithm: Simple background modeling motion detector";
				this.toolsMotionSimpleBackgroundModelingDetector.Name = "toolsMotionSimpleBackgroundModelingDetector";
				this.toolsMotionSimpleBackgroundModelingDetector.Size = new System.Drawing.Size(152, 22);
				this.toolsMotionSimpleBackgroundModelingDetector.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsMotionSimpleBackgroundModelingDetector.Click += new System.EventHandler(this.toolsMotionSimpleBackgroundModelingDetector_Click);
				
				this.toolsCustomFrameDifferenceMotionDetector.Text = "Motion Detection Algorithm: Custom frame difference motion detector";
				this.toolsCustomFrameDifferenceMotionDetector.Name = "toolsCustomFrameDifferenceMotionDetector";
				this.toolsCustomFrameDifferenceMotionDetector.Size = new System.Drawing.Size(152, 22);
				this.toolsCustomFrameDifferenceMotionDetector.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsCustomFrameDifferenceMotionDetector.Click += new System.EventHandler(this.toolsCustomFrameDifferenceMotionDetector_Click);
				
				this.toolsMotionAreaHighlighting.Text = "Motion Processing Algorithm: Motion area highlighting";
				this.toolsMotionAreaHighlighting.Name = "toolsMotionAreaHighlighting";
				this.toolsMotionAreaHighlighting.Size = new System.Drawing.Size(152, 22);
				this.toolsMotionAreaHighlighting.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsMotionAreaHighlighting.Click += new System.EventHandler(this.toolsMotionAreaHighlighting_Click);
				
				this.toolsMotionBorderHighlighting.Text = "Motion Processing Algorithm: Motion border highlighting";
				this.toolsMotionBorderHighlighting.Name = "toolsMotionBorderHighlighting";
				this.toolsMotionBorderHighlighting.Size = new System.Drawing.Size(152, 22);
				this.toolsMotionBorderHighlighting.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsMotionBorderHighlighting.Click += new System.EventHandler(this.toolsMotionBorderHighlighting_Click);
				
				this.toolsGridMotionAreaProcessing.Text = "Motion Processing Algorithm: Grid motion area processing";
				this.toolsGridMotionAreaProcessing.Name = "toolsGridMotionAreaProcessing";
				this.toolsGridMotionAreaProcessing.Size = new System.Drawing.Size(152, 22);
				this.toolsGridMotionAreaProcessing.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsGridMotionAreaProcessing.Click += new System.EventHandler(this.toolsGridMotionAreaProcessing_Click);
				
				this.toolsBlobCountingObjectsProcessing.Text = "Motion Processing Algorithm: Blob counting objects processing";
				this.toolsBlobCountingObjectsProcessing.Name = "toolsBlobCountingObjectsProcessing";
				this.toolsBlobCountingObjectsProcessing.Size = new System.Drawing.Size(152, 22);
				this.toolsBlobCountingObjectsProcessing.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsBlobCountingObjectsProcessing.Click += new System.EventHandler(this.toolsBlobCountingObjectsProcessing_Click);

				this.toolsGrayScaleVideo.Text = "Gray scale video";
				this.toolsGrayScaleVideo.Name = "toolsGrayScaleVideo";
				this.toolsGrayScaleVideo.Size = new System.Drawing.Size(152, 22);
				this.toolsGrayScaleVideo.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/web-camera.ico")).ToBitmap());
				this.toolsGrayScaleVideo.Click += new System.EventHandler(this.toolsGrayScaleVideo_Click);

			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.helpAboutToolStripMenuItem});

				this.helpAboutToolStripMenuItem.Text = "About";
				this.helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
				this.helpAboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
				this.helpAboutToolStripMenuItem.Image = ((System.Drawing.Image)(Icon.ExtractAssociatedIcon("Ico/help1.ico")).ToBitmap());
				this.helpAboutToolStripMenuItem.Click += new System.EventHandler(this.About_Click);

			//Main controlbar: Configure control bar:
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButton1,
			this.toolStripButton2,
			this.toolStripButton3,
			this.toolStripButton4,
			this.toolStripButton5,
			this.toolStripButton6,
			this.toolStripButtonExit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(383, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";

			//Main controlbar buttons:
			this.toolStripButton1.Text = "Save log";
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = this.fileSaveLogToolStripMenuItem.Image;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Click += new System.EventHandler(this.SaveLog_Click);
			this.toolStripButton1.Visible = false;

			this.toolStripButton2.Text = "Clear log";
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = this.fileClearLogToolStripMenuItem.Image;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Click += new System.EventHandler(this.ClearLog_Click);
			this.toolStripButton2.Visible = false;
		
			this.toolStripButton3.Text = "Log viewer";
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = this.toolsLogViewerToolStripMenuItem.Image;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Click += new System.EventHandler(this.LogViewer_Click);
			this.toolStripButton3.Visible = false;

			this.toolStripButton4.Text = "13 diodes panel manager";
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = this.tools13DiodedPanManagToolStripMenuItem.Image;
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Click += new System.EventHandler(this.Diodes13PanelManager_Click);
			this.toolStripButton4.Visible = false;
			
			this.toolStripButton5.Text = "HDD motor control form";
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = this.toolsHddEngineControlToolStripMenuItem.Image;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Click += new System.EventHandler(this.HddEngineControlForm_Click);
			this.toolStripButton5.Visible = false;

			this.toolStripButton6.Text = this.toolsSingleWebCamManagerToolStripMenuItem.Text;
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = this.toolsSingleWebCamManagerToolStripMenuItem.Image;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton6.Click += new System.EventHandler(this.SingleWebCamManager_Click);
			this.toolStripButton6.Visible = false;

			this.toolStripButtonExit.Text = "Exit";
			this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
			this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonExit.Name = "toolStripButtonExit";
			this.toolStripButtonExit.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);

			//Configure text box 1:
			//this.objTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objTextBox1.Location = new System.Drawing.Point(0, this.menuStrip1.Height + this.toolStrip1.Height);
			this.objTextBox1.Multiline = true;
			this.objTextBox1.Name = "textBox1";
			this.objTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.objTextBox1.Size = new System.Drawing.Size(100, 100);
			this.objTextBox1.TabIndex = 0;
			this.objTextBox1.Visible = false;

			//Configure status control:
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 249);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(383, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			
			//13 LED controling interface:
			Setup13LedControlInterface();
			
			//HDD motor manage interface:
			HddMotorManagerInterfaceSetup();
			
			//Single web cam manager interface:
			SingleWebCamManagerSetup();

            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "";

			//Setup main form:
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 800);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Video Camera";
			this.Icon = Icon.ExtractAssociatedIcon("Ico/web-camera.ico");

			//Add to form controls:
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.objTextBox1);
			this.Controls.Add(this.flowLayoutPanel13LedCheckBoxes);
			this.Controls.Add(this.flowHddEngineControlForm);
			this.Controls.Add(this.groupBoxSingleWebCamManager);

			//Add form events:
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
		}

		/// <summary>
		/// Main form loading event.
		/// </summary>
		private void MainForm_Load(object sender, EventArgs e)
		{
			//Resize controls:
			MainFormControlsResize();
			
			//Inform that Arduino manager started:
			//SysDebugLog("INFO","Arduino manager started.");
			
			//Search for Arduino board and connect:
			//FindArduinoAndConnectToIt();
			
			//Get available cameras list:
			GetCamList();
		}

		/// <summary>
		/// Handling form resize events.
		/// </summary>
		private void MainForm_Resize(object sender, EventArgs e)
		{
			//Resize controls:
			MainFormControlsResize();
		}
		
		/// <summary>
		/// Set controls size.
		/// </summary>
		private void MainFormControlsResize()
		{
			//Set main textarea size:
			this.objTextBox1.Width  = this.Width - 10;
			this.objTextBox1.Height = this.Height - this.menuStrip1.Height - this.toolStrip1.Height - this.statusStrip1.Height - 30;
			
			//Resize groupBoxSingleWebCamManager:
			groupBoxSingleWebCamManager_Resize();
		}
		
		/// <summary>
		/// This method will connect to Arduino board.
		/// </summary>
		private void FindArduinoAndConnectToIt()
		{
			//Declare and set local variables:
			conf_DeviceComPortNumberString = GetComDevicePortNumberByDeviceName("USB Serial Port");
			
			//Check, or we have a device port:
			if (conf_DeviceComPortNumberString=="")
			{
				//Write error:
				SysDebugLog("ERROR","Device COM port not found.");
			}
			else
			{
				//Write information:
				SysDebugLog("INFO","Device COM port number is " + conf_DeviceComPortNumberString + ".");

                //Creating portname:
                Settings.Port.PortName = "COM" + conf_DeviceComPortNumberString;
				
				//Set baudrate:
				Settings.Port.BaudRate = 9600;
				
				//Prepare COM port object:
				CommPort com = CommPort.Instance;
				
                //Adding events:
                com.StatusChanged += OnStatusChanged;
                com.DataReceived += OnDataReceived;
				
				//Open port:
                com.Open();

                //Send hello:
                com.Send("!");
			}
		}
		
		/// <summary>
        /// Function returns port number for Arduino.
        /// </summary>
        /// <param name="inDeviceName">device name</param>
        /// <returns>string of port number or empty if nothing</returns>
        private string GetComDevicePortNumberByDeviceName(string inDeviceName)
        {
			//Declare and set local variables:
            string PortNumber = "";
			string oneitem = "";
			string temp1 = "";
			int index1;
			string temp2 = "";
			string temp3 = "";
			int i =0;
			
			//Check or we have device name:
            if (inDeviceName.Trim() == "") return "";
			
			//Handling all possible errors:
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select Name From Win32_PnPEntity");
                foreach (ManagementObject Port in searcher.Get())
                {
					//Set device name:
                    oneitem = (string)Port.GetPropertyValue("Name");
					
					//Check, or device is COM:
                    if (oneitem.Contains("COM"))
                    {
						//Check or we have required name:
						if (oneitem.ToLower().Contains(inDeviceName.ToLower()))
						{
							//Convert letters:
                            temp1 = oneitem.ToLower().Trim();
							
							//Get COM position in string:
                            index1 = temp1.IndexOf("(com");
							
							//Checking or we found COM and extract port number:
                            if (index1 > -1)
                            {
                                temp2 = temp1.Substring(index1);
                                temp3 = temp2.Replace("(com", "");
                                temp1 = temp3.Replace(")", "");
                            }
							
							//Set port number:
                            PortNumber = temp1.ToString();
							
							//Increase found by same name devices amount:
							i++;
						}
					}
                }
            }
            catch (IOException ex1)
            {
				SysDebugLog("ERROR","GetComDevicePortNumberByDeviceName: " + String.Format("{0}", ex1.ToString()));
                PortNumber = "";
            }
            catch (UnauthorizedAccessException ex2)
            {
				SysDebugLog("ERROR","GetComDevicePortNumberByDeviceName: " + String.Format("{0}", ex2.ToString()));
                PortNumber = "";
            }
            catch (Exception ex3)
            {
				SysDebugLog("ERROR","GetComDevicePortNumberByDeviceName: " + String.Format("{0}", ex3.ToString()));
                PortNumber = "";
            }
			
			//Check, or device just 1:
			if (i > 1)
			{
				SysDebugLog("ERROR","Exist more as 1 devices with name \"" + inDeviceName + "\"!");
				PortNumber = "";
			}

			//Return port number:
            return PortNumber;
        }

        /// <summary>
        /// Handle data received event from serial port.
        /// </summary>
        /// <param name="data">incoming data</param>
        public void OnDataReceived(string dataIn)
        {
			//DEBUG:
			if (conf_EnableDebugMessagesToLog)
			{
				this.objTextBox1.Text += "DEBUG: info from Arduino: " + dataIn + "\r\n";
				this.objTextBox1.Text += "DEBUG: this string codes: ";
			}

			//Check, or we have some data:
			if (dataIn.Length > 0)
			{
				//Looping current string all items:
				foreach (char c in dataIn)
				{
					//DEBUG, writing all current string codes:
					if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "[" + ((int)c).ToString() + "]";
				
					//Check or we have symbol 10:
					if (  (((int)c)==10) || (((int)c)==46)  )
					{
						//Check or string not empty:
						if (conf_curr_partialLine != "")
						{
							//OK string:
							if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "DEBUG: conf_curr_partialLine=" + conf_curr_partialLine + "\r\n";
							
							//Invoke messages from arduino parsing method:
							ParseArduinoMessages(conf_curr_partialLine);
						}
						
						//Clear line:
						conf_curr_partialLine="";
					}
					else
					{
						if (  (((int)c)!=10) && (((int)c)!=13) && (((int)c)!=46)  )
						{
							conf_curr_partialLine += c.ToString();
						}
					}
				}

				//DEBUG, writing all current string codes:
				if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "\r\n";
			}
		}
		
        /// <summary>
        /// This method parses Arduino messages.
        /// </summary>
        public void ParseArduinoMessages(string inMessage)
        {
			//Check, or Arduino answering Hello...:
			if (inMessage == "Hello, i'm Arduino")
			{
				conf_ArduinoAnsweredHello=true;
				SysDebugLog("INFO","Arduino answered hello...");
				if (conf_ArduinoAnsweredHello){/*  */}
			}
			
        }
		
        /// <summary>
        /// Update the connection status
        /// </summary>
        public void OnStatusChanged(string status)
        {
			//DEBUG:
			if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "INFO: status changed to " + status + "\r\n";// need in future some modification, maybe - just skip now
        }

		/// <summary>
		/// Menu item "File" > "Get latest data from internet"  click event.
		/// </summary>
        private void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

		/// <summary>
		/// Menu item "File" > "Exit" click event.
		/// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			CloseThis();
        }
		
		/// <summary>
		/// Menu item "Help" > "About" click event.
		/// </summary>
        private void About_Click(object sender, EventArgs e)
        {
			//MessageBox.Show(this.Text + "\n" + "aaa","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
			MessageBox.Show(this.Text + " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version,"Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		/// <summary>
		/// Button "Get latest data from internet" click event.
		/// </summary>
		private void toolStripButtonSyncWithInternet_Click(object sender, EventArgs e)
		{
			//MessageBox.Show(this.Text + "\n" + "aaa","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	
		/// <summary>
		/// Button "Exit" click event.
		/// </summary>
		private void toolStripButtonExit_Click(object sender, EventArgs e)
		{
			CloseThis();
		}
		
		/// <summary>
		/// "Save log" click.
		/// </summary>
		private void SaveLog_Click(object sender, EventArgs e)
		{
			//Declare and set local variables.
			DateTime dt = DateTime.Now;
			DateTimeFormatInfo dfi = new DateTimeFormatInfo();//NOTE: required "using System.Globalization;"
			dfi.MonthDayPattern = "yyyy_MM_dd_HH_mm_ss";
			string NextLine=this.objTextBox1.Text;
			string curr_PATH=System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Logs\\" + dt.ToString("m",dfi) + ".log";

			//DEBUG:
			//MessageBox.Show(curr_PATH,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

			//Save data:
			try
			{
				//Check or not empty log:
				if (NextLine.Trim()!="")
				{
					FileStream fs=new FileStream(curr_PATH, FileMode.Append, FileAccess.Write, FileShare.Write);
					fs.Close();
					StreamWriter sw=new StreamWriter(curr_PATH, true, Encoding.ASCII);
					sw.Write(NextLine);
					sw.Close();
				}
			}
			catch//(Exception ex)
			{
				MessageBox.Show("Save failed. Try again.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		/// <summary>
		/// "Clear log" click.
		/// </summary>
		private void ClearLog_Click(object sender, EventArgs e)
		{
			this.objTextBox1.Text="";
		}
		
		/// <summary>
		/// Method, to close main windows and finish a program.
		/// </summary>
        private void CloseThis()
        {
			//Close com port:
			try
			{
				//Close com port:
				CommPort com = CommPort.Instance;
				com.Close();
			}
			catch//(Exception ex)
			{
				//MessageBox.Show("Failded cleaning.\n" +  ex.ToString(),"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			//Disable cam:
			try
			{
				camera.Stop_Camera();
			}
			catch//(Exception ex)
			{
				//MessageBox.Show("Failded cleaning.\n" +  ex.ToString(),"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
            //Application.Exit();
            this.Close();
        }
		
		/// <summary>
		/// This method will send data to COM:
		/// </summary>
        private void SendDataToCom(string inValue)
        {
			CommPort com = CommPort.Instance;
			com.Send(inValue);
		}

		/// <summary>
		/// Default event for buttons, they don't have own method.
		/// </summary>
        private void NotSupportedButton(object sender, EventArgs e)
        {
            MessageBox.Show("Not supported button.","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		/// <summary>
		/// Method, to get latest data from internet.
		/// </summary>
		private void SysDebugLog(string inMsgType,string inMsg)
		{
			//Declare and set local variables.
			DateTime dt = DateTime.Now;
			DateTimeFormatInfo dfi = new DateTimeFormatInfo();//NOTE: required "using System.Globalization;"
			dfi.MonthDayPattern = "yyyy.MM.dd HH:mm:ss";
			
			//Add new entry to log:
			this.objTextBox1.Text = inMsgType + "\t" + dt.ToString("m",dfi) + "\t" + inMsg +"\r\n" + this.objTextBox1.Text;

			//if (conf_EnableDebugMessagesToLog) this.objTextBox1.Text += "INFO: status changed to " + status + "\r\n";// need in future some modification, maybe - just skip now
		}

		/// <summary>
		/// Show log viewer.
		/// </summary>
		private void LogViewer_Click(object sender, EventArgs e)
		{
			HideAllControls();
			this.objTextBox1.Visible = true;
		}

		/// <summary>
		/// Method, to hide all controls.
		/// </summary>
		private void HideAllControls()
		{
			this.toolStripStatusLabel1.Text = "";
			this.objTextBox1.Visible = false;
			this.flowLayoutPanel13LedCheckBoxes.Visible=false;
			this.flowHddEngineControlForm.Visible=false;
			this.groupBoxSingleWebCamManager.Visible = false;
		}
	}
}
//Revolutions per minute (abbreviated rpm, RPM, r/min, or r·min-1) is a unit of frequency of rotation: the number of full rotations completed in one minute around a fixed axis.