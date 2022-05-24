using Sovran.Logger.Mongo;
using Sovran.Logger.Sql;
using System.Text.Json;

namespace Sovran.Logger
{
    /// <summary>
    /// SovranLogger is the primary class for this package.
    /// 
    /// Allows for payload logging to NoSQL database and activity logging to SQL.<br></br><br></br>
    /// </summary>
    public sealed class SovranLogger : ISovranLogger
    {
        private readonly string _loggerName;
        private readonly MongoLogger _mongo;
        private readonly SqlLogger _sql;

        /// <summary>
        /// Constructor requires the following.<br></br>
        /// 
        /// - <b>loggerName</b>: Logger hosting service name. (e.g. 'payment' / 'inventory' / etc.)<br></br>
        ///     
        /// 
        /// - <b>mongoDbConn</b>: MongoDb connection string. <br></br>
        /// - <b>sqlConn</b>: MySQL connection string.
        /// </summary>
        /// <param name="loggerName"></param>
        /// <param name="mongoDbConn"></param>
        /// <param name="sqlConn"></param>
        public SovranLogger(string loggerName, string mongoDbConn, string sqlConn)
        {
            _loggerName = loggerName;
            _mongo = new MongoLogger(mongoDbConn);
            _sql = new SqlLogger(sqlConn, loggerName);
        }

        /// <summary>
        /// Pass object for payload logging to NoSQL service.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public async void LogPayload(object payload)
        {
            _mongo.Log(payload, _loggerName);
        }

        /// <summary>
        /// Log's activity (i.e. the flow of a component) through passed messages.
        /// </summary>
        /// <param name="message"></param>
        public void LogActivity(string message)
        {
            _sql.LogActivity(message);
        }
        /// <summary>
        /// Log's errors encountered during execution of a component method.
        /// </summary>
        /// <param name="message"></param>
        public void LogError(string message)
        {
            _sql.LogError(message);
        }

    }
}