using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class ContractData
{
    [XmlElement(ElementName = "enddate")]
    public string? Enddate { get; set; }

    [XmlElement(ElementName = "contractType")]
    public string? ContractType { get; set; }

    [XmlElement(ElementName = "hiredate")]
    public string? Hiredate { get; set; }
}