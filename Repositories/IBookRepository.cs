using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;


namespace Repositories
{
    public interface IBookRepository
    {

        int GetNextBookId();
        IEnumerable<Book> GetAllBooks();
        Book GetById(int id);
        Book GetByISBN(int isbn);
        void Delete(int id);
        void Add(Book book);
        void Update(Book book);

    }
}
