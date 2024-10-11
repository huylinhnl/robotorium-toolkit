using Domain.Enums;
using RoboToolkit.Builders;
using RoboToolkit.Domain.Models;
using RoboToolkit.Extentions;

namespace RoboToolkit.Services;

public class RequestMessageService(IRequestMessageBuilder requestMessageBuilder) : IRequestMessageService
{
    private readonly IRequestMessageBuilder _requestMessageBuilder = requestMessageBuilder;

    public string TargetSystemId { get; set; } = string.Empty;
    public TestUser TestUser { get; set; } = new();

    public void SetTestData(string targetSystemId, TestUser testData)
    {
        targetSystemId = targetSystemId;
        testData = testData;
    }

    public string AddMessage() => BuildMessage(IdmAction.add);
    public string DeleteMessage() => BuildMessage(IdmAction.delete);
    public string BlockMessage() => BuildMessage(IdmAction.block);
    public string UnblockMessage() => BuildMessage(IdmAction.unblock);
    public string ModifyMessage() => BuildMessage(IdmAction.modify);
    public string AddPrivilegeMessage(string privilege) => BuildMessage(IdmAction.addPrivilege, privilege);
    public string DeletePrivilegeMessage(string privilege) => BuildMessage(IdmAction.deletePrivilege, privilege);

    private string BuildMessage(IdmAction action, string? privilegeName = null)
    {
        _requestMessageBuilder.AddEnvelope(TargetSystemId);

        if (action == IdmAction.add)
        {
            _requestMessageBuilder.AddEmployeeData(
                initials: TestUser.Initials,
                lastName: TestUser.LastName,
                firstName: TestUser.FirstName,
                email: TestUser.Email);
        }
        else
        {
            _requestMessageBuilder.AddEmployeeData();
        }

        _requestMessageBuilder
           .AddEmployeeId(
               accountName: TestUser.AccountName,
               employeeNumber: TestUser.EmployeeNumber,
               accountPW: action == IdmAction.add ? TestUser.AccountPW.Encrypt("P@ssW0rd!") : null)
           .AddMessagePropertyData(
               action: action.ToString(),
               targetSystemID: TargetSystemId)
           .AddPrivilegeData(
               privelegeName: privilegeName);

        return _requestMessageBuilder.Build().ToXmlStringContent();
    }
}