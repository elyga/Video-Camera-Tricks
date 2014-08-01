using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ES.Software.Arduino_Windows_Client
{
    public partial class AppForm
    {	
		//HDD engine control form:
        private System.Windows.Forms.TrackBar trackBarHddMotorSpeed = new System.Windows.Forms.TrackBar();
        private System.Windows.Forms.Label trackBarHddMotorSpeedValue = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button vtnStartHddMotor = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button buttonStopHddMotor = new System.Windows.Forms.Button();
		private System.Windows.Forms.FlowLayoutPanel flowHddEngineControlForm = new System.Windows.Forms.FlowLayoutPanel();

		/// <summary>
		/// HDD motor manage interface setup method.
		/// </summary>
		private void  HddMotorManagerInterfaceSetup()
		{
            // 
            // flowHddEngineControlForm
            // 
            //this.flowHddEngineControlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowHddEngineControlForm.Controls.Add(this.trackBarHddMotorSpeedValue);
            this.flowHddEngineControlForm.Controls.Add(this.trackBarHddMotorSpeed);
            this.flowHddEngineControlForm.Controls.Add(this.vtnStartHddMotor);
            this.flowHddEngineControlForm.Controls.Add(this.buttonStopHddMotor);
            this.flowHddEngineControlForm.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowHddEngineControlForm.Location = new System.Drawing.Point(20, this.menuStrip1.Height + this.toolStrip1.Height+20);
            this.flowHddEngineControlForm.Name = "flowHddEngineControlForm";
            this.flowHddEngineControlForm.Size = new System.Drawing.Size(290, 237);
            this.flowHddEngineControlForm.TabIndex = 7;
			this.flowHddEngineControlForm.Visible = false;
            // 
            // trackBarHddMotorSpeed
            // 
            this.trackBarHddMotorSpeed.Location = new System.Drawing.Point(3, 16);
            this.trackBarHddMotorSpeed.Maximum = 20;
            this.trackBarHddMotorSpeed.Name = "trackBarHddMotorSpeed";
            this.trackBarHddMotorSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarHddMotorSpeed.Size = new System.Drawing.Size(42, 199);
            this.trackBarHddMotorSpeed.TabIndex = 0;
            this.trackBarHddMotorSpeed.Scroll += new System.EventHandler(this.trackBarHddMotorSpeed_Scroll);
            // 
            // trackBarHddMotorSpeedValue
            // 
            this.trackBarHddMotorSpeedValue.AutoSize = true;
            this.trackBarHddMotorSpeedValue.Location = new System.Drawing.Point(3, 0);
            this.trackBarHddMotorSpeedValue.Name = "trackBarHddMotorSpeedValue";
            this.trackBarHddMotorSpeedValue.Size = new System.Drawing.Size(13, 13);
            this.trackBarHddMotorSpeedValue.TabIndex = 1;
            this.trackBarHddMotorSpeedValue.Text = "0";
            // 
            // vtnStartHddMotor
            // 
            this.vtnStartHddMotor.Location = new System.Drawing.Point(51, 3);
            this.vtnStartHddMotor.Name = "vtnStartHddMotor";
            this.vtnStartHddMotor.Size = new System.Drawing.Size(78, 22);
            this.vtnStartHddMotor.TabIndex = 2;
            this.vtnStartHddMotor.Text = "Start motor";
            this.vtnStartHddMotor.UseVisualStyleBackColor = true;
			this.vtnStartHddMotor.Click += new System.EventHandler(this.vtnStartHddMotor_Click);
            // 
            // buttonStopHddMotor
            // 
            this.buttonStopHddMotor.Location = new System.Drawing.Point(51, 31);
            this.buttonStopHddMotor.Name = "buttonStopHddMotor";
            this.buttonStopHddMotor.Size = new System.Drawing.Size(78, 23);
            this.buttonStopHddMotor.TabIndex = 3;
            this.buttonStopHddMotor.Text = "Stop motor";
            this.buttonStopHddMotor.UseVisualStyleBackColor = true;
			this.buttonStopHddMotor.Click += new System.EventHandler(this.buttonStopHddMotor_Click);
			this.buttonStopHddMotor.Enabled=false;
		}
		
		/// <summary>
		/// Slider value changed event.
		/// </summary>
        private void trackBarHddMotorSpeed_Scroll(object sender, EventArgs e)
        {
			//Declare and set local variables:
			int curr_IntervalBetweenSteps=1000;
		
			//Set number:
            trackBarHddMotorSpeedValue.Text = trackBarHddMotorSpeed.Value.ToString();// + " rpm";
			
			//Set interval:
			if (trackBarHddMotorSpeed.Value==1) curr_IntervalBetweenSteps = 200;
			if (trackBarHddMotorSpeed.Value==2) curr_IntervalBetweenSteps = 100;
			if (trackBarHddMotorSpeed.Value==3) curr_IntervalBetweenSteps = 90;
			if (trackBarHddMotorSpeed.Value==4) curr_IntervalBetweenSteps = 80;
			if (trackBarHddMotorSpeed.Value==5) curr_IntervalBetweenSteps = 70;
			if (trackBarHddMotorSpeed.Value==6) curr_IntervalBetweenSteps = 60;
			if (trackBarHddMotorSpeed.Value==7) curr_IntervalBetweenSteps = 50;
			if (trackBarHddMotorSpeed.Value==8)  curr_IntervalBetweenSteps = 40;
			if (trackBarHddMotorSpeed.Value==9)  curr_IntervalBetweenSteps = 30;
			if (trackBarHddMotorSpeed.Value==10) curr_IntervalBetweenSteps = 20;
			if (trackBarHddMotorSpeed.Value==11) curr_IntervalBetweenSteps = 10;
			if (trackBarHddMotorSpeed.Value==12) curr_IntervalBetweenSteps =  9;
			if (trackBarHddMotorSpeed.Value==13) curr_IntervalBetweenSteps =  8;
			if (trackBarHddMotorSpeed.Value==14) curr_IntervalBetweenSteps =  7;
			if (trackBarHddMotorSpeed.Value==15) curr_IntervalBetweenSteps =  6;
			if (trackBarHddMotorSpeed.Value==16) curr_IntervalBetweenSteps =  5;
			if (trackBarHddMotorSpeed.Value==17) curr_IntervalBetweenSteps =  4;
			if (trackBarHddMotorSpeed.Value==18) curr_IntervalBetweenSteps =  3;
			if (trackBarHddMotorSpeed.Value==19) curr_IntervalBetweenSteps =  2;
			if (trackBarHddMotorSpeed.Value==20) curr_IntervalBetweenSteps =  1;
			/*
			if (trackBarHddMotorSpeed.Value==trackBarHddMotorSpeed.Maximum)
			{
				curr_IntervalBetweenSteps = 9;
			}
			else if (trackBarHddMotorSpeed.Value==(trackBarHddMotorSpeed.Maximum  - 1))
			{
				curr_IntervalBetweenSteps = 10;
			}
			else if (trackBarHddMotorSpeed.Value==(trackBarHddMotorSpeed.Maximum  - 2))
			{
				curr_IntervalBetweenSteps = 20;
			}
			else if (trackBarHddMotorSpeed.Value==(trackBarHddMotorSpeed.Maximum  - 3))
			{
				curr_IntervalBetweenSteps = 30;
			}
			else if (trackBarHddMotorSpeed.Value==(trackBarHddMotorSpeed.Maximum  - 4))
			{
				curr_IntervalBetweenSteps = 40;
			}
			else
			{
				curr_IntervalBetweenSteps = curr_IntervalBetweenSteps - trackBarHddMotorSpeed.Value * 49;
			}
			*/
			
			//Set interval:
			this.toolStripStatusLabel1.Text = curr_IntervalBetweenSteps.ToString();
			
			//Send  "B" to Arduino:
			SendDataToCom(curr_IntervalBetweenSteps.ToString());
			
			//Setup buttons:
			if (trackBarHddMotorSpeed.Value==0)
			{
				if (this.buttonStopHddMotor.Enabled)
				{
					buttonStopHddMotor_Click(null,null);
				}
			}
			if (trackBarHddMotorSpeed.Value==1)
			{
				if(this.vtnStartHddMotor.Enabled)
				{				
					vtnStartHddMotor_Click(null,null);
				}
			}
        }

		/// <summary>
		/// View 13 diodes manager panel.
		/// </summary>
		private void HddEngineControlForm_Click(object sender, EventArgs e)
		{
			HideAllControls();
			this.flowHddEngineControlForm.Visible=true;
		}
		
		/// <summary>
		/// Start button click.
		/// </summary>
        private void vtnStartHddMotor_Click(object sender, EventArgs e)
        {
			//Enable/disable required buttons:
			this.vtnStartHddMotor.Enabled=false;
			this.buttonStopHddMotor.Enabled=true;
			trackBarHddMotorSpeed.Value=1;
			trackBarHddMotorSpeedValue.Text="1";
			
			//Send  "A" to Arduino:
			SendDataToCom("A");
        }

		/// <summary>
		/// Stop button click.
		/// </summary>
        private void buttonStopHddMotor_Click(object sender, EventArgs e)
        {
			//Enable/disable required buttons:
			this.vtnStartHddMotor.Enabled=true;
			this.buttonStopHddMotor.Enabled=false;
			trackBarHddMotorSpeed.Value=0;
			trackBarHddMotorSpeedValue.Text="0";

			//Send  "B" to Arduino:
			SendDataToCom("B");
        }
    }
}
