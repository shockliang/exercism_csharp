using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private SimpleLinkedList<T> _last;

    public SimpleLinkedList(T value)
    {
        Value = value;
        Next = null;
        _last = this;
    }

    public SimpleLinkedList(IEnumerable<T> values) : this(values.First())
    {
        foreach (var value in values.Skip(1))
            Add(value);
    }

    public T Value { get; }

    public SimpleLinkedList<T> Next { get; private set; }

    public SimpleLinkedList<T> Add(T value)
    {
        _last.Next = new SimpleLinkedList<T>(value);
        _last = _last.Next;

        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}