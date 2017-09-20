using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;

namespace TileNator
{
    class Tile
    {
        public ProcessStartInfo psiTileApplication;
        public Boolean bShowTileTitle;
        public Bitmap bmpLogo70px, bmpLogo150px;
        public String strName;                      //Speaking Name of Item
        public String strForegroundColor;           //Text Color (light/dark)
        public String strBackgroundColor;           //Tile Color (#000000)
        public Int32 iUniqueID;

        public Tile(string name, string filename, string arguments, Boolean showtitle, Bitmap logo70px, Bitmap logo150px)
        {
            strName = name;
            psiTileApplication = new ProcessStartInfo(filename, arguments);
            bShowTileTitle = showtitle;
            bmpLogo70px = logo70px;
            bmpLogo150px = logo150px;
        }

        public Tile(Int32 UniqueID)
        {
            psiTileApplication = new ProcessStartInfo();
            iUniqueID = UniqueID;

        }

        public void Save()
        {
            string TargetDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + iUniqueID;
            Directory.CreateDirectory(TargetDir);
            Helper.ExtractEmbeddedResource(TargetDir, "TileNator.res", "AppOpener.exe");

            using (XmlWriter writer = XmlWriter.Create(TargetDir + Path.DirectorySeparatorChar + "AppOpener.visualelementsmanifest.xml"))
            {
                writer.WriteStartDocument();

                writer.WriteStartElement("Application");

                writer.WriteStartElement("VisualElements");
                writer.WriteAttributeString("ShowNameOnSquare150x150Logo", "off");
                writer.WriteAttributeString("Square150x150Logo", "logo150px.png");
                writer.WriteAttributeString("Square70x70Logo", "logo70px.png");
                writer.WriteAttributeString("ForegroundText", "light");
                writer.WriteAttributeString("BackgroundColor", "#000000");
                writer.WriteEndElement();

                writer.WriteStartElement("Process");
                writer.WriteAttributeString("name", strName);
                writer.WriteAttributeString("filename", psiTileApplication.FileName);
                writer.WriteAttributeString("arguments", psiTileApplication.Arguments);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            File.Delete(TargetDir + @"\logo70px.png");
            bmpLogo70px.Save(TargetDir + @"\logo70px.png", ImageFormat.Png);
            bmpLogo150px.Save(TargetDir + @"\logo150px.png", ImageFormat.Png);

        }

        public void Delete()
        {
            string TargetDir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + iUniqueID;
            Directory.Delete(TargetDir, true);

        }

        public void pin()
        {
            string TargetDir = Directory.GetCurrentDirectory() +Path.DirectorySeparatorChar;

            Process pinner = new Process();
            pinner.StartInfo.RedirectStandardOutput = true;
            pinner.StartInfo.UseShellExecute = false;
            pinner.StartInfo.CreateNoWindow = true;
            pinner.StartInfo.FileName = TargetDir + "syspin.exe";
            pinner.StartInfo.Arguments = "\"" + TargetDir + iUniqueID + @"\AppOpener.exe"" c:51201";
            pinner.Start();


        }
    }
}
