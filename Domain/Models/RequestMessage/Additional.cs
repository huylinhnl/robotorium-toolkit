using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class Additional
{
    [XmlElement(ElementName = "phone")]
    public string? Phone { get; set; }

    [XmlElement(ElementName = "email")]
    public string? Email { get; set; }
}