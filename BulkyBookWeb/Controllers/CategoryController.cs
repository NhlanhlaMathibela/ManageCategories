using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbcontext _db;
        public CategoryController( ApplicationDbcontext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            var ObjCategoryList = _db.Categories;
            return View(ObjCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category Obj)
        {
            if(Obj.Name == Obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category added successfully";
                return RedirectToAction("Index");

            }
            return View(Obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id==0 )
            { 
                return NotFound();
            }
            var CategoriesDB =_db.Categories.Find(id);

            if(CategoriesDB == null)
            {
                return NotFound();

            }
            return View(CategoriesDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category Obj)
        {
            if (Obj.Name == Obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");

            }
            return View(Obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CategoriesDB = _db.Categories.Find(id);

            if (CategoriesDB == null)
            {
                return NotFound();

            }
            return View(CategoriesDB);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var Obj = _db.Categories.Find(id);

            if (Obj == null)
            {
                return NotFound();

            }
            _db.Categories.Remove(Obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
