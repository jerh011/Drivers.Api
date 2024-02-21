using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Drivers.Api.Models;

    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get; set;} = string.Empty;
        
        [BsonElement("NAME")]
        public string Name {get;set;} = string.Empty;
        [BsonElement("Number")]
        public int Number {get; set;}
        [BsonElement("TEAM")]
        public string Team {get; set;} = string.Empty;
    }
