using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var newEmployee = new Empleado
                {
                    IdEmpleado = employee.IdEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    IdBarrio = employee.IdBarrio,
                    IdContacto = employee.IdContacto
                };
                await _repository.AddEmployee(newEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el empleado", ex);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                await _repository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el empleado", ex);
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var employees = await _repository.GetAllEmployees();
                return employees.Select(e => new EmployeeDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    NomEmpleado = e.NomEmpleado,
                    ApeEmpleado = e.ApeEmpleado,
                    IdBarrio = e.IdBarrio,
                    IdContacto = e.IdContacto,
                    Barrio = e.IdBarrioNavigation is not null
                        ? new NeighborhoodDTO
                        {
                            IdBarrio = e.IdBarrioNavigation.IdBarrio,
                            Descripcion = e.IdBarrioNavigation.Descripcion
                        }
                        : null!,
                    Contacto = e.IdContactoNavigation is not null
                        ? new ContactDTO
                        {
                            IdContacto = e.IdContactoNavigation.IdContacto,
                            Descripcion = e.IdContactoNavigation.Descripcion,
                            IdTipoContacto = e.IdContactoNavigation.IdTipoContacto
                        }
                        : null!
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los empleados", ex);
            }
        }

        public async Task<EmployeeDTO?> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _repository.GetEmployeeById(id);
                if (employee == null) return null;
                return new EmployeeDTO
                {
                    IdEmpleado = employee.IdEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    IdBarrio = employee.IdBarrio,
                    IdContacto = employee.IdContacto,
                    Barrio = employee.IdBarrioNavigation is not null
                        ? new NeighborhoodDTO
                        {
                            IdBarrio = employee.IdBarrioNavigation.IdBarrio,
                            Descripcion = employee.IdBarrioNavigation.Descripcion
                        }
                        : null!,
                    Contacto = employee.IdContactoNavigation is not null
                        ? new ContactDTO
                        {
                            IdContacto = employee.IdContactoNavigation.IdContacto,
                            Descripcion = employee.IdContactoNavigation.Descripcion,
                            IdTipoContacto = employee.IdContactoNavigation.IdTipoContacto
                        }
                        : null!
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el empleado", ex);
            }
        }

        public async Task UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var updatedEmployee = new Empleado
                {
                    IdEmpleado = employee.IdEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    IdBarrio = employee.IdBarrio,
                    IdContacto = employee.IdContacto
                };
                await _repository.UpdateEmployee(updatedEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el empleado", ex);
            }
        }
    }
}
