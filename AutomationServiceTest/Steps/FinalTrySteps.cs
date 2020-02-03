using System.Linq;
using AutomationService.Infrastructure;
using AutomationService.Infrastructure.Models;
using NUnit.Framework;

namespace AutomationServiceTest.Steps
{
    public class FinalTrySteps
    {
        private FinalService _finalTryService = new FinalService();

#region Giveh-When

        public void WhenIGetEmployees()
        {
           Storage.Employees =  _finalTryService.GetAllEmployees();
        }

        public void WhenIGetEmployeeById(int id)
        {
            Storage.Employee = _finalTryService.GetEmployeeById(id);
        }

        public void WhenIGetEmployeesBySpecialization(string specialization)
        {
            Storage.Employees = _finalTryService.GetEmployeeBySpecialization(specialization);
        }

        public void WhenIAddNewEmployee(Employee employee)
        {
            _finalTryService.AddEmployee(employee);
            Storage.Employee = employee;
        }

        public void WhenIUpdateEmployee(Employee employee)
        {
            _finalTryService.UpdateEmployee(employee);
            Storage.Employee = employee;
        }

        #endregion

        public void ThenEmployeesListIsNotEmpty()
        {
            var employees = Storage.Employees;
            Assert.That(employees.Employes.Count > 0, "Employees list is empty");
        }

        public void ThenEmployeeDataIsCorrect(Employee expected)
        {
            var actual = Storage.Employee;
            Assert.That(actual.Equals(expected), "Employee data is incorrect");
        }

        public void ThenResponseContainsOnlyEmployeesWithFollowingSpecialization(string specialization)
        {
            var employees = Storage.Employees;
            Assert.That(employees.Employes.All(e => e.Specialization.Equals(specialization)),
                "Employees list contains employees with wrong specialization or is empty ");
        }

        public void TheEmployeeIsPresentInTheListWithCorrectData()
        {
           var actual = _finalTryService.GetEmployeeById((int)Storage.Employee.Id);
           Assert.That(Storage.Employee.Equals(actual), "Employee data is incorrect");

        }
    }
}
