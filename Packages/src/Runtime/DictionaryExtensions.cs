using System;
using System.Collections.Generic;

public static class DictionaryExtensions
{
    public static bool InsertAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, IEnumerable<TValue> values, Func<TValue, TKey> getKey)
    {
        foreach (var value in values)
        {
            if (dic.TryAdd(getKey(value), value) == false)
                return false;
        }

        return true;
    }

    public static bool InsertAll<TKey, TValue, TElement>(this Dictionary<TKey, TElement> dic, IEnumerable<TValue> values, Func<TValue, TKey> getKey, Func<TValue, TElement> getElement)
    {
        foreach (var value in values)
        {
            if (dic.TryAdd(getKey(value), getElement(value)) == false)
                return false;
        }

        return true;
    }
}
