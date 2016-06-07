using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PNetJson;

namespace QuestRacoon.Quest
{
    public class Description : BaseOperator
    {
        public LocalizedText Text { get; private set; }

        public override OperatorType Type { get { return OperatorType.Description; } }

        public Description()
        {
            Text = new LocalizedText();
            Text.Edited += TextEdited;
        }

        public Description(JSONValue json):this()
        {
            Text.Parse(json["text"]);
        }

        public void TextEdited()
        {
            Edited?.Invoke();
        }

        public override void DeleteLocale(string locale)
        {
            Text.DeleteLocale(locale);
        }

        public override void RenameLocale(string oldLocale, string locale)
        {
            Text.RenameLocale(oldLocale, locale);
        }

        public override string GetText(string locale)
        {
            return Text.GetText(locale);
        }
        
        public override string ToString()
        {
            return string.Format("Description:[{0}]", GetText("Default"));
        }

        public override JSONValue ToJson()
        {
            var json = base.ToJson();
            json.Obj.Add("text", Text.ToJson());
            return json;
        }

        internal static IOperator ParseOld(JSONValue jSONValue)
        {
            return new Description(new JSONObject(new JOPair("text", jSONValue)));
        }
    }
}
