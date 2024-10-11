using System.Xml.Serialization;

namespace Domain.Models.RequestMessage;

[XmlType(AnonymousType = true)]
public partial class Location
{
    [XmlElement(ElementName = "workLocation")]
    public string? WorkLocation { get; set; }

    [XmlElement(ElementName = "houseNr")]
    public string? HouseNr { get; set; }

    [XmlElement(ElementName = "city")]
    public string? City { get; set; }

    [XmlElement(ElementName = "street")]
    public string? Street { get; set; }
}