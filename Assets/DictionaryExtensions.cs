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
}
