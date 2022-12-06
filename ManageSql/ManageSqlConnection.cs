﻿using System;
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



    }
}

