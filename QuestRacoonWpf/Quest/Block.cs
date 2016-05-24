using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PNetJson;

namespace QuestRacoonWpf.Quest
{
    public class Block
    {
        public string Name { get; private set; }
        public Point Location { get; private set; }
        public IEnumerable<string> Locales { get { return _rawTexts.Keys; } }

        public event Action NameChanged;
        public event Action<string> TextChanged;
        public event Action Edited;

        private Dictionary<string, string> _rawTexts = new Dictionary<string, string>();
        

        public Block(Point location, string name, IEnumerable<string> locales)
        {
            Location = location;
            Name = name;
            foreach (var loc in locales)
                _rawTexts.Add(loc, "");
        }

        public Block(JSONValue json)
        {
            Name = json["name"];
            Location = new Point(json["location"]["x"], json["location"]["y"]);
            foreach (var text in json["text"].Obj)
                _rawTexts.Add(text.Key, text.Value);
        }

        public string GetRawText(string locale)
        {
            return _rawTexts[locale];
        }

        public void SetRawText(string locale, string text)
        {
            if (_rawTexts[locale] != text)
            {
                _rawTexts[locale] = text;
                TextChanged?.Invoke(locale);
                Edited?.Invoke();
            }
        }

        public void SetName(string name)
        {
            if (Name != name)
            {
                Name = name;
                NameChanged?.Invoke();
                Edited?.Invoke();
            }
        }

        public void SetLocation(Point location)
        {
            if (Location != location)
            {
                Location = location;
                Edited?.Invoke();
            }
        }

        public void DeleteLocale(string locale)
        {
            _rawTexts.Remove(locale);
        }

        public void CloneLocale(string fromLocale, string toLocale)
        {
            _rawTexts.Add(toLocale, _rawTexts[fromLocale]);
        }

        public IEnumerable<string> GetLinks(string locale)
        {
            foreach (Match match in GetRawLinks(locale))
            {
                yield return match.Value.Substring(2, match.Value.Length - 4).Split('|')[0];
            }
        }

        internal void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Match> GetRawLinks(string locale)
        {
            Regex reg = new Regex(@"\[\[[\w ]+\|[\w ]+\]\]");
            var matches = reg.Matches(_rawTexts[locale]);
            foreach (Match match in matches)
            {
                yield return match;
            }
        }

        public JSONValue ToJson()
        {
            return new JSONObject(
                new JOPair("name", Name),
                new JOPair("location", new JSONObject(
                    new JOPair("x", Location.X),
                    new JOPair("y", Location.Y))),
                new JOPair("text", new JSONObject(from t in _rawTexts select new JOPair(t.Key, t.Value))));
        }
    }
}
