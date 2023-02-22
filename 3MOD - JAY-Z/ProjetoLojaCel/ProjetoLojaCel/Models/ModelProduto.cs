using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Models
{
    public class ModelProduto
    {
        [DisplayName("Código")]
        public string CodProd { get; set; }

        [DisplayName("Nome")]
        public string NmProd { get; set; }

        [DisplayName("Descrição")]
        public string DescricaoProd { get; set; }

        [DisplayName("Valor")]
        public string VlProd { get; set; }

        [DisplayName("Marca")]
        public string MarcaProd { get; set; }

        [DisplayName("Estoque")]
        public string EstoqueProd { get; set; }

        [DisplayName("Imagem")]
        public string ImagemProd { get; set; }

        [DisplayName("Tipo")]
        public string CodTipoProduto { get; set; }
    }
}