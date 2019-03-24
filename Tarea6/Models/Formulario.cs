using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea6.Models
{
    public class Formulario
    {
        public int ID { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Range(15,100,ErrorMessage ="Debe ser mayor de 15 años")]
        public int Edad { get; set; }
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Debe ser una direccion de correo valida")]
        public string Correo { get; set; }
        public Genero Genero { get; set; }
        public string EstadoCivil { get; set; }
        public IList<string> HobbiesSeleccionados { get; set; }
        public string Hobbies { get; set; }
        [NotMapped]
        public IList<SelectListItem> HobbiesDisponibles { get; set; }

        public Formulario()
        {
            HobbiesSeleccionados = new List<string>();
            HobbiesDisponibles = new List<SelectListItem>();
        }
    }

    public enum Genero { Masculino , Femenino}
}