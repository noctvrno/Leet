namespace Leet.BinarySearchTrees;

internal static class Validate
{
    public static bool IsValidBST(TreeNode node)
    {
        List<TreeNode> flattenedTree = [];
        TraverseBst(node, flattenedTree);
        return flattenedTree
            .OrderBy(node => node.val)
            .Select(node => node.val)
            .Distinct()
            .SequenceEqual(flattenedTree.Select(node => node.val));
    }

    private static void TraverseBst(TreeNode node, ICollection<TreeNode> result)
    {
        if (node.left != null)
            TraverseBst(node.left, result);

        result.Add(node);

        if (node.right != null)
            TraverseBst(node.right, result);
    }
}

internal class TreeNode
{
    public readonly int val;
    public readonly TreeNode? left;
    public readonly TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}