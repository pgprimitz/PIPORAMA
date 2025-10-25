using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employees = await _service.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            try
            {
                await _service.AddEmployee(employee);
                return Ok("Empleado creado correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            try
            {
                await _service.UpdateEmployee(employee);
                return Ok("Empleado actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                await _service.DeleteEmployee(id);
                return Ok("Empleado eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
