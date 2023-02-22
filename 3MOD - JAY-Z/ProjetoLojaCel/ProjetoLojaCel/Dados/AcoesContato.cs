using MySql.Data.MySqlClient;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLojaCel.Dados
{
    public class AcoesContato
    {
        Conexao con = new Conexao();

        public void inserirContato(ModelContato cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbContato (NomeContato, EmailContato, NumeroContato, MensagemContato) values (@NomeContato, @EmailContato, @NumeroContato, @MensagemContato)", con.MyConectarBD()); // @: PARAMETRO

            cmd.Parameters.Add("@NomeContato", MySqlDbType.VarChar).Value = cm.NomeContato;
            cmd.Parameters.Add("@EmailContato", MySqlDbType.VarChar).Value = cm.EmailContato;
            cmd.Parameters.Add("@NumeroContato", MySqlDbType.VarChar).Value = cm.NumeroContato;
            cmd.Parameters.Add("@MensagemContato", MySqlDbType.VarChar).Value = cm.MensagemContato;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<ModelContato> GetContato()
        {
            List<ModelContato> ContatoList = new List<ModelContato>();

            MySqlCommand cmd = new MySqlCommand("select * from tbContato", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ContatoList.Add(
                    new ModelContato
                    {
                        CodContato = Convert.ToString(dr["CodContato"]),
                        NomeContato = Convert.ToString(dr["NomeContato"]),
                        EmailContato = Convert.ToString(dr["EmailContato"]),
                        NumeroContato = Convert.ToString(dr["NumeroContato"]),
                        MensagemContato = Convert.ToString(dr["MensagemContato"])
                        
                    });
            }
            return ContatoList;
        }
    }
}
