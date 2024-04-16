namespace LeetCodes;

public static class SlidingWindows
{
    public static int MaxProfit(int[] prices)
    {
        int leftPointer = 0;
        int rightPointer = 1;
        int maxProfit = 0;

        while (rightPointer < prices.Length)
        {
            var diff = prices[rightPointer] - prices[leftPointer];
            if (diff > maxProfit)
            {
                maxProfit = diff;
            }

            if (prices[rightPointer] < prices[leftPointer])
            {
                leftPointer = rightPointer;
            }
            rightPointer++;
        }

        return maxProfit;
    }
}
