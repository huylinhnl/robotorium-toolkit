using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class EmployeeID
{
    public string? UID { get; set; }

    [XmlElement(ElementName = "accountName")]
    public string? AccountName { get; set; }

    [XmlElement(ElementName = "accountPW")]
    public string? AccountPW { get; set; }

    [XmlElement(ElementName = "employeeNumber")]
    public string? EmployeeNumber { get; set; }
}