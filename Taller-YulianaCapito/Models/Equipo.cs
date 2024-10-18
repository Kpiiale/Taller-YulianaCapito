using System.ComponentModel.DataAnnotations;

namespace Taller_YulianaCapito.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int Titulos { get; set; }
        public string AceptaExtranjeros {  get; set; }
}
