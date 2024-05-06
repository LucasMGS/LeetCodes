using System;

namespace LeetCodes;

public static class ArraysAndHashing
{
    public static bool ContainsDuplicate(int[] nums)
    {
        //TIME: O(N)
        //SPACE: O(N)
        var addedNums = new HashSet<int>();
        foreach (var num in nums)
        {
            if (addedNums.Contains(num))
                return true;

            addedNums.Add(num);
        }

        return false;
    }

    public static bool IsAnagram(string s, string t)
    {
        var map = new Dictionary<char, int>();
        if (s == t)
            return true;

        foreach (var item in s)
        {
            if (!map.TryGetValue(item, out int value))
                map.Add(item, 1);
            else
                map[item] = ++value;

        }

        foreach (var item1 in t)
        {
            if (map.TryGetValue(item1, out int value))
                map[item1] = --value;
            else
                map.Add(item1, 1);
        }

        if (map.Any(x => x.Value != 0))
            return false;
        return true;
    }


    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //Example 1:

        //Input: strs = ["eat", "tea", "tan", "ate", "nat", "bat"]
        //Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

        //Input: strs = [["",""]]

        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string sorted = new(chars);

            if (!anagrams.ContainsKey(sorted))
                anagrams[sorted] = [];

            anagrams[sorted].Add(str);
        }

        return anagrams.Select(kv => kv.Value).ToList<IList<string>>();
    }

    public static IList<string> FizzBuzz(int n)
    {
        //Given an integer n, return a string array answer(1 - indexed) where:

        //answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
        //answer[i] == "Fizz" if i is divisible by 3.
        //answer[i] == "Buzz" if i is divisible by 5.
        //answer[i] == i(as a string) if none of the above conditions are true.

        var result = new List<string>();

        for(int x = 1; x <= n; x++)
        {
            var isDivisibleBy3 = x % 3 == 0;
            var isDivisibleBy5 = x % 5 == 0;

            if (isDivisibleBy3 && isDivisibleBy5)
                result.Add("FizzBuzz");
            else if (isDivisibleBy3 && !isDivisibleBy5)
                result.Add("Fizz");

            else if (!isDivisibleBy3 && isDivisibleBy5)
                result.Add("Buzz");
            else 
                result.Add(x.ToString());
        }
        return result;
    }


}
