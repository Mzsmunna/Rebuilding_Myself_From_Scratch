using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mongo.Configs
{
    public class IssueConfiguration : IEntityConfiguration
    {
        private readonly string _collectionName = "Issue";

        public string Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Issue)))
            {
                BsonClassMap.RegisterClassMap<Issue>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapProperty(x => x.Id).SetElementName("_id");
                    map.GetMemberMap(x => x.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));
                });

                return _collectionName;
            }

            return string.Empty;
        }
    }
}
