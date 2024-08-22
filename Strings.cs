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
}