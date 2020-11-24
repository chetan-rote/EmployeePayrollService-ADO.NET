using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollServices
{
    public class EmployeeRepo
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
        /// <summary>
        /// UC2 Gets all employee record from the database.
        /// </summary>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// UC7-Adds the new employee to database.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Impementing the command on the connection to add data to database table.
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployee", this.sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employeeModel.start_date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Address", employeeModel.EmployeeAddress);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employeeModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employeeModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employeeModel.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", employeeModel.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", employeeModel.Net_Pay);
                    this.sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            /// Catching the null record exception.
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            /// Alway ensuring the closing of the connection.
            finally
            {
                this.sqlConnection.Close();
            }
            return false;
        }
        /// <summary>
        /// UC3&4 Update the salary using Stored procedure.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="salary">The salary.</param>
        /// <returns></returns>
        public int UpdateEmployeeSalary(SalaryUpdateModel model)
        {
            try
            {
                int salary = 0;
                using (this.sqlConnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("dbo.spUpdateSalary", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", model.SalaryId);
                    command.Parameters.AddWithValue("@month", model.Month);
                    command.Parameters.AddWithValue("@salary", model.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", model.EmployeeId);
                    this.sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            displayModel.Employee_Id = reader.GetInt32(0);
                            displayModel.EmployeeName = reader["Name"].ToString();
                            displayModel.JobDescritption = reader["Job"].ToString();
                            displayModel.Month = reader["salMonth"].ToString();
                            displayModel.SalaryId = Convert.ToInt32(reader["Salary_id"]);
                            displayModel.EmployeeSalary = reader.GetDecimal(3);
                            Console.WriteLine("EmployeeId={0}\nEmployeeName={1}\nEmployeeSalary={2}\nMonth={3}\nSalaryId={5}\nJobDescription={4}", displayModel.Employee_Id, displayModel.EmployeeName, displayModel.EmployeeSalary, displayModel.Month, displayModel.JobDescritption, displayModel.SalaryId);
                            Console.WriteLine("\n");
                            salary = (int)displayModel.EmployeeSalary;

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                    return salary;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
        /// <summary>
        /// UC5 Gets the allemployee started in a date range.
        /// </summary>
        /// <exception cref="System.Exception">No data found</exception>
        public void GetAllemployeeStartedInADateRange()
        {
            ///creating a list to store all those employees
            EmployeeModel model = new EmployeeModel();

            using (sqlConnection)
            {
                ///Query to get Employees by the mentioned hire date.
                string query = "select * from employee_payroll where start_date between cast('01-01-2018' as date) and getdate()";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                ///opening connection to read.
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.Id = reader.GetInt32(0);
                        model.Name = reader.GetString(1);                        
                        model.start_date = reader.GetDateTime(2);
                        model.Gender = reader.GetString(3);
                        model.EmployeeAddress = reader.GetString(4);
                        model.Department = reader.GetString(5);
                        model.PhoneNumber = reader.GetString(6);
                        model.Basic_Pay = reader.GetDecimal(7);                        
                        model.Deductions = reader.GetDecimal(8);
                        model.Taxable_Pay = reader.GetDecimal(9);
                        model.Income_Tax = reader.GetDecimal(10);
                        model.Net_Pay = reader.GetDecimal(11);                        
                        Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", model.Id,
                        model.Name, model.Gender, model.EmployeeAddress, model.Basic_Pay, model.start_date,
                        model.PhoneNumber, model.Department, model.Deductions, model.Taxable_Pay,
                        model.Income_Tax, model.Net_Pay);
                        Console.WriteLine("\n");

                    }
                    ///closing reader and connection
                    reader.Close();
                    sqlConnection.Close();
                }
                else
                {
                    throw new Exception("No data found");
                }
            }
        }
        /// <summary>
        /// UC6 Get aggregate salary details by gender
        /// </summary>
        public void GetAggregateSalaryDetailsByGender()
        {
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                string query = @"Select Gender,SUM(Basic_Pay),AVG(Basic_Pay), MIN(Basic_Pay),MAX(Basic_Pay),COUNT(id)
                                    from employee_payroll Group by Gender";

                SqlCommand command = new SqlCommand(query, this.sqlConnection);
                this.sqlConnection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine("Gender\t\tSUM\t\tAVG\t\tMIN\t\tMAX\tCount");
                    while (dr.Read())
                    {
                        string gender = dr.GetString(0);
                        decimal SUM = dr.GetDecimal(1);
                        decimal AVG = dr.GetDecimal(2);
                        decimal MIN = dr.GetDecimal(3);
                        decimal MAX = dr.GetDecimal(4);
                        int Count = dr.GetInt32(5);
                        Console.WriteLine(gender + "\t" + SUM + "\t" + AVG + "\t" + MIN + "\t" + MAX + "\t" + Count);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No such records found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}
