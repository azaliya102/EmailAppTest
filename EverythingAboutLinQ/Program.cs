using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {

            var salaries = context.Employees.Select(emp => emp.sal).ToList();
            foreach (var salary in salaries)
            {
                Console.WriteLine(salary);
            }

        }
    }
}
