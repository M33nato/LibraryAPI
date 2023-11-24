using ServiceLayer.Interfaces;
using Repositories;
using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Service
{
    public class BookService : IBookService
    {

        private IBookRepository _bookRepository;
        private IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }


        public int GetNextBookId()
        {
            return _bookRepository.GetNextBookId();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public IActionResult GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(book);
        }

        public IActionResult GetByISBN(int isbn)
        {
            var book = _bookRepository.GetByISBN(isbn);
            if (book == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(book);
        }

        public IActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return new OkObjectResult(new { Message = "Delete successfully" });
        }

        public IActionResult PostBody(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return new BadRequestObjectResult("BookDTO is null");
            }

            var book = _mapper.Map<Book>(bookDTO);
            _bookRepository.Add(book);

            return new CreatedAtActionResult(nameof(GetById), "Books", new { id = book.Id }, book);
        }

        public IActionResult Put(int id, BookDTO bookDTO)
        {
            if (bookDTO==null)
            {
                return new BadRequestObjectResult("BookDTO is null");
            }

            var storedBook = _bookRepository.GetById(id);
            if (storedBook == null)
            {
                return new NotFoundResult();
            }

            _mapper.Map(bookDTO, storedBook);
            _bookRepository.Update(storedBook);

            return new OkObjectResult(storedBook);
        }


    }
}
