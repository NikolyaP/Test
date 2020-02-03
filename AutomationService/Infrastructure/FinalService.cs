using System.Collections.Generic;
using Employee = AutomationService.Infrastructure.Models.Employee;
using Employees = AutomationService.Infrastructure.Models.Employees;

namespace AutomationService.Infrastructure
{
    public class FinalService
    {
         private FinalActions _actions = new FinalActions();

         public Employees GetAllEmployees()
         {
             var response = _actions.GetAllEmployees();
             return response.Content<Employees>();
         }

         public Employee GetEmployeeById(int id)
         {
             var response = _actions.GetEmployeeById(id);
             return response.Content<Employee>();
         }

         public Employees GetEmployeeBySpecialization(string specialization)
         {
             var response = _actions.GetEmployeesBySpecialization(specialization);
             return response.Content<Employees>();
         }

         public void AddEmployee(Employee employee)
         {
             _actions.PostEmployee(employee).EnsureSuccessful();
         }

         public void UpdateEmployee(Employee employee)
         {
             _actions.PutEmployee(employee).EnsureSuccessful();
         }
    }
}
