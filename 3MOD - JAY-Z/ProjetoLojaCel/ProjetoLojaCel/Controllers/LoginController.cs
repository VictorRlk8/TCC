using MySql.Data.MySqlClient;
using ProjetoLojaCel.Dados;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaCel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        AcoesCadastro acLogin = new AcoesCadastro();
        AcoesLogin acLg = new AcoesLogin();

        [HttpPost]
        public ActionResult Index(ModelLogin verLogin)
        {
            acLg.TestarUsuario(verLogin);

            if (verLogin.usuario != null & verLogin.senha != null)
            {
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();
                Session["CodCli"] = "1";

                if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString(); //=1
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString(); //=2
                    return RedirectToAction("Admin", "Login");
                }
            }

            else
            {
                ViewBag.msgLogar = "Usuário ou senha incorretos";
                return View();
            }

        }
        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Sem acesso')</script>");
            ViewBag.message = "Você não tem acesso a essa página";
            return View();
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(ModelCadastro mod)
        {
            acLogin.inserirLogin(mod);
            acLogin.inserirCliente(mod);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EsqueceuSenha(ModelCadastro verLogin)
        {
            acLg.TestarEmail(verLogin);

            if (verLogin.EmailCli != null)
            {
                Session["usuarioEmail"] = verLogin.EmailCli.ToString();
                return RedirectToAction("EditarSenha", "Login");
            }
            else
            {
                ViewBag.msgLogar = "E-mail não encontrado. Verifique se o e-mail está correto.";
                return View();
            }
        }

        public ActionResult EditarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarSenha(ModelCadastro cm)
        {
            acLg.atualizaSenha(cm);
            ViewBag.msg = "Alteração efetuada com sucesso";
            return View();

        }

        public ActionResult RedirecionaCarrinho()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RedirecionaCarrinho(ModelLogin verLogin)
        {
            acLg.TestarUsuario(verLogin);

            if (verLogin.usuario != null & verLogin.senha != null)
            {
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();

                return RedirectToAction("SalvarCarrinho", "Home");
            }

            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Veirifique o nome de usúario e a senha";
                return View();
            }
        }

    }
}