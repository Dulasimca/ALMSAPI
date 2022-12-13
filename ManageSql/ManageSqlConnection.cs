using System;
using System.Collections.Generic;
using System.Data;
using ALMS_API.Controllers;
using Npgsql;

namespace ALMS_API.ManageSQL
{
    public class ManageSQLConnection
    {
        NpgsqlConnection sqlConnection = new NpgsqlConnection();
        NpgsqlCommand sqlCommand = new NpgsqlCommand();

        NpgsqlDataAdapter dataAdapter;
        /// <summary>
        /// Gets values from 
        /// </summary>
        /// <param name="procedureName"></param>
        /// <returns></returns>
        public DataSet GetDataSetValues(string procedureName)
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }

        }

        public DataSet GetDataSetValues(string procedureName, List<KeyValuePair<string, string>> parameterList)
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, string> keyValuePair in parameterList)
                {
                    sqlCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                }
                sqlCommand.CommandTimeout = 360;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        public bool UpdateValues(string procedureName, List<KeyValuePair<string, string>> parameterList)
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (KeyValuePair<string, string> keyValuePair in parameterList)
                {
                    sqlCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                }
                sqlCommand.ExecuteNonQuery();
                //  AuditLog.WriteError(affected.ToString());
                return true;
            }
            catch (Exception ex)
            {
                // AuditLog.WriteError(ex.Message + " : " + ex.StackTrace);
                return false;

            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        public bool InsertData(string procedureName, List<KeyValuePair<string, string>> parameterList)
        {



            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = procedureName;
                sqlCommand.CommandType = CommandType.Text;
                foreach (KeyValuePair<string, string> keyValuePair in parameterList)
                {
                    sqlCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                }
                sqlCommand.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
            {
                //AuditLog.WriteError(ex.Message);
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        public bool Inserttest(TestEntity TestEntity)
        {

            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "call inserttest(@sno,@countryname)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@sno", TestEntity.sno);
                sqlCommand.Parameters.AddWithValue("@countryname", TestEntity.countryname);
                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }



        //library register

        public bool insertlibrarienregister(librarienregisterEntity librarienregisterEntity)
        {

            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "call insertlibrarienregister(@sno,@username,@email,@password,@confirmpassword)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@sno", librarienregisterEntity.sno);
                sqlCommand.Parameters.AddWithValue("@username", librarienregisterEntity.username);
                sqlCommand.Parameters.AddWithValue("@email", librarienregisterEntity.email);
                sqlCommand.Parameters.AddWithValue("@password", librarienregisterEntity.password);
                sqlCommand.Parameters.AddWithValue("@confirmpassword", librarienregisterEntity.confirmpassword);
                sqlCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        //GetBookCategoryMaster
        public DataSet GetBookCategoryMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getbookcategorymaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        //languageMaster

        public DataSet GetLanguageMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getlanguagemaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        //Geteditionbook

        public DataSet GetBookEditionMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getbookedition()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        // insertbook

        public bool insertbook(BookEntity BookEntity)
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {         
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "call insertbook(@bookid,@languageid,@bookname,@author,@bookcategoryid,@editionid,@publisheddate,@copies,@remarks,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@bookid", BookEntity.bookid);
                sqlCommand.Parameters.AddWithValue("@languageid", BookEntity.languageid);
                sqlCommand.Parameters.AddWithValue("@bookname", BookEntity.bookname);
                sqlCommand.Parameters.AddWithValue("@author", BookEntity.author);
                sqlCommand.Parameters.AddWithValue("@bookcategoryid", BookEntity.bookcategoryid);
                sqlCommand.Parameters.AddWithValue("@editionid", BookEntity.editionid);
                sqlCommand.Parameters.AddWithValue("@publisheddate", BookEntity.publisheddate);
                sqlCommand.Parameters.AddWithValue("@copies", BookEntity.copies);
                sqlCommand.Parameters.AddWithValue("@remarks", BookEntity.remarks);
                sqlCommand.Parameters.AddWithValue("@flag", BookEntity.flag);
                sqlCommand.ExecuteNonQuery();



                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }


        //bookget
        public DataSet GetBook()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getbook_master()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }


        //libraryregister
        public DataSet Getlibrarain()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getlibrarienregister";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        //studentregister
        public bool insertstudentreg(StudentregEntity StudentregEntity)
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "call insertstudentreg(@sno,@firstname,@lastname,@regno,@genderid,@dob,@age,@email,@address,@pincode,@collegeid,@courseid,@department,@password,@confirmpassword,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@sno", StudentregEntity.sno);
                sqlCommand.Parameters.AddWithValue("@firstname", StudentregEntity.firstname);
                sqlCommand.Parameters.AddWithValue("@lastname", StudentregEntity.lastname);
                sqlCommand.Parameters.AddWithValue("@regno", StudentregEntity.regno);
                sqlCommand.Parameters.AddWithValue("@genderid", StudentregEntity.genderid);
                sqlCommand.Parameters.AddWithValue("@dob", StudentregEntity.dob);
                sqlCommand.Parameters.AddWithValue("@age", StudentregEntity.age);
                sqlCommand.Parameters.AddWithValue("@email", StudentregEntity.email);
                sqlCommand.Parameters.AddWithValue("@address", StudentregEntity.address);
                sqlCommand.Parameters.AddWithValue("@pincode", StudentregEntity.pincode);
                sqlCommand.Parameters.AddWithValue("@collegeid", StudentregEntity.collegeid);
                sqlCommand.Parameters.AddWithValue("@courseid", StudentregEntity.courseid);
                sqlCommand.Parameters.AddWithValue("@department", StudentregEntity.department);
                sqlCommand.Parameters.AddWithValue("@password", StudentregEntity.password);
                sqlCommand.Parameters.AddWithValue("@confirmpassword", StudentregEntity.confirmpassword);
                sqlCommand.Parameters.AddWithValue("@flag", StudentregEntity.flag);
                sqlCommand.ExecuteNonQuery();



                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        public DataSet Getstudentreg()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getstudentreg()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

        public DataSet GetGenderMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getgendermaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        public DataSet GetCollegeMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getcollegemaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        public DataSet GetCourseMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getcoursemaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }
        public DataSet GetDepartmentMaster()
        {
            sqlConnection = new NpgsqlConnection(GlobalVariable.ConnectionStringForPostgreSQL);
            DataSet ds = new DataSet();
            sqlCommand = new NpgsqlCommand();
            try
            {
                if (sqlConnection.State == 0)
                {
                    sqlConnection.Open();
                }
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from getdepartmentmaster()";
                sqlCommand.CommandType = CommandType.Text;
                dataAdapter = new NpgsqlDataAdapter(sqlCommand);
                dataAdapter.Fill(ds);
                return ds;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Dispose();
                ds.Dispose();
                dataAdapter = null;
            }
        }

    }

}

