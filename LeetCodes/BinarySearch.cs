namespace LeetCodes;

public static class BinarySearch
{
    public static int Search(int[] nums, int target)
    {
        //return Array.BinarySearch(nums, target);
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int middle = (left + right) / 2;
            int middleTarget = nums[middle];
            if (middleTarget == target)
                return middle;

            else if (target > middleTarget)
                left = middle + 1;
            else
                right = middle - 1;
        }
        return -1;
    }
}
