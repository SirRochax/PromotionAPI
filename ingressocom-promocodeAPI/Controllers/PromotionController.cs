using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services.Interface;
using ingressocom_promocodeAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        public IEventService EventService { get; set; }
        public ITheatreService TheatreService { get; set; }
        public IPromotionService PromotionService { get; set; }
        public IPromocodeRepository PromocodeRepository { get; set; }

        public PromotionController(IEventService _EventService, ITheatreService _TheatreService, IPromotionService _PromotionService, IPromocodeRepository _PromocodeRepository)
        {
            EventService = _EventService;
            TheatreService = _TheatreService;
            PromotionService = _PromotionService;
            PromocodeRepository = _PromocodeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get([FromBody]CartViewModel cart)
        {
            string response = null;

            if (cart != null)
            {
                var movieValidation = await EventService.ValidateEvent(cart.Session.Event._id, cart.Session.Event.Name);

                if (!movieValidation)
                    return NotFound("Filme Inválido!");

                var theatreValidation = await TheatreService.ValidateTheatre(cart.Session.Theatre._id, cart.Session.Theatre.Name);

                if (!theatreValidation)
                    return NotFound("Cinema Inválido!");

                var promocode = await PromocodeRepository.GetPromocodeByCodeAsync(cart.Promocode);

                if (promocode == null)
                    return NotFound("Promocode Inválido!");

                var promotionValidation = await PromotionService.ValidatePromotionConditions(cart, promocode.PromotionId);

                if (!promotionValidation)
                    return ("A compra não atende as regras da promoção!");

                var discount = await PromotionService.GetPromotionDiscount(cart, promocode.PromotionId);

                response = string.Format($"Desconto realizado: R$ {discount}", discount);
            }
            else
            {
                return NotFound();
            }

            return response;
        }
    }
}