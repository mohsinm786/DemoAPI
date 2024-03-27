using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}
