using ingressocom_promocodeAPI.Domain.Entites;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories.Interface
{
    public interface IPromotionRepository
    {
        Task<Promotion> GetPromotionByIdAsync(string id);
    }
}
