using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public partial class EnvelopeBody
{
    [XmlElement(ElementName = "achmeaData", Namespace = "")]
    public AchmeaData? AchmeaData { get; set; }
}