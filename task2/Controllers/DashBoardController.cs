using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;
using task2.Models.data;
using Type = task2.Models.Type;

namespace task2.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Blog> _blog = new List<Blog>();

        private static List<Type> _type = new List<Type>();

        private static List<Company> _company = new List<Company>();

        private static List<Product> _product = new List<Product>();
        private readonly ApplicationDbContext _db;


        public DashBoardController(ApplicationDbContext db)
        {
            _company.Add(new Company { Id = 1, Name = "Niki" });
            _company.Add(new Company { Id = 2, Name = "Addidas" });
            _type.Add(new Type { Id = 1, Name = "Action" });
            _type.Add(new Type { Id = 2, Name = "Comidy" });


            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        #region GetAll
        public IActionResult GetAllData()
        {
            var product = _db.Products.Include(p => p.company).ToList();
            return View(product);

        }
        #endregion

        #region delet
        public IActionResult DeletProduct(int id) {
            Product? product = _db.Products.FirstOrDefault(x => x.Id == id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("GetAllData");
        }
        #endregion


        #region edit
        public IActionResult EditProduct(int id)
        {

            Product product = _db.Products.FirstOrDefault(x => x.Id == id);

            return View(product);

        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {

            Product product2 = _db.Products.SingleOrDefault(x => x.Id == product.Id);

            product2.Name = product.Name;
            product2.price = product.price;
            product2.Quantity = product.Quantity;
            product2.EnablSize = product.EnablSize;
            product2.Description = product.Description;
            product2.CompanyId = product.CompanyId;
            _db.Products.Update(product2);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
        #endregion



        #region blog

        #region AddBlog
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            _db.blogs.Add(blog);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        #endregion

        #region GetBlog
        public IActionResult GetBlog() {


            var blog = _db.blogs.Include(p => p.type).ToList();

            return View(blog);

        }
        #endregion


        #region DeletBlog
        public IActionResult DeleteBlog(int id) {

            Blog blog = _db.blogs.SingleOrDefault(X => X.Id == id);
            _db.blogs.Remove(blog);
            _db.SaveChanges();
            return RedirectToAction("GetBlog");
        }
        #endregion


        #region EditBlog

        public IActionResult EditeBlog(int id) {

            Blog blog = _db.blogs.SingleOrDefault(x => x.Id == id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult EditeBlog(Blog blog)
        {

            Blog blog1 = _db.blogs.SingleOrDefault(x => x.Id == blog.Id);

            blog1.Name = blog.Name;
            blog1.TypeId = blog.TypeId;
            blog1.Description = blog.Description;
            _db.Update(blog1);
            _db.SaveChanges();
            return RedirectToAction("GetBlog");
        }
        #endregion

        #endregion
    
    }

} 