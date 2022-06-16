using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly CommerceDbContext _commerceDbContext;

        // Dependency Injection
        public CategoryApiController(CommerceDbContext commerceDbContext)
        {
            _commerceDbContext = commerceDbContext;
        }
        //[Route("Index123")] attribute routing
        public List<CategoryModel> Get()
        {
            List<CategoryModel> categories = _commerceDbContext.Categories.ToList();
            return categories; 
        }
    }
}
