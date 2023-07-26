using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _dataContext;
        public DepartmentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddDepartment(Department department)
        {
            try
            {
                if (department != null)
                {
                    await _dataContext.AddAsync(department);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                var department = await GetDepartmentById(id);
                if (department != null)
                {
                    _dataContext.Remove(department);
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

        public async Task<Department> GetDepartmentById(int id)
        {
            try
            {
                return await _dataContext.Departments.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<List<Department>> GetDepartmentListAsync()
        {
            try
            {
                return await _dataContext.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> UpdateDepartment(int id, Department department)
        {
            try
            {
                var departmentExist = await GetDepartmentById(id);
                if (departmentExist != null)
                {
                    departmentExist.Designation = department.Designation;
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
