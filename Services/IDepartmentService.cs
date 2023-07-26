using API.Models;

namespace API.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentListAsync();
        Task<Department> GetDepartmentById(int id);
        Task<bool> AddDepartment(Department department);
        Task<bool> UpdateDepartment(int id, Department department);
        Task<bool> DeleteDepartment(int id);
    }
}
