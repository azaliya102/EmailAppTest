using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("emp")]
public class Employee
{
    [Key]
    public int empno { get; set; }
    public string ename { get; set; }
    public string job { get; set; }
    public int? mgr { get; set; }
    public DateTime hiredate { get; set; }
    public decimal sal { get; set; }
    public decimal? comm { get; set; }
    public int deptno { get; set; }
}
