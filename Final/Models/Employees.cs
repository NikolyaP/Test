using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Final.Models
{
    [DataContract]
    [XmlRoot("EmployeeList")]
    public class Employees
    {
        [DataMember]
        [XmlElement("Employee")]
        public List<Employee> Employes { get; set; }
    }

    public class Employee
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Specialization")]
        public string Specialization { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Salary")]
        public string Salary { get; set; }

        [XmlElement("Experience")]
        public string Experience { get; set; }
    }
}