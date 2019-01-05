using static System.Console;

namespace LongestSubstringProblem
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    ///	
    ///	Example 1:
    ///	
    ///	Input: "abcabcbb"
    ///	Output: 3 
    ///	Explanation: The answer is "abc", with the length of 3. 
    ///	Example 2:
    ///	
    ///	Input: "bbbbb"
    ///	Output: 1
    ///	Explanation: The answer is "b", with the length of 1.
    ///	Example 3:
    ///	
    ///	Input: "pwwkew"
    ///	Output: 3
    ///	Explanation: The answer is "wke", with the length of 3. 
    ///		         Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    /// </summary>
    public class LongestSubstring
    {
        static void Main(string[] args)
        {

            var test = new string[]
            {
                "abcabcbb",
                "bbbbb",
                "pwwkew",
                "",
                " ",
                "au",
                "dvdf",
                "vbxpvwkkteaiob",
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ abcdefghijklmnopqrstuvwxyzABC"
            };

            foreach(var str in test)
            {
                WriteLine();
                WriteLine($"...Processing: {str}");
                WriteLine(LengthOfLongestSubstring(str));
                WriteLine();
            }

            ReadKey();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var longest = 0;

            for (var i = 0; i < s.Length; i++)
            {   
                var currentIndexSize = LongestSubstringFromGivenIndex(s, i);
                if (currentIndexSize > longest)
                {
                    longest = currentIndexSize;
                }


                //If the longest calculated string is already as long as the current remaining substring, break iteration
                if (longest >= s.Length - i)
                {
                    break;
                }
            }     

            return longest;
        }

        private static int LongestSubstringFromGivenIndex(string s, int index)
        {
            if (s == "")
            {
                return 0;
            }

            var longestSubstring = "";
            var currentSubstring = "";

            foreach (var chr in s.Substring(index).ToCharArray())
            {
                //If current substring does not contain 
                if (!currentSubstring.Contains(chr.ToString()))
                {
                    currentSubstring += chr.ToString();
                }
                //Current char is already in the current substring
                //Compare current substring with longest to see if we have a newer, longer substring
                //Reset the current substring to be a string startign with just the curren char.
                else
                {
                    if (currentSubstring.Length > longestSubstring.Length)
                    {
                        longestSubstring = currentSubstring;                        
                    }

                    currentSubstring = chr.ToString();
                }
            }

            //Check if we ended the string with the longest substring
            if (currentSubstring.Length > longestSubstring.Length)
            {
                longestSubstring = currentSubstring;
            }

            WriteLine($"Current Index: {index}, Substring: {longestSubstring}");

            return longestSubstring.Length;
        }
    }
}
