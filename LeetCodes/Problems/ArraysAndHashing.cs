using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Text;

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
    
    public static int[] TopKFrequent(int[] nums, int k) {
        var elemFreq = new Dictionary<int,int>();
        foreach (var item in nums)
        {
           if(elemFreq.ContainsKey(item)) {
            elemFreq[item]++;
           } 
           else {
            elemFreq.Add(item,1);
           }
        }

        var result = new int[k];

        return elemFreq.OrderByDescending(x => x.Value).Select(x => x.Key).Take(k).ToArray();
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        var prefix = 1;
        var result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = prefix;
            prefix *= nums[i];
        }
        var postFix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= postFix;
            postFix *= nums[i];
        }

        return result;
    }

    public static char[] ReverseString(char[] s)
    {
        var left = 0;
        var right = s.Length - 1;
        while(left != right && right > left) {
            char aux = s[left];
            s[left] = s[right];
            s[right] = aux;
            left++;
            right--;
        }
        return s;
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        //        Example 1:

        //Input: strs = ["flower", "flow", "flight"]
        //Output: "fl"
        //Example 2:

        //Input: strs = ["dog", "racecar", "car"]
        //Output: ""
        //Explanation: There is no common prefix among the input strings.

        var stringBuilder = new StringBuilder(strs[0][0]);
        if (strs.Length == 0)
            return "";

        foreach (var str in strs)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != stringBuilder[i] && stringBuilder.Length <= str.Length)
                {
                    stringBuilder.Remove(i, stringBuilder.Length - i);
                    break;
                }
                stringBuilder.Append(str[i]);
            }
        }

        return stringBuilder.ToString();
    }

    public static void SortColors(int[] nums)
    {
        var leftPointer = 0;
        var midPointer = 0;
        var rightPointer = nums.Length - 1;
        //PROBLEM OF THE DUTCH NATION FLAG PROBLEM 
        while (midPointer <= rightPointer)
        {
            switch (nums[midPointer])
            {
                case 0:
                    (nums[leftPointer], nums[midPointer]) = (nums[midPointer], nums[leftPointer]);
                    leftPointer++;
                    midPointer++;
                    break;
                case 1:
                    midPointer++;
                    break;
                case 2:
                    (nums[midPointer], nums[rightPointer]) = (nums[rightPointer], nums[midPointer]);
                    rightPointer--;
                    break;
            }
        }

    }

    public static int MinMovesToSeat(int[] seats, int[] students)
    {
        var ordenedSeats = seats.OrderBy(x => x).ToArray();
        var ordenedStudents = students.OrderBy(x => x).ToArray();
        var result = 0;
        for (int i = 0; i < seats.Length; i++)
        {
            result += Math.Abs(ordenedSeats[i] - ordenedStudents[i]);
        }
        return result;
    }

    public static  int MinIncrementForUnique(int[] nums)
    {
        Dictionary<int,int> result = [];
        int numMoves = 0;
        Array.Sort(nums);

        var prevNumb = nums[0];

        for(int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= prevNumb)
            {
                numMoves += (prevNumb + 1 - nums[i]);
                nums[i] = prevNumb + 1;
            }
            prevNumb = nums[i];
        }
        return numMoves;
    }
}
