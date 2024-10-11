using RoboToolkit.Domain.Models;

namespace RoboToolkit.Services;
public interface IRequestMessageService
{
    string TargetSystemId { get; set; }
    TestUser TestUser { get; set; }
    string AddMessage();
    string AddPrivilegeMessage(string privilege);
    string BlockMessage();
    string DeleteMessage();
    string DeletePrivilegeMessage(string privilege);
    string ModifyMessage();
    string UnblockMessage();
}