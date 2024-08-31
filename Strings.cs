using System.Text;

namespace Leet;

public static class Strings
{
    public static string MergeAlternately(string word1, string word2)
    {
        var wordIndex = 0;
        var maxWordLength = Math.Max(word1.Length, word2.Length);
        var mergedChars = new StringBuilder(maxWordLength);
        while (wordIndex < maxWordLength)
        {
            if (wordIndex < word1.Length)
                mergedChars.Append(word1[wordIndex]);

            if (wordIndex < word2.Length)
                mergedChars.Append(word2[wordIndex]);

            ++wordIndex;
        }

        return mergedChars.ToString();
    }

    public static int RomanToInt(string s)
    {
        var romanNumeralToValue = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        if (s.Length == 1)
            return romanNumeralToValue[s[0]];

        var romanNumeral = 0;
        for (var index = 0; index < s.Length; ++index)
        {
            var currentNumeralValue = romanNumeralToValue[s[index]];
            var nextNumeralValue = index < s.Length - 1 ? romanNumeralToValue[s[index + 1]] : 0;
            if (currentNumeralValue < nextNumeralValue)
            {
                romanNumeral += nextNumeralValue - currentNumeralValue;
                ++index;
                continue;
            }

            romanNumeral += currentNumeralValue;
        }

        return romanNumeral;
    }

    public static string LongestCommonPrefix(string[] strings)
    {
        if (strings.Length == 1)
            return strings[0];

        var minimumStringLength = strings.Min(s => s.Length);
        var stringBuilder = new StringBuilder(minimumStringLength);
        var charIndex = 0;
        while (charIndex < minimumStringLength)
        {
            char currentChar = '\0';
            for (var strIndex = 0; strIndex < strings.Length - 1; ++strIndex)
            {
                string currentStr = strings[strIndex];
                string nextStr = strings[strIndex + 1];
                currentChar = currentStr[charIndex];
                char nextChar = nextStr[charIndex];
                if (currentChar != nextChar)
                    return stringBuilder.ToString();
            }

            stringBuilder.Append(currentChar);
            ++charIndex;
        }

        return stringBuilder.ToString();
    }

    public static int CalPoints(string[] operations)
    {
        Stack<int> stack = new();
        foreach (var operation in operations)
        {
            switch (operation)
            {
                case var _ when int.TryParse(operation, out int result):
                    stack.Push(result);
                    break;
                case "+":
                    var mostRecent = stack.Pop();
                    var secondMostRecent = stack.Count > 0
                        ? stack.Peek()
                        : 0;

                    stack.Push(mostRecent);
                    stack.Push(mostRecent + secondMostRecent);
                    break;
                case "D":
                    stack.Push(stack.Peek() * 2);
                    break;
                case "C":
                    stack.Pop();
                    break;
            }
        }

        return stack.Sum(); // Could replace this by using a variable that gets modified throughout operations.
    }

    public static bool IsValid(string s)
    {
        if (s.Length == 1)
            return false;

        Stack<char> openBracketStack = new();
        Dictionary<char, char> closedBracketToOpenBracket = new()
        {
            {')', '('},
            {']', '['},
            {'}', '{'}
        };

        foreach (var bracket in s)
        {
            if (closedBracketToOpenBracket.TryGetValue(bracket, out var correspondingOpenBracket) &&
                openBracketStack.TryPeek(out var lastOpenBracket) &&
                correspondingOpenBracket == lastOpenBracket)
            {
                openBracketStack.Pop();
                continue;
            }

            openBracketStack.Push(bracket);
        }

        return openBracketStack.Count == 0;
    }

    public static int EvalRPN(string[] tokens)
    {
        if (tokens.Length == 1)
            return int.Parse(tokens[0]);

        Stack<int> stack = new();
        foreach (var token in tokens)
        {
            int mostRecent;
            int secondMostRecent;
            switch (token)
            {
                case var _ when int.TryParse(token, out var result):
                    stack.Push(result);
                    break;
                case "+":
                    mostRecent = stack.Pop();
                    secondMostRecent = stack.Pop();
                    stack.Push(secondMostRecent + mostRecent);
                    break;
                case "-":
                    mostRecent = stack.Pop();
                    secondMostRecent = stack.Pop();
                    stack.Push(secondMostRecent - mostRecent);
                    break;
                case "*":
                    mostRecent = stack.Pop();
                    secondMostRecent = stack.Pop();
                    stack.Push(secondMostRecent * mostRecent);
                    break;
                case "/":
                    mostRecent = stack.Pop();
                    secondMostRecent = stack.Pop();
                    stack.Push(secondMostRecent / mostRecent);
                    break;
            }
        }

        return stack.Single();
    }
}