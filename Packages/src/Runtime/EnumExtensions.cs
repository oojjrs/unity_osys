using System;

public static class EnumExtensions
{
    public static T GetNext<T>(this T value) where T : struct, Enum
    {
        var values = (T[])Enum.GetValues(typeof(T));
        if (values.Length > 0)
        {
            var index = Array.IndexOf(values, value);
            if (index >= 0)
                return values[(index + 1) % values.Length];

            return values[0];
        }

        return default;
    }

    public static T GetPrevious<T>(this T value) where T : struct, Enum
    {
        var values = (T[])Enum.GetValues(typeof(T));
        if (values.Length > 0)
        {
            var index = Array.IndexOf(values, value);
            if (index >= 0)
                return values[(index - 1 + values.Length) % values.Length];

            return values[^1];
        }

        return default;
    }
}
