using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Services
{
    public class EventService : IEventService
    {
        public IEventRepository EventRepository { get; set; }

        public EventService(IEventRepository IEventRepository)
        {
            EventRepository = IEventRepository;
        }
        public async Task<bool> ValidateEvent(string id, string name)
        {
            var movie = await EventRepository.GetEventByIdAsync(id);

            if(movie == null)
                return false;

            if (movie._id != id)
                return false;

            if (movie.Name != name)
                return false;

            return true;
        }
    }
}
