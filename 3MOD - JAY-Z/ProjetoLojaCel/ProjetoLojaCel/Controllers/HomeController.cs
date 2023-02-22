using Google.Protobuf.WellKnownTypes;
using ProjetoLojaCel.Dados;
using ProjetoLojaCel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProjetoLojaCel.Controllers
{
    public class HomeController : Controller
    {
        // SAMUEL 
        AcoesProduto acProd = new AcoesProduto();
        AcoesCarrinho acCar = new AcoesCarrinho();
        AcoesItensCarrinho acItens = new AcoesItensCarrinho();
        AcoesPagamento acPag = new AcoesPagamento();
        AcoesLogin acLg = new AcoesLogin();
        AcoesContato acCon = new AcoesContato();

        public ActionResult Index()
        {
            return View(acProd.GetAtendProd());
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contato(ModelContato mod)
        {
            acCon.inserirContato(mod);
            return View();
        }

        public ActionResult Empresa()
        {
            return View();
        }

        public ActionResult ConsContato()
        {
            return View(acCon.GetContato());
        }

        public static string codigo;

        public ActionResult AdicionarCarrinho(int id, double pre)
        {
            ModelCarrinho carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();
            var produto = acProd.GetConsProd(id);
            codigo = id.ToString();

            ModelProduto prod = new ModelProduto();

            if (produto != null)
            {
                var itemPedido = new ModelItemCarrinho();
                itemPedido.ItemPedidoID = Guid.NewGuid();
                itemPedido.ProdutoID = id.ToString();
                itemPedido.Produto = produto[0].NmProd;
                itemPedido.Qtd = 1;
                itemPedido.valorUnit = pre;

                List<ModelItemCarrinho> x = carrinho.ItensPedido.FindAll(l => l.Produto == itemPedido.Produto);

                if (x.Count != 0)
                {
                    carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NmProd).Qtd += 1;
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.valorUnit;
                    carrinho.VlCompra += itemPedido.valorParcial;
                    carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NmProd).valorParcial = carrinho.ItensPedido.FirstOrDefault(p => p.Produto == produto[0].NmProd).Qtd * itemPedido.valorUnit;

                }

                else
                {
                    itemPedido.valorParcial = itemPedido.Qtd * itemPedido.valorUnit;
                    carrinho.VlCompra += itemPedido.valorParcial;
                    carrinho.ItensPedido.Add(itemPedido);
                }

                /*carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto).Sum(d => d.Valor);*/

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            ModelCarrinho carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();

            return View(carrinho);
        }

        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(i => i.ItemPedidoID == id);

            carrinho.VlCompra -= itemExclusao.valorParcial;

            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult MaisProduto(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();
            var itemAdicao = carrinho.ItensPedido.FirstOrDefault(i => i.ItemPedidoID == id);

            carrinho.VlCompra += itemAdicao.valorParcial;

            itemAdicao.Qtd = itemAdicao.Qtd+ 1;
            itemAdicao.valorParcial = itemAdicao.valorParcial + itemAdicao.valorUnit;
            carrinho.VlCompra =+ itemAdicao.valorParcial;

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult MenosProduto(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();
            var itemSub = carrinho.ItensPedido.FirstOrDefault(i => i.ItemPedidoID == id);

            carrinho.VlCompra += itemSub.valorParcial;

            itemSub.Qtd = itemSub.Qtd - 1;
            itemSub.valorParcial = itemSub.valorParcial - itemSub.valorUnit;
            carrinho.VlCompra -= carrinho.VlCompra -= itemSub.valorParcial;

            if (itemSub.Qtd < 1)
            {
                carrinho.ItensPedido.Remove(itemSub);
            }

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult SalvarCarrinho(ModelCarrinho x)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("RedirecionaCarrinho", "Login");
            }
            else
            {
                var carrinho = Session["Carrinho"] != null ? (ModelCarrinho)Session["Carrinho"] : new ModelCarrinho();

                ModelCarrinho md = new ModelCarrinho();
                ModelItemCarrinho mdV = new ModelItemCarrinho();

                md.DataCarrinho = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy");
                md.HoraCarrinho = DateTime.Now.ToLocalTime().ToString("HH:mm");
                md.UsuarioID = Session["CodCli"].ToString();
                md.VlCompra = carrinho.VlCompra;

                acCar.inserirCarrinho(md);


                acCar.buscaIdCarrinho(x);

                for (int i = 0; i < carrinho.ItensPedido.Count; i++)
                {

                    mdV.PedidoID = x.CodCarrinho;
                    mdV.ProdutoID = carrinho.ItensPedido[i].ProdutoID;
                    mdV.Qtd = carrinho.ItensPedido[i].Qtd;
                    mdV.valorParcial = carrinho.ItensPedido[i].valorParcial;
                    acItens.inserirItem(mdV);
                }

                carrinho.VlCompra = 0;
                carrinho.ItensPedido.Clear();

                return RedirectToAction("FormPgto");
            }
        }

        public ActionResult FormPgto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormPgto(ModelPagamento mod, ModelCarrinho verCarrinho)
        {
            acPag.inserirPagamento(mod);
            return RedirectToAction("confVenda", "Home");
        }

        public ActionResult confVenda()
        {
            return View();
        }
    }
}