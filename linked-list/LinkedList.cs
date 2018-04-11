using System;

public class Deque<T>
{
    private Node<T> head;
    private Node<T> current;

    /// <summary>
    /// insert value at back
    /// </summary>
    /// <param name="value"></param>
    public void Push(T value)
    {
        var node = new Node<T>(value);
        if (head == null) 
        { 
            head = node; 
            current = head;
        }
        else
        {
            current.Next = node;
            node.Previous = current;
            current = node;
        }
    }

    /// <summary>
    /// remove value at back
    /// </summary>
    /// <returns></returns>
    public T Pop()
    {
        var previous = current.Previous;
        var value = current.Data;
        current = previous;
        return value;
    }

    /// <summary>
    /// remove value at front
    /// </summary>
    /// <param name="value"></param>
    public void Unshift(T value)
    {
        var node = new Node<T>(value);
        if (head == null) 
        { 
            head = node; 
            current = head;
        }
        else
        {
            head.Previous = node;
            node.Next = head;
            head = node;
        }
    }

    /// <summary>
    /// remove value at front
    /// </summary>
    /// <returns></returns>
    public T Shift()
    {
        var next = head.Next;
        var value = head.Data;
        head = next;
        return value;
    }
}

internal class Node<T>
{
    public Node<T> Next { get; set; }
    public Node<T> Previous { get; set; }
    public T Data { get; private set; }

    public Node(T data)
    {
        Data = data;
    }
}