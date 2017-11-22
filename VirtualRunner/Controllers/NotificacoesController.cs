using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualRunner.ViewModels;

namespace VirtualRunner.Controllers
{
    public class NotificacoesController : Controller
    {
        [HttpPost]
        public void Index(NotificacaoViewModel model)
        {
            
        }

        public IActionResult Redirecionamento(string id)
        {
            
            return Content("Sua doação está sendo processada:" + id);
        }
    }
}