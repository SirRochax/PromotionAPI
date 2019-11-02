using ingressocom_promocodeAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Services.Interface
{
    public interface ITheatreService
    {
        Task<bool> ValidateTheatre(string id, string name);
    }
}
