using WebApplication2.Entities;
using WebApplication2.Repository;
using static WebApplication2.Repository.EmployeeRepository;

namespace WebApplication2.Services
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
            try
            {
                return await _employeeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the employee by ID.", ex);
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching all employees.", ex);
            }
        }

        public async Task AddEmployeeAsync(EmployeeWithImageInput employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the employee.", ex);
            }
        }

        public async Task UpdateEmployeeAsync(EmployeeWithImageInput employee)
        {
            try
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the employee.", ex);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                await _employeeRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the employee.", ex);
            }
        }
    }
}
