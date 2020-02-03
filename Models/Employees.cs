using System.Collections.Generic;
using System.Xml.Serialization;

namespace WCFApp.Models
{
    [XmlRoot("EmployeeList")]
    public class Employees: IHttpModel
    {
        [XmlElement("Employee")]
        public List<Employee> Employes { get; set; }
    }

    public class Employee
    {
        [XmlElement("Id")]
        public int? Id { get; set; }

        [XmlElement("Specialization")]
        public string Specialization { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Salary")]
        public int? Salary { get; set; }

        [XmlElement("Experience")]
        public int? Experience { get; set; }
    }
}