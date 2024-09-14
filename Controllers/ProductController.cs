using DeveloperTask.Data;
using DeveloperTask.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace DeveloperTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int? page, string search)
        {
            //    List<Product> objProductList = _db.Products.ToList();
            //    return View(objProductList);

               int pageSize = 5;
               int pageNumber = (page ?? 1);

              ViewBag.CurrentFilter = search;


            var products = _db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.ProductName.Contains(search) ||
                                                p.Price.ToString().Contains(search) ||
                                                p.Quantity.ToString().Contains(search));
            }

            var pagedProducts = products.ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated Successfully";

                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _db.Products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Products.Remove(obj);
            TempData["Success"] = "Category deleted Successfully";

            _db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}
