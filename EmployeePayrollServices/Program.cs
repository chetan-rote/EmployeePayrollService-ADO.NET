/**********************************************************************************
 *  Purpose: This code will try to mock the query implementation using the ado.net.
 *
 *
 *  @author  Chetan Rote
 *  @version 1.0
 *  @since   23-11-2020
 **********************************************************************************/
using System;

namespace EmployeePayrollServices
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Payroll Service");
            EmployeeRepo repo = new EmployeeRepo();
            SalaryUpdateModel updateModel = new SalaryUpdateModel();
            Console.WriteLine("1.Get all values\n2.Insert value\n3.Update salary\n4.Get Employeesby Hire Date.");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: repo.GetAllEmployeeRecord();
                    break;
                case 2: Console.WriteLine("Enter Name, Start date, Gender, Address, Department, Phone Number," +
                    "Basic Pay, Deductions, Taxable Pay, Income Tax, Net Pay");
                    string[] details = Console.ReadLine().Split(",");
                    EmployeeModel employee = new EmployeeModel();
                    employee.Name = details[0];
                    employee.start_date = DateTime.Today;
                    employee.Gender = details[2];
                    employee.EmployeeAddress = details[3];
                    employee.Department = details[4];
                    employee.PhoneNumber = details[5];
                    employee.Basic_Pay = Convert.ToDecimal(details[6]);
                    employee.Deductions = Convert.ToDecimal(details[7]);
                    employee.Taxable_Pay = Convert.ToDecimal(details[8]);
                    employee.Income_Tax = Convert.ToDecimal(details[9]);
                    employee.Net_Pay = Convert.ToDecimal(details[10]);
                    repo.AddEmployee(employee);
                    Console.WriteLine("Record added successfully.");
                    break;

                case 3:
                    Console.WriteLine("Enter employee name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new salary");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    repo.UpdateEmployeeSalary(updateModel);
                    Console.WriteLine("Salary updated successfully");
                    break;

                case 4:
                    repo.GetAllemployeeStartedInADateRange();
                    break;
            }
            Console.ReadKey();
        }
    }
}
