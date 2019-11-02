using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Services
{
    public class TheatreService : ITheatreService
    {
        public ITheatreRepository TheatreRepository { get; set; }

        public TheatreService(ITheatreRepository ITheatreRepository)
        {
            TheatreRepository = ITheatreRepository;
        }

        public async Task<bool> ValidateTheatre(string id, string name)
        {
            var theatre = await TheatreRepository.GetTheatreByIdAsync(id);

            if (theatre._id != id)
                return false;


            if (theatre.Name != name)
                return false;

            return true;
        }
    }
}
