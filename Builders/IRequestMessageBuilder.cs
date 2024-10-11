using Domain.Models.RequestMessage;

namespace RoboToolkit.Builders
{
    public interface IRequestMessageBuilder
    {
        RequestMessageBuilder AddEnvelope(string targetSystemId);
        RequestMessageBuilder AddEmployeeData();
        RequestMessageBuilder AddEmployeeData(string initials, string lastName, string firstName, string email);
        RequestMessageBuilder AddEmployeeId(string accountName, string employeeNumber, string? accountPW = null);
        RequestMessageBuilder AddMessagePropertyData(string action, string targetSystemID);
        RequestMessageBuilder AddPrivilegeData(string? privelegeName = null);
        RequestEnvelope Build();
    }
}