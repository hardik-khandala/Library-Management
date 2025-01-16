using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Controllers
{
    [ApiController]
    [Route("api/books/[action]")]
    public class BookControllers : ControllerBase
    {

        private readonly BookDbContext _db;
        public BookControllers(BookDbContext db)
        {
            _db = db;
        }

        [HttpGet(Name = "Get All Books")]
        public async Task<ActionResult<IEnumerable<Book>>> getAllBooks()
        {
            var books = await _db.Books.ToListAsync();
            if (books.Count == 0)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> getBookById(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost(Name = "Add a Book")]
        public async Task<ActionResult<Book>> postBook(Book book)
        {
            if (book.Title is null || book.Author is null || book.Price <= 0)
            {
                return BadRequest();
            }
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(getAllBooks), book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> updateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            _db.Entry(book).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_db.Books?.Any(p => p.Id == id)).GetValueOrDefault())
                {
                    return NotFound();
                }
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> deleteBook(int id)
        {
            var book = await _db.Books.FindAsync(id);
            if(book is null)
            {
                return NotFound();  
            }
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("author/{authorName}")]
        public async Task<ActionResult<dynamic>> getBooksByAuthorName(string authorName)
        {
            var b = await _db.Books.Where(b => b.Author == authorName).ToListAsync();
            if (b.Count == 0)
            {
                return NotFound($"No books available from {authorName}");
            }
            return b;
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<dynamic>> getBooksByYear(int year)
        {
            var b = await _db.Books.Where(b => b.YearPublished == year).ToListAsync();
            if (b.Count == 0)
            {
                return NotFound($"No books available from year {year}");
            }
            return b;
        }

        [HttpGet(Name = "Pagination")]
        public async Task<ActionResult> Pagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var query = _db.Books.AsQueryable();
            var books = await _db.Books.ToListAsync();
            var total = books.Count();
            var totalPages = (int)Math.Ceiling((double)total / pageSize);
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return Ok(query);
        }
    }
}
