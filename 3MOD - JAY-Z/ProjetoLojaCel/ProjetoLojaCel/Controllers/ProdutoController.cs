using MySql.Data.MySqlClient;
using ProjetoLojaCel.Dados;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaCel.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        AcoesProduto acProd = new AcoesProduto();

        public ActionResult Index()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
        }

        public void CarregaTipoProduto()
        {
            List<SelectListItem> tipoProduto = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=dbLojaCel;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbTipoProduto", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tipoProduto.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();

                con.Open();
            }

            ViewBag.tipoProduto = new SelectList(tipoProduto, "Value", "Text");
        }
        
        

        public ActionResult CadProduto()
        {
            CarregaTipoProduto();
            return View();
        }

        AcoesProduto acPro = new AcoesProduto();

        [HttpPost]
        public ActionResult CadProduto(ModelProduto md, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);
            md.ImagemProd = file2;

            CarregaTipoProduto();
            md.CodTipoProduto = Request["tipoProduto"];

            acPro.inserirProduto(md);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Detalhes(string id)
        {
            return View(acProd.GetAtendProd().Find((smodel => smodel.CodProd == id)));
        }

        public ActionResult ConsProduto()
        {
            return View(acProd.GetProduto());
        }

        public ActionResult excluirProduto(int id)
        {
            acProd.DeleteProduto(id);
            return RedirectToAction("ConsProduto");
        }

        public ActionResult EditarProduto(string id, ModelProduto mod)
        {
            CarregaTipoProduto();
            mod.CodTipoProduto = Request["tipoProduto"];
            return View(acProd.GetProduto().Find(model => model.CodProd == id));
        }

        [HttpPost]
        public ActionResult EditarProduto(int id, ModelProduto cmImagem, HttpPostedFileBase file)
        {
            cmImagem.CodProd = id.ToString();
            CarregaTipoProduto();
            cmImagem.CodTipoProduto = Request["tipoProduto"];
            if (file == null)
            {
                acProd.atualizaProdutoSemFoto(cmImagem);
                ViewBag.msg = "Produto atualizado com sucesso.";
            }
            else
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
                file.SaveAs(_path);
                cmImagem.ImagemProd = file2;
                cmImagem.CodProd = id.ToString();
                acProd.atualizaProduto(cmImagem);
                ViewBag.msg = "Produto e foto atualizado com sucesso.";
            }
            return View();
        }

    }
}