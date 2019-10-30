using ingressocom_promocodeAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories.Interface
{
    public interface IPromotionRepository
    {
        Task<Promotion> GetPromocodeByIdAsync(string id);
    }
}
