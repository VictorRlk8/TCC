using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLojaCel.Dados
{
    public class AcoesLogin
    {
        Conexao con = new Conexao();

        public void TestarUsuario(ModelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbLogin where usuario = @usuario and senha = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.usuario = Convert.ToString(leitor["usuario"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.usuario = null;
                user.senha = null;
                user.tipo = null;
            }

            con.MyDesconectarBD();
        }
        public static string Usuario;
        public void TestarEmail(ModelCadastro user)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbCliente where EmailCli = @EmailCli", con.MyConectarBD());

            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = user.EmailCli;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.EmailCli = Convert.ToString(leitor["EmailCli"]);
                    Usuario = Convert.ToString(leitor["usuario"]);
                }
            }

            else
            {
                user.EmailCli = null;
            }

            con.MyDesconectarBD();
        }

        public bool atualizaSenha(ModelCadastro cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbLogin set senha=@senha where usuario=@usuario ", con.MyConectarBD());


            cmd.Parameters.AddWithValue("@senha", cm.senha);
            cmd.Parameters.AddWithValue("@usuario", Usuario);


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}