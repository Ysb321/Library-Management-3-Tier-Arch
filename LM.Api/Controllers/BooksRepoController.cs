using LM.BussinessLayer.Model;
using LM.DataAccessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksRepoController : ControllerBase
    {
        private readonly IBooksRepo _booksRepo;
        public BooksRepoController(IBooksRepo booksRepo)
        {
            _booksRepo = booksRepo;
        }

        [HttpGet("list")]
        public IActionResult BooksList()
        {
            var booksList = _booksRepo.List();
            if(booksList != null)
            {
                return Ok(booksList);
            }
            return BadRequest("Book not found!!!");
        }
        [HttpPost("create")]
        public IActionResult BooksCreate(Books books)
        {
            var result = _booksRepo.Create(books);
            if(result == 1)
            {
                return Ok(result);
            }
            return BadRequest("Record is not created!!");
        }

        [HttpPut("update/{id}")]
        public IActionResult BooksUpdate(Books Update)
        {
            var result = _booksRepo.Update(Update);
            if(result == 1)
            {
                return Ok("Record Update Successfully!!");
            }
            return BadRequest("Record is not Updated!!");
        }

        [HttpDelete("deletebook/{id}")]
        public IActionResult BooksDelete(int id)
        {
            if(id==0)
            {
                return Ok("Record is not found!!");
            }
            _booksRepo.Delete(id);
            return BadRequest("Record is Deleted!!");
        }

    }
}
