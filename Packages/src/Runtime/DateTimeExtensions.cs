using System;
using System.Globalization;

public static class DateTimeExtensions
{
    public static string ToOsysDateHourMinuteString(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
    }

    public static string ToOsysDateString(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    public static string ToOsysDateTimeString(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public static string ToOsysFileTimestampString(this DateTime value)
    {
        return value.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture);
    }

    public static string ToOsysHourMinuteString(this DateTime value)
    {
        return value.ToString("HH:mm", CultureInfo.InvariantCulture);
    }

    public static string ToOsysTimeString(this DateTime value)
    {
        return value.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
    }

    public static string ToOsysTimeWithMillisecondsString(this DateTime value)
    {
        return value.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);
    }
}
