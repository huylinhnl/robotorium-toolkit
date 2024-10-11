using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[Serializable]
[XmlType(AnonymousType = true)]
public partial class ContactData
{
    [XmlElement(ElementName = "additional")]
    public Additional? Additional { get; set; }

    [XmlElement(ElementName = "location")]
    public Location? Location { get; set; }

    [XmlElement(ElementName = "mobile", IsNullable = true)]
    public string? Mobile { get; set; }

    [XmlElement(ElementName = "primary")]
    public Primary? Primary { get; set; }
}