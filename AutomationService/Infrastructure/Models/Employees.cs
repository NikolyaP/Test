using System;
using System.Collections.Generic;
using AutomationService.Helpers;
using AutomationService.Infrastructure.Enums;

namespace AutomationService.Infrastructure.Models
{
    public class Employees
    {
        public List<Employee> Employes { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee)obj);
        }
    }

    public class Employee
    {
        public int? Id { get; set; }

        public int? Salary { get; set; }

        public double? Experience { get; set; }

        public string Specialization { get; set; }

        public string Position { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Employee) obj);
        }

        public bool Equals(Employee objB)
        {
            return ((Id == null && objB.Id == null) || Id.Equals(objB.Id))
                   && ((Salary == null && objB.Salary == null) || Salary.Equals(objB.Salary))
                   && ((Experience == null && objB.Experience == null) || Experience.Equals(objB.Experience))
                   && ((string.IsNullOrEmpty(Specialization) && string.IsNullOrEmpty(objB.Specialization)) || Specialization.Equals(objB.Specialization))
                   && ((string.IsNullOrEmpty(Position) && string.IsNullOrEmpty(objB.Position)) || Position.Equals(objB.Position))
                   && ((string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(objB.Name)) || Name.Equals(objB.Name));
        }

        public Employee GenerateBaseEmployee()
        {
            var random = new Random();
            return new Employee()
            {
                Salary = random.Next(500, 5000),
                Experience = random.Next(1, 5),
                Specialization = ((SpecializationEnum) random.Next(1, 3)).GetDescription(),
                Position = ((PositionEnum) random.Next(1, 3)).GetDescription(),
                Name = "TestEmployee" + DateTime.UtcNow.ToString("O")

            };
        }
    }
}