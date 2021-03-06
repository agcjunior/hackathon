﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualRunner.ViewModels;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml.Linq;
using VirtualRunner.Data;
using VirtualRunner.Services;
using VirtualRunner.Data.Entities;

namespace VirtualRunner.Controllers
{
    public class HomeController : Controller
    {
        private IDoacaoService __doacaoService;

        public HomeController(IDoacaoService doacaoService)
        {
            __doacaoService = doacaoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            var reference = Guid.NewGuid().ToString();
            var pagSeguroPage = "https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=";
            var uri = "https://ws.sandbox.pagseguro.uol.com.br/v2/checkout";

            var parametros = new NameValueCollection();
            parametros.Add("email", "antonio.jr@outlook.com");
            parametros.Add("token", "1D7254DACE40448BA5E43680A7807EBE");
            parametros.Add("currency", "BRL");
            parametros.Add("itemId1", "1");
            parametros.Add("itemDescription1", "Doacao para o Incor Crianca");
            parametros.Add("itemAmount1", "50.00");
            parametros.Add("itemQuantity1", "1");
            parametros.Add("reference", reference);

            // Envia um POST para obter o codigo da transação no PagSeguro
            var xmlResponse = "";
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");              
                byte[] responsebytes = wc.UploadValues(uri, "POST", parametros);
                xmlResponse = Encoding.UTF8.GetString(responsebytes);
            }            

            // Obtem o codigo da transação xml recebido
            var xDoc = XDocument.Parse(xmlResponse);
            var code = xDoc.Descendants("checkout").Elements("code").Single().Value;
            pagSeguroPage += code;


            // Grava no BD o registro / doação do Runner
            var registroRunner = new RegistroRunner
            {
                Email = model.Email,
                NomeCompleto = model.NomeCompleto,
                GostaSerChamado = model.ComoQuerSerChamado
            };
            var doacao = new Doacao
            {
                Data = DateTime.UtcNow,
                Referencia = reference,
                SituacaoPagamento = SituacaoPagamento.AguardandoProcessamento,
                Valor = 50.00m
            };

            registroRunner.RegistrarDoacao(doacao);
            __doacaoService.Doar(registroRunner);
            return Redirect(pagSeguroPage);
        }
    }
}