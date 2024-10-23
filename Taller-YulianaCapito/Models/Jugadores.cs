using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller_YulianaCapito.Models
{
    public class Jugadores
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Posicion {  get; set; }
        public int Edad {  get; set; }

        public Equipo Equipo { get; set; }

        [ForeignKey("Equipo")]
        public int IdEquipo { get; set; }

    }
}
