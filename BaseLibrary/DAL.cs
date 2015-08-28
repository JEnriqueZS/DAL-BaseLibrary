using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BaseLibrary
{
    /// <summary>
    /// Data Access Layer Class to connect with SQL Server
    /// </summary>
    public class DAL
    {
        /// <summary>
        /// Call a Stored procedure with no parameters and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTable(string storedProcedure)
        {
            return ConnectionTools._getDataTable(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure));
        }
        /// <summary>
        /// Call a Stored procedure with no parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTable(string storedProcedure, string connStr)
        {
            return ConnectionTools._getDataTable(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr));
        }
        /// <summary>
        /// Call a Stored procedure with parameters and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTable(string storedProcedure, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataTable(cmd);
        }
        /// <summary>
        /// Call a Stored procedure with parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTable(string storedProcedure, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataTable(cmd);
        }

        /// <summary>
        /// Execute the query with no parameters and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTableFromQuery(string query)
        {
            return ConnectionTools._getDataTable(ConnectionTools._createConnection(query, CommandType.Text));
        }
        /// <summary>
        /// Execute the query with no parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTableFromQuery(string query, string connStr)
        {
            return ConnectionTools._getDataTable(ConnectionTools._createConnection(query, CommandType.Text, connStr));
        }
        /// <summary>
        /// Execute the query with parameters and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTableFromQuery(string query, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataTable(cmd);
        }
        /// <summary>
        /// Execute the query with parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statement</returns>
        public static DataTable getDataTableFromQuery(string query, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataTable(cmd);
        }




        /// <summary>
        /// Call a Stored procedure with no parameters and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSet(string storedProcedure)
        {
            return ConnectionTools._getDataSet(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure));
        }
        /// <summary>
        /// Call a Stored procedure with no parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSet(string storedProcedure, string connStr)
        {
            return ConnectionTools._getDataSet(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr));
        }
        /// <summary>
        /// Call a Stored procedure with parameters and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSet(string storedProcedure, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataSet(cmd);
        }
        /// <summary>
        /// Call a Stored procedure with parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSet(string storedProcedure, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataSet(cmd);
        }

        /// <summary>
        /// Execute the query with no parameters and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSetFromQuery(string query)
        {
            return ConnectionTools._getDataSet(ConnectionTools._createConnection(query, CommandType.Text));
        }
        /// <summary>
        /// Execute the query with no parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSetFromQuery(string query, string connStr)
        {
            return ConnectionTools._getDataSet(ConnectionTools._createConnection(query, CommandType.Text, connStr));
        }
        /// <summary>
        /// Execute the query with parameters and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSetFromQuery(string query, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataSet(cmd);
        }
        /// <summary>
        /// Execute the query with parameters, specifying the connection string and getting the result set
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>The result of the stored procedure's SELECT statements</returns>
        public static DataSet getDataSetFromQuery(string query, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._getDataSet(cmd);
        }




        /// <summary>
        /// Call a Stored procedure with no parameters
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQuery(string storedProcedure)
        {
            return ConnectionTools._executeNonQuery(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure));
        }
        /// <summary>
        /// Call a Stored procedure with no parameters, specifying the connection string to use
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQuery(string storedProcedure, string connStr)
        {
            return ConnectionTools._executeNonQuery(ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr));
        }
        /// <summary>
        /// Call a Stored procedure with parameters
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQuery(string storedProcedure, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._executeNonQuery(cmd);
        }
        /// <summary>
        /// Call a Stored procedure with parameters specifying the connection string to use
        /// </summary>
        /// <param name="storedProcedure">Stored procedure name</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQuery(string storedProcedure, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(storedProcedure, CommandType.StoredProcedure, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._executeNonQuery(cmd);
        }

        /// <summary>
        /// Execute the query with no parameters
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQueryFromQuery(string query)
        {
            return ConnectionTools._executeNonQuery(ConnectionTools._createConnection(query, CommandType.Text));
        }
        /// <summary>
        /// Execute the query with no parameters specifying the connection string to use
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQueryFromQuery(string query, string connStr)
        {
            return ConnectionTools._executeNonQuery(ConnectionTools._createConnection(query, CommandType.Text, connStr));
        }
        /// <summary>
        /// Execute the query with parameters
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQueryFromQuery(string query, Dictionary<string, object> parameters)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._executeNonQuery(cmd);
        }
        /// <summary>
        /// Execute the query with parameters specifying the connection string to use
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <param name="connStr">Connection string to use</param>
        /// <returns>True if one or more rows were affected, other way False </returns>
        public static bool executeNonQueryFromQuery(string query, Dictionary<string, object> parameters, string connStr)
        {
            var cmd = ConnectionTools._createConnection(query, CommandType.Text, connStr);
            if (parameters != null) cmd = AddParameters(cmd, parameters);
            return ConnectionTools._executeNonQuery(cmd);
        }

        /// <summary>
        /// Add parameters to a command
        /// </summary>
        /// <param name="cmd">command</param>
        /// <param name="parameters">The stored procedure's params, the dictionary's Key and the stored procedure's parameter must have the same name</param>
        /// <returns>The command with the parameters added</returns>
        private static SqlCommand AddParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            foreach (var item in parameters)
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            return cmd;
        }
    }
}
