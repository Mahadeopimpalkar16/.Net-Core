using System.Security.Cryptography;

namespace LINQ
{
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
        static void Main1()
        {
            AddRecs();
            //var returnvalue =from single_object in collection select something.

            //var emps = from emp in lstEmp select emp; // select * from emp;

            // OR
            //IEnumerable<Employee>emps = from emp in lstEmp select emp;

            // from emp in lstEmp => points to 1st collection in Emp, like loops and go on further.
            // select emp => select All collection. like Select * from emp.

            // IEnumerable : its a interface to iterate to foreach loop
            // IQueryable

            // All properties

            //var emps = from emp in lstEmp select emp;
            //foreach (Employee emp in emps)
            // Or
            //foreach (var item in emps)
            //{
            //    Console.WriteLine(item);
            //}

            // One property

            //var emps = from emp in lstEmp select emp.Name;
            //foreach (var item in emps)
            //{
            //    Console.WriteLine(item);
            //}

            // Two properties

            var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo };
            foreach (var item in emps)
            {
                Console.WriteLine(item.Name + " " + item.EmpNo);
            }

            /*
             Where :-
                    - var emps => IEnumerable of Anonymous type.
                    - lstEmp   => List<Employee>
                    - item     => item is type of Anonymous.
          - Anonymous Employee => new { emp.Name ,emp.EmpNo}
             */
        }

        static void Main2() // Conditional Query
        {
            AddRecs();

            // Conditional statement

            //var emps = from emp in lstEmp 
            //           where emp.Basic > 10000
            //           select emp;


            var emps = from emp in lstEmp
                       orderby emp.EmpNo ascending, emp.Name descending
                       select emp;
            foreach (var item in emps)
            {
                Console.WriteLine(item);
                //Console.WriteLine($"{item.Name} {item.Basic}");
            }
            static void Main()
            {
                AddRecs();


                //var emps = from emp in lstEmp
                //               //where emp.Basic > 10000
                //           orderby emp.Name
                //           select emp;
                //var emps = from emp in lstEmp
                //           orderby emp.Name descending
                //           select emp;

                var emps = from emp in lstEmp
                           orderby emp.DeptNo ascending, emp.Name descending
                           select emp;

                foreach (var emp in emps)
                {
                    Console.WriteLine(emp);
                }
                Console.ReadLine();
            }
        }

        static void Main() // joins
        {
            AddRecs();

            //var emps = from emp in lstEmp
            //           join dept in lstDept
            //                 on emp.DeptNo equals dept.DeptNo
            //           select emp;


            // var emps returns => IEnumerable<Employee>. 


            var emps = from emp in lstEmp
                       join dept in lstDept
                               on emp.DeptNo equals dept.DeptNo
                       select emp;

            var emps1 = from emp in lstEmp
                        join dept in lstDept
                                on emp.DeptNo equals dept.DeptNo // join property
                        select dept;

            var emps2 = from emp in lstEmp
                        join dept in lstDept
                                on emp.DeptNo equals dept.DeptNo
                        select new { emp, dept };  // select all dept and emp

            var emps3 = from emp in lstEmp
                        join dept in lstDept
                                on emp.DeptNo equals dept.DeptNo
                        select new { emp.Name, dept.DeptName }; // select only emp.Name and dep.DeptName so we cant access any data rather than that.

            //foreach(var emp in emps)
            //{
            //    Console.WriteLine(emp); 
            //}

            //foreach (var item in emps1)
            //{
            //    Console.WriteLine(item.DeptName +" "+ item.DeptNo);
            //}

            //foreach (var item in emps2)
            //{
            //    Console.WriteLine(item.emp.Name+" => "+ item.dept.DeptName);
             //}

            foreach (var item in emps3)
            {
                Console.WriteLine(item.Name + " => " + item.DeptName);
            }
        }
    }


    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
}
/*
 Basic Operations,

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		List<int> list = new List<int>(){
		10,20,30,40,50,60,70,80,90
		};
		
		//var result = list.Where(s => s >= 30);
		
		var result = from items in list
					where items >=30
					select items;
					

foreach (var items in result)
{
    Console.WriteLine(items);
}
	}
}
 
 */
