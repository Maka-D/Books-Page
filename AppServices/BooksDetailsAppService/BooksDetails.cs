using Project_2_2.AppServices.BaseAppService;
using Project_2_2.AppServices.BooksDetailsAppService.DTOs;
using Project_2_2.Cores;
using Project_2_2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2_2.AppServices.BooksDetailsAppService
{
    public class BooksDetails : IBooksDetails, IBaseService
    {
        private readonly AppDbContext _regRepository;
        public BooksDetails(AppDbContext regRepository)
        {
            _regRepository = regRepository;
        }
        //method to add new books to database
        public string AddBooks(string BookName, DateTime WrittenDate)
        {
            if (BookName != null)
            {
                if (_regRepository.BooksDetails.Any(x=>x.BookName == BookName))
                {
                    return "Arsebobs";
                }
                else
                {
                    BooksInfo newBook = new BooksInfo();
                    newBook.BookName = BookName.Trim();
                    newBook.WrittenTime = WrittenDate;
                    newBook.DateTime = DateTime.Now;
                    _regRepository.BooksDetails.Add(newBook);
                    _regRepository.SaveChanges();
                    return "True";
                }

            }
            else
            {
                return "False";
            }

        }
        //returns the list of books with authors info to output
        public List<FullInfoOutput> BooksWithAuthor()
        {
            if(_regRepository.AuthorsDetails != null)
            {
                List<FullInfoOutput> booksWithAuthorsList = new List<FullInfoOutput>();
                var booksTable = _regRepository.BooksDetails;
                foreach(var item in booksTable)
                {
                    
                    if(item.AuthorId != null)
                    {
                        FullInfoOutput bookWithAuthor = new FullInfoOutput();
                        bookWithAuthor.BookId = item.Id;
                        bookWithAuthor.BookName = item.BookName;
                        bookWithAuthor.WrittenTime = item.WrittenTime;
                        item.AuthorsInfo = _regRepository.AuthorsDetails.Where(x => x.Id == item.AuthorId).FirstOrDefault();
                        bookWithAuthor.AuthorId = item.AuthorsInfo.Id;
                        bookWithAuthor.Name = item.AuthorsInfo.Name;
                        bookWithAuthor.Lastname = item.AuthorsInfo.Lastname;
                        bookWithAuthor.BirthCounty = item.AuthorsInfo.BirthCountry;
                        bookWithAuthor.BirthDate = item.AuthorsInfo.BirthDate;                        
                        if(item.AuthorsInfo.DeathDate == null)
                        {
                            bookWithAuthor.isAlive = true;
                        }
                        else
                        {
                            bookWithAuthor.DeathDate = item.AuthorsInfo.DeathDate;
                        }
                        booksWithAuthorsList.Add(bookWithAuthor);
                    }
                    
                    
                }
                return booksWithAuthorsList;
                 
            }
            else
            {
                return new List<FullInfoOutput>();
            }
        }

        //returns the book which we want to add author, if book already has an author it returns empty object
        public BooksDetailsInput GetBookInfo(int bookId)
        {
            BooksInfo bookInfo = _regRepository.BooksDetails.Where(x => x.Id == bookId).FirstOrDefault();
            BooksDetailsInput getBookInfo = new BooksDetailsInput();
            if(bookInfo.AuthorId == null)
            {             
               getBookInfo.BookName = bookInfo.BookName;
               getBookInfo.Id = bookInfo.Id;
               getBookInfo.WrittenTime = bookInfo.WrittenTime;               
            }
            return getBookInfo;
            
        }
        //returns books and authors data to edit
        public FullInfoOutput GetFullInfoToEdit(int BookId)
        {
            if (_regRepository.BooksDetails.Any(x => x.Id == BookId))
            {
                var bookToEdit = _regRepository.BooksDetails.Where(x => x.Id == BookId).FirstOrDefault();
                
                FullInfoOutput fullInfo = new FullInfoOutput();
                fullInfo.BookId = bookToEdit.Id;              
                fullInfo.BookName = bookToEdit.BookName;
                fullInfo.WrittenTime = bookToEdit.WrittenTime;               
                if(bookToEdit.AuthorId != null)
                {
                   bookToEdit.AuthorsInfo = _regRepository.AuthorsDetails.Where(x => x.Id == bookToEdit.AuthorId).FirstOrDefault();
                   fullInfo.AuthorId = bookToEdit.AuthorsInfo.Id;
                   fullInfo.Name = bookToEdit.AuthorsInfo.Name;
                   fullInfo.Lastname = bookToEdit.AuthorsInfo.Lastname;
                   fullInfo.BirthCounty = bookToEdit.AuthorsInfo.BirthCountry;
                   fullInfo.BirthDate = bookToEdit.AuthorsInfo.BirthDate;
                   if(bookToEdit.AuthorsInfo.DeathDate == null)
                   {
                      fullInfo.isAlive = true;
                   }
                   else
                   {
                      fullInfo.DeathDate = bookToEdit.AuthorsInfo.DeathDate;
                   }
                }
                
                return fullInfo;
                
            }
            else{
                return new FullInfoOutput();
            }
        }

        //method to print all books on ShowBooks page, it returns the list of books
        public List<BooksDetailsInput> PrintBooks()
        {
            List<BooksDetailsInput> booksList = new List<BooksDetailsInput>();
            var sortedBooks = _regRepository.BooksDetails.OrderByDescending(x => x.DateTime);
            foreach(var item in sortedBooks)
            {
                BooksDetailsInput book = new BooksDetailsInput();
                book.AuthorId = item.AuthorId;
                book.BookName = item.BookName;
                book.WrittenTime = item.WrittenTime;
                book.Id = item.Id;
                booksList.Add(book);
            }
            return booksList;
        }
    }
}
