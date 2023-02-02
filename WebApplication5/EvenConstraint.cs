using RazorPages.Services;

namespace RazorPages
{
    public class EvenConstraint : IRouteConstraint
    {
        public EvenConstraint(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public IEmployeeRepository EmployeeRepository { get; }

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool flag = false;
            int id;
            foreach (var item in EmployeeRepository.listOfAllEmployeeId())
            {
                if (int.TryParse(values["id"]?.ToString(), out id))
                {
                    if (Convert.ToInt32(item) == Convert.ToInt32(values["id"]))
                    {
                        return flag = true;
                    }
                }

            }
            return flag;
        }
    }
}
