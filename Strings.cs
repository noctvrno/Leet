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
}