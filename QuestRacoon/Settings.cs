using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Threading;
using PNetJson;
using System.IO;

namespace QuestRacoon
{
    public class Settings
    {
        public bool FirstStart { get; private set; }
        public string LastOpenedFile { get { return _recentFiles.Count > 0 ? _recentFiles[0] : ""; } }
        public IEnumerable<string> RecentFiles { get { foreach (var file in _recentFiles) yield return file; } }
        
        //public string Locale { get { return Thread.CurrentThread.CurrentUICulture.ToString(); } }

        private List<string> _recentFiles = new List<string>();

        private string _path = Path.Combine(QR.AppDataPath, "settings.json");
        
        public Settings()
        {
            FirstStart = true;
            LoadSettings();
        }

        public void AddRecentFile(string file)
        {
            if (_recentFiles.Contains(file))
                _recentFiles.Remove(file);
            _recentFiles.Insert(0, file);
            if (_recentFiles.Count > 10)
            {
                int count = _recentFiles.Count;
                for (int i = 10; i < count; i++)
                    _recentFiles.RemoveAt(10);
            }
            SaveSettings();
        }

        public void LoadSettings()
        {
            if (File.Exists(_path))
                ImportSettings(JSONValue.Load(_path));
        }

        public void SaveSettings()
        {
            Directory.CreateDirectory(QR.AppDataPath);
            ExportSettings().Save(_path, false);
        }
        
        public void ImportSettings(JSONValue settings)
        {
            if (settings.Obj.ContainsKey("first_start"))
                FirstStart = settings["first_start"];
            if (settings.Obj.ContainsKey("recent_files"))
                _recentFiles.AddRange(settings["recent_files"].DynamicCast<string>());
        }

        public JSONValue ExportSettings()
        {
            JSONValue result = new JSONValue(new JSONObject(
                new JOPair("first_start", false),
                new JOPair("last_version", QR.CurrentVersion),
                new JOPair("recent_files", new JSONArray(_recentFiles.DynamicCast<JSONValue>().ToArray()))
                ));
            return result;
        }

    }
}
