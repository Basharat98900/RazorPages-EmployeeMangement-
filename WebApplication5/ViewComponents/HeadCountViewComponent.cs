using Microsoft.AspNetCore.Mvc;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public IEmployeeRepository EmployeeRepository { get; }

        public IViewComponentResult Invoke(Dept? dept = null)
        {
            var result = EmployeeRepository.GetDeptHeadCount(dept);
            return View(result);
        }
    }
}
