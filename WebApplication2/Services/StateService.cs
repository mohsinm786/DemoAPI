using EmployeeManagement.Entities;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class StateService:IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<State>> GetState(int Id)
        {
            return await _stateRepository.GetState(Id);
        }
    }
}
