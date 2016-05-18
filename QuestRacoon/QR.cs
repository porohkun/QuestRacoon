using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;

namespace QuestRacoon
{
    public static class QR
    {
        public static string CurrentVersion { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }
        public static string AppDataPath { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuestRacoon"); } }
        public static string AppRunPath { get { return Application.StartupPath; } }
        public static Settings Set { get; private set; }
        public static UTF8Encoding UTF8WithoutBom { get; private set; }

        public static bool UpdateArrows { get; set; }

        static QR()
        {
            UpdateArrows = true;
            Set = new Settings();
            UTF8WithoutBom = new UTF8Encoding(false);
        }
    }
}