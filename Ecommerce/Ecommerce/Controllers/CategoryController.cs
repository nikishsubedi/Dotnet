using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Ecommerce.Controllers
{
    //[Route("NewSummit")] // attribute routing
    public class CategoryController:Controller
    {

        private readonly CommerceDbContext _commerceDbContext;
        private readonly ICategoryService _categoryService;

        // Dependency Injection
        public CategoryController(CommerceDbContext commerceDbContext,ICategoryService categoryService)
        {
            _commerceDbContext = commerceDbContext;
            _categoryService = categoryService;
        }
        //[Route("Index123")] attribute routing
        public IActionResult Index()
        {
            List<CategoryModel> categories = _commerceDbContext.Categories.ToList();
            return View(categories);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            //string conString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=myDB;Integrated Security=True;";
            //SqlConnection con = new SqlConnection(conString);
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "insert into Category(Name,Description,isActive) values ('Category 1','New Category in the town',1)";
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //con.Dispose();

            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            _categoryService.Add(model);
            return RedirectToAction("Create");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryModel c = _commerceDbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (c == null)
                c = new CategoryModel();
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(CategoryModel model)
        {

            _commerceDbContext.Categories.Update(model);
            _commerceDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            CategoryModel c = _commerceDbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (c != null)
            {    
                _commerceDbContext.Categories.Remove(c);
                _commerceDbContext.SaveChanges();
            }
                
            return RedirectToAction("Index");
        }
    }
}
