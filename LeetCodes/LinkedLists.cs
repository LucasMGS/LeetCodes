namespace LeetCodes;


  //Definition for singly-linked list.
public class ListNode {
    public int val { get; set; }
    public ListNode next { get; set; }

    public ListNode(int val=0, ListNode? next=null) {
      this.val = val;
      this.next = next;
  }
}

public static  class LinkedLists
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode? currentNode = head;
        ListNode? prevPointer = null;
        while (currentNode != null)
        {
            var aux = currentNode.next;
            currentNode.next = prevPointer;
            prevPointer = currentNode;
            currentNode = aux;
        }

        return prevPointer;
    }
}
