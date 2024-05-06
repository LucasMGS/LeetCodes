using System.Text;

namespace LeetCodes;

public class StringManipulations
{
    public static IList<string> PrintVertically(string s)
    {
        var splited = s.Split(' ');
        var maxWordLength = splited.Max(word => word.Length);
        var result = new List<string>();

        for (int i = 0; i < maxWordLength; i++)
        {
            var resultWords = new List<char>();

            foreach (var word in splited)
            {
                if (word.Length > i)
                {
                    resultWords.Add(word[i]);
                }
                else
                {
                    resultWords.Add(' ');
                }
            }

            result.Add(new string(resultWords.ToArray()).TrimEnd());
        }

        return result;
    }

    public static string FrequencySort(string s)
    {
        var dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                dict[s[i]]++;
            }
            else
            {
                dict.Add(s[i], 1);
            }
        }

        var sortedDict = dict.OrderByDescending(x => x.Value)
            .Select(x =>
            {
                var builder = new StringBuilder();
                for (int i = 0; i < x.Value; i++)
                {
                    builder.Append(x.Key);
                }
                return builder.ToString();
            }).ToArray();

        return string.Join(null, sortedDict);
    }
}
