using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
