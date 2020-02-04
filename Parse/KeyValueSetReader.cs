using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoxAgent.Parse
{
    public class KeyValueSetReader
    {
        private Dictionary<string, string> _entrySet;
        public string Key { get; private set; }
        public string Value { get; private set; }

        private void addEntrySet(Match match)
        {
            Group keyGroup = match.Groups["KEY"];
            Group valueGroup = match.Groups["VALUE"];

            if(null == keyGroup)
            {
                return;
            }

            string key = keyGroup.Value.ToUpper().Trim();
            
            if(!_entrySet.ContainsKey(key))
            {
                string value = (null == valueGroup ? "" : valueGroup.Value.Trim());
                _entrySet.Add(key, value);
            }
        }

        public KeyValueSetReader()
        {
            _entrySet = new Dictionary<string, string>();
        }

        public void read(string input, string delimeter = @":")
        {
            string pattern = string.Format(@"(?<KEY>.+)(?<DELIMETER>{0})(?<VALUE>.*($|\n))", delimeter);

            Regex regex = new Regex(pattern, RegexOptions.Compiled 
                | RegexOptions.IgnoreCase | RegexOptions.Multiline);

            MatchCollection matches = regex.Matches(input);
            foreach(Match entrySetMatch in matches){ addEntrySet(entrySetMatch); }
        }

        public string GetValue(string key)
        {
            return _entrySet.GetValueOrDefault(key.ToUpper());
        }

        public int GetIntValue(string key)
        {
            int value = 0;
            string stringValue = GetValue(key);

            int.TryParse(stringValue, out value);

            return value;
        }

        public double GetDoubleValue(string key)
        {
            double value = 0;
            string stringValue = GetValue(key);

            double.TryParse(stringValue, out value);

            return value;
        }

        public Dictionary<string, string> EntrySet()
        {
            return _entrySet;
        }
    }
}