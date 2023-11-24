using DataAccessLayer.Models;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class BookRepository : IBookRepository
    {
        private DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public int GetNextBookId()
        {
            return _context.books.Any() ? _context.books.Max(x => x.Id) + 1 : 1;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.books;
        }

        public Book GetById(int id)
        {
            return _context.books.SingleOrDefault(x => x.Id == id);
        }

        public Book GetByISBN(int isbn)
        {
            return _context.books.SingleOrDefault(t => t.ISBN == isbn);
        }

        public void Delete(int id)
        {
            var bookToRemove = _context.books.SingleOrDefault(x => x.Id == id);
            if (bookToRemove != null)
            {
                _context.books.Remove(bookToRemove);
                
                _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('books', RESEED, 0)");
                _context.SaveChanges();
            }
        }

        public void Add(Book book)
        {
            //book.Id = GetNextBookId();
            _context.books.Add(book);
            _context.SaveChanges();

        }

        public void Update(Book book)
        {
            var existingBook = _context.books.SingleOrDefault(x => x.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Genre = book.Genre;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.BorrowedTime = book.BorrowedTime;
                existingBook.ReturnTime = book.ReturnTime;

                _context.SaveChanges();
            }
        }
    }
}
