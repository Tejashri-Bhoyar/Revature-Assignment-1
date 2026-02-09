using System;

namespace Utilities
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}