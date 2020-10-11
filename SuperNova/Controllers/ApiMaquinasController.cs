using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using System.Net;
using SuperNovaDataBase;
using SuperNova.Models;
using SuperNova.DTO;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace SuperNova.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiMaquinasController : ApiController
    {
   
        [HttpGet]
        public HttpResponseMessage getMaquina(int ID_MAQUINA_FACA)
        {
            Maquinas Maquinas = new Maquinas();
            try
            {
              
                MaquinasDTO GetMaquina = Maquinas.listMaquinas(ID_MAQUINA_FACA);
                List<MaquinasDTO> maq = new List<MaquinasDTO>();
                maq.Add(GetMaquina);

                if (GetMaquina != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, Maquinas = maq });
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
        public HttpResponseMessage getListMaquinas()
        {
            Maquinas Maquinas = new Maquinas();
            try
            {
                List<MaquinasDTO> listMaquina = Maquinas.listMaquinas();
                if (listMaquina != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { valid = true, Maquinas = listMaquina });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, new { valid = true, msg = "Não Existe Maquinas Cadastradas no Sistema" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

        [HttpPut]
        public HttpResponseMessage cadMaquina(TB_SN_MAQUINA_FACAS cadMaquinas)
        {
            Maquinas Maquinas = new Maquinas();
            try
            {
                
                if (cadMaquinas != null)
                {
                    Maquinas.cadMaquina(cadMaquinas);
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
        public HttpResponseMessage delMaquina(int ID_MAQUINA_FACA)
        {
            Maquinas Maquinas = new Maquinas();
            try
            {
                Maquinas.delMaquina(ID_MAQUINA_FACA);
                return Request.CreateResponse(HttpStatusCode.OK, new { valid = true });

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

    }
}