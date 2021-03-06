using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class Quest
    {
        private List<Block> _blocks = new List<Block>();
        private List<string> _locales = new List<string>();
        private List<string> _variables = new List<string>();

        public bool Edited { get; private set; }
        public string MainLocale { get; private set; }
        public IEnumerable<Block> Blocks { get { foreach (var block in _blocks) yield return block; } }
        public IEnumerable<string> Locales { get { foreach (var locale in _locales) yield return locale; } }
        public IEnumerable<string> Variables { get { foreach (var variable in _variables) yield return variable; } }

        public event Action<Block> BlockAdded;
        public event Action MainLocaleChanged;

        public Quest()
        {
            Edited = false;
            _locales.Add("Default");
            MainLocale = "Default";
        }

        public Quest(JSONValue json) : this()
        {
            Edited = false;
            if (json.Obj.ContainsKey("version"))
                ParseOld(json);
            else
                ParseNew(json);
        }

        private void ParseOld(JSONValue json)
        {
            _locales.Clear();
            _locales.AddRange(json["locales"].DynamicCast<string>());
            foreach (var jBlock in json["blocks"])
            {
                var block = new Block(this, jBlock);
                block.Edited += blockEdited;
                _blocks.Add(block);
            }
            MainLocale = json["main_locale"];
            if (_locales.Contains("Standart"))
                RenameLocale("Standart", "Default");
            if (MainLocale == "Standart")
                SetMainLocale("Default");
        }

        private void ParseNew(JSONValue json)
        {
            _locales.Clear();
            _locales.AddRange(json["locales"].DynamicCast<string>());
            MainLocale = json["main_locale"];
            foreach (var jBlock in json["blocks"])
            {
                var block = new Block(this, jBlock);
                block.Edited += blockEdited;
                _blocks.Add(block);
            }
        }
        
        public Block CreateBlock(Point location)
        {
            int i = 0;
            while (true)
            {
                i++;
                var name = string.Format("block_{0}", i);
                if (GetBlock(name) == null)
                    return CreateBlock(location, name);
            }
        }

        public Block CreateBlock(Point location, string name)
        {
            var block = new Block(this, location, name);
            block.Edited += blockEdited;
            _blocks.Add(block);
            BlockAdded?.Invoke(block);
            Edited = true;
            return block;
        }

        internal void DeleteBlock(Block block)
        {
            _blocks.Remove(block);
            Edited = true;
        }

        internal void RecalculateVariables()
        {
            _variables.Clear();
            List<string> temp = new List<string>();
            foreach (var block in Blocks)
                foreach (var ass in (from c in block where c is Assignment select c as Assignment))
                    temp.AddRange(ass.GetVariables());

            _variables.AddRange((from v in temp where v != null && v != "" select v).Distinct());
        }

        public Block GetBlock(string name)
        {
            return Blocks.FirstOrDefault(b => b.Name == name);
        }

        public void SetMainLocale(string mainLocale)
        {
            if (MainLocale != mainLocale)
            {
                Edited = true;
                MainLocale = mainLocale;
                MainLocaleChanged?.Invoke();
            }
        }

        public void DropEdited()
        {
            Edited = false;
        }

        public void AddLocale(string locale)
        {
            Edited = true;
            _locales.Add(locale);
            //foreach (var block in _blocks)
            //    block.CloneLocale(MainLocale, locale);
        }

        public void DeleteLocale(string locale)
        {
            Edited = true;
            _locales.Remove(locale);
            foreach (var block in _blocks)
                block.DeleteLocale(locale);
        }

        public void RenameLocale(string oldLocale, string locale)
        {
            if (_locales.Contains(oldLocale))
            {
                Edited = true;
                _locales.Remove(oldLocale);
                _locales.Add(locale);
                foreach (var block in _blocks)
                    block.RenameLocale(oldLocale, locale);
            }
        }

        private void blockEdited()
        {
            Edited = true;
        }

        public JSONValue ToJson()
        {
            JSONValue json = new JSONObject(
                new JOPair("version", QR.CurrentVersion),
                new JOPair("locales", new JSONArray(Locales.DynamicCast<JSONValue>())),
                new JOPair("main_locale", MainLocale),
                new JOPair("blocks", new JSONArray(_blocks.Select(b => b.ToJson()))));
            return json;
        }
        
    }
}
