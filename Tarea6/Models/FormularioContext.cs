using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tarea6.Models;

namespace Tarea6.DAL
{
    public class FormularioContext:DbContext
    {
        public FormularioContext() : base("FormularioContext") { }

        public DbSet<Formulario> Formularios { get; set; }
    }
}