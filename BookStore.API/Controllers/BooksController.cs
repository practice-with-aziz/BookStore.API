using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController:ControllerBase
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async ActionResult<List<Book>> GetAllBooks()
        {
            _context.Books.
        }
    }
}
