﻿/**********************************************************************************
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
            do
            {
                Console.WriteLine("1.Get all records.\n2.Add new Employee.\n3.Update salary.\n4.Get Employeesby Hire Date." +
                "\n5.Get Aggregate Salary Details By Gender.\n6.Delete record.\n7.Exit.");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.GetAllEmployeeRecord();
                        break;
                    case 2:                        
                        EmployeeModel employee = new EmployeeModel();
                        employee.Name = "Robert Shaw";
                        employee.start_date = Convert.ToDateTime("12-08-2018");
                        employee.Gender = "F";
                        employee.EmployeeAddress = "Brooklyn";
                        employee.Department = "Delivery";
                        employee.PhoneNumber = "7895478596";
                        employee.Basic_Pay = 10000;
                        employee.Deductions = 500;
                        employee.Taxable_Pay = 500;
                        employee.Income_Tax = 500;
                        employee.Net_Pay = 11500;
                        var record = repo.AddEmployee(employee);
                        Console.WriteLine("Record added successfully: " + record);
                        break;

                    case 3:
                        Console.WriteLine("Enter employee name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter new salary");
                        decimal salary = Convert.ToDecimal(Console.ReadLine());
                        repo.UpdateEmployeeSalary(name, salary);
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
