using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
[XmlRoot(elementName: "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
public partial class RequestEnvelope
{
    private const string ns = "http://www.achmea.nl/BuildingBlocks/ChainLogging/2007/11";
    private const string soap = "http://schemas.xmlsoap.org/soap/envelope/";

    public EnvelopeHeader? Header { get; set; }
    public EnvelopeBody? Body { get; set; }

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces xmlns;

    public RequestEnvelope()
    {
        xmlns = new XmlSerializerNamespaces();
        xmlns.Add("ns", ns);
        xmlns.Add("soap", soap);
    }
}