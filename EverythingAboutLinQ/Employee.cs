using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("emp")]
public class Employee
{
    [Key]
    public decimal empno { get; set; }
    public string ename { get; set; }
    public string job { get; set; }
    public decimal? mgr { get; set; }
    public DateTime hiredate { get; set; }
    public decimal sal { get; set; }
    public decimal? comm { get; set; }
    public decimal deptno { get; set; }
}

[Table("dept")]
public class Department
{
    [Key]
    public int deptno { get; set; }

    public string dname { get; set; }

    public string loc { get; set; }
}


