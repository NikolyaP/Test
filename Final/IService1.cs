using System.ServiceModel;
using System.ServiceModel.Web;
using Final.Models;

namespace Final
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [ WebInvoke(Method = "GET", UriTemplate = "/employees",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        Employees GetAllEmployees();

        [OperationContract]
        [ WebInvoke(Method = "GET", UriTemplate = "/employees/id/{empId}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        Employee GetEmployee(string empId);

        [OperationContract]
        [ WebInvoke(Method = "GET", UriTemplate = "/employees/specialization/{specialization}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        Employees GetEmployeesBySpecialization(string specialization);

        [OperationContract]
        [ WebInvoke(Method = "POST", UriTemplate = "/employees/addEmployee",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        void PutEmployee(Employee employee);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/employees/updateEmployee",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        void AddEmployee(Employee employee);
    }
}
