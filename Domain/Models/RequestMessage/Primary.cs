using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class Primary
{
    [XmlElement(ElementName = "phone")]
    public string? Phone { get; set; }

    [XmlElement(ElementName = "email")]
    public string? Email { get; set; }
}