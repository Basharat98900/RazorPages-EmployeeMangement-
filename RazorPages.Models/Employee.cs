using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;


        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
