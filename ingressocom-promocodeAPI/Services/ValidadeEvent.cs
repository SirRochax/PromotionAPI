using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Services
{
    public class ValidadeEvent : IValidateEvent
    {
        public Task<Event> ValidateById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
