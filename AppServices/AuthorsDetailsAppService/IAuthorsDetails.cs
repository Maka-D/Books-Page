using Project_2_2.AppServices.AuthorsDetailsAppService.DTOs;
using Project_2_2.AppServices.BooksDetailsAppService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.AuthorsDetailsAppService
{
    public interface IAuthorsDetails
    {
        void CreateAuthor(AuthorsDetailsInput authorInfo);
        void UpdateBookAndAuthorInfo(FullInfoOutput updatedInfo);
        void DeleteBookAndAuthor(int BookId);

    }
}
