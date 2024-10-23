using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller_YulianaCapito.Models
{
    public class Estadio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Direccion { get; set; }
        [MaxLength(1000)]
        public string Ciudad { get; set; }
        [Range (0,50000)]
        public int Capacidad { get; set; }
        


    }
}
