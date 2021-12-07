using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace smstylers.Models
{
    public class Voorraad
    {
        [ForeignKey("Surfboards")]
        public int SurfboardId { get; set; }

        public Surfboards Surfboards { get; set; }

        [ForeignKey("Filiaal")]
        public int FiliaalId { get; set; }

        public Filiaal Filiaal { get; set; }
        [Range(0,20)]
        public int Aantal { get; set; }
    }
}