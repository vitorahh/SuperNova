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
    public class TipoFacas
    {
        SUPER_NOVAEntities db = new SUPER_NOVAEntities("SUPER_NOVA");
        public List<TipoFacasDTO> listTipoFacas()
        {
            try
            {
                List<TipoFacasDTO> listTipoFacas = (from TipoFacas in db.TB_SN_TIPO_FACAS
                                                    orderby TipoFacas.ID_TIPO_FACAS descending
                                                    select new TipoFacasDTO
                                                    {
                                                        ID_TIPO_FACAS = TipoFacas.ID_TIPO_FACAS
                                                        ,
                                                        DS_TIPO_FACAS = TipoFacas.DS_TIPO_FACAS
                                                    }).ToList<TipoFacasDTO>();
                return listTipoFacas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TipoFacasDTO listTipoFacas(int ID_TIPO_FACAS)
        {
            try
            {

                TB_SN_TIPO_FACAS entity = db.TB_SN_TIPO_FACAS.First(x => x.ID_TIPO_FACAS == ID_TIPO_FACAS);
                TipoFacasDTO GetTipoFaca = new TipoFacasDTO();
                GetTipoFaca.ID_TIPO_FACAS = entity.ID_TIPO_FACAS;
                GetTipoFaca.DS_TIPO_FACAS = entity.DS_TIPO_FACAS;

                return GetTipoFaca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cadTipoFacas(TB_SN_TIPO_FACAS cadTipoFaca)
        {
            try
            {
                db.TB_SN_TIPO_FACAS.Add(cadTipoFaca);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delTipoFacas(int ID_TIPO_FACAS)
        {
            try
            {
                TB_SN_TIPO_FACAS entity = db.TB_SN_TIPO_FACAS.First(x => x.ID_TIPO_FACAS == ID_TIPO_FACAS);
                db.TB_SN_TIPO_FACAS.Attach(entity);
                db.TB_SN_TIPO_FACAS.Remove(entity);
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
                            throw new System.ArgumentException("Não e possivel deletar este tipo de Faca pois existe facas cadastradas com o mesmo.");
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