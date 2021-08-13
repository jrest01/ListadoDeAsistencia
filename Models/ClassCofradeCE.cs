using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/* Sirve de Clase parcial, para añadir campos temporales al modelo de DB*/

namespace Cofradia.Models
{
    public class ClassCofradeCE
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
    }

    [MetadataType(typeof(Cofrade))]
    public partial class Cofrade{
        public int Estado { get; set; }
        public string NombreConApodo { get { return Nombre +" " + Apodo; } }
    }
}