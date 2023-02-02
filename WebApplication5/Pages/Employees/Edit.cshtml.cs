using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository employee;
        private readonly IWebHostEnvironment webHostEnvironment;


        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            employee = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;

        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                emp = employee.GetEmployee(id.Value) ?? new Employee();
            }
            else
            {
                emp = new Employee();
            }
            if (emp == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }
        [BindProperty]
        public IFormFile? Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string? Message { get; set; }

        public Employee emp { get; private set; } = new Employee();

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }
            TempData["Message"] = Message;
            return RedirectToPage("Details", new { id = id, check = Notify });
        }

        public IActionResult OnPost(Employee emp)
        {
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    if (emp.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", emp.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    emp.PhotoPath = ProcessUploadedFile();
                }

                if (emp.Id > 0)
                {
                    Employee emps = this.employee.UpdateEmployee(emp);
                }
                else
                {
                    Employee emps = this.employee.AddEmployee(emp);
                    Console.WriteLine(":not  done");
                }
                return RedirectToPage("Index");
            }
            return Page();

        }
        private string ProcessUploadedFile()
        {
            string? uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo!.FileName.ToString();
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName!;
        }
    }
}
