using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly PIPORAMAContext _context;
        public ClientRepository(PIPORAMAContext context)
        {
            _context = context;
        }
        public async Task<Cliente> AddClientAsync(Cliente client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            await _context.Clientes.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;

        }
        public async Task<bool> DeleteClientAsync(int clientId)
        {
            var client = _context.Clientes.Find(clientId);
            if (client != null)
            {
                _context.Clientes.Remove(client);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            var lst = await _context.Clientes
                .Include(b => b.IdBarrioNavigation)
                .Include(tp => tp.IdTipoClienteNavigation)
                .Include(ct => ct.IdContactoNavigation)
                .ToListAsync();
            if (lst != null && lst.Count > 0)
            {
                return lst;
            }
            return null;
        }

        public async Task<Cliente?> GetClientByIdAsync(int id)
        {
            var client = await _context.Clientes.Include(c => c.IdBarrioNavigation).Include(c => c.IdTipoClienteNavigation)
                .Include(c => c.IdContactoNavigation).FirstOrDefaultAsync(c => c.IdCliente == id);
            if (client != null)
            {
                return client;
            }
            return null;

        }

        public async Task<Cliente> UpdateClientAsync(Cliente client)
        {
            var clientToUpdate = _context.Clientes.Find(client.IdCliente);
            if (clientToUpdate == null) return null;
            clientToUpdate.NomCliente = client.NomCliente;
            clientToUpdate.ApeCliente = client.ApeCliente;
            clientToUpdate.IdBarrio = client.IdBarrio;
            clientToUpdate.IdContacto = client.IdContacto;
            clientToUpdate.IdTipoCliente = client.IdTipoCliente;
            await _context.SaveChangesAsync();
            return clientToUpdate;

        }
    }
}
