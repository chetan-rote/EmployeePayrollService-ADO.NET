using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServices
{
    class EmployeeRepo
    {
        /// Specifying the connection string from the sql server connection
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True";
        /// Establishing the connection using the Sql Connection
        public SqlConnection sqlConnection = new SqlConnection(connectionString);
        /// <summary>
        /// UC1 Checking for the database connection.
        /// </summary>
        public void EnsureDataBaseConnection()
        {
            this.sqlConnection.Open();
            using (sqlConnection)
            {
                Console.WriteLine("The Connection is created");
            }
            this.sqlConnection.Close();
        }
        public void GetAllEmployeeRecord()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            try
            {
                /// Query to get all the data from the table.
                string query = @"select * from employee_payroll;";
                /// Impementing the command on the connection fetched database table.
                SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                /// Opening the connection to start mapping.
                this.sqlConnection.Open();
                /// executing the sql data reader to fetch the records.
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                /// executing for not null.
                if (dataReader.HasRows)
                {
                    /// Moving to the next record from the table
                    /// Mapping the data to the employee model class object
                    while (dataReader.Read())
                    {
                        employeeModel.Id = dataReader.GetInt32(0);
                        employeeModel.Name = dataReader.GetString(1);
                        employeeModel.start_date = dataReader.GetDateTime(2);
                        employeeModel.Gender = dataReader.GetString(3);
                        employeeModel.EmployeeAddress = dataReader.GetString(4);
                        employeeModel.Department = dataReader.GetString(5);
                        employeeModel.PhoneNumber = dataReader.GetString(6);
                        employeeModel.Basic_Pay = dataReader.GetDecimal(7);
                        employeeModel.Deductions = dataReader.GetDecimal(8);
                        employeeModel.Taxable_Pay = dataReader.GetDecimal(9);
                        employeeModel.Income_Tax = dataReader.GetDecimal(10);
                        employeeModel.Income_Tax = dataReader.GetDecimal(11);

                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}", employeeModel.Id , employeeModel.Name,
                        employeeModel.start_date, employeeModel.Gender, employeeModel.EmployeeAddress, employeeModel.Department, employeeModel.PhoneNumber,
                        employeeModel.Basic_Pay, employeeModel.Deductions, employeeModel.Taxable_Pay, employeeModel.Income_Tax, employeeModel.Net_Pay);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                dataReader.Close();
            }
            /// Catching the null record exception.
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            /// Alway ensuring the closing of the connection.
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
