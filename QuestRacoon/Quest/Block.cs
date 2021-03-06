using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PNetJson;
using System.Collections;

namespace QuestRacoon.Quest
{
    public class Block:IEnumerable<IOperator>, IList<IOperator>
    {
        public string Name { get; private set; }
        public Point Location { get; private set; }

        public int Count { get { return _operators.Count; } }
        public bool IsReadOnly { get { return false; } }

        public event Action NameChanged;
        public event Action OperatorsChanged;
        public event Action Edited;
        public event Action Deleted;

        private Quest _quest;
        private List<IOperator> _operators;

        public IOperator this[int index]
        {
            get { return _operators[index]; }
            set
            {
                _operators[index] = value;
                value.Edited = OperatorEdited;
                value.WantBeDeleted = OperatorWantBeDeleted;
                Edited?.Invoke();
            }
        }

        public Block(Quest quest, Point location, string name) : this(quest, location, name, false) { }

        private Block(Quest quest, Point location, string name, bool intern)
        {
            _quest = quest;
            Location = location;
            Name = name;
            _operators = new List<IOperator>();
            if (!intern)
                Add(new Description());
        }

        public Block(Quest quest, JSONValue json) : this(quest, new Point(json["location"]["x"], json["location"]["y"]), json["name"], true)
        {
            if (json.Obj.ContainsKey("text"))
            {
                Add(Description.ParseOld(json["text"]));
            }
            else
            {
                foreach (var op in json["operators"])
                    Add(BaseOperator.Parse(op));
            }
        }

        private void OperatorEdited()
        {
            Edited?.Invoke();
            OperatorsChanged?.Invoke();
        }

        private void OperatorWantBeDeleted(IOperator sender)
        {
            Remove(sender);
        }

        public string GetRawText(string locale)
        {
            var builder = new StringBuilder();
            foreach (var op in _operators)
                builder.AppendLine(op.GetText(locale));
            return builder.ToString();
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
            foreach (var op in _operators)
                op.DeleteLocale(locale);
        }

        public void RenameLocale(string oldLocale, string locale)
        {
            foreach (var op in _operators)
                op.RenameLocale(oldLocale, locale);
        }

        internal void DeleteBlock()
        {
            _quest.DeleteBlock(this);
            Deleted?.Invoke();
        }
        
        public JSONValue ToJson()
        {
            return new JSONObject(
                new JOPair("name", Name),
                new JOPair("location", new JSONObject(
                    new JOPair("x", Location.X),
                    new JOPair("y", Location.Y))),
                new JOPair("operators", new JSONArray(_operators.Select(o => o.ToJson()))));
        }

        public IEnumerator<IOperator> GetEnumerator()
        {
            return _operators.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _operators.GetEnumerator();
        }

        public int IndexOf(IOperator item)
        {
            return _operators.IndexOf(item);
        }

        public void Insert(int index, IOperator item)
        {
            _operators.Insert(index, item);
            item.Edited = OperatorEdited;
            item.WantBeDeleted = OperatorWantBeDeleted;
            OperatorsChanged?.Invoke();
            Edited?.Invoke();
        }

        public void RemoveAt(int index)
        {
            _operators.RemoveAt(index);
            OperatorsChanged?.Invoke();
            Edited?.Invoke();
        }

        public void MoveByIndex(int oldi, int newi)
        {
            if (oldi == newi) return;
            var op = _operators[oldi];
            _operators.Insert(oldi < newi ? newi + 1 : newi, op);
            _operators.RemoveAt(newi < oldi ? oldi + 1 : oldi);
            OperatorsChanged?.Invoke();
            Edited?.Invoke();
        }

        public void Add(IOperator item)
        {
            _operators.Add(item);
            item.Edited = OperatorEdited;
            item.WantBeDeleted = OperatorWantBeDeleted;
            OperatorsChanged?.Invoke();
            Edited?.Invoke();
        }

        public void Clear()
        {
            _operators.Clear();
            OperatorsChanged?.Invoke();
            Edited?.Invoke();
        }

        public bool Contains(IOperator item)
        {
            return _operators.Contains(item);
        }

        public void CopyTo(IOperator[] array, int arrayIndex)
        {
            _operators.CopyTo(array, arrayIndex);
        }

        public bool Remove(IOperator item)
        {
            var rem = _operators.Remove(item);
            if (rem)
            {
                OperatorsChanged?.Invoke();
                Edited?.Invoke();
            }
            return rem;
        }
    }
}
