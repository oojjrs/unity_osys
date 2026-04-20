using System;
using System.Collections.Generic;
using System.Linq;

public class NotifierBufferT<T> : NotifierBufferInterface
{
    private readonly List<T> _values = new();

    public event Action<IEnumerable<T>> OnUpserted;

    public void Add(T value)
    {
        if (_values.Contains(value) == false)
            _values.Add(value);
    }

    public void AddRange(IEnumerable<T> values)
    {
        _values.AddRange(values.Except(_values));
    }

    public void Broadcast(T value)
    {
        Add(value);
        ((NotifierBufferInterface)this).Flush();
        ((NotifierBufferInterface)this).Clear();
    }

    public void Broadcast(IEnumerable<T> values)
    {
        AddRange(values);
        ((NotifierBufferInterface)this).Flush();
        ((NotifierBufferInterface)this).Clear();
    }

    void NotifierBufferInterface.Clear()
    {
        _values.Clear();
    }

    void NotifierBufferInterface.Flush()
    {
        if (_values.Count > 0)
        {
            OnUpserted?.Invoke(_values);
            _values.Clear();
        }
    }
}
