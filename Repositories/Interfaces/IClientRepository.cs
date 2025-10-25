using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente?> GetClientByIdAsync(int id);
        Task<Cliente> AddClientAsync(Cliente client);
        Task<Cliente> UpdateClientAsync(Cliente client);
        Task<bool> DeleteClientAsync(int clientId);
    }
}
