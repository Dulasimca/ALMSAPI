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



        //GetFlashNewsEntry
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
                    sqlCommand.CommandText = "select * from geteditionmaster()";
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
                sqlCommand.CommandText = "select * from book_master";
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

public bool Insertlibrarienregister(librarienregisterEntity librarienregisterEntity)
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
    }
}