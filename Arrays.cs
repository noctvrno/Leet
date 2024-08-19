namespace Leet;

public static class Arrays
{
    public static int[] SearchRange(int[] numbers, int target)
    {
        switch (numbers.Length)
        {
            case 0:
                return [-1, -1];
            case 1 when target == numbers[0]:
                return [0, 0];
        }

        List<int> result = [];
        int firstMatchIndex = BinarySearch(numbers, target);
        if (firstMatchIndex == -1)
            return [-1, -1];

        int leftMostMatchIndex = GetLeftmostMatchIndex(numbers, target, firstMatchIndex);
        result.Add(leftMostMatchIndex == -1 ? firstMatchIndex : leftMostMatchIndex);

        int rightMostMatchIndex = GetRightmostMatchIndex(numbers, target, firstMatchIndex);
        result.Add(rightMostMatchIndex == -1 ? firstMatchIndex : rightMostMatchIndex);

        return [.. result];
    }

    private static int BinarySearch(IReadOnlyList<int> numbers, int target)
    {
        int start = 0;
        int end = numbers.Count - 1;
        while (start <= end)
        {
            int middle = (start + end) / 2;
            int value = numbers[middle];
            if (target == value)
            {
                return middle;
            }

            if (target > value)
            {
                start = middle + 1;
                continue;
            }

            end = middle - 1;
        }

        return -1;
    }

    private static int GetLeftmostMatchIndex(IReadOnlyList<int> numbers, int target, int index)
    {
        var value = numbers[index];
        while (index > 0 && value == target)
        {
            --index;
            value = numbers[index];
        }

        if (value < target)
            return index + 1;

        if (value == target)
            return index;

        return -1;
    }

    private static int GetRightmostMatchIndex(IReadOnlyList<int> numbers, int target, int index)
    {
        var value = numbers[index];
        while (index < numbers.Count - 1 && value == target)
        {
            ++index;
            value = numbers[index];
        }

        if (value > target)
            return index - 1;

        if (value == target)
            return index;

        return -1;
    }
}
