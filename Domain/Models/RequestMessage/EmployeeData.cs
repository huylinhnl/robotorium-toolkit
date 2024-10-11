using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class EmployeeData
{
    [XmlElement(ElementName = "functionData")]
    public FunctionData? FunctionData { get; set; }

    [XmlElement(ElementName = "managerData")]
    public ManagerData? ManagerData { get; set; }

    [XmlElement(ElementName = "contactData")]
    public ContactData? ContactData { get; set; }

    [XmlElement(ElementName = "contractData")]
    public ContractData? ContractData { get; set; }

    [XmlElement(ElementName = "organisationData")]
    public OrganisationData? OrganisationData { get; set; }

    [XmlElement(ElementName = "personalData")]
    public PersonalData? PersonalData { get; set; }
}