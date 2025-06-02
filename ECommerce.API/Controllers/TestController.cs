using ECommerce.AdminAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.AdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                if (canConnect)
                    return Ok("✅ Database connection successful.");
                else
                    return StatusCode(500, "❌ Failed to connect to the database.");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "❌ Failed to connect to the database.");
            }
        }
    }
}
