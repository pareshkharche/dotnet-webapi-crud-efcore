using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //static private List<Book> books = new List<Book>
        //{
        //new Book
        //{
        //    Id = 1,
        //    Title = "Clean Code",
        //    Author = "Robert C. Martin",
        //    YearPublished = 2008
        //},
        //new Book
        //{
        //    Id = 2,
        //    Title = "The Pragmatic Programmer",
        //    Author = "Andrew Hunt",
        //    YearPublished = 1999
        //},
        //new Book
        //{
        //    Id = 3,
        //    Title = "Design Patterns",
        //    Author = "Erich Gamma",
        //    YearPublished = 1994
        //},
        //new Book
        //{
        //    Id = 4,
        //    Title = "Refactoring",
        //    Author = "Martin Fowler",
        //    YearPublished = 1999
        //},
        //new Book
        //{
        //    Id = 5,
        //    Title = "Introduction to Algorithms",
        //    Author = "Thomas H. Cormen",
        //    YearPublished = 2009
        //},
        //new Book
        //{
        //    Id = 6,
        //    Title = "Head First Design Patterns",
        //    Author = "Eric Freeman",
        //    YearPublished = 2004
        //},
        //new Book
        //{
        //    Id = 7,
        //    Title = "You Don’t Know JS",
        //    Author = "Kyle Simpson",
        //    YearPublished = 2015
        //},
        //new Book
        //{
        //    Id = 8,
        //    Title = "Effective Java",
        //    Author = "Joshua Bloch",
        //    YearPublished = 2001
        //},
        //new Book
        //{
        //    Id = 9,
        //    Title = "C# in Depth",
        //    Author = "Jon Skeet",
        //    YearPublished = 2019
        //},
        //new Book
        //{
        //    Id = 10,
        //    Title = "System Design Interview",
        //    Author = "Alex Xu",
        //    YearPublished = 2020
        //}
        //};


        private readonly FirstAPIContext _context;
        public BooksController(FirstAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book =await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        

       [HttpPost]
       public async Task<ActionResult<Book>> AddBook(Book newBook)
       {
           if (newBook == null)
               return BadRequest();

           _context.Books.Add(newBook);
            await _context.SaveChangesAsync();

           return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);

       }


       
       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateBook(int id, Book updateBook)
       {
           var book = await _context.Books.FindAsync(id);
           if (book == null)
           {
               return NotFound();
           }

           book.Id = updateBook.Id;
           book.Title = updateBook.Title;
           book.Author = updateBook.Author;
           book.YearPublished = updateBook.YearPublished;

           await _context.SaveChangesAsync(); 

           return NoContent();
       }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();


            return NoContent();
        }
      
    }
}
