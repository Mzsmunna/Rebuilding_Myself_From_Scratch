using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class ReverseKGroupNode
    {
        public static ListNode ReverseKGroup(ListNode head, int k)
        {

            ////ListNode head = new ListNode(1); //[1,2,3,4,5]
            ////head.next = new ListNode(2);
            ////head.next.next = new ListNode(3);
            ////head.next.next.next = new ListNode(4);
            ////head.next.next.next.next = new ListNode(5);

            //ListNode head = new ListNode(1); //[1,2,3,4,5,6]
            //head.next = new ListNode(2);
            //head.next.next = new ListNode(3);
            //head.next.next.next = new ListNode(4);
            ////head.next.next.next.next = new ListNode(5);
            ////head.next.next.next.next.next = new ListNode(6);
            ////head.next.next.next.next.next.next = new ListNode(7);

            ////ListNode head = new ListNode(1); //[1]

            //int k = 2; //3;

            ListNode currentIndexNode;
            ListNode mergedList = new ListNode();
            List<int> leftNumbers = new List<int>();
            List<int> rightNumbers = new List<int>();

            if (head != null)
            {
                int i = 0;
                currentIndexNode = head;

                var val = head.val;
                leftNumbers.Add(val);

                do
                {
                    i++;
                    currentIndexNode = currentIndexNode.next;

                    if (currentIndexNode != null)
                    {
                        val = currentIndexNode.val;

                        if (i < k)
                            leftNumbers.Add(val);
                        else
                            rightNumbers.Add(val);
                    }

                } while (currentIndexNode?.next != null);
            }

            currentIndexNode = mergedList;

            if (leftNumbers.Count > 0)
            {
                for (int i = leftNumbers.Count - 1; i >= 0; i--)
                {
                    currentIndexNode.val = leftNumbers[i];

                    if (i > 0)
                    {
                        currentIndexNode.next = new ListNode();
                        currentIndexNode = currentIndexNode.next;
                    }
                }
            }

            if (rightNumbers.Count > 0)
            {
                var skipNumbers = rightNumbers.Skip(leftNumbers.Count).ToList();
                rightNumbers = rightNumbers.Take(leftNumbers.Count).ToList();
                List<List<int>> rightNumberCombo = new List<List<int>>();

                if (leftNumbers.Count <= rightNumbers.Count)
                    rightNumberCombo.Add(rightNumbers);

                while (skipNumbers.Count >= leftNumbers.Count)
                {
                    rightNumbers = skipNumbers.Take(leftNumbers.Count).ToList();
                    rightNumberCombo.Add(rightNumbers);
                    skipNumbers = skipNumbers.Skip(leftNumbers.Count).ToList();
                }

                if (rightNumberCombo.Count > 0)
                {
                    foreach (var numbers in rightNumberCombo)
                    {
                        currentIndexNode.next = new ListNode();
                        currentIndexNode = currentIndexNode.next;

                        for (int i = numbers.Count - 1; i >= 0; i--)
                        {
                            currentIndexNode.val = numbers[i];

                            if (i > 0)
                            {
                                currentIndexNode.next = new ListNode();
                                currentIndexNode = currentIndexNode.next;
                            }
                        }
                    }
                }
                else
                {
                    skipNumbers = rightNumbers;
                }

                if (skipNumbers.Count > 0)
                {
                    currentIndexNode.next = new ListNode();
                    currentIndexNode = currentIndexNode.next;

                    for (int i = 0; i < skipNumbers.Count; i++)
                    {
                        currentIndexNode.val = skipNumbers[i];

                        if (i < skipNumbers.Count - 1)
                        {
                            currentIndexNode.next = new ListNode();
                            currentIndexNode = currentIndexNode.next;
                        }
                    }
                }
            }

            return mergedList;
        }
    }
}
