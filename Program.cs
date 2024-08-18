using Leet;

var root = new TreeNode(
    0,
    new TreeNode(
        1,
        new TreeNode(
            0,
            new TreeNode(1),
            new TreeNode(1)),
        new TreeNode(
            0,
            new TreeNode(1),
            new TreeNode(1))),
    new TreeNode(
        2,
        new TreeNode(
            0,
            new TreeNode(2),
            new TreeNode(2)),
        new TreeNode(
            0,
            new TreeNode(2),
            new TreeNode(2))));

BinaryTrees.ReverseOddLevels(root);

return;