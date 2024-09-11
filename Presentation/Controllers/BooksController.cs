using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = _manager.BookService.GetAllBooks(false);
            return Ok(query);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBook([FromRoute] int id)
        {
            try
            {
                var query = _manager.BookService.GetOneBookById(id, false);
                if (query == null)
                    return NotFound();

                return Ok(query);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOneBook(Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                _manager.BookService.CreateOneBook(book);

                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBook([FromRoute] int id, [FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); //400

                _manager.BookService.UpdateOneBook(id, book, true); ;
                return NoContent(); //204
            }
            catch (Exception ex)
            {

                throw new(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBook([FromRoute] int id)
        {

            try
            {
                _manager.BookService.DeleteOneBook(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                var entity = _manager.BookService.GetOneBookById(id, true);

                if (entity is null)
                    return NotFound(); //404

                bookPatch.ApplyTo(entity);
                _manager.BookService.UpdateOneBook(id, entity, true);

                return NoContent(); //204
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
