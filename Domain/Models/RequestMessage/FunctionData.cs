using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class FunctionData
{
    [XmlElement(ElementName = "functionName")]
    public string? FunctionName { get; set; }

    [XmlElement(ElementName = "functionCode")]
    public string? FunctionCode { get; set; }

    [XmlElement(ElementName = "isManager")]
    public string? IsManager { get; set; }
}