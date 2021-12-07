using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smstylers.Models
{
    public class Filiaal
    {
        public int Id { get; set; }

        public string Naam { get; set; }
        public ICollection<Voorraad> Voorraad { get; set; }
    }
}
