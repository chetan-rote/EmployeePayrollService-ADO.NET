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
            repo.EnsureDataBaseConnection();
        }
    }
}
