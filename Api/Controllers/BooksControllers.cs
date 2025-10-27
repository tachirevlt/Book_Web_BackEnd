using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Queries;
using Core.Entities;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] BookEntity book)
        { 
            var result = await sender.Send(new AddBookCommand(book));
            return Ok(result);
        }

 
        [HttpGet("{BookId}")]
        public async Task<IActionResult> GetBookByIdAsync([FromRoute] Guid BookId)
        {
            var result = await sender.Send(new GetBookByIdQuery(BookId));
            if (result == null) // Hoặc dùng Result Pattern nếu bạn triển khai
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }
            return Ok(result);
        }

        [HttpPut("{BookId}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute] Guid BookId, [FromBody] BookEntity Book)
        {
            var result = await sender.Send(new UpdateBookCommand(BookId, Book));
            if (result == null) // Hoặc dùng Result Pattern nếu bạn triển khai
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }
            return Ok(result);
        }

        [HttpDelete("{BookId}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] Guid BookId)
        {
            var result = await sender.Send(new DeleteBookCommand(BookId));
            if (result == null) // Hoặc dùng Result Pattern nếu bạn triển khai
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }
            return Ok(result);
        }
    }


}
