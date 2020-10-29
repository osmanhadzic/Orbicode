using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orbicode.Models
{
    public class Food
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public float cijena { get; set; }
        [Display(Name  = "Ocjena")]
        public int MyProperty { get; set; }
        public Restoran restoran{ get; set; }
    }
}
