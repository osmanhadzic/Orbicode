using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orbicode.Models
{
    public class Restoran
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string brojTelefona { get; set; }

        public ICollection<Food> foods { get; set; }

    }
}
