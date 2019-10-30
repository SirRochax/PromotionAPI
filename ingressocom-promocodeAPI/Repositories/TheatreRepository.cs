using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories
{
    public class TheatreRepository : ITheatreRepository
    {
        public async Task<Theatre> GetTheatreByIdAsync(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("PromotionAPI");
            var coll = db.GetCollection<Theatre>("Theatres");

            var theatre = await coll.Find(c => c._id == id).FirstOrDefaultAsync();

            return theatre;
        }
    }
}
