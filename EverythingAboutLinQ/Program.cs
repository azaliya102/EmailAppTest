using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            //// a simple one 

            //var salaries = context.Employees.Select(emp => emp.sal).ToList();

            //foreach (var salary in salaries)
            //{
            //    Console.WriteLine(salary);
            //}

            // inner - join  

            var query = from emp in context.Employees
                        join dept in context.Departments
                        on emp.deptno equals dept.deptno
                        select new
                        {
                            EmployeeName = emp.ename,
                            Job = emp.job,
                            Salary = emp.sal,
                            DepartmentName = dept.dname,
                            DepartmentLocation = dept.loc
                        };

            foreach (var result in query)
            {
                //Console.WriteLine(result);

                Console.WriteLine($"Name: {result.EmployeeName}, " +
                    $"Job: {result.Job}, " +
                    $"Salary: {result.Salary}, " +
                    $"DepartmentName: {result.DepartmentName}, " +
                    $"DeptLocation: {result.DepartmentLocation}"); // this one looks prettier
            }

            // insert 

            Employee budgieEmployee = new Employee
            {
                empno = 8458,
                ename = "Sean",
                job = "Salesman",
                mgr = null,
                hiredate = DateTime.Now,
                sal = 5000,
                comm = 5000,
                deptno = 30
            };

            context.Employees.Add(budgieEmployee);
            context.SaveChanges();

            // with orderBy

            var orderedQuery = from emp in context.Employees
                               orderby emp.ename ascending
                               select new
                               {
                                   emp.ename,
                                   emp.job,
                                   emp.sal
                               };

            foreach (var employee in orderedQuery)
            {
                Console.WriteLine($"Employee: {employee.ename}, Job: {employee.job}, Salary: {employee.sal}");
            }

            // with where
            var whereQuery = from emp in context.Employees
                             where emp.sal > 1500
                             select new
                             {
                                 emp.ename,
                                 emp.job,
                                 emp.sal
                             };

            foreach (var employee in whereQuery)
            {
                Console.WriteLine($"Employee: {employee.ename}, Job: {employee.job}, Salary: {employee.sal}");
            }

            // update 

            var updateQuery = from emp in context.Employees
                              where emp.job == "Salesman"
                              select emp;
            foreach (Employee emp in updateQuery)
            {
                emp.job = "SALESMAN";
            }
            context.SaveChanges();

            // simple lambda function

            int[] nums = { 1, 2, 3, 4, 5, 6 };
            var sumOfSquaredNums = nums.Select(x => x * x).Sum();
            Console.WriteLine(string.Join(" ", sumOfSquaredNums));

            // where with lambda expression

            var name = context.Employees.Where(s => s.ename.Contains("SEAN"));

            foreach (Employee s in name)
            {
                Console.WriteLine($"His name is {s.ename} and his job is a {s.job}");
            }


        }

    }
}
