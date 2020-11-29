using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollServices;
using System.Collections.Generic;
using System;

namespace EmployeePayrollTest
{
    [TestClass]
    public class PayrollTests
    {
        /// <summary>
        /// Givens the name and salary update salary should return true.
        /// </summary>
        [TestMethod]
        public void Given_NameAndSalary_UpdateSalary_Should_Return_True()
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            string name = "Terissa";
            decimal salary = 3000000M;

            bool result = employeeRepo.UpdateEmployeeSalary(name, salary);

            Assert.AreEqual(true, result);
        }
    }
}
