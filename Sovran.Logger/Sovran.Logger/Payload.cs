using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sovran.Logger
{
    /// <summary>
    /// Payload class used in logging JSON documents to MongoDb payloads collection.
    /// </summary>
    internal class Payload
    {
        /// <summary>
        /// The source name delineates where this payload comes from (i.e. Payment, Catalog, Account).
        /// </summary>
        public string sourceName;
        /// <summary>
        /// Payload is of generic object type in order to accept any kind as a logged payload.
        /// </summary>
        public object payload;
    }
}
