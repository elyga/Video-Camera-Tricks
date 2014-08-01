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
		//13 checkboxes for LED controling list:
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13LedCheckBoxes = new System.Windows.Forms.FlowLayoutPanel();
        private System.Windows.Forms.CheckBox checkBoxLed1 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed2 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed3 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed4 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed5 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed6 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed7 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed8 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed9 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed10 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed11 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed12 = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox checkBoxLed13 = new System.Windows.Forms.CheckBox();

		/// <summary>
		/// Setup 13 LED control interface.
		/// </summary>
		private void Setup13LedControlInterface()
		{
            this.checkBoxLed1.Text = "Led 1";
			this.checkBoxLed1.Name = "checkBoxLed1";
            this.checkBoxLed1.UseVisualStyleBackColor = true;
			this.checkBoxLed1.CheckedChanged += new System.EventHandler(this.checkBoxLed1_CheckedChanged);
			
            this.checkBoxLed2.Text = "Led 2";
			this.checkBoxLed2.Name = "checkBoxLed2";
            this.checkBoxLed2.UseVisualStyleBackColor = true;
			this.checkBoxLed2.CheckedChanged += new System.EventHandler(this.checkBoxLed2_CheckedChanged);
			
            this.checkBoxLed3.Text = "Led 3";
			this.checkBoxLed3.Name = "checkBoxLed3";
            this.checkBoxLed3.UseVisualStyleBackColor = true;
			this.checkBoxLed3.CheckedChanged += new System.EventHandler(this.checkBoxLed3_CheckedChanged);
			
            this.checkBoxLed4.Text = "Led 4";
			this.checkBoxLed4.Name = "checkBoxLed4";
            this.checkBoxLed4.UseVisualStyleBackColor = true;
			this.checkBoxLed4.CheckedChanged += new System.EventHandler(this.checkBoxLed4_CheckedChanged);
			
            this.checkBoxLed5.Text = "Led 5";
			this.checkBoxLed5.Name = "checkBoxLed5";
            this.checkBoxLed5.UseVisualStyleBackColor = true;
			this.checkBoxLed5.CheckedChanged += new System.EventHandler(this.checkBoxLed5_CheckedChanged);
			
            this.checkBoxLed6.Text = "Led 6";
			this.checkBoxLed6.Name = "checkBoxLed6";
            this.checkBoxLed6.UseVisualStyleBackColor = true;
			this.checkBoxLed6.CheckedChanged += new System.EventHandler(this.checkBoxLed6_CheckedChanged);
			
            this.checkBoxLed7.Text = "Led 7";
			this.checkBoxLed7.Name = "checkBoxLed7";
            this.checkBoxLed7.UseVisualStyleBackColor = true;
			this.checkBoxLed7.CheckedChanged += new System.EventHandler(this.checkBoxLed7_CheckedChanged);
			
            this.checkBoxLed8.Text = "Led 8";
			this.checkBoxLed8.Name = "checkBoxLed8";
            this.checkBoxLed8.UseVisualStyleBackColor = true;
			this.checkBoxLed8.CheckedChanged += new System.EventHandler(this.checkBoxLed8_CheckedChanged);
			
            this.checkBoxLed9.Text = "Led 9";
			this.checkBoxLed9.Name = "checkBoxLed9";
            this.checkBoxLed9.UseVisualStyleBackColor = true;
			this.checkBoxLed9.CheckedChanged += new System.EventHandler(this.checkBoxLed9_CheckedChanged);
			
            this.checkBoxLed10.Text = "Led 10";
			this.checkBoxLed10.Name = "checkBoxLed10";
            this.checkBoxLed10.UseVisualStyleBackColor = true;
			this.checkBoxLed10.CheckedChanged += new System.EventHandler(this.checkBoxLed10_CheckedChanged);
			
            this.checkBoxLed11.Text = "Led 11";
			this.checkBoxLed11.Name = "checkBoxLed11";
            this.checkBoxLed11.UseVisualStyleBackColor = true;
			this.checkBoxLed11.CheckedChanged += new System.EventHandler(this.checkBoxLed11_CheckedChanged);
			
            this.checkBoxLed12.Text = "Led 12";
			this.checkBoxLed12.Name = "checkBoxLed12";
            this.checkBoxLed12.UseVisualStyleBackColor = true;
			this.checkBoxLed12.CheckedChanged += new System.EventHandler(this.checkBoxLed12_CheckedChanged);
			
            this.checkBoxLed13.Text = "Led 13";
			this.checkBoxLed13.Name = "checkBoxLed13";
            this.checkBoxLed13.UseVisualStyleBackColor = true;
			this.checkBoxLed13.CheckedChanged += new System.EventHandler(this.checkBoxLed13_CheckedChanged);
			
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed1);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed2);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed3);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed4);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed5);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed6);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed7);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed8);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed9);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed10);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed11);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed12);
            this.flowLayoutPanel13LedCheckBoxes.Controls.Add(this.checkBoxLed13);
            this.flowLayoutPanel13LedCheckBoxes.Location = new System.Drawing.Point(20, this.menuStrip1.Height + this.toolStrip1.Height+20);
            this.flowLayoutPanel13LedCheckBoxes.Name = "flowLayoutPanel13LedCheckBoxes";
            this.flowLayoutPanel13LedCheckBoxes.Size = new System.Drawing.Size(91, 400);
            this.flowLayoutPanel13LedCheckBoxes.TabIndex = 6;
			this.flowLayoutPanel13LedCheckBoxes.Visible=false;
		}
	
		/// <summary>
		/// View 13 diodes manager panel.
		/// </summary>
		private void Diodes13PanelManager_Click(object sender, EventArgs e)
		{
			HideAllControls();
			this.flowLayoutPanel13LedCheckBoxes.Visible=true;
		}

		/// <summary>
		/// Led 1 check box checking event
		/// </summary>
        private void checkBoxLed1_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed1.Checked)
			{
				SysDebugLog("INFO","Led 1 on command sending.");
				SendDataToCom("A");
			}
			else
			{
				SysDebugLog("INFO","Led 1 off command sending.");
				SendDataToCom("a");
			}
        }

		/// <summary>
		/// Led 2 check box checking event
		/// </summary>
        private void checkBoxLed2_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed2.Checked)
			{
				SysDebugLog("INFO","Led 2 on command sending.");
				SendDataToCom("B");
			}
			else
			{
				SysDebugLog("INFO","Led 2 off command sending.");
				SendDataToCom("b");
			}
        }
		
		/// <summary>
		/// Led 3 check box checking event
		/// </summary>
        private void checkBoxLed3_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed3.Checked)
			{
				SysDebugLog("INFO","Led 3 on command sending.");
				SendDataToCom("C");
			}
			else
			{
				SysDebugLog("INFO","Led 3 off command sending.");
				SendDataToCom("c");
			}
        }
		
		/// <summary>
		/// Led 4 check box checking event
		/// </summary>
        private void checkBoxLed4_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed4.Checked)
			{
				SysDebugLog("INFO","Led 4 on command sending.");
				SendDataToCom("D");
			}
			else
			{
				SysDebugLog("INFO","Led 4 off command sending.");
				SendDataToCom("d");
			}
        }
		
		/// <summary>
		/// Led 5 check box checking event
		/// </summary>
        private void checkBoxLed5_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed5.Checked)
			{
				SysDebugLog("INFO","Led 5 on command sending.");
				SendDataToCom("E");
			}
			else
			{
				SysDebugLog("INFO","Led 5 off command sending.");
				SendDataToCom("e");
			}
        }
		
		/// <summary>
		/// Led 6 check box checking event
		/// </summary>
        private void checkBoxLed6_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed6.Checked)
			{
				SysDebugLog("INFO","Led 6 on command sending.");
				SendDataToCom("F");
			}
			else
			{
				SysDebugLog("INFO","Led 6 off command sending.");
				SendDataToCom("f");
			}
        }
		
		/// <summary>
		/// Led 7 check box checking event
		/// </summary>
        private void checkBoxLed7_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed7.Checked)
			{
				SysDebugLog("INFO","Led 7 on command sending.");
				SendDataToCom("G");
			}
			else
			{
				SysDebugLog("INFO","Led 7 off command sending.");
				SendDataToCom("g");
			}
        }

		/// <summary>
		/// Led 8 check box checking event
		/// </summary>
        private void checkBoxLed8_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed8.Checked)
			{
				SysDebugLog("INFO","Led 8 on command sending.");
				SendDataToCom("H");
			}
			else
			{
				SysDebugLog("INFO","Led 8 off command sending.");
				SendDataToCom("h");
			}
        }
		
		/// <summary>
		/// Led 9 check box checking event
		/// </summary>
        private void checkBoxLed9_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed9.Checked)
			{
				SysDebugLog("INFO","Led 9 on command sending.");
				SendDataToCom("I");
			}
			else
			{
				SysDebugLog("INFO","Led 9 off command sending.");
				SendDataToCom("i");
			}
        }
		
		/// <summary>
		/// Led 10 check box checking event
		/// </summary>
        private void checkBoxLed10_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed10.Checked)
			{
				SysDebugLog("INFO","Led 10 on command sending.");
				SendDataToCom("J");
			}
			else
			{
				SysDebugLog("INFO","Led 10 off command sending.");
				SendDataToCom("j");
			}
        }
		
		/// <summary>
		/// Led 11 check box checking event
		/// </summary>
        private void checkBoxLed11_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed11.Checked)
			{
				SysDebugLog("INFO","Led 11 on command sending.");
				SendDataToCom("K");
			}
			else
			{
				SysDebugLog("INFO","Led 11 off command sending.");
				SendDataToCom("k");
			}
        }
		
		/// <summary>
		/// Led 12 check box checking event
		/// </summary>
        private void checkBoxLed12_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed12.Checked)
			{
				SysDebugLog("INFO","Led 12 on command sending.");
				SendDataToCom("L");
			}
			else
			{
				SysDebugLog("INFO","Led 12 off command sending.");
				SendDataToCom("l");
			}
        }
		
		/// <summary>
		/// Led 13 check box checking event
		/// </summary>
        private void checkBoxLed13_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBoxLed13.Checked)
			{
				SysDebugLog("INFO","Led 13 on command sending.");
				SendDataToCom("M");
			}
			else
			{
				SysDebugLog("INFO","Led 13 off command sending.");
				SendDataToCom("m");
			}
        }
    }
}
