using ingressocom_promocodeAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ingressocom_promocodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<decimal> Get([FromBody]TheaterViewModel myViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
