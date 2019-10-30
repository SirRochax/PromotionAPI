using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Repositories.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories
{
    public class PromocodeRepository : IPromocodeRepository
    {
        public async Task<Promocode> GetPromocodeByCodeAsync(string code)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("PromotionAPI");
            var coll = db.GetCollection<Promocode>("Promocodes");

            var promocode = await coll.Find(c => c.Code == code).FirstOrDefaultAsync();

            return promocode;
        }
    }
}
