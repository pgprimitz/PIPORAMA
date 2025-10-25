using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmployees();
        Task<Empleado?> GetEmployeeById(int id);
        Task AddEmployee(Empleado employee);
        Task UpdateEmployee(Empleado employee);
        Task DeleteEmployee(int id);
    }
}
