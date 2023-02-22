using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesProduto
    {
        Conexao con = new Conexao();

        public void inserirProduto(ModelProduto cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbProduto (NmProd, DescricaoProd, VlProd, MarcaProd, EstoqueProd, ImagemProd, CodTipoProduto) values (@NmProd, @DescricaoProd, @VlProd, @MarcaProd, @EstoqueProd, @ImagemProd, @CodTipoProduto)", con.MyConectarBD());

            cmd.Parameters.Add("@NmProd", MySqlDbType.VarChar).Value = cm.NmProd;
            cmd.Parameters.Add("@DescricaoProd", MySqlDbType.VarChar).Value = cm.DescricaoProd;
            cmd.Parameters.Add("@VlProd", MySqlDbType.VarChar).Value = cm.VlProd;
            cmd.Parameters.Add("@MarcaProd", MySqlDbType.VarChar).Value = cm.MarcaProd;
            cmd.Parameters.Add("@EstoqueProd", MySqlDbType.VarChar).Value = cm.EstoqueProd;
            cmd.Parameters.Add("@ImagemProd", MySqlDbType.VarChar).Value = cm.ImagemProd;
            cmd.Parameters.Add("@CodTipoProduto", MySqlDbType.VarChar).Value = cm.CodTipoProduto;
            
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<ModelProduto> GetAtendProd()
        {
            List<ModelProduto> Produtoslist = new List<ModelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from vwProduto", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Produtoslist.Add(
                    new ModelProduto
                    {
                        CodProd = Convert.ToString(dr["CodProd"]),
                        NmProd = Convert.ToString(dr["NmProd"]),
                        DescricaoProd = Convert.ToString(dr["DescricaoProd"]),
                        VlProd = Convert.ToString(dr["VlProd"]),
                        MarcaProd = Convert.ToString(dr["MarcaProd"]),
                        EstoqueProd = Convert.ToString(dr["EstoqueProd"]),
                        ImagemProd = Convert.ToString(dr["ImagemProd"]),
                        CodTipoProduto = Convert.ToString(dr["NmTipoProduto"])
                    });
            }
            return Produtoslist;
        }


        public List<ModelProduto> GetConsProd(int id)
        {
            List<ModelProduto> Produtoslist = new List<ModelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbProduto where CodProd=@cod", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cod", id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Produtoslist.Add(
                    new ModelProduto
                    {
                        CodProd = Convert.ToString(dr["CodProd"]),
                        NmProd = Convert.ToString(dr["NmProd"]),
                        DescricaoProd = Convert.ToString(dr["DescricaoProd"]),
                        VlProd = Convert.ToString(dr["VlProd"]),
                        MarcaProd = Convert.ToString(dr["MarcaProd"]),
                        EstoqueProd = Convert.ToString(dr["EstoqueProd"]),
                        ImagemProd = Convert.ToString(dr["ImagemProd"]),
                        CodTipoProduto = Convert.ToString(dr["CodTipoProduto"])
                    });
            }
            return Produtoslist;
        }

        public List<ModelProduto> GetProduto()
        {
            List<ModelProduto> ProdutoList = new List<ModelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbProduto", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoList.Add(
                    new ModelProduto
                    {
                        CodProd = Convert.ToString(dr["CodProd"]),
                        NmProd = Convert.ToString(dr["NmProd"]),
                        DescricaoProd = Convert.ToString(dr["DescricaoProd"]),
                        VlProd = Convert.ToString(dr["VlProd"]),
                        MarcaProd = Convert.ToString(dr["MarcaProd"]),
                        EstoqueProd = Convert.ToString(dr["EstoqueProd"]),
                        ImagemProd = Convert.ToString(dr["ImagemProd"]),
                        CodTipoProduto = Convert.ToString(dr["CodTipoProduto"])
                    });
            }
            return ProdutoList;
        }

        public bool DeleteProduto(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbProduto where CodProd=@id", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@id", id);


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // Atualiza tudo, inclusive a foto
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

        // Atualiza produto sem a foto
        public bool atualizaProdutoSemFoto(ModelProduto cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbProduto set NmProd=@NmProd, DescricaoProd=@DescricaoProd, VlProd=@VlProd, MarcaProd=@MarcaProd, EstoqueProd=@EstoqueProd, CodTipoProduto=@CodTipoProduto where CodProd=@CodProd", con.MyConectarBD());


            cmd.Parameters.AddWithValue("@NmProd", cm.NmProd);
            cmd.Parameters.AddWithValue("@DescricaoProd", cm.DescricaoProd);
            cmd.Parameters.AddWithValue("@VlProd", cm.VlProd);
            cmd.Parameters.AddWithValue("@MarcaProd", cm.MarcaProd);
            cmd.Parameters.AddWithValue("@EstoqueProd", cm.EstoqueProd);
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