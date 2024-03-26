using WebApplication2.Entities;
using static WebApplication2.Repository.EmployeeRepository;

namespace WebApplication2.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeWithImageInput employee);
        Task UpdateEmployeeAsync(EmployeeWithImageInput employee);
        Task DeleteEmployeeAsync(int id);
    }
}
