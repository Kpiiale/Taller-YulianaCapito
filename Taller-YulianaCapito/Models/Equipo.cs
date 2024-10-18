using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller_YulianaCapito.Models
{
    public class Equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Ciudad { get; set; }
        public int Titulos { get; set; }
        public string AceptaExtranjeros {  get; set; }
        public Jugadores Jugadores { get; set; } 

        [ForeignKey("Jugadores")]
        public int IdJugador { get; set; }
}
