using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddAsync(EmployeeWithImageInput employee)
        {
            byte[] imageData = null;
            if (employee.Photo != null && employee.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await employee.Photo.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
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
                Photo = imageData,

            };
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeWithImageInput updatedEmployee)
        {
            byte[] imageData = null;
            if (updatedEmployee.Photo != null && updatedEmployee.Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await updatedEmployee.Photo.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
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
                currentEmployee.Photo = imageData;
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

        public class EmployeeWithImageInput
        {
            [Key]
            public int Id { get; set; }
            [Required, StringLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
            public string? FirstName { get; set; }
            [Required, StringLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
            public string? LastName { get; set; }
            [Required,StringLength(50, ErrorMessage = "Email must not exceed 50 characters."), EmailAddress(ErrorMessage = "Invalid email address format")]
            public string? Email { get; set; }
            [StringLength(1, ErrorMessage = "Enter M/F")]
            public string? Gender { get; set; }
            public bool MaritalStatus { get; set; }
            public DateOnly BirthDate { get; set; }
            [StringLength(100, ErrorMessage = "Should not cross 100 characters")]
            public string? Hobbies { get; set; }
            [Range(5000, double.MaxValue, ErrorMessage = "The value must be greater than 5000.")]
            public decimal? Salary { get; set; }
            [StringLength(500)]
            public string? Address { get; set; }
            public int Country { get; set; }
            public int State { get; set; }
            public int City { get; set; }
            [RegularExpression(@"^\d{6}$", ErrorMessage = "The property must be a 6-digit number.")]
            public string? ZipCode { get; set; }
            [Required,RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$", ErrorMessage = "Password must be 8-16 characters long and contain at least one uppercase letter, one number, and one special character.")]
            public string? Password { get; set; }
            public DateTime Created { get; set; }

            public IFormFile Photo { get; set; } // Property to accept image input
        }

    }
}
