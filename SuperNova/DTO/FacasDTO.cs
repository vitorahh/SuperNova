using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperNova.DTO
{
    public class FacasDTO
    {

        public int ID_FACA { get; set; }

        public int ID_MAQUINA_FACA { get; set; }
        public  int ID_TIPO_FACAS { get; set; }
        public string DS_MAQUINA_FACA { get; set; }
        public string DS_TIPO_FACAS { get; set; }
        public string DS_URL_IMG { get; set; }
        public Nullable<decimal> VL_ALTURA_FACA { get; set; }
        public Nullable<decimal> VL_LARGURA_FACA { get; set; }

        public Nullable<int> NR_FACA { get; set; }
        public Nullable<int> NR_COLUNAS_FACA { get; set; }
        public Nullable<int> NR_LINHAS_FACA { get; set; }

        public string DS_CAIXA_FACA { get; set; }
        public string DS_CLIENTE_FACA { get; set; }
        public string DS_OBSERVACAO { get; set; }
    }
}