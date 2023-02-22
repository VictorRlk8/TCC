using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Models
{
    public class ModelCarrinho
    {
        [DisplayName("Código")]
        public string CodCarrinho { get; set; }

        [DisplayName("Data")]
        public string DataCarrinho { get; set; }

        [DisplayName("Horário")]
        public string HoraCarrinho { get; set; }

        [DisplayName("Usúario")]
        public string UsuarioID { get; set; }

        [DisplayName("Valor")]
        public double VlCompra { get; set; }

        [DisplayName("Pagamento")]
        public string CodPagto { get; set; }

        public List<ModelItemCarrinho> ItensPedido = new List<ModelItemCarrinho>();
    }
}