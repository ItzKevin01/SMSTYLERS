using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smstylers.Models
{
    public class Afspraak
    {
        public int Id { get; set; }

        public string Surfboard { get; set; }

        public string Materiaal { get; set; }
        public string Naam { get; set; }

        public string Achternaam { get; set; }

        public string Email { get; set; }

        public string Telefoonnummer { get; set; }
    }
}
