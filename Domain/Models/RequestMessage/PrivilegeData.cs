using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class PrivilegeData
{
    [XmlElement(ElementName = "privelegeName")]
    public string? PrivelegeName { get; set; }
}