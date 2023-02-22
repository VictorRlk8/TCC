using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesPagamento
    {
        Conexao con = new Conexao();

        public void inserirPagamento(ModelPagamento cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbPagamento (CodPagto, NomeCartao, NumeroCartao, DtExpiracao, Cvv, CodCarrinho) values (@CodPagto, @NomeCartao, @NumeroCartao, @DtExpiracao, @Cvv, @CodCarrinho)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@CodPagto", MySqlDbType.VarChar).Value = cm.CodPagto;
            cmd.Parameters.Add("@NomeCartao", MySqlDbType.VarChar).Value = cm.NomeCartao;
            cmd.Parameters.Add("@NumeroCartao", MySqlDbType.VarChar).Value = cm.NumeroCartao;
            cmd.Parameters.Add("@DtExpiracao", MySqlDbType.VarChar).Value = cm.DtExpiracao;
            cmd.Parameters.Add("@Cvv", MySqlDbType.VarChar).Value = cm.Cvv;
            cmd.Parameters.Add("@CodCarrinho", MySqlDbType.VarChar).Value = cm.CodCarrinho;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}