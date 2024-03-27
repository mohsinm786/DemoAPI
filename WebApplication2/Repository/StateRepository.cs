using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class StateRepository:IStateRepository
    {
        private readonly DataContext _context;
        public StateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetState(int Id)
        {
            var countries = await _context.States
           .Where(s => s.CountryId == Id)
           .ToListAsync();
            return countries;
        }
    }
}
