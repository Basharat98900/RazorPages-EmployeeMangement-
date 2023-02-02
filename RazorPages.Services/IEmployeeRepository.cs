using RazorPages.Models;

namespace RazorPages.Services
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        Employee? GetEmployee(int? id);
        List<int> listOfAllEmployeeId();
        Employee UpdateEmployee(Employee employee);
        Employee AddEmployee(Employee employee);
        Employee DeleteEmployee(int id);
        IEnumerable<DeptHeadCount> GetDeptHeadCount(Dept? department);
        IEnumerable<Employee> Search(string SearchTerm);
    }
}