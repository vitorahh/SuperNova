using SuperNova.DTO;
using SuperNovaDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperNova.Models
{
    public class Usuarios
    {
        SUPER_NOVAEntities db = new SUPER_NOVAEntities("SUPER_NOVA");

        public void InsereUsuario(TB_SN_USUARIOS usuario)
        {
            try
            {
                db.TB_SN_USUARIOS.Add(usuario);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SearchUser(string DS_LOGIN)
        {
            try
            {
                TB_SN_USUARIOS usuario = new TB_SN_USUARIOS();
                usuario = db.TB_SN_USUARIOS.FirstOrDefault(c => c.DS_LOGIN_USUARIO == DS_LOGIN);
                if (usuario != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioDTO Login(TB_SN_USUARIOS usuario)
        {
            return null;
        }
    }
}