using SuperNova.DTO;
using SuperNovaDataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperNova.Models
{
    public class Maquinas
    {
        SUPER_NOVAEntities db = new SUPER_NOVAEntities("SUPER_NOVA");
        public List<MaquinasDTO> listMaquinas()
        {
            try
            {
                List<MaquinasDTO> listMaquinas = (from Maquinas in db.TB_SN_MAQUINA_FACAS orderby Maquinas.ID_MAQUINA_FACA descending select new MaquinasDTO
                   {
                        ID_MAQUINA_FACA = Maquinas.ID_MAQUINA_FACA
                       ,DS_MAQUINA_FACA = Maquinas.DS_MAQUINA_FACA
                   }).ToList<MaquinasDTO>();
                return listMaquinas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MaquinasDTO listMaquinas(int ID_MAQUINA_FACA)
        {
            try
            {

               

                TB_SN_MAQUINA_FACAS entity = db.TB_SN_MAQUINA_FACAS.First(x => x.ID_MAQUINA_FACA == ID_MAQUINA_FACA);
                MaquinasDTO GetMaquina = new MaquinasDTO();
                GetMaquina.ID_MAQUINA_FACA = entity.ID_MAQUINA_FACA;
                GetMaquina.DS_MAQUINA_FACA = entity.DS_MAQUINA_FACA;

                return GetMaquina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cadMaquina(TB_SN_MAQUINA_FACAS cadMaquina)
        {
            try
            {
                db.TB_SN_MAQUINA_FACAS.Add(cadMaquina);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delMaquina(int ID_MAQUINA_FACA)
        {
            try
            {
                TB_SN_MAQUINA_FACAS entity = db.TB_SN_MAQUINA_FACAS.First(x => x.ID_MAQUINA_FACA == ID_MAQUINA_FACA);
                db.TB_SN_MAQUINA_FACAS.Attach(entity);
                db.TB_SN_MAQUINA_FACAS.Remove(entity);
                db.SaveChanges();
            }
            catch (DbUpdateException upex)
            {
                var sqlException = upex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    var number = sqlException.Number;
                    if (number == 547)
                    {
                        if (sqlException.Message.Contains("dbo.TB_SN_FACAS"))
                        {
                            throw new System.ArgumentException("Não e possivel deletar esta maquina pois existe facas cadastradas para mesma.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}