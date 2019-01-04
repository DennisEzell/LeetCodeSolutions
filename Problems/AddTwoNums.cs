using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace AddTwoNumsProblem
{
    /// <summary>
    ///	You are given two non-empty linked lists representing two non-negative integers. 
    ///	The digits are stored in reverse order and each of their nodes contain a single digit. 
    ///	Add the two numbers and return it as a linked list.
    ///	
    ///	You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    ///
    ///	Example:
    ///		Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    ///		Output: 7 -> 0 -> 8
    ///		Explanation: 342 + 465 = 807.
    /// </summary>
    public class AddTwoNums
    {
        static void Main(string[] args)
        {
            //var l1 = CreateList(new int[] { 2, 4, 3 });
            //var l2 = CreateList(new int[] { 5, 6, 4 });

            var l1 = CreateList(new int[] { 1, 0, 0, 0, 0, 0, 0 });
            var l2 = CreateList(new int[] { 5, 6, 4 });

            PrintList(l1);      
            PrintList(l2);

            var result = AddTwoNumbers(l1, l2);            
            WriteLine();
            PrintList(result);

            ReadKey(); //Pause console execution in order to view results
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //faster result:
            //ListNode head = new ListNode(-1);
            //ListNode l3 = head;
            //int carry = 0, x, y;
            //while (l1 != null || l2 != null || carry > 0)
            //{
            //    x = l1 == null ? 0 : l1.val;
            //    y = l2 == null ? 0 : l2.val;
            //    l3.next = new ListNode((x + y + carry) % 10);
            //    carry = (x + y + carry) / 10;
            //    l3 = l3.next;
            //    l1 = l1 == null ? null : l1.next;
            //    l2 = l2 == null ? null : l2.next;
            //}
            //return head.next;
        


        var result = new ListNode(0);
            List<int> arg1 = new List<int>();
            List<int> arg2 = new List<int>();
            ListNode currentNode = l1;
            do
            {
                arg1.Add(currentNode.val);
                currentNode = currentNode.next;
            } while (currentNode != null);

            var strArg1 = "";            
            arg1.Reverse();
            arg1.ForEach(i => strArg1 += i.ToString());

            currentNode = l2;
            do
            {
                arg2.Add(currentNode.val);
                currentNode = currentNode.next;
            } while (currentNode != null);

            var strArg2 = "";
            arg2.Reverse();
            arg2.ForEach(i => strArg2 += i.ToString());

            var sum = (double.Parse(strArg1) + double.Parse(strArg2)).ToString().ToCharArray().Reverse();

            var sumArray = sum.Select(i => Convert.ToInt32(double.Parse(i.ToString()))).ToArray();

            return CreateList(sumArray);
        }


        private static ListNode CreateList(int[] val)
        {
            var result = new ListNode(Convert.ToInt32(val[0]));       
            ListNode currentNode = null;
            for (var i = 0; i < val.Length; i++) 
            {
                //The first iteration will refer to the outer most node, which is what we will be returing
                if (i == 0)
                {
                    currentNode = result;
                }

                if (i != val.Length - 1)
                {
                    currentNode.next = new ListNode(Convert.ToInt32(val[i + 1]));
                    //Now that we have established the next link for the current node, reset the "CurrentNode" variable
                    //to point at the next node in the chain for the next iteration's logic. 
                    currentNode = currentNode.next;
                }
            }

            return result;
        }

        private static void PrintList(ListNode firstNode)
        {
            var terminate = false;
            ListNode currentNode = null;
            while (!terminate)
            {
                if(currentNode == null)
                {
                    currentNode = firstNode;
                }
                Write(currentNode.val);
                if (currentNode.next == null)
                {
                    WriteLine();
                    terminate = true;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }
        }
    }


    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x) { val = x; }

    }
}
