using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.SQLConnection.SQLConnectionGET;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace appSERP.appCode.SQL.ADO
{

    public class clsADO : IclsADO
    {
        private readonly string connString;
        private ILog _ILog;
        public clsADO(ILog log)
        {
            _ILog = log;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["dbERPConnectionString"].ConnectionString;
        }

        // Fill Data Table
        public DataTable funFillDataTable(string pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null)
        {
            try
            {
                // Connection
                //clsConnection.funGetSQLConnection();
                using (var sqlConn = new SqlConnection(connString))
                {
                    // Command
                    SqlCommand vCmd = new SqlCommand(pCmdText);
                    vCmd.CommandTimeout = 0;
                    //vCmd.Connection = clsConnection.vSQLConnection;
                    vCmd.Connection = sqlConn;
                    vCmd.CommandType = CommandType.StoredProcedure;
                    // Parameter
                    if (pLstParam != null)
                        foreach (SqlParameter vSQLParam in pLstParam) { vCmd.Parameters.Add(vSQLParam); }
                    // Open Connection
                    //funOpenConnection();
                    sqlConn.Open();

                    // SQL ADAP - DT - RESULT
                    SqlDataAdapter vSQLAdap = new SqlDataAdapter(vCmd);
                    // Data Table
                    DataTable vDtResult = new DataTable();
                    vSQLAdap.Fill(vDtResult);

                    sqlConn.Close();
                    //funCloseConnection();


                    // Return Result
                    return vDtResult;
                }
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.Message.ToString());

                return new DataTable();
            }
        }

        // Execute Scalar
        public object funExecuteScalar(String pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null)
        {
            try
            {
                // Connection
                //clsConnection.funGetSQLConnection();
                // Command

                using (var sqlConn = new SqlConnection(connString))
                {
                    SqlCommand vCmd = new SqlCommand(pCmdText);
                    vCmd.Connection = sqlConn;

                    //vCmd.Connection = clsConnection.vSQLConnection;
                    vCmd.CommandType = CommandType.StoredProcedure;


                    // Parameter
                    foreach (SqlParameter vSQLParam in pLstParam) { vCmd.Parameters.Add(vSQLParam); }
                    // Open Connection
                    //funOpenConnection();
                    //clsConnection.vSQLConnection.Open();
                    sqlConn.Open();
                    // Execute Non Query
                    var x = vCmd.ExecuteScalar();
                    // funCloseConnection();
                    //clsConnection.vSQLConnection.Close();
                    sqlConn.Close();
                    return x;
                }

            }
            catch (Exception ex)
            {             
                _ILog.LogException(ex.Message.ToString());

                return ex.Message.ToString();
            }
        }

        public DataTable funFillDataTableQuery(string queryText, List<SqlParameter> pLstParam = null)
        {
            try
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    // Command
                    SqlCommand vCmd = new SqlCommand(queryText);
                    vCmd.CommandTimeout = 0;
                    vCmd.Connection = sqlConn;
                    vCmd.CommandType = CommandType.Text;
                    // Parameter
                    if (pLstParam != null)
                        foreach (SqlParameter vSQLParam in pLstParam) { vCmd.Parameters.Add(vSQLParam); }   
                    sqlConn.Open();
                    SqlDataAdapter vSQLAdap = new SqlDataAdapter(vCmd);
                    // Data Table
                    DataTable vDtResult = new DataTable();
                    vSQLAdap.Fill(vDtResult);

                    sqlConn.Close();
                    return vDtResult;
                }
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.Message.ToString());

                return new DataTable();
            }
        }
        // Execute Non Query
        public void funExecuteNonQuery(String pCmdText, List<SqlParameter> pLstParam = null, string pFrmText = null)
        {
            try
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    // Connection
                    //clsConnection.funGetSQLConnection();
                    // Command
                    SqlCommand vCmd = new SqlCommand(pCmdText);
                    vCmd.CommandTimeout = 0;
                    //vCmd.Connection = clsConnection.vSQLConnection;
                    vCmd.Connection = sqlConn;
                    vCmd.CommandType = CommandType.StoredProcedure;
                    // Parameter
                    foreach (SqlParameter vSQLParam in pLstParam) { vCmd.Parameters.Add(vSQLParam); }
                    // Open Connection
                    //funOpenConnection();
                    sqlConn.Open();
                    // Execute Non Query
                    vCmd.ExecuteNonQuery();
                    //funCloseConnection();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                _ILog.LogException(ex.Message.ToString());

            }
        }

        // Open Connection
        public void funOpenConnection()
        {
            // Check State
            if (clsConnection.vSQLConnection.State == ConnectionState.Closed || clsConnection.vSQLConnection.State == ConnectionState.Connecting)
            {
                // Open Connection
                clsConnection.vSQLConnection.Open();}
        }

        public void funCloseConnection()
        {
            // Check State
            if (clsConnection.vSQLConnection.State == ConnectionState.Open || clsConnection.vSQLConnection.State == ConnectionState.Connecting)
            {
                // Open Connection
                clsConnection.vSQLConnection.Close();
            }
        }
    }
}