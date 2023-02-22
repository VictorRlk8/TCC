using ProjetoLojaCel.Dados;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoLojaCel.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        AcoesCliente acCli = new AcoesCliente();
        public ActionResult ConsCliente()
        {
            return View(acCli.GetCliente());
        }

        public ActionResult excluirCliente(int id)
        {
            acCli.DeleteCliente(id);
            return RedirectToAction("ConsCliente");
        }

        public ActionResult EditarCliente(string id)
        {
            return View(acCli.GetCliente().Find(model => model.CodCli == id));
        }

        [HttpPost]
        public ActionResult EditarCliente(int id, ModelCliente cm)
        {
            cm.CodCli = id.ToString();

            acCli.atualizaCliente(cm);
            ViewBag.msg = "Alteração efetuada com sucesso";
            return View();

        }
    }
}