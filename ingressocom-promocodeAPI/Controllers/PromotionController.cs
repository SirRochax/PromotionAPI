using ingressocom_promocodeAPI.Domain.Entites;
using ingressocom_promocodeAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ingressocom_promocodeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<decimal> Get([FromBody]CartViewModel cart)
        {
            
            throw new NotImplementedException();
        }
    }
}
