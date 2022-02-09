using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using BookStore.Logic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogLogic _logic;

        public CatalogController(CatalogLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Catalog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _logic.ShowCatalog();
        }

        // GET: api/Catalog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _logic.FindBookByID(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // GET: api/Catalog/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookByField(string field)
        {
            var searchList = await _logic.FindBooksByField(field);
            return searchList;
        }

        // POST: api/Catalog
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            _logic.CreateBook(book);

            return NoContent();
        }

        // PUT: api/Catalog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.BookID)
            {
                return BadRequest();
            }

            await _logic.EditBook(book);

            return NoContent();
        }

        // DELETE: api/Catalog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _logic.FindBookByID(id);
            if (book == null)
            {
                return NotFound();
            }

            await _logic.DeleteBook(book);

            return NoContent();
        }
    }
}
