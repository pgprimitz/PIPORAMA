using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;
        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }
        public async Task<ClientDTO> AddClientAsync(Cliente client)
        {
            var addedClient = await _repo.AddClientAsync(client);
            if (addedClient != null)
            {
                return new ClientDTO
                {
                    Codigo = addedClient.IdCliente,
                    Nombre = addedClient.NomCliente,
                    Apellido = addedClient.ApeCliente,
                    IdTipoCliente = addedClient.IdTipoCliente,
                    IdBarrio = addedClient.IdBarrio,
                    IdContacto = addedClient.IdContacto,
                    Barrio = addedClient.IdBarrioNavigation is not null
                    ? new NeighborhoodDTO
                    {
                        IdBarrio = addedClient.IdBarrioNavigation.IdBarrio,
                        Descripcion = addedClient.IdBarrioNavigation.Descripcion,
                    } : null!,
                    Contacto = addedClient.IdContactoNavigation is not null
                    ? new ContactDTO
                    {
                        IdContacto = addedClient.IdContactoNavigation.IdContacto,
                        Descripcion = addedClient.IdContactoNavigation.Descripcion,
                        IdTipoContacto = addedClient.IdContactoNavigation.IdTipoContactoNavigation.IdTipoContacto
                    } : null!
                };

            }
            return null;

        }

        public async Task<bool> DeleteClientAsync(int clientId)
        {
            return await _repo.DeleteClientAsync(clientId);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await _repo.GetAllClientsAsync();
            var clientDTOs = clients.Select(c => new ClientDTO
            {
                Codigo = c.IdCliente,
                Nombre = c.NomCliente,
                Apellido = c.ApeCliente,
                IdTipoCliente = c.IdTipoCliente,
                IdBarrio = c.IdBarrio,
                IdContacto = c.IdContacto,
                TipoCliente = c.IdTipoClienteNavigation is not null
                    ? new ClientTypeDTO
                    {
                        IdTipoCliente = c.IdTipoClienteNavigation.IdTipoCliente,
                        TipoCliente = c.IdTipoClienteNavigation.TipoCliente,
                    } 
                    : null!,
                Barrio = c.IdBarrioNavigation is not null
                    ? new NeighborhoodDTO
                    {
                        IdBarrio = c.IdBarrioNavigation.IdBarrio,
                        Descripcion = c.IdBarrioNavigation.Descripcion,
                    } 
                    : null!,
                Contacto = c.IdContactoNavigation is not null
                    ? new ContactDTO
                    {
                        IdContacto = c.IdContactoNavigation.IdContacto,
                        Descripcion = c.IdContactoNavigation.Descripcion,
                        IdTipoContacto = c.IdContactoNavigation.IdTipoContacto
                    } 
                    : null!


            }).ToList();
            return clientDTOs;

        }

        public async Task<ClientDTO> GetClientByIdAsync(int clientId)
        {
            var client = await _repo.GetClientByIdAsync(clientId);
            if (client == null) return null;
            return new ClientDTO
            {
                Codigo = client.IdCliente,
                Nombre = client.NomCliente,
                Apellido = client.ApeCliente,
                IdTipoCliente = client.IdTipoCliente,
                IdBarrio = client.IdBarrio,
                IdContacto = client.IdContacto,
                TipoCliente = client.IdTipoClienteNavigation is not null
                ? new ClientTypeDTO
                {
                    IdTipoCliente = client.IdTipoClienteNavigation.IdTipoCliente,
                    TipoCliente = client.IdTipoClienteNavigation.TipoCliente,
                } : null!,
                Barrio = client.IdBarrioNavigation is not null
                ? new NeighborhoodDTO
                {
                    IdBarrio = client.IdBarrioNavigation.IdBarrio,
                    Descripcion = client.IdBarrioNavigation.Descripcion,
                } : null!,
                Contacto = client.IdContactoNavigation is not null
                ? new ContactDTO
                {
                    IdContacto = client.IdContactoNavigation.IdContacto,
                    Descripcion = client.IdContactoNavigation.Descripcion,
                    IdTipoContacto = client.IdContactoNavigation.IdTipoContacto
                } : null!
            };
        }

        public async Task<ClientDTO> UpdateClientAsync(Cliente client)
        {
            var updatedClient = await _repo.UpdateClientAsync(client);
            if (updatedClient != null)
            {
                return new ClientDTO
                {
                    Codigo = updatedClient.IdCliente,
                    Nombre = updatedClient.NomCliente,
                    Apellido = updatedClient.ApeCliente,
                    IdTipoCliente = updatedClient.IdTipoCliente,
                    IdBarrio = updatedClient.IdBarrio,
                    IdContacto = updatedClient.IdContacto,
                    Barrio = updatedClient.IdBarrioNavigation is not null
                    ? new NeighborhoodDTO
                    {
                        IdBarrio = updatedClient.IdBarrioNavigation.IdBarrio,
                        Descripcion = updatedClient.IdBarrioNavigation.Descripcion,
                    } : null!,
                    Contacto = updatedClient.IdContactoNavigation is not null
                    ? new ContactDTO
                    {
                        IdContacto = updatedClient.IdContactoNavigation.IdContacto,
                        Descripcion = updatedClient.IdContactoNavigation.Descripcion,
                        IdTipoContacto = updatedClient.IdContactoNavigation.IdTipoContactoNavigation.IdTipoContacto
                    } : null!
                };
            }
            return null;
        }
    }
}
