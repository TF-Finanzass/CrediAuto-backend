using System.Threading.Tasks;

namespace CrediAuto.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}