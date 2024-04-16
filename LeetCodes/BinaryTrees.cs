
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LeetCodes;

 //* Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
  }

public static class BinaryTrees
{
    public static TreeNode? InvertTree(TreeNode root)
    {
        if (root is null)
            return null;

        var tmp = root.left;
        root.left = root.right;
        root.right = tmp;
        
        InvertTree(root.left);
        InvertTree(root.right);
        return root;
    }


    private static int maxDepth = 0;
    public static int MaxDepth(TreeNode root)
    {
        DFS(root);
        return maxDepth;
    }

    private static int DFS(TreeNode root)
    {
        if (root == null)
            return -1;

        var left = DFS(root.left);
        var right = DFS(root.right);

        maxDepth = Math.Max(maxDepth, 2 + left + right);
        return 1 + Math.Max(left,right);
    }

    public static bool IsBalanced(TreeNode root)
    {
        return DFSBalanced(root).Item1;
    }

    private static (bool,int) DFSBalanced(TreeNode root)
    {
        if (root == null)
            return (true,0);

        var left = DFSBalanced(root.left);
        var right = DFSBalanced(root.right);

        var maxDepth = Math.Max(left.Item2,right.Item2);
        var balanced = left.Item1 && right.Item1 && Math.Abs(left.Item2 - right.Item2) <= 1;

        return (balanced,1 + maxDepth);
    }

}
