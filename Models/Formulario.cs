using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace RegistroAlumno.Models
{
    public class Formulario
    {        
        
           [Display(Name ="Nombre del estudiante:",Prompt ="Ingresar nombres y apellidos")]
            public string? nombre {get;set;}    
            public Boolean curso1 {get;set;}
            public Boolean curso2 {get;set;}
            public Boolean curso3 {get;set;}
    }

}