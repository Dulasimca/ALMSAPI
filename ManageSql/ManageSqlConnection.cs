using System;
using System.Collections.Generic;
using System.Data;
using ALMS_API.AMS;
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
        //it register
        public bool Insertitregister(itregisterEntity itregisterEntity)
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
                sqlCommand.CommandText = "call insertitregister(@sno,@name,@employeeid,@email,@password,@confirmpassword)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@sno", itregisterEntity.sno);
                sqlCommand.Parameters.AddWithValue("@name", itregisterEntity.name);
                sqlCommand.Parameters.AddWithValue("@employeeid", itregisterEntity.employeeid);
                sqlCommand.Parameters.AddWithValue("@email", itregisterEntity.email);
                sqlCommand.Parameters.AddWithValue("@password", itregisterEntity.password);
                sqlCommand.Parameters.AddWithValue("@confirmpassword", itregisterEntity.confirmpassword);

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
        public DataSet GetItRegister()
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
                sqlCommand.CommandText = "select * from getitregister()";
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

        // product master get

        public DataSet Getproductmaster()
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
                sqlCommand.CommandText = "select * from productmaster";
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
        //Get Brand Master
        public DataSet Getbrandmaster()
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
                sqlCommand.CommandText = "select * from brandmaster";
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

        //Insert ProductMaster
        public bool insertproductmaster(productmasterEntity productmasterEntity)
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
                sqlCommand.CommandText = "call insertproductmaster(@productid,@productname,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@productid", productmasterEntity.productid);
                sqlCommand.Parameters.AddWithValue("@productname", productmasterEntity.productname);
                sqlCommand.Parameters.AddWithValue("@flag", productmasterEntity.flag);
               
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

        //Insert Brand Master
        public bool insertbrandmaster(brandmasterEntity brandmasterEntity)
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
                sqlCommand.CommandText = "call insertbrandmaster(@brandid,@brandname,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@brandid", brandmasterEntity.brandid);
                sqlCommand.Parameters.AddWithValue("@brandname", brandmasterEntity.brandname);
                sqlCommand.Parameters.AddWithValue("@flag", brandmasterEntity.flag);

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

        //Insert specifaction Master

        public bool insertspecificationmaster(specificationmasterEntity specificationmasterEntity)
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
                sqlCommand.CommandText = "call insertspecificationmaster(@id,@productid,@brandid,@name,@specification,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@id", specificationmasterEntity.id);
                sqlCommand.Parameters.AddWithValue("@productid", specificationmasterEntity.productid);
                sqlCommand.Parameters.AddWithValue("@brandid", specificationmasterEntity.brandid);
                sqlCommand.Parameters.AddWithValue("@name", specificationmasterEntity.name);
                sqlCommand.Parameters.AddWithValue("@specification", specificationmasterEntity.specification);
                sqlCommand.Parameters.AddWithValue("@flag", specificationmasterEntity.flag);

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


        //Get specifaction Master
        public DataSet Getspecificationmaster()
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
                sqlCommand.CommandText = "select * from specificationmaster";
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
        public bool insertlanguagemaster(LanguageMasterEntity LanguageMasterEntity)
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
                sqlCommand.CommandText = "call insertlanguagemaster(@languageid,@languagename,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@languageid", LanguageMasterEntity.languageid);
                sqlCommand.Parameters.AddWithValue("@languagename", LanguageMasterEntity.languagename);
                sqlCommand.Parameters.AddWithValue("@flag", LanguageMasterEntity.flag);
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
        public bool inserteditionmaster(BookEditionEntity BookEditionEntity)
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
                sqlCommand.CommandText = "call inserteditionmaster(@editionid,@editionname,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@editionid", BookEditionEntity.editionid);
                sqlCommand.Parameters.AddWithValue("@editionname", BookEditionEntity.editionname);
                sqlCommand.Parameters.AddWithValue("@flag", BookEditionEntity.flag);
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
        public bool insertcoursemaster(CourseMasterEntity CourseMasterEntity)
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
                sqlCommand.CommandText = "call insertcoursemaster(@courseid,@coursename,@flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@courseid", CourseMasterEntity.courseid);
                sqlCommand.Parameters.AddWithValue("@coursename", CourseMasterEntity.coursename);
                sqlCommand.Parameters.AddWithValue("@flag", CourseMasterEntity.flag);
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
        public bool updatebookmaster(updatebookmasterEntity updatebookmaster)
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
                sqlCommand.CommandText = "call updatebookmaster(@v_bookid,@v_languageid,@v_bookname,@v_author,@v_bookcategoryid,@v_editionid,@v_publisheddate,@v_copies,@v_remarks,@v_flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@v_bookid", updatebookmaster.bookid);
                sqlCommand.Parameters.AddWithValue("@v_languageid", updatebookmaster.languageid);
                sqlCommand.Parameters.AddWithValue("@v_bookname", updatebookmaster.bookname);
                sqlCommand.Parameters.AddWithValue("@v_author", updatebookmaster.author);
                sqlCommand.Parameters.AddWithValue("@v_bookcategoryid", updatebookmaster.bookcategoryid);
                sqlCommand.Parameters.AddWithValue("@v_editionid", updatebookmaster.editionid);
                sqlCommand.Parameters.AddWithValue("@v_publisheddate", updatebookmaster.publisheddate);
                sqlCommand.Parameters.AddWithValue("@v_copies", updatebookmaster.copies);
                sqlCommand.Parameters.AddWithValue("@v_remarks", updatebookmaster.remarks);
                sqlCommand.Parameters.AddWithValue("@v_flag", updatebookmaster.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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
        public bool updatelanguagemaster(updatelanguagemasterEntity updatelanguagemaster)
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
                sqlCommand.CommandText = "call updatelanguagemaster(@v_languageid,@v_languagename,@v_flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@v_languageid", updatelanguagemaster.languageid);
                sqlCommand.Parameters.AddWithValue("@v_languagename", updatelanguagemaster.languagename);
                sqlCommand.Parameters.AddWithValue("@v_flag", updatelanguagemaster.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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
        public bool updateeditionmaster(updateeditionmasterEntity updateeditionmaster)
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
                sqlCommand.CommandText = "call updateeditionmaster(@v_editionid,@v_editionname,@v_flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@v_editionid", updateeditionmaster.editionid);
                sqlCommand.Parameters.AddWithValue("@v_editionname", updateeditionmaster.editionname);
                sqlCommand.Parameters.AddWithValue("@v_flag", updateeditionmaster.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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
        public bool updatecoursemaster(updatecoursemasterEntity updatecoursemaster)
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
                sqlCommand.CommandText = "call updatecoursemaster(@v_courseid,@v_coursename,@v_flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@v_courseid", updatecoursemaster.courseid);
                sqlCommand.Parameters.AddWithValue("@v_coursename", updatecoursemaster.coursename);
                sqlCommand.Parameters.AddWithValue("@v_flag", updatecoursemaster.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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
        public bool updatedepartmentmaster(updatedepartmentmasterEntity updatedepartmentmaster)
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
                sqlCommand.CommandText = "call updatedepartmentmaster(@v_departmentid,@v_departmentname,@v_flag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@v_departmentid", updatedepartmentmaster.departmentid);
                sqlCommand.Parameters.AddWithValue("@v_departmentname", updatedepartmentmaster.departmentname);
                sqlCommand.Parameters.AddWithValue("@v_flag", updatedepartmentmaster.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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
        public bool updatestudentreg(updatestudentregEntity updatestudentreg)
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
                sqlCommand.CommandText = "call updatestudentreg(@vsno,@vfirstname,@vlastname,@vregno,@vgenderid,@vdob,@vage,@vemail,@vaddress,@vpincode,@vcollegeid,@vcourseid,@vdepartment,@vpassword,@vconfirmpassword,@vflag)";
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@vsno", updatestudentreg.sno);
                sqlCommand.Parameters.AddWithValue("@vfirstname", updatestudentreg.firstname);
                sqlCommand.Parameters.AddWithValue("@vlastname", updatestudentreg.lastname);
                sqlCommand.Parameters.AddWithValue("@vregno", updatestudentreg.regno);
                sqlCommand.Parameters.AddWithValue("@vgenderid", updatestudentreg.genderid);
                sqlCommand.Parameters.AddWithValue("@vdob", updatestudentreg.dob);
                sqlCommand.Parameters.AddWithValue("@vage", updatestudentreg.age);
                sqlCommand.Parameters.AddWithValue("@vemail", updatestudentreg.email);
                sqlCommand.Parameters.AddWithValue("@vaddress", updatestudentreg.address);
                sqlCommand.Parameters.AddWithValue("@vpincode", updatestudentreg.pincode);
                sqlCommand.Parameters.AddWithValue("@vcollegeid", updatestudentreg.collegeid);
                sqlCommand.Parameters.AddWithValue("@vcourseid", updatestudentreg.courseid);
                sqlCommand.Parameters.AddWithValue("@vdepartment", updatestudentreg.department);
                sqlCommand.Parameters.AddWithValue("@vpassword", updatestudentreg.password);
                sqlCommand.Parameters.AddWithValue("@vconfirmpassword", updatestudentreg.confirmpassword);
                sqlCommand.Parameters.AddWithValue("@vflag", updatestudentreg.flag);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
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

