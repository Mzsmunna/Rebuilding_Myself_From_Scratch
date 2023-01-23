using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP
{
    public static class MergekSortedLists
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            //ListNode listNode1 = new ListNode(1); //[[1, 4, 5],[1,3,4],[2,6]]
            //listNode1.next = new ListNode(4);
            //listNode1.next.next = new ListNode(5);

            //ListNode listNode2 = new ListNode(1);
            //listNode2.next = new ListNode(3);
            //listNode2.next.next = new ListNode(4);

            //ListNode listNode3 = new ListNode(2);
            //listNode3.next = new ListNode(6);

            //ListNode[] lists = new ListNode[] { listNode1, listNode2, listNode3 };


            //ListNode listNode1 = new ListNode(1); //[[1]]


            //ListNode listNode1 = new ListNode(0); //[[0,2,5]]
            //listNode1.next = new ListNode(2);
            //listNode1.next.next = new ListNode(5);

            //ListNode[] lists = new ListNode[] { listNode1 };


            //ListNode[] lists = new ListNode[] {  };

            List<int> allNumbers = new List<int>();
            ListNode mergedList = new ListNode();
            ListNode currentIndexNode;

            foreach (ListNode node in lists)
            {
                if (node != null)
                {
                    currentIndexNode = node;

                    var val = node.val;
                    allNumbers.Add(val);

                    do
                    {
                        currentIndexNode = currentIndexNode.next;

                        if (currentIndexNode != null)
                        {
                            val = currentIndexNode.val;
                            allNumbers.Add(val);
                        }

                    } while (currentIndexNode?.next != null);
                }
            }

            allNumbers.Sort();

            if (allNumbers.Count > 0)
            {
                currentIndexNode = mergedList;

                for (int i = 0; i < allNumbers.Count; i++)
                {
                    currentIndexNode.val = allNumbers[i];

                    if (i < allNumbers.Count - 1)
                    {
                        currentIndexNode.next = new ListNode();
                        currentIndexNode = currentIndexNode.next;
                    }
                }
            }
            else
            {
                mergedList = null;
            }

            return mergedList;
        }
    }
}
