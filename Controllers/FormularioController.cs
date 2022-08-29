using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegistroAlumno.Models;
namespace RegistroAlumno.Controllers
{
    
    public class FormularioController : Controller
    {
        private readonly ILogger<FormularioController> _logger;

        public FormularioController(ILogger<FormularioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Formulario objFormulario){
            string? nom=null;
            nom=objFormulario.nombre;
            double precioF=0.0;
            int credito=3;
            int precio=100;
            double igv=0.18;
            double precioT;        
            
            
            
            if (objFormulario.curso1==true||objFormulario.curso2==true||objFormulario.curso3==false)
            {                
                precioF=precio*credito;
            }

            if(objFormulario.curso1==true&&objFormulario.curso2==true||objFormulario.curso2==true&&objFormulario.curso3==true||objFormulario.curso1==true&&objFormulario.curso3==true)
            {
                precioF=precioF+(precio*credito);
            }
            if(objFormulario.curso1==true||objFormulario.curso2==true||objFormulario.curso3==true)
            {
                precioF=precioF+(precio*credito)+(precio*credito);
            }
            igv=igv*precioF;
            precioT=precioF+igv;
            
            ViewData["Message"]=nom+" el total por los cursos es: " + precioF;
            ViewData["Message2"]="El IGV es: "  + igv;
            ViewData["Message3"]="El total a pagar es: "  + precioT;
            return View("Index");
        }

        
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}