using API.Data;
using API.Models;
using API.Resources;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public UserService(DataContext dataContext, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _dataContext = dataContext;
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public List<FruitVegesOutput> GetFruitVeges()
        {
            try
            {
                string filepath = "C:\\Users\\Lenovo\\Desktop\\Project\\fruitnveges.txt";
                FileStream fileStream = new FileStream(filepath, FileMode.Open);

                List<FruitVegesOutput> items = new List<FruitVegesOutput>();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Assuming the format is "{id} {name} {category}"
                        string[] parts = line.Split(' ');
                        if (parts.Length == 3 && int.TryParse(parts[0], out int id))
                        {
                            items.Add(new FruitVegesOutput
                            {
                                Id = id,
                                Name = parts[1],
                                Category = parts[2]
                            });
                        }
                    }
                }

                return items; // Return the list directly
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null; // Return null or an empty list in case of an error
        }


        public async Task<List<ExpectedOutput>> GetExpectedOutput()
        {
            try
            {
                var employees = await _dataContext.Employees.ToListAsync();
                if(employees.Any())
                {
                    List<ExpectedOutput> outputList = new List<ExpectedOutput>();
                    foreach(var employee in employees)
                    {
                        Department department = await _departmentService.GetDepartmentById(employee.Id);
                        ExpectedOutput o = new ExpectedOutput();
                        o.EmployeeName = employee.Name;
                        o.Designation = department.Designation;
                        o.Age = employee.Age;

                        outputList.Add(o);
                    }
                    List<ExpectedOutput> outputs = new List<ExpectedOutput>
                    {
                        outputList.OrderByDescending(age => age.Age).FirstOrDefault(),
                        outputList.OrderBy(age => age.Age).FirstOrDefault()

                    };
                    return outputs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
