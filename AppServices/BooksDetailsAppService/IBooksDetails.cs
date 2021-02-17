using Project_2_2.AppServices.BooksDetailsAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.BooksDetailsAppService
{
    public interface IBooksDetails
    {
        string AddBooks(string BookName, DateTime WrittenDate);
        List<BooksDetailsInput> PrintBooks();
        BooksDetailsInput GetBookInfo(int bookId);
        FullInfoOutput GetFullInfoToEdit(int BookId);
        List<FullInfoOutput> BooksWithAuthor();
    }
}
