﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperNovaDataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SUPER_NOVAEntities : DbContext
    {
        public SUPER_NOVAEntities()
            : base("name=SUPER_NOVAEntities")
        {
        }
        public SUPER_NOVAEntities(string connectionStringName) : base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_SN_FACAS> TB_SN_FACAS { get; set; }
        public virtual DbSet<TB_SN_MAQUINA_FACAS> TB_SN_MAQUINA_FACAS { get; set; }
        public virtual DbSet<TB_SN_TIPO_FACAS> TB_SN_TIPO_FACAS { get; set; }
        public virtual DbSet<TB_SN_USUARIOS> TB_SN_USUARIOS { get; set; }
    
        public virtual ObjectResult<SN_sp_ListaFacas_Result> SN_sp_ListaFacas(Nullable<int> iD_FACA, Nullable<int> iD_MAQUINA_FACA, Nullable<int> iD_TIPO_FACAS, Nullable<decimal> vL_ALTURA_FACA, Nullable<decimal> vL_LARGURA_FACA, Nullable<int> nR_FACA, Nullable<int> nR_COLUNAS_FACA, Nullable<int> nR_LINHAS_FACA, string dS_CAIXA_FACA, string dS_CLIENTE_FACA, string dS_OBSERVACAO)
        {
            var iD_FACAParameter = iD_FACA.HasValue ?
                new ObjectParameter("ID_FACA", iD_FACA) :
                new ObjectParameter("ID_FACA", typeof(int));
    
            var iD_MAQUINA_FACAParameter = iD_MAQUINA_FACA.HasValue ?
                new ObjectParameter("ID_MAQUINA_FACA", iD_MAQUINA_FACA) :
                new ObjectParameter("ID_MAQUINA_FACA", typeof(int));
    
            var iD_TIPO_FACASParameter = iD_TIPO_FACAS.HasValue ?
                new ObjectParameter("ID_TIPO_FACAS", iD_TIPO_FACAS) :
                new ObjectParameter("ID_TIPO_FACAS", typeof(int));
    
            var vL_ALTURA_FACAParameter = vL_ALTURA_FACA.HasValue ?
                new ObjectParameter("VL_ALTURA_FACA", vL_ALTURA_FACA) :
                new ObjectParameter("VL_ALTURA_FACA", typeof(decimal));
    
            var vL_LARGURA_FACAParameter = vL_LARGURA_FACA.HasValue ?
                new ObjectParameter("VL_LARGURA_FACA", vL_LARGURA_FACA) :
                new ObjectParameter("VL_LARGURA_FACA", typeof(decimal));
    
            var nR_FACAParameter = nR_FACA.HasValue ?
                new ObjectParameter("NR_FACA", nR_FACA) :
                new ObjectParameter("NR_FACA", typeof(int));
    
            var nR_COLUNAS_FACAParameter = nR_COLUNAS_FACA.HasValue ?
                new ObjectParameter("NR_COLUNAS_FACA", nR_COLUNAS_FACA) :
                new ObjectParameter("NR_COLUNAS_FACA", typeof(int));
    
            var nR_LINHAS_FACAParameter = nR_LINHAS_FACA.HasValue ?
                new ObjectParameter("NR_LINHAS_FACA", nR_LINHAS_FACA) :
                new ObjectParameter("NR_LINHAS_FACA", typeof(int));
    
            var dS_CAIXA_FACAParameter = dS_CAIXA_FACA != null ?
                new ObjectParameter("DS_CAIXA_FACA", dS_CAIXA_FACA) :
                new ObjectParameter("DS_CAIXA_FACA", typeof(string));
    
            var dS_CLIENTE_FACAParameter = dS_CLIENTE_FACA != null ?
                new ObjectParameter("DS_CLIENTE_FACA", dS_CLIENTE_FACA) :
                new ObjectParameter("DS_CLIENTE_FACA", typeof(string));
    
            var dS_OBSERVACAOParameter = dS_OBSERVACAO != null ?
                new ObjectParameter("DS_OBSERVACAO", dS_OBSERVACAO) :
                new ObjectParameter("DS_OBSERVACAO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SN_sp_ListaFacas_Result>("SN_sp_ListaFacas", iD_FACAParameter, iD_MAQUINA_FACAParameter, iD_TIPO_FACASParameter, vL_ALTURA_FACAParameter, vL_LARGURA_FACAParameter, nR_FACAParameter, nR_COLUNAS_FACAParameter, nR_LINHAS_FACAParameter, dS_CAIXA_FACAParameter, dS_CLIENTE_FACAParameter, dS_OBSERVACAOParameter);
        }
    }
}
