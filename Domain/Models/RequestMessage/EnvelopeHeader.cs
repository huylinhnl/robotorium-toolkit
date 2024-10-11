using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public partial class EnvelopeHeader
{
    private const string wsa = "http://www.w3.org/2005/08/addressing";

    [XmlElement(Namespace = "http://www.achmea.nl/BuildingBlocks/ChainLogging/2007/11")]
    public ChainLogHeader? ChainLogHeader { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string? To { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string? MessageID { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string? Action { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2005/08/addressing")]
    public string? From { get; set; }

    [XmlElement(ElementName = "signature", Namespace = "")]
    public string? Signature { get; set; }

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces xmlns;

    public EnvelopeHeader()
    {
        xmlns = new XmlSerializerNamespaces();
        xmlns.Add("wsa", wsa);
    }
}