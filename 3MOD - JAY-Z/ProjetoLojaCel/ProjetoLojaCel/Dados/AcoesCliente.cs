using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesCliente
    {
        Conexao con = new Conexao();

        public List<ModelCliente> GetCliente()
        {
            List<ModelCliente> ClienteList = new List<ModelCliente>();

            MySqlCommand cmd = new MySqlCommand("select * from vwCliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ClienteList.Add(
                    new ModelCliente
                    {
                        CodCli = Convert.ToString(dr["CodCli"]),
                        NomeCli = Convert.ToString(dr["NomeCli"]),
                        usuario = Convert.ToString(dr["usuario"]),
                        CpfCli = Convert.ToString(dr["CpfCli"]),
                        DataNascCli = Convert.ToString(dr["DataNascCli"]),
                        SexoCli = Convert.ToString(dr["SexoCli"]),
                        EnderecoCli = Convert.ToString(dr["EnderecoCli"]),
                        NumeroCasaCli = Convert.ToString(dr["NumeroCasaCli"]),
                        CepCli = Convert.ToString(dr["CepCli"]),
                        NmBairro = Convert.ToString(dr["NmBairro"]),
                        NmEstado = Convert.ToString(dr["NmEstado"]),
                        EmailCli = Convert.ToString(dr["EmailCli"]),
                        CelularCli = Convert.ToString(dr["CelularCli"]),
                        TelefoneCli = Convert.ToString(dr["TelefoneCli"])                        
                    });
            }
            return ClienteList;
        }

        public bool DeleteCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCliente where CodCli=@id", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@id", id);


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizaCliente(ModelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCliente set NomeCli=@NomeCli, CpfCli=@CpfCli , DataNascCli=@DataNascCli, SexoCli=@SexoCli, EnderecoCli=@EnderecoCli, NumeroCasaCli=@NumeroCasaCli, CepCli=@CepCli, NmBairro=@NmBairro, NmEstado=@NmEstado, EmailCli=@EmailCli, CelularCli=@CelularCli, TelefoneCli=@TelefoneCli, usuario=@usuario where CodCli=@CodCli", con.MyConectarBD());


            cmd.Parameters.AddWithValue("@NomeCli", cm.NomeCli);
            cmd.Parameters.AddWithValue("@CpfCli", cm.CpfCli);
            cmd.Parameters.AddWithValue("@DataNascCli", cm.DataNascCli);
            cmd.Parameters.AddWithValue("@SexoCli", cm.SexoCli);
            cmd.Parameters.AddWithValue("@EnderecoCli", cm.EnderecoCli);
            cmd.Parameters.AddWithValue("@NumeroCasaCli", cm.NumeroCasaCli);
            cmd.Parameters.AddWithValue("@CepCli", cm.CepCli);
            cmd.Parameters.AddWithValue("@NmBairro", cm.NmBairro);
            cmd.Parameters.AddWithValue("@NmEstado", cm.NmEstado);
            cmd.Parameters.AddWithValue("@EmailCli", cm.EmailCli);
            cmd.Parameters.AddWithValue("@CelularCli", cm.CelularCli);
            cmd.Parameters.AddWithValue("@TelefoneCli", cm.TelefoneCli);
            cmd.Parameters.AddWithValue("@usuario", cm.usuario);
            cmd.Parameters.AddWithValue("@CodCli", cm.CodCli);


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizaProduto(ModelProduto cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbProduto set NmProd=@NmProd, DescricaoProd=@DescricaoProd, VlProd=@VlProd, MarcaProd=@MarcaProd, EstoqueProd=@EstoqueProd, ImagemProd=@ImagemProd, CodTipoProduto=@CodTipoProduto where CodProd=@CodProd", con.MyConectarBD());


            cmd.Parameters.AddWithValue("@NmProd", cm.NmProd);
            cmd.Parameters.AddWithValue("@DescricaoProd", cm.DescricaoProd);
            cmd.Parameters.AddWithValue("@VlProd", cm.VlProd);
            cmd.Parameters.AddWithValue("@MarcaProd", cm.MarcaProd);
            cmd.Parameters.AddWithValue("@EstoqueProd", cm.EstoqueProd);
            cmd.Parameters.AddWithValue("@ImagemProd", cm.ImagemProd);
            cmd.Parameters.AddWithValue("@CodTipoProduto", cm.CodTipoProduto);
            cmd.Parameters.AddWithValue("@CodProd", cm.CodProd);


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}