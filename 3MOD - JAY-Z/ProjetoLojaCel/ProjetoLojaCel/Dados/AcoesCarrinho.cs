using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesCarrinho
    {
        Conexao con = new Conexao();

        public void inserirCarrinho(ModelCarrinho cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbCarrinho values(default, @DataCarrinho, @HoraCarrinho , @VlCompra, @CodCli)", con.MyConectarBD());

            cmd.Parameters.Add("@DataCarrinho", MySqlDbType.VarChar).Value = cm.DataCarrinho;
            cmd.Parameters.Add("@HoraCarrinho", MySqlDbType.VarChar).Value = cm.HoraCarrinho;
            cmd.Parameters.Add("@VlCompra", MySqlDbType.VarChar).Value = cm.VlCompra;
            cmd.Parameters.Add("@CodCli", MySqlDbType.VarChar).Value = cm.UsuarioID;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        MySqlDataReader dr;
        public void buscaIdCarrinho(ModelCarrinho vend)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT CodCarrinho FROM tbCarrinho ORDER BY CodCarrinho DESC limit 1", con.MyConectarBD());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vend.CodCarrinho = dr[0].ToString();
            }
            con.MyDesconectarBD();
        }

    }
}