namespace LeetCodes;

public static class BackTracking
{
    public static IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>>();
        var subset = new List<int>();
        DFSSubset(nums,0,subset, result);
        return result;
    }

    private static void DFSSubset(int[] nums, int index, List<int> current, IList<IList<int>> result)
    {
        if (index == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        current.Add(nums[index]);
        DFSSubset(nums, index + 1, current, result);
        current.RemoveAt(current.Count - 1);
        DFSSubset(nums, index + 1, current, result);
    }
}
