using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var allBooks = await _context.Books.ToListAsync();
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book is null)
            {
                return NotFound($"Book with ID {id} was not found");
            }
            else
            {
                return Ok(book);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            book.BookId = 0;
            _context.Books.Add(book); 
            await _context.SaveChangesAsync(); 

            return CreatedAtAction(nameof(GetBookById), new {id = book.BookId}, book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            if(id != book.BookId)
            {
                return BadRequest("route id and body id does not match");
            }
            var findBook = await _context.Books.FindAsync(id);
            if(findBook == null)
            {
                return NotFound($"the book with ID {id} could not be find, hence it cannot be updated");
            }
            findBook.Title = book.Title;
            findBook.Author = book.Author;
            findBook.Price = book.Price;
            findBook.Genre = book.Genre;

            await _context.SaveChangesAsync();
            return Ok(findBook);
        }
    }
}
