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
        public string TheatreId { get; set; }
        public string MovieId { get; set; }
        public List<DaysOfWeek> DaysOfWeek { get; set; }
        public decimal Discount { get; set; }
        public DiscountType DiscountType { get; set; }
    }

    public enum DiscountType
    {
        HIGHER,
        SMALLER,
        TOTAL
    }

    public class DaysOfWeek
    {
        public int Day { get; set; }
    }
}
