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

    public static int SearchInsert(int[] numbers, int target)
    {
        var start = 0;
        var end = numbers.Length - 1;
        var result = 0;
        while (start <= end)
        {
            var middle = (start + end) / 2;
            var value = numbers[middle];
            if (target == value)
                return middle;

            if (target < value)
            {
                end = middle - 1;
                result = middle;
                continue;
            }

            start = middle + 1;
            result = start;
        }

        return result;
    }

    public static int MaxArea(int[] height)
    {
        var maxContainerArea = 0;
        int start = 0;
        int end = height.Length - 1;
        while (start <= end)
        {
            var firstHeight = height[start];
            var secondHeight = height[end];
            var containerHeight = Math.Min(firstHeight, secondHeight);
            var containerWidth = end - start;
            var containerArea = containerHeight * containerWidth;

            maxContainerArea = Math.Max(containerArea, maxContainerArea);
            if (firstHeight >= secondHeight)
            {
                --end;
                continue;
            }

            ++start;
        }

        return maxContainerArea;
    }

    public static int FindClosestNumber(int[] numbers)
    {
        var closestToZero = int.MaxValue;
        foreach (int number in numbers)
        {
            var absoluteNumber = Math.Abs(number);
            var absoluteClosestToZero = Math.Abs(closestToZero);
            if (absoluteNumber < absoluteClosestToZero)
            {
                closestToZero = number;
                continue;
            }

            if (absoluteNumber == absoluteClosestToZero)
                closestToZero = Math.Max(number, closestToZero);
        }

        return closestToZero;
    }

    public static int[] SortedSquares(int[] numbers)
    {
        int left = 0;
        int right = numbers.Length - 1;
        List<int> result = [];
        while (left <= right)
        {
            int leftNumber = Math.Abs(numbers[left]);
            int rightNumber = Math.Abs(numbers[right]);

            if (leftNumber > rightNumber)
            {
                result.Add(leftNumber * leftNumber);
                ++left;
                continue;
            }

            result.Add(rightNumber * rightNumber);
            --right;
        }

        Reverse(result);
        return [.. result];
    }

    private static void Reverse(List<int> numbers)
    {
        var left = 0;
        int right = numbers.Count - 1;
        while (left < right)
        {
            (numbers[left], numbers[right]) = (numbers[right], numbers[left]);
            ++left;
            --right;
        }
    }

    public static IList<IList<int>> ThreeSum(int[] numbers)
    {
        numbers = numbers.Order().ToArray();
        IList<IList<int>> result = [];
        for (var i = 0; i < numbers.Length; ++i)
        {
            var currentNumber = numbers[i];
            if (currentNumber > 0)
                return result;
            if (i > 0 && currentNumber == numbers[i - 1])
                continue;

            var left = i + 1;
            var right = numbers.Length - 1;
            while (left < right)
            {
                var leftNumber = numbers[left];
                var rightNumber = numbers[right];
                var sum = currentNumber + leftNumber + rightNumber;
                switch (sum)
                {
                    case 0:
                        result.Add([currentNumber, leftNumber, rightNumber]);
                        ++left;
                        while (left < right && numbers[left] == numbers[left - 1])
                        {
                            ++left;
                        }

                        --right;
                        while (left < right && numbers[right] == numbers[right + 1])
                        {
                            --right;
                        }

                        continue;
                    case > 0:
                        --right;
                        continue;
                    case < 0:
                        ++left;
                        continue;
                }
            }
        }

        return result;
    }
}
