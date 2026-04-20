using System.Text.RegularExpressions;

public static class RegexHelper
{
    public static bool RegexIsLike(this string s, string likePattern)
    {
        return RegexIsLike(s, likePattern, RegexOptions.None);
    }

    public static bool RegexIsLike(this string s, string likePattern, RegexOptions regexOptions)
    {
        if ((s is null) || (likePattern is null))
            return false;

        var regexPattern = "^" + Regex.Escape(likePattern).Replace("%", ".*") + "$";

        return Regex.IsMatch(s, regexPattern, regexOptions);
    }
}
