using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServices
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime start_date { get; set; }
        public string Gender { get; set; }
        public string EmployeeAddress { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Basic_Pay { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
    }
}
