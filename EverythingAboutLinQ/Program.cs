using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        DBLinQExamples();
        CollectionsLinQExamples();
    }
    static void DBLinQExamples()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("\n============ Simple Select Query ============\n");
            var salaries = context.Employees.Select(emp => emp.sal).ToList();

            foreach (var salary in salaries)
            {
                Console.WriteLine(salary);
            }

            Console.WriteLine("\n============ Inner-Join Query ============\n");
            var query = from emp in context.Employees
                        join dept in context.Departments on emp.deptno equals dept.deptno
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
                Console.WriteLine($"Name: {result.EmployeeName}, Job: {result.Job}, Salary: {result.Salary}, " +
                                  $"DepartmentName: {result.DepartmentName}, DeptLocation: {result.DepartmentLocation}");
            }

            Console.WriteLine("\n============ OrderBy Query ============\n");
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

            Console.WriteLine("\n============ Filtering Query ============\n");
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

            Console.WriteLine("\n============ Where with Lambda Query ============\n");
            var nameQuery = context.Employees.Where(s => s.ename.Contains("SEAN"));

            foreach (var emp in nameQuery)
            {
                Console.WriteLine($"His name is {emp.ename} and his job is a {emp.job}");
            }
        }
    }

    static void CollectionsLinQExamples()
    {
        Console.WriteLine("\n============ LINQ with Collections and lambda query ============");

        int[] nums = { 1, 2, 3, 4, 5, 6 };
        var sumOfSquaredNums = nums.Select(x => x * x).Sum();
        Console.WriteLine("\nSum of squared numbers: " + sumOfSquaredNums);

        Console.WriteLine("\n============ inner-join with 2 collections  ============");
        List<int> IDs = new List<int> { 1, 2, 3 };
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop" },
            new Product { Id = 2, Name = "Phone" },
            new Product { Id = 3, Name = "Tablet" },
            new Product { Id = 4, Name = "Monitor" }
        };

        var joinedProducts = from id in IDs
                             join product in products on id equals product.Id
                             select product;

        foreach (var product in joinedProducts)
        {
            Console.WriteLine($"Product Name: {product.Name}");
        }
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}
