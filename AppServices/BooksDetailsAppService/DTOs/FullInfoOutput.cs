using Project_2_2.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.BooksDetailsAppService.DTOs
{
    public class FullInfoOutput
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public DateTime WrittenTime { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public CountryEnum BirthCounty { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public bool isAlive { get; set; }
    }
}
