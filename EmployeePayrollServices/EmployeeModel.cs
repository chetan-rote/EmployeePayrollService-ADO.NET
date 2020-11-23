using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollServices
{
    class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime start_date { get; set; }
        public string Gender { get; set; }
        public string EmployeeAddress { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public double Basic_Pay { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
    }
}
