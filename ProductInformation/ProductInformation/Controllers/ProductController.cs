using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInformation.Models;

namespace ProductInformation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult Create(string categoryID, string name)
        {
            if (Request.Method == "POST")
            {
                try
                {
                    CreateProduct(categoryID, name);
                    ViewBag.Message = $"Successfully created product {name}!";
                }
                catch (Exception e)
                {
                    ViewBag.CategoryID = categoryID;
                    ViewBag.Name = name;
                    ViewBag.Message = e.Message;
                    ViewBag.Error = true;
                }
            }
           
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Products = GetProducts();
            return View();
        }

        public List<Product> GetProducts()
        {
            List<Product> all;
            using (ProductInfoContext context = new ProductInfoContext())
            {
                all = context.Products.Include(x => x.Category).ToList();
            }
            return all;
        }

        public void CreateProduct(string name, string categoryID)
        {
            int parsedCategoryID;

            categoryID = categoryID != null ? categoryID.Trim() : null;
            name = name != null ? name.Trim() : null;

            if(string.IsNullOrWhiteSpace(categoryID))
            {
                throw new Exception("Category ID not provided");
            }
            if (!int.TryParse(categoryID, out parsedCategoryID))
            {
                throw new Exception("Category ID not valid");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name not provided");
            }

            using (ProductInfoContext context = new ProductInfoContext())
            {
                if(context.Categories.Where(x => x.ID == parsedCategoryID).Count() < 1)
                {
                    throw new Exception("Category Does Not Exist");
                }

                context.Products.Add(new Product()
                {
                    Name = name,
                    CategoryID = int.Parse(categoryID)
                });
                context.SaveChanges();
            }
        }
    }
}
