using EmployeeManagement.Entities;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<List<City>> GetCity(int Id)
        {
            return await _cityRepository.GetCity(Id);
        }
    }
}
