using System.Text;

namespace LeetCodes
{
    public static class TwoPointers
    {
        public static bool IsPalindrome(string s)
        {
            var formatted = new StringBuilder();
            foreach (var letter in s)
            {
                if (char.IsLetter(letter) || char.IsNumber(letter))
                {
                    formatted.Append(letter);
                }
            }

            var result = formatted.ToString().ToLower();
            var initialPointer = 0;
            var endPointer = result.Length - 1;

            while (initialPointer < endPointer)
            {
                if (result[initialPointer] == result[endPointer])
                {
                    initialPointer++;
                    endPointer--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
