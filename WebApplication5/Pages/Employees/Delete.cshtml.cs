using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees
{
    public class DeleteModel : PageModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DeleteModel(IEmployeeRepository employeeRepository) => EmployeeRepository = employeeRepository;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public IEmployeeRepository EmployeeRepository { get; }

        [BindProperty]
        public Employee? Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = EmployeeRepository.GetEmployee(id);
            if (Employee == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Employee? deletedEmployee = EmployeeRepository.DeleteEmployee(Employee!.Id);
            if (deletedEmployee == null)
            {
                return RedirectToPage("NotFound");
            }
            return RedirectToPage("Index");
        }
    }
}
