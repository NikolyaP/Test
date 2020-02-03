using System.Runtime.CompilerServices;
using AutomationServiceTest.Steps;
using AutomationService.Infrastructure.Models;
using NUnit.Framework;

namespace AutomationServiceTest.Tests
{
    [TestFixture]
    public class FinalTryServiceFeature
    {
        private FinalTrySteps _finalTrySteps = new FinalTrySteps();

        [Test]
        public void Case1_GetAllEmployeesReturnsAListOfEmployees()
        {
            _finalTrySteps.WhenIGetEmployees();
            _finalTrySteps.ThenEmployeesListIsNotEmpty();
        }

        [Test]
        public void Case2_GetByEmployeeIdReturnsCorrectEmployee()
        {
            var employerIdToTest = 1;                                     //Here and everywhere else, I know that this is wrong and                                                      
            var expected = new Employee()                                 // I should create test data for each test case before execution                              
            {                                                             // But my server refuses to update the file
                Id = 1,
                Position = "Senior",
                Name = "Jacob",
                Salary = 2500,
                Experience = 3.5,
                Specialization = "QA"
            };
            _finalTrySteps.WhenIGetEmployeeById(1);
            _finalTrySteps.ThenEmployeeDataIsCorrect(expected);
        }

        [Test]
        public void Case3_GetEmployeesBySpecializationReturnsAListOfEmployees()
        {
            var specialization = "QA";
            _finalTrySteps.WhenIGetEmployeesBySpecialization(specialization);
            _finalTrySteps.ThenResponseContainsOnlyEmployeesWithFollowingSpecialization(specialization);
        }


        [Test]
        public void Case4_PostEmployeeStoresAnEmployeeInXmlFile()
        {
            var employee = new Employee().GenerateBaseEmployee();
            _finalTrySteps.WhenIAddNewEmployee(employee);
            _finalTrySteps.TheEmployeeIsPresentInTheListWithCorrectData();
        }

        [Test]
        public void Case5_UpdateEmployeeUpdatesEmployeeInXmlFile()
        {
            const int employeeToUpdate = 1;                            
            var employee = new Employee().GenerateBaseEmployee();
            employee.Id = employeeToUpdate;
            _finalTrySteps.WhenIUpdateEmployee(employee);
            _finalTrySteps.TheEmployeeIsPresentInTheListWithCorrectData();
        }
    }
}
