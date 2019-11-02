using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services.Interface;
using ingressocom_promocodeAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Services
{
    public class PromotionService : IPromotionService
    {
        public IPromotionRepository PromotionRepository { get; set; }

        public PromotionService(IPromotionRepository _PromotionRepository)
        {
            PromotionRepository = _PromotionRepository;
        }

        public async Task<bool> ValidatePromotionConditions(CartViewModel cart, string promotionId)
        {
            var boolean,  = false;
            var promotion = await PromotionRepository.GetPromotionByIdAsync(promotionId);

            if (promotion.MovieId != null)
                foreach (string movieId in promotion.MovieId)
                    if (movieId == cart.Session.Event._id)
                    {
                        boolean = true;
                        break;
                    }

            foreach (string theatreId in promotion.TheatreId)
                if (promotion.TheatreId != null && theatreId == cart.Session.Theatre._id)
                {
                    boolean = true;
                    break;
                }


            return boolean;
        }
    }
}
