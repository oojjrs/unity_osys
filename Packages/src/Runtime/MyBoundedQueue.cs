using System;
using System.Collections.Generic;

public class MyBoundedQueue<T>
{
    private readonly Queue<T> _queue;

    public int Count => _queue.Count;
    public int MaxCount { get; }

    public MyBoundedQueue(int maxCount)
    {
        if (maxCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxCount), maxCount, "Max count must be greater than zero.");

        _queue = new(maxCount);

        MaxCount = maxCount;
    }

    public void Clear()
    {
        _queue.Clear();
    }

    public bool Contains(T item)
    {
        return _queue.Contains(item);
    }

    public void Enqueue(T item)
    {
        while (_queue.Count >= MaxCount)
            _queue.Dequeue();

        _queue.Enqueue(item);
    }

    public bool TryDequeue(out T item)
    {
        if (_queue.Count <= 0)
        {
            item = default;
            return false;
        }

        item = _queue.Dequeue();
        return true;
    }

    public bool TryPeek(out T item)
    {
        if (_queue.Count <= 0)
        {
            item = default;
            return false;
        }

        item = _queue.Peek();
        return true;
    }
}
