using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orbicode.Models
{
    public class Restoran
    {
        public int id { get; set; }
        [Display(Name = "Naziv")]
        public string naziv { get; set; }
        [Display(Name = "Adresa")]
        public string adresa { get; set; }
        [Display(Name = "Broj Telefona")]
        public string brojTelefona { get; set; }

        public ICollection<Food> foods { get; set; }

    }
}
