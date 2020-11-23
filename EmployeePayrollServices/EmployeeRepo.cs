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
    }
}
