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
    public class UserConfiguration: IEntityConfiguration
    {
        private readonly string _collectionName = "User";

        public string Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(User)))
            {
                BsonClassMap.RegisterClassMap<User>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapProperty(x => x.Id).SetElementName("_id");
                    map.GetMemberMap(x => x.Id).SetSerializer(new StringSerializer(BsonType.ObjectId));

                    map.MapProperty(x => x.ClientId).SetElementName("ClientId");
                    map.GetMemberMap(x => x.ClientId).SetSerializer(new StringSerializer(BsonType.ObjectId));

                    map.MapProperty(x => x.AdminUserId).SetElementName("AdminUserId");
                    map.GetMemberMap(x => x.AdminUserId).SetSerializer(new StringSerializer(BsonType.ObjectId));

                    map.MapProperty(x => x.CreatedBy).SetElementName("CreatedBy");
                    map.GetMemberMap(x => x.CreatedBy).SetSerializer(new StringSerializer(BsonType.ObjectId));

                    map.MapProperty(x => x.ModifiedBy).SetElementName("ModifiedBy");
                    map.GetMemberMap(x => x.ModifiedBy).SetSerializer(new StringSerializer(BsonType.ObjectId));
                });
            }

            //if (!BsonClassMap.IsClassMapRegistered(typeof(Guide)))
            //{
            //    BsonClassMap.RegisterClassMap<Guide>(child1 =>
            //    {
            //        child1.AutoMap();
            //        child1.SetIgnoreExtraElements(true);
            //    });
            //}

            return _collectionName;
        }
    }
}
