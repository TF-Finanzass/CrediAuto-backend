using CrediAuto.API.Clients.Domain.Model.Commands;
using CrediAuto.API.Clients.Domain.Model.ValueObjects;

namespace CrediAuto.API.Clients.Domain.Model.Aggregates;

public partial class Client : ClientAudit
{
    public int Id { get; }
    public string FullName { get; private set; }
    public string LastName { get; private set; }
    public string DocumentNumber { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public decimal MonthlyIncome { get; private set; }
    public int UserId { get; private set; }
    public ClientStatus Status { get; private set; }

    protected Client()
    {
        FullName = string.Empty;
        LastName = string.Empty;
        DocumentNumber = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        MonthlyIncome = 0;
        UserId = 0;
        Status = ClientStatus.Aprobado;
    }

    public Client(CreateClientCommand command)
    {
        FullName = command.FullName;
        LastName = command.LastName;
        DocumentNumber = command.DocumentNumber;
        Email = command.Email;
        Phone = command.Phone;
        MonthlyIncome = command.MonthlyIncome;
        UserId = command.UserId;
        Status = command.Status;
    }
    
    public void UpdateContactInfo(string fullName, string lastName, string documentNumber, string email, string phone, decimal monthlyIncome, ClientStatus status)
    {
        FullName = fullName;
        LastName = lastName;
        DocumentNumber = documentNumber;
        Email = email;
        Phone = phone;
        MonthlyIncome = monthlyIncome;
        Status = status;
    }

    public void UpdateStatus(ClientStatus status)
    {
        Status = status;
    }
}