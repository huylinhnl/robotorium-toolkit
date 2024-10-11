namespace RoboToolkit.Domain.Models;

public class Application
{
    public string Name { get; set; }
    public string TargetSystemId { get; set; }
    public string BaseURI { get; set; }
    public ICollection<string> Privileges { get; set; }
}
