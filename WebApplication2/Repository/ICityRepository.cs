using EmployeeManagement.Entities;

namespace EmployeeManagement.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetCity(int Id);
    }
}
