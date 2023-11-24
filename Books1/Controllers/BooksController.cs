using AutoMapper;
using DataAccessLayer.DataAccess;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace Books1.Controllers
{
    [Route("/api/[controller]")]
    public class BooksController : Controller
    {
        private IMapper mapper;
        private IBookService _bookService;
        private DataContext _context;
        public BooksController(IMapper mapper, IBookService bookService,DataContext context)
        {
            this.mapper = mapper;
            _bookService = bookService;
            _context = context;
        }

        [HttpGet("next")]
        public int GetNextBookId()
        {
            return _bookService.GetNextBookId();
        }
        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return _bookService.GetById(id);
        }
        [HttpGet("isbn/{isbn}")]
        public IActionResult GetByISBN(int isbn)
        {
            return _bookService.GetByISBN(isbn);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _bookService.Delete(id);
        }
        [HttpPost]
        public IActionResult PostBody([FromBody] BookDTO bookDTO)
        {
            return _bookService.PostBody(bookDTO);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDTO bookDTO)
        {
            return _bookService.Put(id, bookDTO);
        }
    }
}
