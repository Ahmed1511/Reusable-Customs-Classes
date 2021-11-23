
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rev
{    
    class Program
    {
        static void Main(string[] args)
        {
            List<Error> errors = new List<Error>();
            // list of employees
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1, Name="ahmed",Salary=200},
                new Employee{Id=2, Name="ali",Salary=2000},
                new Employee{Id=3, Name="mohamed",Salary=200},
                new Employee{Id=4, Name="mahmoud",Salary=0},
            };
            // iterate employees
            foreach (var employee in employees)
            {
                // list of employee obj properties
                var proplist = employee.GetType().GetProperties();
                // iterate throw properties
                foreach (var prop in proplist)
                {
                    // get custom property
                    var salaryAttr = prop.GetCustomAttribute<SalaryAttribute>();
                    // if not null
                    if (salaryAttr is not null)
                    {
                        // get this property value of this currnt object.
                        var value = prop.GetValue(employee);
                        if (!salaryAttr.IsValid(value))
                        {
                            errors.Add(new Error(prop.Name,$"Invalid Value accepted Range is {salaryAttr.MinVal} to  {salaryAttr.MaxVal}"));
                        }
                    }
                }
            }
            if (errors.Count > 0)
            {
                foreach (var e in errors)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Employees info is valid");
            }

            Console.ReadKey();           
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Salary(nameof(Salary),1000,2000)]
        public int Salary { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class SalaryAttribute : Attribute
    {
        public string Name { get; set; }
        public int MinVal { get; set; }
        public int MaxVal { get; set; }
        public SalaryAttribute(string name,int minVal, int maxVal)
        {
            Name = name;
            MinVal = minVal;
            MaxVal = maxVal;
        }
       public  bool IsValid(object obj)
        {
            var value = (Int32)obj;
             return value >= MinVal && value <= MaxVal;
        }
    }

    public class Error
    {

        public string Field { get; set; }
        public string Detail { get; set; }
        public Error(string field, string detail)
        {
            Field = field;
            Detail = detail;
        }
        public override string ToString()
        {
            return $"{{title : {Field} , details : {Detail}}}"; 
        }
    }
}
