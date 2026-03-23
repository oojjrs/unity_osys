using System.Collections.Generic;
using System.Linq;

public class MyDictionaryListT<TKey, TValue>
{
    private readonly Dictionary<TKey, List<TValue>> _values = new();

    public int Count => _values.Count;

    public void Add(TKey key, TValue value)
    {
        if (_values.TryGetValue(key, out var values) == false)
        {
            values = new();
            _values.Add(key, values);
        }

        values.Add(value);
    }

    public void Clear()
    {
        _values.Clear();
    }

    public int GetCount(TKey key)
    {
        if (_values.TryGetValue(key, out var values))
            return values.Count;
        else
            return 0;
    }

    public void Remove(TKey key)
    {
        _values.Remove(key);
    }

    public void Remove(TKey key, TValue value)
    {
        if (_values.ContainsKey(key))
            _values[key].Remove(value);
    }

    public bool TryGetValue(TKey key, out IEnumerable<TValue> values)
    {
        if (_values.TryGetValue(key, out var list))
        {
            values = list;
            return true;
        }
        else
        {
            values = Enumerable.Empty<TValue>();
            return false;
        }
    }
}
