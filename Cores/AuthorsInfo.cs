using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.Cores
{
    public class AuthorsInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public CountryEnum BirthCountry { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public DateTime DateTime { get; set; }

    }
}
