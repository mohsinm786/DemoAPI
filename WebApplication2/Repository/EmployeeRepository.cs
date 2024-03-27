using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using EmployeeManagement.ViewModels;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeRepository(DataContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddAsync(EmployeeVM employee)
        {
            if (employee.Photo == null || employee.Photo.Length <= 0)
                throw new ArgumentException("Photo cannot be null or empty.");
            var uniqueFileName = $"{Guid.NewGuid()}_{employee.Photo.FileName}";
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await employee.Photo.CopyToAsync(fileStream);
            }            
            var newEmployee = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                State = employee.State,
                MaritalStatus = employee.MaritalStatus,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                City = employee.City,
                Country = employee.Country,
                Created = employee.Created,
                Email = employee.Email,
                Gender = employee.Gender,
                Hobbies = employee.Hobbies,
                Password = employee.Password,
                ZipCode = employee.ZipCode,
                Photo = uniqueFileName,
            };
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeVM updatedEmployee)
        {
            if (updatedEmployee.Photo == null || updatedEmployee.Photo.Length <= 0)
                throw new ArgumentException("Photo cannot be null or empty.");
            var uniqueFileName = $"{Guid.NewGuid()}_{updatedEmployee.Photo.FileName}";
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await updatedEmployee.Photo.CopyToAsync(fileStream);
            }

            var currentEmployee = await _context.Employees.FirstOrDefaultAsync();
            if (currentEmployee != null)
            {
                currentEmployee.State = updatedEmployee.State;
                currentEmployee.Created = updatedEmployee.Created;
                currentEmployee.Email = updatedEmployee.Email;
                currentEmployee.Gender = updatedEmployee.Gender;
                currentEmployee.Address = updatedEmployee.Address;
                currentEmployee.BirthDate = updatedEmployee.BirthDate;
                currentEmployee.FirstName = updatedEmployee.FirstName;
                currentEmployee.LastName = updatedEmployee.LastName;
                currentEmployee.Salary = updatedEmployee.Salary;
                currentEmployee.MaritalStatus = updatedEmployee.MaritalStatus;
                currentEmployee.City = updatedEmployee.City;
                currentEmployee.Country = updatedEmployee.Country;
                currentEmployee.Hobbies = updatedEmployee.Hobbies;
                currentEmployee.Password = updatedEmployee.Password;
                currentEmployee.ZipCode = updatedEmployee.ZipCode;
                currentEmployee.Photo = uniqueFileName;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public Task AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
