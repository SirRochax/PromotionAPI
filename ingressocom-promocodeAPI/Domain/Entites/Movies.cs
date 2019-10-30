using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Domain.Entites
{
    public class Movies
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
