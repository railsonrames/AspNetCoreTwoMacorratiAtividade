using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTwoMacorratiAtividade.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTwoMacorratiAtividade.Controllers
{
    public class PaisesController : Controller
    {
        private readonly AplicacaoContext _context;
        public PaisesController(AplicacaoContext context)
            => _context = context;

        public IActionResult Index()
        {
            var paises = (from pais in _context.Paises select pais).ToList();
            paises.Insert(0, new Pais { Id = 0, Nome = "Selecione" });
            ViewBag.Paises = paises;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Pais pais)
        {
            if (pais.Id == 0)
                ModelState.AddModelError("", "Selecione um país!");

            var paises = (from p in _context.Paises select p).ToList();
            paises.Insert(0, new Pais { Id = 0, Nome = "Selecione" });
            ViewBag.Paises = paises;
            ViewBag.PaisSelecionado = paises.FirstOrDefault(x => x.Id == pais.Id);

            return View();
        }
    }
}