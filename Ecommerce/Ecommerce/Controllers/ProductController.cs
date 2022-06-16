using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers
{
    
    public class ProductController:Controller
    {
        private readonly CommerceDbContext _commerceDbContext;
        public ProductController(CommerceDbContext commerceDbContext)
        {
            _commerceDbContext = commerceDbContext;
        }
        public IActionResult Index()

        {
            List<ProductViewModel> products = (from p in _commerceDbContext.Products
                                               join c in _commerceDbContext.Categories on
                                               p.CategoryId equals c.Id
                                               //where
                                               select new ProductViewModel
                                               {
                                                   Name = p.Name,
                                                   Id = p.Id,
                                                   CategoryId = p.CategoryId,
                                                   Description = p.Description,
                                                   Photo = p.Photo,
                                                   Price = p.Price,
                                                   Sku = p.Sku,
                                                   CategoryName = c.Name
                                               }).ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //List<CategoryModel> list = _commerceDbContext.Categories.Where(x=>x.IsActive.hasValue?x.isActive.value:false).ToList();
            List<SelectListItem> selectList = _commerceDbContext.Categories.Select(x => new SelectListItem { Text = x.Name,Value=x.Id.ToString()}).ToList();

            ViewBag.Categories = selectList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            _commerceDbContext.Products.Add(model);
            _commerceDbContext.SaveChanges();
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductModel p = _commerceDbContext.Products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                p = new ProductModel();
            return View(p);

        }
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            _commerceDbContext.Products.Update(model);
            _commerceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
