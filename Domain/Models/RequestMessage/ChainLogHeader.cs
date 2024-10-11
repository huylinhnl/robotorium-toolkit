using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true, Namespace = "http://www.achmea.nl/BuildingBlocks/ChainLogging/2007/11")]
[XmlRoot(Namespace = "http://www.achmea.nl/BuildingBlocks/ChainLogging/2007/11", IsNullable = false)]
public partial class ChainLogHeader
{
    [XmlElement(ElementName = "chainId")]
    public string? ChainId { get; set; }

    [XmlElement(ElementName = "requestId")]
    public string? RequestId { get; set; }
}