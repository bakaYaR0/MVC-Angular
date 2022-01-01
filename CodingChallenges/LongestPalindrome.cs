using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_palindrome
{
    internal class LongestPalindrome
    {
        public static int GetLongestPalindromeEfficient(string str)
        {
            int maxLength = 1;
            int length = str.Length;

            int low, high;

            // One by one consider every
            // character as center point
            // of even and length palindromes
            for (int i = 1; i < length; i++)
            {
                // Find the longest even length
                // palindrome with center points
                // as i-1 and i.
                low = i - 1; high = i;
                while (low >= 0 && high < length && str[low] == str[high])
                {
                    --low; ++high;
                }

                // Move back to the last possible valid palindrom substring
                // as that will anyway be the longest from above loop
                ++low; --high;
                if (str[low] == str[high] && high - low + 1 > maxLength)
                {
                    maxLength = high - low + 1;
                }

                // Find the longest odd length
                // palindrome with center point as i
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < length && str[low] == str[high])
                {
                    --low; ++high;
                }

                // Move back to the last possible valid palindrom substring
                // as that will anyway be the longest from above loop
                ++low; --high;
                if (str[low] == str[high] && high - low + 1 > maxLength)
                {
                    maxLength = high - low + 1;
                }
            }

            return maxLength;
        }


        /// <Note>
        /// Additional solutions are saved for further study and efficiency tests
        /// </Note>
        /// <param name="str"></param>
        public static int GetLongestPalindromeLinq(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            var reverse = string.Concat(str.Reverse());

            return Enumerable.Range(0, str.Length)
                .SelectMany(i => Enumerable.Range(i, str.Length - i + 1).Select(j => str.Substring(i, j - i)))
                .Where(x => reverse.Contains(x)).Max(x => x.Length);
        }

        public static int GetLongestPalindromeShort(string str)
        {
            if (str == null) return 0;

            int result = 0;
            for (int i = 0; i < str.Length; ++i)
                for (int j = i; j < str.Length; ++j)
                {
                    var s = str.Substring(i, j - i + 1);
                    if (Enumerable.SequenceEqual(s, s.Reverse()))
                        result = Math.Max(result, s.Length);
                }

            return result;
        }
    }
}
