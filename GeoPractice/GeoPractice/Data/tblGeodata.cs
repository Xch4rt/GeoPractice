using System.ComponentModel.DataAnnotations;

namespace GeoPractice.Data
{
    public class tblGeodata
    {
        [Key]
        public int IdGeorreferencia { get; set; }
        public int IdEstado { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
