using System.ComponentModel.DataAnnotations;

namespace samplemodels.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
    }
}
