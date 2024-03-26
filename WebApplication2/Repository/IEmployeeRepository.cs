using WebApplication2.Entities;
using static WebApplication2.Repository.EmployeeRepository;

namespace WebApplication2.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(EmployeeWithImageInput employee);
        Task UpdateAsync(EmployeeWithImageInput employee);
        Task DeleteAsync(int id);
    }
}
