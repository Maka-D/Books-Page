using Project_2_2.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.AuthorsDetailsAppService.DTOs
{
    public class AuthorsDetailsInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public CountryEnum BirthCountry { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int BookId { get; set; }
        public bool isAlive { get; set; }

    }
}
