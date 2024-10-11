using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public partial class AchmeaData
{
    [XmlElement(ElementName = "employeeData")]
    public EmployeeData? EmployeeData { get; set; }

    [XmlElement(ElementName = "employeeID")]
    public EmployeeID? EmployeeID { get; set; }

    [XmlElement(ElementName = "messagePropertyData")]
    public MessagePropertyData? MessagePropertyData { get; set; }

    [XmlElement(ElementName = "privilegeData")]
    public PrivilegeData? PrivilegeData { get; set; }
}