using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sovran.Logger.Mongo
{
    /// <summary>
    /// Payload logging class. Used in accepting objects to post to MongoDb collection.
    /// </summary>
    internal class MongoLogger
    {
        private string _connStr;
        private readonly MongoClient _client;
        private readonly MongoClientSettings _clientSettings;
        private IMongoCollection<Payload> _payloads;
        private IMongoDatabase _db;
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoLogger"/> class.
        /// </summary>
        /// <param name="conn">Accepts connection string for logging.</param>
        public MongoLogger(string conn)
        {
            _connStr = conn;
            _clientSettings = MongoClientSettings.FromConnectionString(_connStr);
            _clientSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
        }

        /// <summary>
        /// Logs the specified payload.
        /// </summary>
        /// <param name="payload">Generic object payload.</param>
        /// <param name="source">Service this payload is coming from (i.e. Payment, Catalog, etc.) .</param>
        /// <exception cref="System.Exception">Logger error" + ex.Message</exception>
        public async void Log(object payload, string source)
        {
            try
            {
                var serializedPayload = JsonConvert.SerializeObject(payload);
                var payloadObj = new Payload
                {
                    sourceName = source,
                    payload = serializedPayload
                };
                var client = new MongoClient(_clientSettings);
                var database = client.GetDatabase("sovran");
                _payloads = database.GetCollection<Payload>("payloads");
                await _payloads.InsertOneAsync(payloadObj);
            }
            catch (Exception ex)
            {
                throw new Exception("Logger error" + ex.Message);
            }
        }
    }
}
