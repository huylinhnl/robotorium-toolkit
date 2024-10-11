using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class OrganisationData
{
    [XmlElement(ElementName = "costcenter")]
    public string? Costcenter { get; set; }

    [XmlElement(ElementName = "ou")]
    public string? Ou { get; set; }

    [XmlElement(ElementName = "ouCode")]
    public string? OuCode { get; set; }

    [XmlElement(ElementName = "department")]
    public string? Department { get; set; }

    [XmlElement(ElementName = "company")]
    public string? Company { get; set; }

    [XmlElement(ElementName = "departmentCode")]
    public string? DepartmentCode { get; set; }

    [XmlElement(ElementName = "abu")]
    public string? Abu { get; set; }

    [XmlElement(ElementName = "companyCode")]
    public string? CompanyCode { get; set; }

    [XmlElement(ElementName = "abuCode")]
    public string? AbuCode { get; set; }
}