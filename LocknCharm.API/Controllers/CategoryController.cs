using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    public class CategoryController : Controller
    {

        [HttpGet]
        [Route("categories")]
        public IActionResult GetCategories()
        {
            // This is a placeholder for the actual implementation
            // You would typically call a service to get the categories
            return Ok(new { Message = "List of categories" });
        }
    }
}
