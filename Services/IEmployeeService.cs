using API.Models;
using API.Resources;

namespace API.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<bool> AddEmployee(EmployeeRequest employee);
        Task<bool> UpdateEmployee(int id, EmployeeRequest employee);
        Task<bool> DeleteEmployee(int  id);
    }
}
