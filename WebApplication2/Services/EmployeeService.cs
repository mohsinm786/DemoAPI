using EmployeeManagement.Entities;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModels;
using static EmployeeManagement.Repository.EmployeeRepository;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
                return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
                return await _employeeRepository.GetAllAsync();
        }

        public async Task AddEmployeeAsync(EmployeeVM employee)
        {
                await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(EmployeeVM employee)
        {
                await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
                await _employeeRepository.DeleteAsync(id);
        }
    }
}
