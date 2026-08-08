using System;
using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static int GetIndex<T>(this IEnumerable<T> values, T value)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        var index = 0;
        foreach (var current in values)
        {
            if (EqualityComparer<T>.Default.Equals(current, value))
                return index;

            ++index;
        }

        return index;
    }

    public static T GetNext<T>(this IEnumerable<T> values, T value)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        using (var enumerator = values.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                var first = enumerator.Current;
                while (EqualityComparer<T>.Default.Equals(enumerator.Current, value) == false)
                {
                    if (enumerator.MoveNext() == false)
                        return first;
                }

                if (enumerator.MoveNext())
                    return enumerator.Current;

                return first;
            }
        }

        return default;
    }

    public static T GetPrevious<T>(this IEnumerable<T> values, T value)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        using (var enumerator = values.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {
                var first = enumerator.Current;
                var previous = first;
                if (EqualityComparer<T>.Default.Equals(first, value))
                {
                    while (enumerator.MoveNext())
                        previous = enumerator.Current;

                    return previous;
                }

                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (EqualityComparer<T>.Default.Equals(current, value))
                        return previous;

                    previous = current;
                }

                return previous;
            }
        }

        return default;
    }
}
