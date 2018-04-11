using System;

public class Deque<T>
{
    private class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node()
        {
            Next = this;
            Prev = this;
        }

        public void Append(T value)
        {
            Next = Next.Prev = new Node { Value = value, Prev = this, Next = this.Next };
        }

        public T Remove()
        {
            Prev.Next = Next;
            Next.Prev = Prev;
            return Value;
        }
    };

    Node root = new Node();

    public void Push(T value) => root.Prev.Append(value);
    public T Pop() => root.Prev.Remove();
    public void Unshift(T value) => root.Append(value);
    public T Shift() => root.Next.Remove();

}