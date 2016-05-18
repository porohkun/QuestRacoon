﻿using System;
using System.Collections.Generic;
using System.Drawing;
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

        public bool Edited { get; private set; }
        public string MainLocale { get; private set; }
        public IEnumerable<Block> Blocks { get { foreach (var block in _blocks) yield return block; } }
        public IEnumerable<string> Locales { get { foreach (var locale in _locales) yield return locale; } }

        public event Action<Block> BlockAdded;
        public event Action MainLocaleChanged;

        public Quest()
        {
            Edited = false;
            _locales.Add("Standart");
            MainLocale = "Standart";
        }

        public Quest(JSONValue json)
        {
            Edited = false;
            _locales.AddRange(json["locales"].DynamicCast<string>());
            MainLocale = json["main_locale"];
            foreach (var jBlock in json["blocks"])
            {
                var block = new Block(jBlock);
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
            var block = new Block(location, name, Locales);
            block.Edited += blockEdited;
            _blocks.Add(block);
            BlockAdded?.Invoke(block);
            Edited = true;
            return block;
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

        public void AddLocale(string locale)
        {
            Edited = true;
            _locales.Add(locale);
            foreach (var block in _blocks)
                block.CloneLocale(MainLocale, locale);
        }

        public void DeleteLocale(string locale)
        {
            Edited = true;
            _locales.Remove(locale);
            foreach (var block in _blocks)
                block.DeleteLocale(locale);
        }

        private void blockEdited()
        {
            Edited = true;
        }

        public JSONValue ToJson()
        {
            JSONValue json = new JSONObject(
                new JOPair("locales", new JSONArray(Locales.DynamicCast<JSONValue>())),
                new JOPair("main_locale", MainLocale),
                new JOPair("blocks", new JSONArray(_blocks.Select(b => b.ToJson()))));
            return json;
        }
        
    }
}