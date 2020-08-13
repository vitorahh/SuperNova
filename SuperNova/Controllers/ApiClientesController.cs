using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;
using System.Net;
using SuperNovaDataBase;

namespace SuperNova.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiClientesController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public HttpResponseMessage getcliente()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, msg = "Amigos Estou aqui" }); ;
        }

    }
}