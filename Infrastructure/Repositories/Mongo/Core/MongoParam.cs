using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mongo.Core
{
    public class MongoParam : BsonDocument
    {
        public BsonDocument Parameters
        {
            get
            {
                return this.bsonDocument;
            }
        }
        private readonly BsonDocument bsonDocument;
        public MongoParam()
        {
            bsonDocument = new BsonDocument();
        }

        public void AddParameter(string parameterName, string value)
        {
            bsonDocument.Add(new BsonElement(parameterName, value));
        }

        public void AddParameter(string parameterName, string value, bool IsIdentity)
        {
            if (IsIdentity)
            {
                bsonDocument.Add(new BsonElement(parameterName, ObjectId.Parse(value)));
            }
            else
                AddParameter(parameterName, value);
        }

        public void AddParameter(string parameterName, bool value)
        {
            bsonDocument.Add(new BsonElement(parameterName, value));
        }

    }
}
