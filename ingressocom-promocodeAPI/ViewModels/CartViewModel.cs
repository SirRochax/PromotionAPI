using ingressocom_promocodeAPI.Domain.Entites;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.ViewModels
{
    public class CartViewModel
    {
        [BsonId]
        public string _id { get; set; }
        public DateTime Date { get; set; }
        public Decimal TotalPrice { get; set; }
        public Session Session { get; set; }
        public string Promocode { get; set; }
    }

    public class Session
    {
        public Event Event { get; set; }
        public DateTime Date { get; set; }
        public Theatre Theatre { get; set; }
        public List<Ticket> Tickets { get; set; }
    }

    public class Ticket
    {
        [BsonId]
        public string _id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
    }
}
