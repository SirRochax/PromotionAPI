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
            var promotionIsValid = false;
            var EventIsValid = false;
            var TheatreIsValid = false;
            var DateIsValid = false;

            var promotion = await PromotionRepository.GetPromotionByIdAsync(promotionId);

            //valida caso haja regra da promocao por Filme
            if (promotion.MovieId != null)
            {
                foreach (string movieId in promotion.MovieId)
                    if (movieId == cart.Session.Event._id)
                    {
                        EventIsValid = true;
                        break;
                    }
            }
            else
            {
                EventIsValid = true;
            }

            //valida caso haja regra da promocao por filme
            if (promotion.TheatreId != null)
            {
                foreach (string theatreId in promotion.TheatreId)
                    if (theatreId == cart.Session.Theatre._id)
                    {
                        TheatreIsValid = true;
                        break;
                    }
            }
            else
            {
                TheatreIsValid = true;
            }

            //valida caso haja regra da promocao por Dia da semana
            if (promotion.DayOfWeek != null)
            {
                var sessionDayOfWeek = cart.Session.Date.DayOfWeek;

                foreach (int dayOfWeek in promotion.DayOfWeek)
                    if (dayOfWeek == Convert.ToInt32(sessionDayOfWeek))
                    {
                        DateIsValid = true;
                        break;
                    }
            }
            else
            {
                DateIsValid = true;
            }

            //verifica se todas as regras da promocao foram contempladas
            if (EventIsValid && TheatreIsValid && DateIsValid)
                promotionIsValid = true;

            return promotionIsValid;
        }

        public async Task<decimal> GetPromotionDiscount(CartViewModel cart, string promotionId)
        {
            decimal ticketValue = 0;
            decimal finalDiscount = 0;

            var promotion = await PromotionRepository.GetPromotionByIdAsync(promotionId);

            switch (Convert.ToInt32(promotion.DiscountType))
            {
                case 0:

                    foreach (Ticket ticket in cart.Session.Tickets)
                    {
                        if (ticketValue < ticket.Price)
                            ticketValue = ticket.Price;
                    }

                    if (promotion.Discount > ticketValue)
                    {
                        finalDiscount = ticketValue;
                        break;
                    }

                    finalDiscount = promotion.Discount;
                    break;

                case 1:

                    ticketValue = cart.Session.Tickets[0].Price;

                    foreach (Ticket ticket in cart.Session.Tickets)
                    {
                        if (ticketValue > ticket.Price)
                            ticketValue = ticket.Price;
                    }

                    if (promotion.Discount > ticketValue)
                    {
                        finalDiscount = ticketValue;
                        break;
                    }

                    finalDiscount = promotion.Discount;
                    break;

                case 2:

                    decimal totalPrice = 0;

                    foreach (Ticket ticket in cart.Session.Tickets)
                    {
                        totalPrice += ticket.Price;
                    }

                    if (promotion.Discount > totalPrice)
                    {
                        finalDiscount = totalPrice;
                        break;
                    }

                    finalDiscount = promotion.Discount;
                    break;
            }

            return finalDiscount;
        }
    }
}
