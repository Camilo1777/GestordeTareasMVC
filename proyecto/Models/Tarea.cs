using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }

        public Tarea ( int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            Completada = false;
        }


    }
}
