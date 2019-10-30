using ingressocom_promocodeAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories.Interface
{
    public interface IPromocodeRepository
    {
        Task<Promocode> GetPromocodeByCodeAsync(string code);
    }
}
