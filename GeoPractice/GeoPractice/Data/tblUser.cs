using System;
using System.ComponentModel.DataAnnotations;

namespace GeoPractice.Data
{
    public class tblUser
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string RFC { get; set; }
    }
}
