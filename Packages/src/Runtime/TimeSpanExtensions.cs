using System;
using System.Globalization;

public static class TimeSpanExtensions
{
    private static string FormatElapsedTime(TimeSpan value, bool includeMilliseconds)
    {
        var sign = value < TimeSpan.Zero ? "-" : string.Empty;
        var totalHours = Math.Floor(Math.Abs(value.TotalHours));
        var minutes = Math.Abs(value.Minutes);
        var seconds = Math.Abs(value.Seconds);

        if (includeMilliseconds)
            return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}:{2:00}:{3:00}.{4:000}", sign, totalHours, minutes, seconds, Math.Abs(value.Milliseconds));

        return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}:{2:00}:{3:00}", sign, totalHours, minutes, seconds);
    }

    public static string ToOsysDurationString(this TimeSpan value)
    {
        return FormatElapsedTime(value, false);
    }

    public static string ToOsysDurationWithMillisecondsString(this TimeSpan value)
    {
        return FormatElapsedTime(value, true);
    }

    public static string ToOsysElapsedString(this TimeSpan value)
    {
        var sign = value < TimeSpan.Zero ? "-" : string.Empty;
        var totalHours = Math.Floor(Math.Abs(value.TotalHours));
        var totalMinutes = Math.Floor(Math.Abs(value.TotalMinutes));
        var minutes = Math.Abs(value.Minutes);
        var seconds = Math.Abs(value.Seconds);

        if (totalHours > 0)
            return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}:{2:00}:{3:00}", sign, totalHours, minutes, seconds);

        if (totalMinutes > 0)
            return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}:{2:00}", sign, totalMinutes, seconds);

        return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}", sign, seconds);
    }

    public static string ToOsysElapsedWithMillisecondsString(this TimeSpan value)
    {
        if (Math.Abs(value.TotalMinutes) >= 1)
            return value.ToOsysElapsedString();

        var sign = value < TimeSpan.Zero ? "-" : string.Empty;
        var seconds = Math.Abs(value.Seconds);
        var milliseconds = Math.Abs(value.Milliseconds);

        return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}.{2:000}", sign, seconds, milliseconds);
    }

    public static string ToOsysMinuteSecondString(this TimeSpan value)
    {
        var sign = value < TimeSpan.Zero ? "-" : string.Empty;
        var totalMinutes = Math.Floor(Math.Abs(value.TotalMinutes));
        var seconds = Math.Abs(value.Seconds);

        return string.Format(CultureInfo.InvariantCulture, "{0}{1:00}:{2:00}", sign, totalMinutes, seconds);
    }
}
