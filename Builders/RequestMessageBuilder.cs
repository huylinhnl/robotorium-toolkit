using Domain.Models.RequestMessage;

namespace RoboToolkit.Builders;

public class RequestMessageBuilder : IRequestMessageBuilder
{
    private RequestEnvelope Envelope { get; set; } = new();

    public RequestMessageBuilder AddEnvelope(string targetSystemId)
    {
        Envelope.Header = new()
        {
            ChainLogHeader = new()
            {
                ChainId = Guid.NewGuid().ToString(),
                RequestId = Guid.NewGuid().ToString()
            },
            To = targetSystemId,
            MessageID = Guid.NewGuid().ToString(),
            Action = "http://www.achmea.nl/algemeen/SAP/IDM/ProvisioningService/2010/07",
            From = "http://www.achmea.nl/ait/SAP/IDM",
            Signature = "MC0CFQCT3TNMVA1PKTSUA7d5An0skUGgnQIUW8HvfBJ+ZnEol24x1hFLHR2bg0U="
        };

        Envelope.Body = new()
        {
            AchmeaData = new AchmeaData()
        };

        return this;
    }

    public RequestMessageBuilder AddEmployeeData(string initials, string lastName, string firstName, string email)
    {
        Envelope.Body.AchmeaData.EmployeeData = new()
        {
            FunctionData = new()
            {
                FunctionName = "SPECIALIST"
            },
            ManagerData = new()
            {
                EmployeeNumber = "999999"
            },
            ContactData = new()
            {
                Additional = new()
                {
                    Email = ""
                },
                Location = new()
                {
                    WorkLocation = "APELDOORN, Laan van Malkenschoten 20",
                    HouseNr = "20",
                    City = "APELDOORN",
                    Street = "Laan van Malkenschoten"
                },
                Mobile = "",
                Primary = new()
                {
                    Phone = "",
                    Email = email
                },
            },
            ContractData = new()
            {
                Enddate = "9999-12-31",
                ContractType = "Onbepaalde tijd",
                Hiredate = "2020-06-01"
            },
            OrganisationData = new()
            {
                Costcenter = "0",
                Ou = "Test OU voor GPS aansluiting",
                OuCode = "0",
                Department = "Test OU voor GPS aansluiting",
                Company = "Test OU voor GPS aansluiting",
                DepartmentCode = "0",
                Abu = "AchmeaIT",
                CompanyCode = "0",
                AbuCode = "ABU-NLD0"
            },
            PersonalData = new()
            {
                NamePrefix = "",
                Initials = initials,
                PartnerName = "",
                BirthName = firstName,
                BirthDate = "1900-01-01",
                DisplayName = $"{initials}. {lastName}",
                FirstName = firstName,
                LastName = lastName,
                CallName = firstName
            }
        };
        return this;
    }

    public RequestMessageBuilder AddEmployeeData()
    {
        Envelope.Body.AchmeaData.EmployeeData = new()
        {
            FunctionData = new(),
            ManagerData = new(),
            ContactData = new()
            {
                Additional = new()
                {
                    Email = ""
                },
                Location = new()
                {
                    WorkLocation = ""
                },
                Mobile = "",
                Primary = new()
                {
                    Phone = "",
                    Email = ""
                }
            },
            ContractData = new()
            {
                ContractType = ""
            },
            OrganisationData = new(),
            PersonalData = new()
            {
                NamePrefix = "",
                PartnerName = ""
            },
        };
        return this;
    }

    public RequestMessageBuilder AddEmployeeId(string accountName, string employeeNumber, string? accountPW = null)
    {
        Envelope.Body.AchmeaData.EmployeeID = new()
        {
            UID = $"100.{employeeNumber}",
            AccountName = accountName,
            AccountPW = accountPW!,
            EmployeeNumber = employeeNumber
        };
        return this;
    }

    public RequestMessageBuilder AddMessagePropertyData(string action, string targetSystemID)
    {
        Envelope.Body.AchmeaData.MessagePropertyData = new()
        {
            Action = action,
            TargetSystemID = targetSystemID
        };
        return this;
    }

    public RequestMessageBuilder AddPrivilegeData(string? privelegeName = null)
    {
        Envelope.Body.AchmeaData.PrivilegeData = new PrivilegeData()
        {
            PrivelegeName = privelegeName!
        };
        return this;
    }

    public RequestEnvelope Build() => Envelope;

}
