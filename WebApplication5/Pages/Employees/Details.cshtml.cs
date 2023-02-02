using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        [TempData]
        public string? Message { get; set; }
        public Employee? employee { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool check { get; set; }
        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IActionResult OnGet(int Id)
        {
            employee = employeeRepository.GetEmployee(Id);
            if (employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
    }
}
