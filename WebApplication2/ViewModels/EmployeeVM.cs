using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeVM
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
        public string? FirstName { get; set; }
        [Required, StringLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
        public string? LastName { get; set; }
        [Required, StringLength(50, ErrorMessage = "Email must not exceed 50 characters."), EmailAddress(ErrorMessage = "Invalid email address format")]
        public string? Email { get; set; }
        [StringLength(1, ErrorMessage = "Enter M/F")]
        public string? Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
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
        [Required, RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,16}$", ErrorMessage = "Password must be 8-16 characters long and contain at least one uppercase letter, one number, and one special character.")]
        public string? Password { get; set; }
        public DateTime Created { get; set; }

        public IFormFile Photo { get; set; } // Property to accept image input
    }
}
