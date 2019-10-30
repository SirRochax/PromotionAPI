using ingressocom_promocodeAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Repositories.Interface
{
    public interface IEventRepository
    {
        Task<Event> GetEventByIdAsync(string id);
    }
}
