using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Domain.Entites
{
    public class Promotion
    {
        [BsonId]
        public string _id { get; set; }
        public string Name { get; set; }
        public List<string> TheatreId { get; set; }
        public List<string> MovieId { get; set; }
        public List<int> DayOfWeek { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
    }

    public enum DiscountType
    {
        HIGHER,
        SMALLER,
        TOTAL
    }
}
