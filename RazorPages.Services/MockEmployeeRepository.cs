using RazorPages.Models;

namespace RazorPages.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                 new Employee() { Id = 1, Name = "Mary", Department = Dept.HR,
                    Email = "mary@pragimtech.com", PhotoPath="mary.jpg" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT,
                    Email = "john@pragimtech.com", PhotoPath="jhon.jpg" },
                new Employee() { Id = 3, Name = "Sara", Department = Dept.IT,
                    Email = "sara@pragimtech.com", PhotoPath="sara.jpg" },
                new Employee() { Id = 4, Name = "David", Department = Dept.Payroll,
                    Email = "david@pragimtech.com" },
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = employees.Max(x => x.Id) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Employee employee = employees.FirstOrDefault(x => x.Id == id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return employee!;
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public IEnumerable<DeptHeadCount> GetDeptHeadCount(Dept? department)
        {

            IEnumerable<Employee> query = employees;
            if (department.HasValue)
            {
                query = query.Where(e => e.Department == department.Value);
            }
            return query.GroupBy(x => x.Department).Select(y => new DeptHeadCount()
            {
                Department = y.Key!.Value,
                Count = y.Count()
            });
        }

        public Employee? GetEmployee(int? id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        public List<int> listOfAllEmployeeId()
        {
            return employees.Select(x => x.Id).ToList();
        }

        public IEnumerable<Employee> Search(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return employees;
            }
            else
            {
                return employees.Where(x => x.Name.Contains(SearchTerm) || x.Email.Contains(SearchTerm));
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee? emp = employees.FirstOrDefault(x => x.Id == employee.Id);
            emp!.Name = employee.Name;
            emp.Department = employee.Department;
            emp.Email = employee.Email;
            emp.PhotoPath = employee.PhotoPath;
            return emp;

        }

    }
}
