using E_Commerce_Housing.Data;
using E_Commerce_Housing.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Housing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryobj = _db.Categories.ToList();

            return View(categoryobj);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //Custom Validation
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order and Display Name Should Not Be Same");
            }


            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id); //only on primary key
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryID == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.CategoryID == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //Custom Validation
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order and Display Name Should Not Be Same");
            }


            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
