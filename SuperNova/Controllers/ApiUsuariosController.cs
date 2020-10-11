using SuperNova.Models;
using SuperNovaDataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Security;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace SuperNova.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiUsuariosController : ApiController
    {
        [HttpPut]
        public HttpResponseMessage cadUsuario()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                HttpPostedFile foto = httpRequest.Files["DS_IMG_USUARIO"];
                var form = httpRequest.Form;

                string curDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());

                string pathRandon = DateTime.Now.ToString().Replace("/", string.Empty).Replace(":", string.Empty).Replace(" ", string.Empty); ;
                string path = curDir + "\\Imagens\\Usuarios\\"+ pathRandon + foto.FileName;
                foto.SaveAs(path);

                TB_SN_USUARIOS cadUsuario = new TB_SN_USUARIOS();

                cadUsuario.DS_NOME_USUARIO = form["DS_NOME_USUARIO"];
                cadUsuario.DS_LOGIN_USUARIO = form["DS_LOGIN_USUARIO"];
                cadUsuario.DS_PASSWORD_USUARIO = Crypto.HashPassword(form["DS_PASSWORD_USUARIO"]); 
                cadUsuario.FL_STATUS_USUARIO = true;
                cadUsuario.DS_IMG_USUARIO = path;

                Usuarios usr = new Usuarios();

                bool user = usr.SearchUser(cadUsuario.DS_LOGIN_USUARIO);
                if (!user)
                {
                    usr.InsereUsuario(cadUsuario);
                    return Request.CreateResponse(HttpStatusCode.Created, new { valid = true });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { valid = false, msg = "Ja existe um usuario cadastrado com esse login!" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { valid = false, msg = ex.Message });
            }
        }

    }
}