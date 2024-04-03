namespace LINQ_2
{
    internal class Program
    {

        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void AddRecs()
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

        static Employee GetEmps(Employee obj)
        {
            return obj;
        }

        static string GetName(Employee obj)
        {
            return obj.Name;
        }
        static void Main()
        {
            AddRecs();

            // Functions
            var emps1 = lstEmp.Select(GetEmps);
            var emps2 = lstEmp.Select(GetName);

            // Anonymous methods

            var emps3 = lstEmp.Select(delegate (Employee obj)
            {
                return obj;
            });

            var emps4 = lstEmp.Select(delegate (Employee obj)
            {
                return obj.Name;
            });

            var emps5 = lstEmp.Select(delegate (Employee obj)
            {
                return new { obj.EmpNo, obj.Name };
            });

            // Lambdas

            var emps3a = lstEmp.Select(obj => obj);
            var emps4a = lstEmp.Select(obj => obj.Name);
            var emps5a = lstEmp.Select(obj => new { obj.EmpNo, obj.Name });

            foreach (var item in emps5a)
            {
                Console.WriteLine(item);
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
}
