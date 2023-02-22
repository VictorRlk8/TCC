using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Models
{
    public class ModelCadastro
    {
        [DisplayName("Código")]
        public string CodCli { get; set; }
        [DisplayName("Nome")]
        public string NomeCli { get; set; }
        [DisplayName("CPF")]
        public string CpfCli { get; set; }
        [DisplayName("Nascimento")]
        public string DataNascCli { get; set; }
        [DisplayName("Sexo")]
        public string SexoCli { get; set; }
        [DisplayName("Rua")]
        public string EnderecoCli { get; set; }
        [DisplayName("Número")]
        public string NumeroCasaCli { get; set; }
        [DisplayName("CEP")]
        public string CepCli { get; set; }
        [DisplayName("Bairro")]
        public string NmBairro { get; set; }
        [DisplayName("Estado")]
        public string NmEstado { get; set; }
        [DisplayName("E-mail")]
        public string EmailCli { get; set; }
        [DisplayName("Celular")]
        public string CelularCli { get; set; }
        [DisplayName("Telefone")]
        public string TelefoneCli { get; set; }

        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [DisplayName("Senha")]
        public string senha { get; set; }
        public string tipo { get; set; }
    }
}