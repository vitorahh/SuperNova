using SuperNova.DTO;
using SuperNovaDataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SuperNova.Models
{
    public class Facas
    {
        SUPER_NOVAEntities db = new SUPER_NOVAEntities("SUPER_NOVA");

        public List<FacasDTO> listFacas(FacasDTO filtroFacas)
        {
            try
            {
                ObjectResult<SN_sp_ListaFacas_Result> listFacas = (db.SN_sp_ListaFacas
                                ((string.IsNullOrEmpty(filtroFacas.ID_FACA.ToString()) ? 0 : filtroFacas.ID_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.ID_MAQUINA_FACA.ToString()) ? 0 : filtroFacas.ID_MAQUINA_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.ID_TIPO_FACAS.ToString()) ? 0 : filtroFacas.ID_TIPO_FACAS),
                                    (string.IsNullOrEmpty(filtroFacas.VL_ALTURA_FACA.ToString()) ? 0 : filtroFacas.VL_ALTURA_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.VL_LARGURA_FACA.ToString()) ? 0 : filtroFacas.VL_LARGURA_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.NR_FACA.ToString()) ? 0 : filtroFacas.NR_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.NR_COLUNAS_FACA.ToString()) ? 0 : filtroFacas.NR_COLUNAS_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.NR_LINHAS_FACA.ToString()) ? 0 : filtroFacas.NR_LINHAS_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.DS_CAIXA_FACA) ? "" : filtroFacas.DS_CAIXA_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.DS_CLIENTE_FACA) ? "" : filtroFacas.DS_CLIENTE_FACA),
                                    (string.IsNullOrEmpty(filtroFacas.DS_OBSERVACAO) ? "" : filtroFacas.DS_OBSERVACAO)));

                List<FacasDTO> listFacasDTO = (from result in listFacas
                                               select new FacasDTO
                                               {
                                                   ID_FACA = result.ID_FACA,
                                                   ID_MAQUINA_FACA = result.ID_MAQUINA_FACA,
                                                   ID_TIPO_FACAS = result.ID_TIPO_FACAS,
                                                   DS_MAQUINA_FACA = result.DS_MAQUINA_FACA,
                                                   DS_TIPO_FACAS = result.DS_TIPO_FACAS,
                                                   VL_ALTURA_FACA = result.VL_ALTURA_FACA,
                                                   VL_LARGURA_FACA = result.VL_LARGURA_FACA,
                                                   NR_FACA = result.NR_FACA,
                                                   NR_COLUNAS_FACA = result.NR_COLUNAS_FACA,
                                                   NR_LINHAS_FACA = result.NR_LINHAS_FACA,
                                                   DS_CAIXA_FACA = result.DS_CAIXA_FACA,
                                                   DS_CLIENTE_FACA = ((result.DS_CLIENTE_FACA != null) ? result.DS_CLIENTE_FACA : ""),
                                                   DS_OBSERVACAO = result.DS_OBSERVACAO,
                                                   DS_URL_IMG = ((result.DS_URL_IMG != null) ? result.DS_URL_IMG : "")
                                               }).ToList<FacasDTO>();


                return listFacasDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FacasDTO getFaca(int ID_FACA)
        {
            try
            {
                IEnumerable<FacasDTO> Faca = (from Facas in db.TB_SN_FACAS
                                 join TipoFaca in db.TB_SN_TIPO_FACAS on Facas.ID_TIPO_FACAS equals TipoFaca.ID_TIPO_FACAS
                                 join Maquina in db.TB_SN_MAQUINA_FACAS on Facas.ID_MAQUINA_FACA equals Maquina.ID_MAQUINA_FACA
                                 where Facas.ID_FACA == ID_FACA
                                 orderby Facas.ID_FACA descending
                                 select new FacasDTO
                                 {
                                     ID_FACA = Facas.ID_FACA
                                       ,
                                     ID_MAQUINA_FACA = Facas.ID_MAQUINA_FACA
                                       ,
                                     ID_TIPO_FACAS = Facas.ID_TIPO_FACAS
                                       ,
                                     DS_MAQUINA_FACA = Maquina.DS_MAQUINA_FACA
                                       ,
                                     DS_TIPO_FACAS = TipoFaca.DS_TIPO_FACAS
                                       ,
                                     VL_ALTURA_FACA = Facas.VL_ALTURA_FACA
                                       ,
                                     VL_LARGURA_FACA = Facas.VL_LARGURA_FACA
                                       ,
                                     NR_FACA = Facas.NR_FACA
                                       ,
                                     NR_COLUNAS_FACA = Facas.NR_COLUNAS_FACA
                                       ,
                                     NR_LINHAS_FACA = Facas.NR_LINHAS_FACA
                                       ,
                                     DS_CAIXA_FACA = Facas.DS_CAIXA_FACA
                                       ,
                                     DS_CLIENTE_FACA = ((Facas.DS_CLIENTE_FACA != null) ? Facas.DS_CLIENTE_FACA : "")
                                       ,
                                     DS_OBSERVACAO = Facas.DS_OBSERVACAO
                                       ,
                                     DS_URL_IMG = ((Facas.DS_URL_IMG != null) ? Facas.DS_URL_IMG : "")
                                 }).ToList();
                return Faca.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delFacas(int ID_FACA)
        {
            try
            {
                TB_SN_FACAS entity = db.TB_SN_FACAS.First(x => x.ID_FACA == ID_FACA);
                db.TB_SN_FACAS.Attach(entity);
                db.TB_SN_FACAS.Remove(entity);
                db.SaveChanges();
            }
            catch (DbUpdateException upex)
            {
                var sqlException = upex.GetBaseException() as SqlException;
                if (sqlException != null)
                {
                    throw new ArgumentException(sqlException.Message);
                }
                else
                {
                    throw new ArgumentException(upex.Message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cadFaca(TB_SN_FACAS cadFaca)
        {
            try
            {
                db.TB_SN_FACAS.Add(cadFaca);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void attFaca(TB_SN_FACAS attFaca)
        {
            try
            {
                TB_SN_FACAS entity = db.TB_SN_FACAS.FirstOrDefault(x => x.ID_FACA == attFaca.ID_FACA);
                if (entity != null)
                {
                    entity.ID_MAQUINA_FACA = attFaca.ID_MAQUINA_FACA;
                    entity.ID_TIPO_FACAS = attFaca.ID_TIPO_FACAS;
                    entity.VL_LARGURA_FACA = attFaca.VL_LARGURA_FACA;
                    entity.VL_ALTURA_FACA = attFaca.VL_ALTURA_FACA;
                    entity.NR_FACA = attFaca.NR_FACA;
                    entity.NR_COLUNAS_FACA = attFaca.NR_COLUNAS_FACA;
                    entity.NR_LINHAS_FACA = attFaca.NR_LINHAS_FACA;
                    entity.DS_CAIXA_FACA = attFaca.DS_CAIXA_FACA;
                    entity.DS_CLIENTE_FACA = attFaca.DS_CLIENTE_FACA;
                    entity.DS_OBSERVACAO = attFaca.DS_OBSERVACAO;
                    entity.DS_URL_IMG = attFaca.DS_URL_IMG;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}