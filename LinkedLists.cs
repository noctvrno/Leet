namespace Leet;

public static class LinkedLists
{
    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode currentNode = head;
        ListNode? previousNode = null;
        while (currentNode != null)
        {
            if (previousNode != null && currentNode.val == previousNode.val)
            {
                previousNode.next = currentNode.next;
                currentNode = currentNode.next;
                continue;
            }

            previousNode = currentNode;
            currentNode = currentNode.next;
        }

        return head;
    }
}
