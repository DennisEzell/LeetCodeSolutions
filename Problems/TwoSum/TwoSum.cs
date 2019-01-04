using System;

namespace TwoSumProblem
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// 
    /// Example:
    ///     Given nums = [2, 7, 11, 15], target = 9,
    ///
    ///     Because nums[0] + nums[1] = 2 + 7 = 9,
    ///     return [0, 1].
    /// </summary>
    public class TwoSum
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 7, 11, 15 };

            var solution = EvaluateInput(nums, 13);
            Console.WriteLine($"[{nums[solution[0]]},{nums[solution[1]]}]");
            foreach (var num in solution)
            {
                Console.WriteLine(num);
            }

            //Pause the console for output
            Console.ReadKey();
        }

        public static int[] EvaluateInput(int[] nums, int target)
        {
            var solution = new int[2];
            for (var i = 0; i < nums.Length; i++)
            {
                var foundSolution = false;
                int nextIndex = i + 1;
                while (!foundSolution && nextIndex < nums.Length)
                {
                    if (nums[i] + nums[nextIndex] == target)
                    {
                        solution[0] = i;
                        solution[1] = nextIndex;
                        foundSolution = true;
                    }
                    nextIndex++;
                }

                if (foundSolution) break;
            }

            return solution;
        }
    }
}
