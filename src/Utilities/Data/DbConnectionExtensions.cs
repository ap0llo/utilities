using System;
using System.Data;
using System.Data.Common;

namespace Grynwald.Utilities.Data
{
    /// <summary>
    /// Extension methods for <see cref="IDbConnection"/>.
    /// </summary>
    public static class DbConnectionExtensions
    {
        /// <summary>
        /// Executes the specified query and returns the number of affected rows.
        /// </summary>
        public static int ExecuteNonQuery(this IDbConnection connection, string sql, params (string name, object value)[] parameters)
        {
            var command = connection.CreateCommand(sql, parameters);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// Executes the specified query and converts the value of the first column of
        /// the first returned row to the specified type <typeparamref name="T"/>.
        /// </summary>
        public static T ExecuteScalar<T>(this IDbConnection connection, string sql, params (string name, object value)[] parameters)
        {
            var command = connection.CreateCommand(sql, parameters);
            return (T)Convert.ChangeType(command.ExecuteScalar(), typeof(T));
        }

        /// <summary>
        /// Determines if a table with the specified name exists in the underlying database
        /// </summary>
        public static bool TableExists(this IDbConnection connection, string tableName)
        {
            try
            {
                return connection.ExecuteScalar<int>($"SELECT 1 FROM {tableName}") == 1;
            }
            catch (DbException)
            {
                return false;
            }
        }


        static IDbCommand CreateCommand(this IDbConnection connection, string sql, params (string name, object value)[] parameters)
        {
            var command = connection.CreateCommand();
            command.CommandText = sql;

            foreach (var (name, value) in parameters)
            {
                command.AddParameter(name, value);
            }

            return command;
        }

        static void AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}
