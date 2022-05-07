using System;
using System.Text.Json.Serialization;

namespace EmployeePayRoll
{
    public class Employee
    {
        //[JsonIgnore]
        public int ID { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public string Department { get; set; }
        public int  Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
