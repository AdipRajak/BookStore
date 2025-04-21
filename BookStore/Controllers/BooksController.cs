using BookStore.Data;
using BookStore.Dtos;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                Description = dto.Description,
                ISBN = dto.ISBN,
                Language = dto.Language,
                Publisher = dto.Publisher,
                PublicationDate = dto.GetPublicationDateUtc(), // Use the UTC conversion method
                Format = dto.Format,
                Stock = dto.Stock,
                Price = dto.Price,
                AvailableInLibrary = dto.AvailableInLibrary,
                IsOnSale = dto.IsOnSale,
                DiscountedPrice = dto.DiscountedPrice,
                DiscountStart = dto.GetDiscountStartUtc(), // Use the UTC conversion method
                DiscountEnd = dto.GetDiscountEndUtc() // Use the UTC conversion method
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto dto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Genre = dto.Genre;
            book.Description = dto.Description;
            book.ISBN = dto.ISBN;
            book.Language = dto.Language;
            book.Publisher = dto.Publisher;
            book.PublicationDate = dto.GetPublicationDateUtc(); // Use the UTC conversion method
            book.Format = dto.Format;
            book.Stock = dto.Stock;
            book.Price = dto.Price;
            book.AvailableInLibrary = dto.AvailableInLibrary;
            book.IsOnSale = dto.IsOnSale;
            book.DiscountedPrice = dto.DiscountedPrice;
            book.DiscountStart = dto.GetDiscountStartUtc(); // Use the UTC conversion method
            book.DiscountEnd = dto.GetDiscountEndUtc(); // Use the UTC conversion method

            await _context.SaveChangesAsync();
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok("Book deleted");
        }
    }
}
