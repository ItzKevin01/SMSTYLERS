using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace smstylers.Models
{
    public class Surfboards
    {

        public int Id { get; set; }

        public string Product { get; set; }

        public string Beschrijving { get; set; }

        public int Prijs { get; set; }
        public string AfbeeldingsUrl { get; set; }

        public int MateriaalId { get; set; }
        public Materiaal Materiaal { get; set; }
        public ICollection<Voorraad> Voorraad { get; set; }
    }
}
