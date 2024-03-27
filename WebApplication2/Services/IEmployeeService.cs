using EmployeeManagement.Entities;
using EmployeeManagement.ViewModels;
using static EmployeeManagement.Repository.EmployeeRepository;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeVM employee);
        Task UpdateEmployeeAsync(EmployeeVM employee);
        Task DeleteEmployeeAsync(int id);
    }
}
