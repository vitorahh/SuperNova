using SuperNova.DTO;
using SuperNova.Models;
using SuperNovaDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace SuperNova.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiTipoFacasController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage getTipoFacas(int ID_TIPO_FACAS)
        {
            TipoFacas TipoFacas = new TipoFacas();
            try
            {

                TipoFacasDTO GetTipoFaca = TipoFacas.listTipoFacas(ID_TIPO_FACAS);
                List<TipoFacasDTO> TipoFaca = new List<TipoFacasDTO>();
                TipoFaca.Add(GetTipoFaca);

                if (GetTipoFaca != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, TipoFacas = TipoFaca });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, msg = "ID Incorreto, Maquina não encontrada" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public HttpResponseMessage getListTipoFacas()
        {
            TipoFacas TipoFacas = new TipoFacas();
            try
            {
                List<TipoFacasDTO> listTipoFacas = TipoFacas.listTipoFacas();
                if (listTipoFacas != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, TipoFacas = listTipoFacas });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, msg = "Não Existe Maquinas Cadastradas no Sistema" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPut]
        public HttpResponseMessage cadTipoFacas(TB_SN_TIPO_FACAS cadTipoFacas)
        {
            TipoFacas TipoFacas = new TipoFacas();
            try
            {

                if (TipoFacas != null)
                {
                    TipoFacas.cadTipoFacas(cadTipoFacas);
                    return Request.CreateResponse(HttpStatusCode.Created, new { valid = true });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { valid = false, msg = "Não foi possivel efetuar o cadastro, verifique os campos digitados." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpDelete]
        public HttpResponseMessage delTipoFacas(int ID_TIPO_FACAS)
        {
            TipoFacas TipoFacas = new TipoFacas();
            try
            {
                TipoFacas.delTipoFacas(ID_TIPO_FACAS);
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }
    }
}