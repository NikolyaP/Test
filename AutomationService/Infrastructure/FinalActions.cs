using System.Net.Http;
using AutomationService.Builders;
using AutomationService.Helpers;
using AutomationService.Infrastructure.Models;
using Newtonsoft.Json;

namespace AutomationService.Infrastructure
{
    public class FinalActions
    {                                       
        private RequestBuilder request;

        public FinalActions()
        {
            request = new RequestBuilder(Configuration.ServiceUrl);
        }

        public ApiResponse GetAllEmployees()
        {
            var resource = "/employees";
            return request.WithMethod(HttpMethod.Get).WithUri(resource).Execute();
        }

        public ApiResponse GetEmployeeById(int Id)
        {
            var resource = $"/employees/id/{Id}";
            return request.WithMethod(HttpMethod.Get).WithUri(resource).Execute();
        }

        public ApiResponse GetEmployeesBySpecialization(string specialization)
        {
            var resource = $"/employees/specialization/{specialization}";
            return request.WithMethod(HttpMethod.Get).WithUri(resource).Execute();
        }

        public ApiResponse PostEmployee(Employee employee)
        {
            const string resource = "/employees/addEmployee";
            var requestBody = JsonConvert.SerializeObject(employee);
            return request.WithMethod(HttpMethod.Post).WithUri(resource).WithBody(requestBody).Execute();
        }

        public ApiResponse PutEmployee(Employee employee)
        {
            const string resource = "/employees/updateEmployee";
            var requestBody = JsonConvert.SerializeObject(employee);
            return request.WithMethod(HttpMethod.Post).WithUri(resource).WithBody(requestBody).Execute();
        }
    }
}
