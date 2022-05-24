using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sovran.Logger.Sql
{
    /// <summary>
    /// SqlLogger is the main RDS logging service. Intended to log errors and use case flow activity.
    /// </summary>
    internal class SqlLogger
    {
        private string _connStr;
        private string _serviceName;

        public SqlLogger(string conn, string serviceName)
        {
            _connStr = conn;
            _serviceName = serviceName;
        }

        /// <summary>
        /// LogActivity is a high-level public accessor in order to delineate an activity of a use-case is taking place.
        /// </summary>
        /// <param name="message"></param>
        public async void LogActivity(string message)
        {
            Log(message, "ACTIVITY");
        }
        /// <summary>
        /// LogError is a high-level public accessor in order to delineate an exception was caught, logged and handled.
        /// </summary>
        /// <param name="message"></param>
        public async void LogError(string message)
        {
            Log(message, "ERROR");
        }

        /// <summary>
        /// Privately accessed method used to log all messages passed to the logger class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private async void Log(string message, string type)
        {
            var conn = GetConn();
            try
            {
                using (conn)
                {
                    conn.Open();
                    var parameters = new
                    {
                        ServiceName = _serviceName,
                        Type = type,
                        Message = message
                    };

                    string query = @"INSERT INTO audit_logs
                                                 (serviceName,
                                                  type,
                                                  message)
                                            VALUES(
                                                  @ServiceName,
                                                  @Type,
                                                  @Message)";
                    await conn.ExecuteAsync(query, parameters);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Getter method to generate a MySQL connection from a given string (i.e. the _connStr attribute).
        /// </summary>
        /// <returns></returns>
        private MySqlConnection GetConn()
        {
            return new MySqlConnection(_connStr);
        }
    }
}
