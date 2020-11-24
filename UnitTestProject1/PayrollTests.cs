using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollServices;

namespace EmployeePayrollTest
{
    [TestClass]
    public class PayrollTests
    {
        /// <summary>
        /// Givens the salary details able to update salary details.
        /// </summary>
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            //Arrange
            EmployeeRepo employee = new EmployeeRepo();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {                
                SalaryId = 2,
                Month = "Jan",
                EmployeeSalary = 1300,
                EmployeeId = 2
            };
            //Act
            int EmpSalary = employee.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }
    }
}