using System.Collections.Generic;
using Employee = AutomationService.Infrastructure.Models.Employee;
using Employees = AutomationService.Infrastructure.Models.Employees;

namespace AutomationService.Infrastructure
{
    public static class Storage
    {
        public static Employees Employees { get; set; }
        public static Employee Employee { get; set; }
        public static List<Employee> CurrentEmployeeList { get; set; }
    }
}
