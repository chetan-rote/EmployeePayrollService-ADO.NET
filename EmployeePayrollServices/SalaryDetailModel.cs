using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServices
{
    public class SalaryDetailModel
    {
        public int Employee_Id { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescritption { get; set; }
        public string Month { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int SalaryId { get; set; }
    }
}
