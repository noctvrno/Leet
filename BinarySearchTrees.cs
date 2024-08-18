namespace Leet;

public static class BinarySearchTrees
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