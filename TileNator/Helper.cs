using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TileNator
{
    static class Helper
    {
        static string originalImagePathName;
        static int unicodeSize = IntPtr.Size * 2;

        public static void ExtractEmbeddedResource(string outputDir, string resourceLocation, string file)
        {
            using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceLocation + @"." + file))
            {
                using (FileStream fileStream = new FileStream(Path.Combine(outputDir, file), FileMode.Create))
                {
                    for (int i = 0; i < stream.Length; i++)
                    {
                        fileStream.WriteByte((byte)stream.ReadByte());
                    }
                    fileStream.Close();
                }
            }
        }
        
        public static List<Tile> ImportTiles()
        {
            Tile tempTile;
            XmlDocument doc;
            XmlNode node;
            List<Tile> tempList = new List<Tile>();
            
            foreach (string subdir in Directory.GetDirectories(Directory.GetCurrentDirectory()))
            {
                tempTile = new Tile(Convert.ToInt32(new DirectoryInfo(subdir).Name));

                doc = new XmlDocument();
                doc.Load(subdir + @"\AppOpener.visualelementsmanifest.xml");

                node = doc.DocumentElement.SelectSingleNode("/Application/Process");
                tempTile.strName = node.Attributes["name"]?.InnerText;
                tempTile.psiTileApplication.FileName = node.Attributes["filename"]?.InnerText;
                tempTile.psiTileApplication.Arguments = node.Attributes["arguments"]?.InnerText;

                node = doc.DocumentElement.SelectSingleNode("/Application/VisualElements");
                tempTile.strBackgroundColor = node.Attributes["BackgroundColor"]?.InnerText;
                tempTile.strForegroundColor = node.Attributes["ForegroundText"]?.InnerText;

                using (Image img = Image.FromFile(subdir + @"\logo70px.png"))
                    tempTile.bmpLogo70px = new Bitmap(img);

                using (Image img = Image.FromFile(subdir + @"\logo150px.png"))
                    tempTile.bmpLogo150px = new Bitmap(img); 

                tempList.Add(tempTile);
            }

            return tempList;
        }

        public static Int32 GetFreeUniqueId(List<Tile> lTiles)
        {
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                if (lTiles.Find(item => item.iUniqueID == i) == null)
                    return i;
            }

            throw new InvalidOperationException("All integers are already used.");
        }
        

        [DllImport("ntdll.dll")]
        private static extern uint NtQueryInformationProcess([In] IntPtr ProcessHandle,[In] int ProcessInformationClass,[Out] out ProcessBasicInformation ProcessInformation,[In] int ProcessInformationLength,[Out] [Optional] out int ReturnLength);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern int LoadString(IntPtr hInstance, uint wID, StringBuilder lpBuffer, int nBufferMax);

        private static void GetPointers(out IntPtr imageOffset, out IntPtr imageBuffer)
        {
            IntPtr pebBaseAddress = GetBasicInformation().PebBaseAddress;
            var processParameters = Marshal.ReadIntPtr(pebBaseAddress, 4 * IntPtr.Size);
            imageOffset = processParameters.Increment(4 * 4 + 5 * IntPtr.Size + unicodeSize + IntPtr.Size + unicodeSize);
            imageBuffer = Marshal.ReadIntPtr(imageOffset, IntPtr.Size);
        }

        public static void ChangeImagePathName(string newFileName)
        {
            IntPtr imageOffset, imageBuffer;
            GetPointers(out imageOffset, out imageBuffer);

            //Read original data
            var imageLen = Marshal.ReadInt16(imageOffset);
            originalImagePathName = Marshal.PtrToStringUni(imageBuffer, imageLen / 2);

            var newImagePathName = Path.Combine(Path.GetDirectoryName(originalImagePathName), newFileName);
            if (newImagePathName.Length > originalImagePathName.Length) throw new Exception("new ImagePathName cannot be longer than the original one");

            //Write the string, char by char
            var ptr = imageBuffer;
            foreach (var unicodeChar in newImagePathName)
            {
                Marshal.WriteInt16(ptr, unicodeChar);
                ptr = ptr.Increment(2);
            }
            Marshal.WriteInt16(ptr, 0);

            //Write the new length
            Marshal.WriteInt16(imageOffset, (short)(newImagePathName.Length * 2));
        }

        public static void RestoreImagePathName()
        {
            IntPtr imageOffset, ptr;
            GetPointers(out imageOffset, out ptr);

            foreach (var unicodeChar in originalImagePathName)
            {
                Marshal.WriteInt16(ptr, unicodeChar);
                ptr = ptr.Increment(2);
            }
            Marshal.WriteInt16(ptr, 0);
            Marshal.WriteInt16(imageOffset, (short)(originalImagePathName.Length * 2));
        }

        private static ProcessBasicInformation GetBasicInformation()
        {
            uint status;
            ProcessBasicInformation pbi;
            int retLen;
            var handle = System.Diagnostics.Process.GetCurrentProcess().Handle;
            if ((status = NtQueryInformationProcess(handle, 0,
                out pbi, Marshal.SizeOf(typeof(ProcessBasicInformation)), out retLen)) >= 0xc0000000)
                throw new Exception("Windows exception. status=" + status);
            return pbi;
        }

        private static IntPtr Increment(this IntPtr ptr, int value)
        {
            unchecked
            {
                if (IntPtr.Size == sizeof(Int32))
                    return new IntPtr(ptr.ToInt32() + value);
                else
                    return new IntPtr(ptr.ToInt64() + value);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ProcessBasicInformation
        {
            public uint ExitStatus;
            public IntPtr PebBaseAddress;
            public IntPtr AffinityMask;
            public int BasePriority;
            public IntPtr UniqueProcessId;
            public IntPtr InheritedFromUniqueProcessId;
        }

        public static bool PinUnpinTaskbar(string filePath, bool pin)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            int MAX_PATH = 255;
            //var actionIndex = pin ? 5386 : 5387; // 5386 is the DLL index for"Pin to Tas&kbar", ref. http://www.win7dll.info/shell32_dll.html
            //uncomment the following line to pin to start instead
            //var actionIndex = pin ? 51201 : 51394;
            Int32 actionIndex = 51201;
            StringBuilder szPinToStartLocalized = new StringBuilder(MAX_PATH);
            IntPtr hShell32 = LoadLibrary("Shell32.dll");
            LoadString(hShell32, (uint)actionIndex, szPinToStartLocalized, MAX_PATH);
            string localizedVerb = szPinToStartLocalized.ToString();

            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            // create the shell application object
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            dynamic directory = shellApplication.NameSpace(path);
            dynamic link = directory.ParseName(fileName);

            dynamic verbs = link.Verbs();
            for (int i = 0; i < verbs.Count(); i++)
            {
                dynamic verb = verbs.Item(i);
                if (verb.Name.Equals(localizedVerb))
                {
                    verb.DoIt();
                    return true;
                }
            }
            return false;
        }

    }
}
