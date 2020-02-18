using System.ComponentModel.DataAnnotations;

namespace ApiASPLinux.Models
{
    public class Operario
    {
        [Key]
        public int Id {get; set;}
        [StringLength(15)]
        public string Nombre {get; set;}
        public string Apellidos {get; set;}
        public string Direccion {get; set;}
        public bool activo {get; set;}

    }
}