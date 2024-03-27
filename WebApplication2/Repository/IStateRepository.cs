using EmployeeManagement.Entities;

namespace EmployeeManagement.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetState(int Id);
    }
}
