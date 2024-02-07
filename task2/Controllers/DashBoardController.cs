using Microsoft.AspNetCore.Mvc;
using task2.Models;

namespace task2.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Blog> _blog = new List<Blog>();

        private static List<Product> _product = new List<Product>();

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
            int id;
            if (_product.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = _product.Max(x => x.Id) + 1;
            }
            product.Id = id;
            _product.Add(product);
            return RedirectToAction("index");
        }
        #region GetAll
        public IActionResult GetAllData()
        {
            return View(_product);
        }
        #endregion

        #region delet
        public IActionResult DeletProduct(int id) {
            Product product = _product.FirstOrDefault(x => x.Id == id);
            _product.Remove(product);
            return RedirectToAction("GetAllData");
        }
        #endregion


        #region edit
        public IActionResult EditProduct(int id)
        {

            Product product = _product.FirstOrDefault(x => x.Id == id);
         
            return View(product);

        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {

            Product product2 = _product.SingleOrDefault(x => x.Id == product.Id);

            product2.price = product.price;
            product2.Quantity= product.Quantity;
            product2.Quantity=product.Quantity;
            product2.EnablSize= product.EnablSize;  
            product2.company.Id = product.company.Id;
            product2.Name = product.Name;
            product2.Description = product.Description;

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
            int id;
            if (_blog.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = _blog.Max(x => x.Id) + 1;
            }
            blog.Id = id;
            _blog.Add(blog);
            return RedirectToAction("index");
        }
        #endregion

        #region GetBlog
        public IActionResult GetBlog() { 
        
            return View(_blog);

        }
        #endregion


        #region DeletBlog
        public IActionResult DeleteBlog(int id) {

            Blog blog = _blog.SingleOrDefault(X => X.Id == id);
            _blog.Remove(blog);
            return RedirectToAction("GetBlog");
        }
        #endregion


        #region EditBlog

        public IActionResult EditeBlog(int id) { 
        
        Blog blog = _blog.SingleOrDefault(x => x.Id ==id);   
        return View(blog);
        }
        [HttpPost]
        public IActionResult EditeBlog(Blog blog)
        {

            Blog blog1 = _blog.SingleOrDefault(x => x.Id == blog.Id);

            blog1.Name= blog.Name;
            blog1.type.Id= blog.Id;
            blog1.Description= blog.Description;

            return RedirectToAction("GetBlog");
        }
        #endregion

        #endregion



    }

} 