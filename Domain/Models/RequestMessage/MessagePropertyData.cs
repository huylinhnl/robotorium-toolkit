using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class MessagePropertyData
{
    [XmlElement(ElementName = "action")]
    public string? Action { get; set; }

    [XmlElement(ElementName = "targetSystemID")]
    public string? TargetSystemID { get; set; }
}