using System;
using System.Data.SqlClient;
using System.Data;

namespace BaseLibrary
{
    /// <summary>
    /// Methods to connect to SQL Server
    /// </summary>
    internal class ConnectionTools
    {
        static string getConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnStr"].ToString();

        /// <summary>
        /// Get the connection object
        /// </summary>
        /// <param name="text">The query or Stored procedure to execute</param>
        /// <param name="type">Define if it's a query or a stored procedure</param>
        /// <returns>The connection</returns>
        internal static SqlCommand _createConnection(string text, CommandType type)
        {
            SqlCommand Command;
            SqlConnection Connection = new SqlConnection(getConnectionStr);
            Command = new SqlCommand(text, Connection);
            Command.CommandType = type;
            return Command;
        }
        /// <summary>
        /// Get the connection object
        /// </summary>
        /// <param name="text">The query or Stored procedure to execute</param>
        /// <param name="type">Define if it's a query or a stored procedure</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The connection</returns>
        internal static SqlCommand _createConnection(string text, CommandType type, string connStr)
        {
            SqlCommand Command;
            SqlConnection Connection = new SqlConnection(connStr);
            Command = new SqlCommand(text, Connection);
            Command.CommandType = type;
            return Command;
        }
        /// <summary>
        /// Get the result of the SELECT statement in a DataTable
        /// </summary>
        /// <param name="Command">The command to open</param>
        /// <returns>The DataTable with the SELECT statement</returns>
        internal static DataTable _getDataTable(SqlCommand Command)
        {
            DataTable dt = new DataTable();
            try
            {
                Command.Connection.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = Command;
                Adapter.Fill(dt);
            }
            catch (Exception ex) { ex.logThisException(); }
            finally
            {
                Command.Connection.Dispose();
                Command.Dispose();
            }
            return dt;
        }
        /// <summary>
        /// Get the result of the SELECT statements in a DataSet
        /// </summary>
        /// <param name="Command">The command to open</param>
        /// <returns>The DataSet with the SELECT statements</returns>
        internal static DataSet _getDataSet(SqlCommand Command)
        {
            DataSet ds = new DataSet();
            try
            {
                Command.Connection.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter();
                Adapter.SelectCommand = Command;
                Adapter.Fill(ds);
            }
            catch (Exception ex) { ex.logThisException(); }
            finally
            {
                Command.Connection.Dispose();
                Command.Dispose();
            }
            return ds;
        }
        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="Command">The command to open</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        internal static bool _executeNonQuery(SqlCommand Command)
        {
            try
            {
                Command.Connection.Open();
                return (Command.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (Exception ex) { ex.logThisException(); return false; }
            finally
            {
                Command.Connection.Dispose();
                Command.Dispose();
            }
        }
    }
}