using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.BooksDetailsAppService.DTOs
{
    public class BooksDetailsInput
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime WrittenTime { get; set; }
        public int? AuthorId { get; set; }
    }
}
