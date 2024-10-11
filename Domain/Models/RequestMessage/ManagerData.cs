using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class ManagerData
{
    [XmlElement(ElementName = "employeeNumber")]
    public string? EmployeeNumber { get; set; }

    [XmlElement(ElementName = "displayName")]
    public string? DisplayName { get; set; }
}