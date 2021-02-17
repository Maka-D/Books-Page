using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.Cores
{
    public class BooksInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public DateTime WrittenTime { get; set; }
        public DateTime DateTime { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public AuthorsInfo AuthorsInfo { get; set; }
    }
}
