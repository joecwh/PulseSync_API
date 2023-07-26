using API.Data;
using API.Models;
using API.Resources;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _dataContext;
        public EmployeeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddEmployee(EmployeeRequest request)
        {
            try
            {
                if(request != null)
                {
                    Employee employee = new Employee();
                    employee.Name = request.Name;
                    employee.Age = request.Age;
                    await _dataContext.AddAsync(employee);

                    Department department = new Department
                    {
                        empId = employee.Id,
                        Designation = request.Designation
                    };
                    await _dataContext.AddAsync(department);

                    await _dataContext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = await GetEmployeeById(id);
                if (employee != null)
                {
                    _dataContext.Remove(employee);
                    await _dataContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                return await _dataContext.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                return await _dataContext.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeRequest employee)
        {
            try
            {
                var employeeExist = await GetEmployeeById(id);
                if (employeeExist != null)
                {
                    employeeExist.Name = employee.Name;
                    employeeExist.Age = employee.Age;
                    await _dataContext.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
