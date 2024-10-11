using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace RoboToolkit.Extentions;

public static class MessageExtentions
{
    public static string ToXmlStringContent<T>(this T envelope)
    {
        XmlSerializer serializer = new(typeof(T));
        using (Utf8StringWriter sw = new())
        using (XmlTextWriter writer = new(sw))
        {
            writer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, envelope);
            return sw.ToString();
        };
    }

    public static T Deserialize<T>(this XmlDocument document) where T : class
    {
        using XmlReader reader = new XmlNodeReader(document);
        var serializer = new XmlSerializer(typeof(T));
        T result = (T)serializer.Deserialize(reader)!;
        return result;
    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
