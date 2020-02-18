using System.ComponentModel.DataAnnotations;

namespace ApiASPLinux.Models
{
public class Colores
    {
        [Key]
        public int Id {get; set;}
        public string Nombre {get; set;}
    }
}
