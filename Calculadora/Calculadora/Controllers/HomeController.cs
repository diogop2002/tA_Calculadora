using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet] // este anotador é facultativo
        public IActionResult Index()
        {
            // preparar os dados a serem enviados para a View na primeira interação
            ViewBag.Visor = "0";
            return View();
        }

        [HttpPost] // só quando o fomulario for submetido em 'post' ele será acionado
        public IActionResult Index(string botao, string visor)
        {

            //testar valor do botao
            switch (botao)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    //pressionei um algarismo
                    if(visor == "0")
                    {
                        visor = botao;
                    }
                    else
                    {
                        visor = visor + botao;
                    }
                    //desafio : fazer em modo algebrico esta operação...
                    break;
                
                case ",":
                    // foi pressionado ','            
                    if (!visor.Contains(',')) visor += ',';
                    break;

                case "+/-":
                    // vamos inverter o valor do 'visor'
                    if (visor.StartsWith('-')) visor = visor[1..];
                    else visor = '-' + visor;


                    // sugestão: fazer d forma algebrica
                    break;
            }

            // preparar dados para serem enviados à View
            ViewBag.Visor = visor;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}