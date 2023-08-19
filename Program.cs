using System;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}

public class DoublyLinkedList<T>
{
    private Node<T> Head;
    private Node<T> Tail;

    public void AddToFront(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }
    }

    public void AddToEnd(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (Tail == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void RemoveFromEnd()
    {
        if (Tail != null)
        {
            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
        }
    }

    public void RemoveFromFront()
    {
        if (Head != null)
        {
            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
        }
    }

    public bool Search(T value)
    {
        Node<T> current = Head;
        while (current != null)
        {
            if (current.Value.Equals(value))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void OutputReverse()
    {
        Node<T> current = Tail;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Previous;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        list.AddToFront(3);
        list.AddToFront(2);
        list.AddToFront(1);

        list.AddToEnd(4);
        list.AddToEnd(5);
        list.AddToEnd(6);

        Console.WriteLine("List items:");
        list.OutputReverse();

        Console.WriteLine("Removing element from end:");
        list.RemoveFromEnd();
        list.OutputReverse();

        Console.WriteLine("Removing element from front:");
        list.RemoveFromFront();
        list.OutputReverse();

        Console.WriteLine("Search for element 3: " + list.Search(3));
        Console.WriteLine("Search for element 7: " + list.Search(7));
    }
}
