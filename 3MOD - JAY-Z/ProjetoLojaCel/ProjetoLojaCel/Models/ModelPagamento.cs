using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Models
{
    public class ModelPagamento
    {
        public string CodPagto { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string DtExpiracao { get; set; }
        public string Cvv { get; set; }
        public string CodCarrinho { get; set; }
    }
}