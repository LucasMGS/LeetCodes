using System.Text;

namespace LeetCodes.Problems;

public class Trie
{
    public Dictionary<char, Trie> Children { get; set; } = new();
    public bool IsEndOfWord { get; set; }

    public void Insert(string word)
    {
        var current = this;
        for (int i = 0; i < word.Length; i++)
        {
            var letter = word[i];
            if (!current.Children.TryGetValue(letter, out Trie? value))
            {
                value = new();
                current.Children.Add(letter, value);
            }

            current = value;
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var current = this;
        for (int i = 0; i < word.Length; i++)
        {
            var letter = word[i];
            if (!current.Children.TryGetValue(letter, out Trie? value))
                return false;

            current = value;
        }

        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = this;
        for (int i = 0; i < prefix.Length; i++)
        {
            var letter = prefix[i];
            if (!current.Children.TryGetValue(letter, out Trie? value))
                return false;

            current = value;
        }

        return true;
    }
}
