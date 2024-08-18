namespace Leet;

public static class BinaryTrees
{
    public static TreeNode? InvertTree(TreeNode? root)
    {
        if (root == null)
            return null;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node.left != null)
                queue.Enqueue(node.left);

            if (node.right != null)
                queue.Enqueue(node.right);

            SwapNodes(ref node.left, ref node.right);
        }

        return root;
    }

    private static void SwapNodes(ref TreeNode? left, ref TreeNode? right)
    {
        (left, right) = (right, left);
    }

    public static TreeNode? ReverseOddLevels(TreeNode? root)
    {
        if (root == null)
            return null;

        ReverseOddLevelsInternal(root.left, root.right, 1);
        return root;
    }

    private static void ReverseOddLevelsInternal(TreeNode? left, TreeNode? right, int level)
    {
        if (left == null || right == null)
            return;

        if (level % 2 != 0)
            SwapNodeValues(left, right);

        ReverseOddLevelsInternal(left.left, right.right, level + 1);
        ReverseOddLevelsInternal(left.right, right.left, level + 1);
    }

    private static void SwapNodeValues(TreeNode? left, TreeNode? right)
    {
        if (left == null || right == null)
            return;

        (left.val, right.val) = (right.val, left.val);
    }
}