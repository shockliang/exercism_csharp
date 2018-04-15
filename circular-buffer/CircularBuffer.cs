using System;
using System.Linq;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly int size;
    private Queue<T> data;
    public CircularBuffer(int size)
    {
        this.size = size;
        data = new Queue<T>(size);
    }

    public T Read()
    {
        return data.Dequeue();
    }

    public void Write(T value)
    {
        if (data.Count == size)
            throw new InvalidOperationException();

        data.Enqueue(value);
    }

    public void ForceWrite(T value)
    {
        if (data.Count < size)
        {
            Write(value);
        }
        else
        {
            data.Dequeue();
            data = new Queue<T>(data.Append(value).AsEnumerable());
        }
    }

    public void Clear()
    {
        data.Clear();
    }
}