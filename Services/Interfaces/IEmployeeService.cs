using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO?> GetEmployeeById(int id);
        Task AddEmployee(EmployeeDTO employee);
        Task UpdateEmployee(EmployeeDTO employee);
        Task DeleteEmployee(int id);
    }
}
