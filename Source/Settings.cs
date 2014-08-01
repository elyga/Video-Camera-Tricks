using System;
using System.IO;
using System.IO.Ports;
using System.Collections;

namespace ES.Software.Arduino_Windows_Client
{
    /// <summary>
    /// Persistent settings
    /// </summary>
    public class Settings
    {
        /// <summary> Port settings. </summary>
        public class Port
        {
            public static string PortName = "COM1";
            public static int BaudRate = 38400;
            public static int DataBits = 8;
            public static System.IO.Ports.Parity Parity = System.IO.Ports.Parity.None;
            public static System.IO.Ports.StopBits StopBits = System.IO.Ports.StopBits.One;
            public static System.IO.Ports.Handshake Handshake = System.IO.Ports.Handshake.None;
        }

        /// <summary> Option settings. </summary>
        public class Option
        {
            public enum AppendType
            {
                AppendNothing,
                AppendCR,
                AppendLF,
                AppendCRLF
            }

            public static AppendType AppendToSend = AppendType.AppendNothing;
            public static bool HexOutput = false;
            public static bool MonoFont = true;
            public static bool LocalEcho = true;
            public static bool StayOnTop = false;
            public static bool FilterUseCase = false;
            public static string LogFileName = "";
        }
    }
}
