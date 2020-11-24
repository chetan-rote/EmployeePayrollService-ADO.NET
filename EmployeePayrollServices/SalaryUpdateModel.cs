using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServices
{
    public class SalaryUpdateModel
    {
        public int SalaryId { get; set; }
        public string Month { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
