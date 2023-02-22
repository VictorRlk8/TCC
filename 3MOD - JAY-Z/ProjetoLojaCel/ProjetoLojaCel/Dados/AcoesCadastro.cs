using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesCadastro
    {
        Conexao con = new Conexao();

        public void inserirCliente(ModelCadastro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbCliente (NomeCli, CpfCli,DataNascCli, SexoCli, EnderecoCli, NumeroCasaCli, CepCli, NmBairro, NmEstado, EmailCli, CelularCli, usuario) values (@NomeCli, @CpfCli, @DataNascCli, @SexoCli, @EnderecoCli, @NumeroCasaCli, @CepCli, @NmBairro, @NmEstado, @EmailCli, @CelularCli, @usuario)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cm.NomeCli;
            cmd.Parameters.Add("@CpfCli", MySqlDbType.VarChar).Value = cm.CpfCli;
            cmd.Parameters.Add("@DataNascCli", MySqlDbType.VarChar).Value = cm.DataNascCli;
            cmd.Parameters.Add("@SexoCli", MySqlDbType.VarChar).Value = cm.SexoCli;
            cmd.Parameters.Add("@EnderecoCli", MySqlDbType.VarChar).Value = cm.EnderecoCli;
            cmd.Parameters.Add("@NumeroCasaCli", MySqlDbType.VarChar).Value = cm.NumeroCasaCli;
            cmd.Parameters.Add("@CepCli", MySqlDbType.VarChar).Value = cm.CepCli;
            cmd.Parameters.Add("@NmBairro", MySqlDbType.VarChar).Value = cm.NmBairro;
            cmd.Parameters.Add("@NmEstado", MySqlDbType.VarChar).Value = cm.NmEstado;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cm.EmailCli;
            cmd.Parameters.Add("@CelularCli", MySqlDbType.VarChar).Value = cm.CelularCli;
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
           
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public void inserirLogin(ModelCadastro cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbLogin (usuario, senha, tipo) values (@usuario, @senha, 1)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cm.senha;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }    
    }
}