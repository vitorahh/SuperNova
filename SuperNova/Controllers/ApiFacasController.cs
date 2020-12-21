using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Net;
using SuperNova.DTO;
using SuperNova.Models;
using System.Web.Mvc;
using SuperNovaDataBase;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpPatchAttribute = System.Web.Http.HttpPatchAttribute;

namespace SuperNova.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiFacasController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage getFaca(int ID_FACA)
        {
            Facas Fc = new Facas();
            try
            {
                FacasDTO getFaca = Fc.getFaca(ID_FACA);
                if (getFaca != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, Facas = getFaca });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, msg = "Não Existe Facas Cadastradas no Sistema" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage getListFacas(FacasDTO filtroFacas)
        {
            Facas Fc = new Facas();
            try
            {
                List<FacasDTO> listFacas = Fc.listFacas(filtroFacas);
                if (listFacas != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, Facas = listFacas });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, msg = "Não Existe Facas Cadastradas no Sistema" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPut]
        public HttpResponseMessage cadFaca(TB_SN_FACAS cadFacas)
        {
            Facas fc = new Facas();
            try
            {
                if (cadFacas != null)
                {
                    fc.cadFaca(cadFacas);
                    return Request.CreateResponse(HttpStatusCode.Created, new { valid = true });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, msg = "Não foi possivel efetuar o cadastro, verifique os campos digitados." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPatch]
        public HttpResponseMessage attFaca(TB_SN_FACAS attFacas)
        {
            Facas fc = new Facas();
            try
            {
                if (attFacas != null)
                {
                    fc.attFaca(attFacas);
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, msg = "Não foi possivel atualizar a faca, verifique os campos digitados." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, msg = ex.Message });
            }
        }

        [HttpDelete]
        public HttpResponseMessage delFaca(int ID_FACA)
        {
            Facas Fc = new Facas();
            try
            {
                Fc.delFacas(ID_FACA);
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = false, msg = ex.Message });
            }
        }
    }
}