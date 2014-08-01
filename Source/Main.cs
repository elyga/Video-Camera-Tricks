using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ES.Software.Arduino_Windows_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm());
            //Application.Run(new Form2());
        }
    }
}
/*
CONTENT:
========
(Main.cs).Main()
  |
  +-- (AppForm.cs).AppForm()
        |
		+-- (Tool_SingleWebCamManager.cs)
		      |
			  +-- (Camera.cs) this method contain main methods: Start_Camera() and Stop_Camera()
*/