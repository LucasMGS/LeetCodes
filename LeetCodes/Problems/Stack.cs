
namespace LeetCodes;

public static class Stacks
{
    public static bool IsValid(string s)
    {
        var parenthesisPair = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
        };

        var stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            stack.Push(s[i]);
            if (parenthesisPair.ContainsKey(s[i]) && stack.Count > 1 && stack.ElementAt(1) == parenthesisPair[s[i]])
            {
                stack.Pop();
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}
