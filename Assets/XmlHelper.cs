using System;
using System.IO;
using System.Xml.Serialization;

public static class XmlHelper
{
    public static void Build<T>(string text, Action<T[]> onLoaded)
    {
        using (var sr = new StringReader(text))
        {
            var xs = new XmlSerializer(typeof(T[]));
            onLoaded?.Invoke((T[])xs.Deserialize(sr));
        }
    }
}
