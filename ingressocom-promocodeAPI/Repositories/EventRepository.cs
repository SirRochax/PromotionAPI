using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories
{
    public class EventRepository : IEventRepository
    {

        public async Task<Event> GetEventByIdAsync(string id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("PromotionAPI");
            var coll = db.GetCollection<Event>("Events");

            var movie = await coll.Find(c => c._id == id).FirstOrDefaultAsync();

            return movie;
        }

    }
}
