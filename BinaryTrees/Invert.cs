namespace Leet.BinaryTrees;

public static class Invert
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
}