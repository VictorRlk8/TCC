using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Models
{
    public class ModelLogin
    {
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [DisplayName("Senha")]
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}