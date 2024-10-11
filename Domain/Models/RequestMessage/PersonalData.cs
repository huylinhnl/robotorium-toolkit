using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class PersonalData
{
    [XmlElement(ElementName = "namePrefix")]
    public string? NamePrefix { get; set; }

    [XmlElement(ElementName = "initials")]
    public string? Initials { get; set; }

    [XmlElement(ElementName = "partnerName")]
    public string? PartnerName { get; set; }

    [XmlElement(ElementName = "birthName")]
    public string? BirthName { get; set; }

    [XmlElement(ElementName = "birthDate")]
    public string? BirthDate { get; set; }

    [XmlElement(ElementName = "gender")]
    public string? Gender { get; set; }

    [XmlElement(ElementName = "displayName")]
    public string? DisplayName { get; set; }

    [XmlElement(ElementName = "firstName")]
    public string? FirstName { get; set; }

    [XmlElement(ElementName = "lastName")]
    public string? LastName { get; set; }

    [XmlElement(ElementName = "callName")]
    public string? CallName { get; set; }

    [XmlElement(ElementName = "salutation")]
    public string? Salutation { get; set; }
}