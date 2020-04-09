using Projeto_BRQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Projeto_BRQ.Controllers
{
    public class ContatoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return View();
        }

        public ActionResult Editar()
        {
            return View();
        }

        #region | POST 

        [System.Web.Http.HttpPost]
        public JsonResult CadastrarContato([FromBody]Contato contato)
        {
            if (new Contato().CadastrarContato(contato))
                return Json(new { status = true, JsonRequestBehavior.AllowGet });
            else
                return Json(new { status = false, JsonRequestBehavior.AllowGet });
        }

        [System.Web.Http.HttpPost]
        public JsonResult EditarContato([FromBody]Contato contato)
        {
            if (new Contato().EditarContato(contato))
                return Json(new { status = true, JsonRequestBehavior.AllowGet });
            else
                return Json(new { status = false, JsonRequestBehavior.AllowGet });
        }
        

        [System.Web.Http.HttpPost]
        public JsonResult ExcluirContato(Contato contato)
        {
            if (new Contato().ExcluirContato(contato))
                return Json(new { status = true, JsonRequestBehavior.AllowGet });
            else
                return Json(new { status = false, JsonRequestBehavior.AllowGet });
        }
        

        #endregion

        #region | GETS 

        [System.Web.Http.HttpGet]
        public JsonResult ConsultarContato(Contato contato) { 

            var ListaContato = new Contato().ConsultarContato(contato);

            return Json(new { data = ListaContato }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult ConsultarContatoByID(Contato contato)
        {
            bool status = false;

            var ListaContato = new Contato().ConsultarContatoByID(contato);

            if (ListaContato.Id > 0)
                status = true;

            return Json(new { status, response = ListaContato }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
