using FinalProj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;

namespace FinalProj.Model.DAL
{

    /// <summary>
    /// DBServices is a class created by me to provides some DataBase Services
    /// </summary>
    public class DBservices
    {

        public SqlDataAdapter da;
        public DataTable dt;
        private string myProjDB;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            string cStr = configuration.GetConnectionString("myProjDB");
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //--------------------------------------------------------------------------------------------------
        //   insert methods 
        //--------------------------------------------------------------------------------------------------
        public int InsertNewEmployee(Employee employee)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateInsertEmployeeCommand("spInsertEmployee", con, employee); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public int InsertNewRole(EmployeeRole role)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateInsertRoleCommand("spInsertRole", con, role); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public int InsertProductionReport(ProductionReport PReport)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
         
            // helper method to build the insert string

            cmd = CreateInsertProductionReportCommand("spInsertProductionReport", con, PReport); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //--------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------
        public int InsertInventoryIn(InventoryIn invIn)
        {
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateInsertInventoryInCommand("spInsertInventoryIn", con, invIn); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        //   update methods 
        //--------------------------------------------------------------------------------------------------    
        public int UpdateEmployee(Employee employee)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateInsertEmployeeCommand("spUpdateEmployee", con, employee); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public int UpdateMaterial(int numMat,int amount)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateInsertAmountCommand("spUpdateMaterial", con, numMat, amount); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public int AdminUpdateMaterial(int numMat, int amount)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            // helper method to build the insert string

            cmd = CreateAdminInsertAmountCommand("spUpdateAdminMaterial", con, numMat, amount); // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //--------------------------------------------------------------------------------------------------
        //   read methods 
        //--------------------------------------------------------------------------------------------------
        public List<EmployeeRole> ReadRoles()
        {


            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

            cmd = CreateCommandRead("spReadAllRoles", con);             // create the command


            List<EmployeeRole> list = new List<EmployeeRole>();

            try
            {


                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {

                    EmployeeRole role = new EmployeeRole();
                    role.EmpRoleNum = Convert.ToInt32(dataReader["roleNum"]);
                    role.EmpRoleName = dataReader["roleName"].ToString();

                    list.Add(role);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public List<Employee> ReadEmployees()
        {


            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

            cmd = CreateCommandRead("spReadAllEmployees", con);             // create the command


            List<Employee> list = new List<Employee>();

            try
            {


                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {

                    Employee employee = new Employee();

                    employee.EmpNum = Convert.ToInt32(dataReader["empNum"]);
                    employee.EmpFirstName = dataReader["empFirstName"].ToString();
                    employee.EmpLastName = dataReader["empLastName"].ToString();
                    employee.EmpPhone = dataReader["empCellPhone"].ToString();
                    employee.EmpEmail = dataReader["empEmail"].ToString();
                    employee.EmpPassword = dataReader["empPassword"].ToString();
                    employee.EmpRoleNum = Convert.ToInt32(dataReader["roleNum"]);
                    employee.EmpStatus = (bool)dataReader.GetValue("empStatus");
                    employee.EmpAdmin = (bool)dataReader.GetValue("isAdmin");

                    list.Add(employee);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public string GetRoleNameByNum(int num)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            cmd = CreateCommandRead("spGetRoleNameByNum", con);  // create the command
            cmd.Parameters.AddWithValue("@roleNum", num);  // add the parameter

            try
            {
                string roleName = null;

                using (SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dataReader.Read())
                    {
                        roleName = dataReader.GetString(0);
                    }
                }

                if (roleName == null)
                {
                    throw new Exception("Role not found");
                }

                return roleName;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public List<ProductionReport> ReadProductionReport()
        {


            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

            cmd = CreateCommandRead("spReadProductionReport", con);             // create the command


            List<ProductionReport> list = new List<ProductionReport>();

            try
            {


                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {

                    ProductionReport PReport = new ProductionReport();

                    PReport.ReportNum = Convert.ToInt32(dataReader["prodRepNum"]);
                    PReport.EmpNum = Convert.ToInt32(dataReader["empNum"]);
                    PReport.ReportDate = (DateTime)dataReader["prodRepDate"];
                    PReport.ReportTime = dataReader["prodRepTime"].ToString();
                    PReport.MachineNum = Convert.ToInt32(dataReader["machineNum"]);
                    PReport.MaterialNum = Convert.ToInt32(dataReader["rawMatNum"]);
                    PReport.AmountRep = Convert.ToInt32(dataReader["amountReport"]);


                    list.Add(PReport);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        //---------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------
        public List<InventoryIn> ReadInventoryIn()
        {


            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

            cmd = CreateCommandRead("spReadAllInventoryIn", con);             // create the command


            List<InventoryIn> list = new List<InventoryIn>();

            try
            {


                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {

                    InventoryIn invIn = new InventoryIn();

                    invIn.InvNum = Convert.ToInt32(dataReader["invInNum"]);
                    invIn.EmpNum = Convert.ToInt32(dataReader["empNum"]);
                    invIn.InvDate = (DateTime)dataReader["invInDate"];
                    invIn.MatNum = Convert.ToInt32(dataReader["rawMatNum"]);
                    invIn.InvAmount = Convert.ToInt32(dataReader["invInAmount"]);


                    list.Add(invIn);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        public List<Material> ReadMaterials()
        {


            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            //String cStr = BuildUpdateCommand(student);      // helper method to build the insert string

            cmd = CreateCommandRead("spReadMaterial", con);             // create the command


            List<Material> list = new List<Material>();

            try
            {


                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {

                    Material material = new Material();

                    material.MaterialNum = Convert.ToInt32(dataReader["rawMatNum"]);
                    material.MaterialName = dataReader["rawMatName"].ToString();
                    material.Amount = Convert.ToInt32(dataReader["amountInInv"]);

                    list.Add(material);
                }

                return list;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------

        private SqlCommand CreateInsertEmployeeCommand(String sp, SqlConnection con, Employee employee)
        {


            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            cmd.Parameters.AddWithValue("@empNum", employee.EmpNum);
            cmd.Parameters.AddWithValue("@empFirstName", employee.EmpFirstName);
            cmd.Parameters.AddWithValue("@empLastName", employee.EmpLastName);
            cmd.Parameters.AddWithValue("@empCellPhone", employee.EmpPhone);
            cmd.Parameters.AddWithValue("@empEmail", employee.EmpEmail);
            cmd.Parameters.AddWithValue("@empPassword", employee.EmpPassword);
            cmd.Parameters.AddWithValue("@roleNum", employee.EmpRoleNum);
            cmd.Parameters.AddWithValue("@empStatus", employee.EmpStatus);
            cmd.Parameters.AddWithValue("@IsAdmin", employee.EmpAdmin);

            return cmd;
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private SqlCommand CreateInsertProductionReportCommand(String sp, SqlConnection con, ProductionReport PReport)
        {


            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            //cmd.Parameters.AddWithValue("@prodRepNum", PReport.ReportNum);
     
            cmd.Parameters.AddWithValue("@empNum", PReport.EmpNum);
            cmd.Parameters.AddWithValue("@prodRepDate", PReport.ReportDate);
            cmd.Parameters.AddWithValue("@prodRepTime", PReport.ReportTime);
            cmd.Parameters.AddWithValue("@machineNum", PReport.MachineNum);
            cmd.Parameters.AddWithValue("@rawMatNum", PReport.MaterialNum);
            cmd.Parameters.AddWithValue("@amountReport", PReport.AmountRep);
            
            return cmd;
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private SqlCommand CreateInsertInventoryInCommand(String sp, SqlConnection con, InventoryIn invIn)
        {


            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            //cmd.Parameters.AddWithValue("@prodRepNum", PReport.ReportNum);

            cmd.Parameters.AddWithValue("@empNum", invIn.EmpNum);
            cmd.Parameters.AddWithValue("@invInDate", invIn.InvDate);
            cmd.Parameters.AddWithValue("@rawMatNum", invIn.MatNum);
            cmd.Parameters.AddWithValue("@invInAmount", invIn.InvAmount);

            return cmd;
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private SqlCommand CreateInsertAmountCommand(String sp, SqlConnection con, int matNum,int amount)
        {


            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            //cmd.Parameters.AddWithValue("@prodRepNum", PReport.ReportNum);

            cmd.Parameters.AddWithValue("@rawMatNum", matNum);
            cmd.Parameters.AddWithValue("@amountInInv", amount);

            return cmd;
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------    
        private SqlCommand CreateAdminInsertAmountCommand(String sp, SqlConnection con, int matNum, int amount)
        {


            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            //cmd.Parameters.AddWithValue("@prodRepNum", PReport.ReportNum);

            cmd.Parameters.AddWithValue("@rawMatNum", matNum);
            cmd.Parameters.AddWithValue("@amountInInv", amount);

            return cmd;
         }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private SqlCommand CreateInsertRoleCommand(String sp, SqlConnection con, EmployeeRole role)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = sp;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            cmd.Parameters.AddWithValue("@roleNum", role.EmpRoleNum);
            cmd.Parameters.AddWithValue("@roleName", role.EmpRoleName);
            return cmd;
        }
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        private SqlCommand CreateCommandRead(string spName, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be stored procedure

            return cmd;
        }
    }
}    