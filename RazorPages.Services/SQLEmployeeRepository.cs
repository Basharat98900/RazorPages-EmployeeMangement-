using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Services
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        public SQLEmployeeRepository(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; }

        public Employee AddEmployee(Employee employee)
        {
            Context.Database.ExecuteSqlRaw("spInsertEmployee {0},{1},{2},{3}", employee.Name, employee.Email, employee.Department!, employee.PhotoPath!);
            //Context.Employees!.Add(employee);
            //Context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = Context.Employees!.Find(id);
            if (emp != null)
            {
                Context.Employees.Remove(emp);
                Context.SaveChanges();
            }
            return emp!;
        }

        public List<Employee> GetAllEmployees()
        {
            return Context.Employees!.ToList();
        }

        public IEnumerable<DeptHeadCount> GetDeptHeadCount(Dept? department)
        {
            IEnumerable<Employee>? query = Context.Employees;
            if (department.HasValue)
            {
                query = query!.Where(x => x.Department == department);
            }
            return query!.GroupBy(x => x.Department).Select(d => new DeptHeadCount()
            {
                Department = d.Key!.Value,
                Count = d.Count()
            });

        }

        public Employee? GetEmployee(int? id)
        {

            return Context.Employees!.FromSqlRaw<Employee>("spGetEmployeeById {0}", id!).ToList().FirstOrDefault();
        }

        public List<int> listOfAllEmployeeId()
        {
            return Context.Employees!.Select(x => x.Id).ToList();
        }

        public IEnumerable<Employee> Search(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                return Context.Employees!;
            }
            else
            {
                return Context.Employees!.Where(x => x.Name.Contains(SearchTerm) || x.Email.Contains(SearchTerm));
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var emp = Context.Employees!.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            return employee;
        }
    }
}
