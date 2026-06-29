using CrediAuto.API.Clients.Domain.Model.Commands;

namespace CrediAuto.API.Clients.Domain.Model.Aggregates;

public partial class Client : ClientAudit
{
    public int Id { get; }
    public string Nombre { get; private set; }
    public string Dni { get; private set; }
    public string Email { get; private set; }
    public string Telefono { get; private set; }
    public int UserId { get; private set; }

    protected Client()
    {
        Nombre = string.Empty;
        Dni = string.Empty;
        Email = string.Empty;
        Telefono = string.Empty;
        UserId = 0;
    }

    public Client(CreateClientCommand command)
    {
        Nombre = command.Nombre;
        Dni = command.Dni;
        Email = command.Email;
        Telefono = command.Telefono;
        UserId = command.UserId;
    }
    
    public void UpdateContactInfo(string nombre, string email, string telefono)
    {
        Nombre = nombre;
        Email = email;
        Telefono = telefono;
    }
}