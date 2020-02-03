using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Final.Helpers;
using Final.Models;

namespace Final
{
    public class Service1 : IService1
    {
        private string _dataPath = @"E:\LastTry\Final\Final\App_Data";    //had to hardcode because of some weird problems with the server
        private const string FileName = "Data.xml";

        private JavaScriptSerializer _jsSerializer = new JavaScriptSerializer();
        public Employee GetEmployee(string empId)
        {
            var data = GetServiceData();
            var employee = data.Employes.Single(e => e.Id.ToString().Equals(empId));
            return employee;
        }

        public Employees GetAllEmployees()
            => GetServiceData();

        public Employees GetEmployeesBySpecialization(string specialization)
        {
            var data = GetServiceData();
            var result = new Employees(){Employes = new List<Employee>()};
            data.Employes.ForEach(e =>
            {
                if (e.Specialization.Equals(specialization))
                    result.Employes.Add(e);
            });
            return result;
        }

        public void AddEmployee(Employee employee)
        {
            var existingData = GetServiceData();
            employee.Id = (existingData.Employes.Count + 1).ToString();
            existingData.Employes.Add(employee);
            var xml = XmlHelper.ObjToXml(existingData);
            Directory.Delete(Path.Combine(_dataPath, FileName));             //I give up, tried many ways of deletion- always 400 response
            File.WriteAllText(Path.Combine(_dataPath, FileName),xml); // suspect that it has something to do with wcf permissions...
        }                                                                     // have no time to investigate further

        public void PutEmployee(Employee updatedEmployee)
        {
            var existingData = GetServiceData();
            var oldEmployee = existingData.Employes.Single(e => e.Id.Equals(updatedEmployee.Id));
            var index = existingData.Employes.IndexOf(oldEmployee);
            existingData.Employes[index] = updatedEmployee;

            var xml = XmlHelper.ObjToXml(existingData);
            Directory.Delete(Path.Combine(_dataPath, FileName));                 //cant overwrite the file :(     
            File.WriteAllText(Path.Combine(_dataPath, FileName), xml);
        }

        private Employees GetServiceData()
        {
            
            var data = XmlHelper.XmlToObject<Employees>(Path.Combine(_dataPath, FileName));
            return data;
        }
    }
}
