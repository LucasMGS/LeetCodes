using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodes
{
    internal class TurintProblem1
    {

        public static int TuringProblem1(string[] arr)
        {
            var results = new List<int>();
            foreach (var item in arr)
            {
                if (Regex.IsMatch(item, @"^\d+$"))
                {
                    results.Add(int.Parse(item));
                }
                else
                {
                    results.Add(item.Length);
                }
            }
            return results.Max();
        }

        public static int[] FindErrorNumsTuringProblem2(int[] nums)
        {
            var numbers = new List<int>();
            var results = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbers.Contains(nums[i]))
                {
                    numbers.Add(nums[i]);
                }
                else
                {
                    results.Add(nums[i]);
                    results.Add(nums[i-1] + 1);
                }
            }
            return new ArraySegment<int>(results.ToArray(), 0, 2).ToArray();
        }

    }
}
