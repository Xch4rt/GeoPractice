using System.ComponentModel.DataAnnotations;

namespace GeoPractice.Data
{
    public class tblUrl
    {
        [Key]
        public string Url_ { get; set; } 
        public string ShortURL { get; set; }    
    }
}
