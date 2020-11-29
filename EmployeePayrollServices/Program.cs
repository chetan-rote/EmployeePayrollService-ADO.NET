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
            int choice;
            Console.WriteLine("Welcome to Employee Payroll Service");
            EmployeeRepo repo = new EmployeeRepo();
            SalaryUpdateModel updateModel = new SalaryUpdateModel();
            do
            {
                Console.WriteLine("1.Get all values.\n2.Add new Employee.\n3.Update salary.\n4.Get Employeesby Hire Date." +
                "\n5.Get Aggregate Salary Details By Gender.\n6.Delete record.\n7.Exit.");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.GetAllEmployeeRecord();
                        break;
                    case 2:
                        Console.WriteLine("Enter Name, Start date, Gender, Address, Department, Phone Number," +
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
                    case 5:
                        repo.GetAggregateSalaryDetailsByGender();
                        break;
                    case 6:
                        Console.WriteLine("Enter Employee Id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        repo.RemoveEmployee(id);
                        break;
                    case 7:
                        Console.WriteLine("Thank you for using Employee Payroll System.");
                        break;
                }
            }
            while (choice != 7);
            Console.ReadKey();
        }
    }
}
