using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Interfaces
{
    public interface IBookService
    {
        int GetNextBookId();
        IEnumerable<Book> GetAllBooks();   
        IActionResult GetById(int id);
        IActionResult GetByISBN(int isbn);
        IActionResult Delete(int id);
        IActionResult PostBody(BookDTO bookDTO);
        IActionResult Put(int id, BookDTO bookDTO);


    }
}
