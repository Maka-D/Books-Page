using Project_2_2.AppServices.AuthorsDetailsAppService.DTOs;
using Project_2_2.AppServices.BaseAppService;
using Project_2_2.AppServices.BooksDetailsAppService.DTOs;
using Project_2_2.Cores;
using Project_2_2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.AuthorsDetailsAppService
{
    public class AuthorsDetails : IAuthorsDetails, IBaseService
    {
        private readonly AppDbContext _regRepository;
        public AuthorsDetails(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }
        public void CreateAuthor(AuthorsDetailsInput authorInfo)
        {
            if(authorInfo.Name != null && authorInfo.Lastname != null)
            {
                var book = _regRepository.BooksDetails.Where(x => x.Id == authorInfo.BookId).FirstOrDefault();
                if(book.AuthorsInfo == null)
                {
                  AuthorsInfo author = new AuthorsInfo();
                  author.Name = authorInfo.Name;
                  author.Lastname = authorInfo.Lastname;
                  author.BirthCountry = authorInfo.BirthCountry;
                  author.BirthDate = authorInfo.BirthDate;
                  author.DeathDate = authorInfo.DeathDate;
                  author.DateTime = DateTime.Now;
                  book.AuthorsInfo = author;
                  _regRepository.SaveChanges();
                }
                
            }

        }
        //Deletes the row of book with this BookId and author if it has one
        public void DeleteBookAndAuthor(int BookId)
        {
            if(_regRepository.BooksDetails.Any(x=>x.Id == BookId))
            {
                var bookToRemove = _regRepository.BooksDetails.Where(x => x.Id == BookId).FirstOrDefault();
                if(bookToRemove.AuthorId != null)
                {
                    var authorToRemove =_regRepository.AuthorsDetails.Where(x => x.Id == bookToRemove.AuthorId).FirstOrDefault();
                    _regRepository.Remove(authorToRemove);
                }
                _regRepository.Remove(bookToRemove);
                _regRepository.SaveChanges();
            }
        }

        //changes book and author data with new info
        public void UpdateBookAndAuthorInfo(FullInfoOutput updatedInfo)
        {
            if(updatedInfo != null)
            {
                var bookToUpdate = _regRepository.BooksDetails.Where(x => x.Id == updatedInfo.BookId).FirstOrDefault();
                bookToUpdate.BookName = updatedInfo.BookName;
                bookToUpdate.WrittenTime = updatedInfo.WrittenTime;
                if(_regRepository.AuthorsDetails.Any(x=>x.Id == updatedInfo.AuthorId))
                {
                    bookToUpdate.AuthorsInfo.Name = updatedInfo.Name;
                    bookToUpdate.AuthorsInfo.Lastname = updatedInfo.Lastname;
                    bookToUpdate.AuthorsInfo.BirthCountry = updatedInfo.BirthCounty;
                    bookToUpdate.AuthorsInfo.BirthDate = updatedInfo.BirthDate;
                    bookToUpdate.AuthorsInfo.DeathDate = updatedInfo.DeathDate;
                }
                _regRepository.SaveChanges();
            }
        }
    }
}
