using System.Text.RegularExpressions;

namespace FoxAgent.Parse
{
    public class RegexKeyValue
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public RegexKeyValue(string input, string delimeter = @":")
        {
            Regex regex = new Regex(delimeter, RegexOptions.Compiled);
            Match match = regex.Match(input);
            int index = match.Index;

            if(index > 0)
            {
                Key = input.Substring(0, index).Trim();
                Value = input.Substring(index + 1).Trim();
            }
        }
    }
}