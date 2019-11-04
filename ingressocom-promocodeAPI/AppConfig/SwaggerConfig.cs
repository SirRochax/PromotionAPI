using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ingressocom_promocodeAPI.AppConfig
{
    public class SwaggerConfig : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}
