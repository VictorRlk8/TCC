using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesItensCarrinho
    {
        Conexao con = new Conexao();
        public void inserirItem(ModelItemCarrinho cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbItensCarrinho values(default, @CodCarrinho, @CodProd, @VlTotal , @Qtitens)", con.MyConectarBD());

            cmd.Parameters.Add("@CodCarrinho", MySqlDbType.VarChar).Value = cm.PedidoID;
            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = cm.ProdutoID;
            cmd.Parameters.Add("@VlTotal", MySqlDbType.VarChar).Value = cm.valorParcial;
            cmd.Parameters.Add("@Qtitens", MySqlDbType.VarChar).Value = cm.Qtd;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }
    }
}