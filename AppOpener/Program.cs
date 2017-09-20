using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AppOpener
{
    static class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        static string filename;
        static string arguments;

        [STAThread]
        static void Main()
        {
            ReadXML();

            Process process = new Process();
            process.StartInfo.FileName = @filename;
            process.StartInfo.Arguments = @arguments;
            process.Start();
            process.WaitForInputIdle();

            for (int i = 0; i < 10; i++)
            {
                if (!IsProcForeground(process.MainWindowHandle))
                    SetForegroundWindow(process.MainWindowHandle);
                else
                    break;

                Thread.Sleep(500);
            }
        }

        static bool IsProcForeground(IntPtr MainWindow)
        {
            if (MainWindow == IntPtr.Zero)
                return false;

            if (GetForegroundWindow() == MainWindow)
                return true;
            else
                return false;
        }

        static void ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("AppOpener.visualelementsmanifest.xml");

            XmlNode node = doc.DocumentElement.SelectSingleNode("/Application/Process");
            filename = node.Attributes["filename"]?.InnerText;
            arguments = node.Attributes["arguments"]?.InnerText;
        }

    }


}
