using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class LocalizedText
    {
        private Dictionary<string, string> _texts;

        public Action Edited { get; internal set; }

        public LocalizedText()
        {
            _texts = new Dictionary<string, string>();
            _texts.Add("Default", "");
        }

        internal bool DeleteLocale(string locale)
        {
            if (locale != "Default" && _texts.ContainsKey(locale))
            {
                _texts.Remove(locale);
                Edited?.Invoke();
                return true;
            }
            return false;
        }

        internal void Parse(JSONValue json)
        {
            _texts.Clear();
            foreach (var text in json.Obj)
                _texts.Add(text.Key, text.Value);
        }

        internal JSONValue ToJson()
        {
            return new JSONObject(from t in _texts select new JOPair(t.Key, t.Value));
        }

        internal void RenameLocale(string oldLocale, string locale)
        {
            if (_texts.ContainsKey(oldLocale) && !_texts.ContainsKey(locale))
            {
                _texts.Add(locale, _texts[oldLocale]);
                _texts.Remove(oldLocale);
                Edited?.Invoke();
            }
        }

        internal string GetText(string locale)
        {
            if (_texts.ContainsKey(locale))
                return _texts[locale];
            else
                return _texts["Default"];
        }

        internal void SetText(string text, string locale)
        {
            if (!_texts.ContainsKey(locale))
                _texts.Add(locale, text);
            else
                _texts[locale] = text;
            Edited?.Invoke();
        }
    }
}
