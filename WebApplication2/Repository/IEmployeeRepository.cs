using EmployeeManagement.Entities;
using EmployeeManagement.ViewModels;
using static EmployeeManagement.Repository.EmployeeRepository;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(EmployeeVM employee);
        Task UpdateAsync(EmployeeVM employee);
        Task DeleteAsync(int id);
    }
}
