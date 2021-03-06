using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Bangazon.Models.ProductViewModels;

namespace Bangazon.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Product.Include(p => p.ApplicationUser).Include(p => p.ProductType);

            var productList = await applicationDbContext.ToListAsync();

            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Products = productList
            };
            return View(productListViewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ApplicationUser)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            var productSales = (_context.OrderProduct
                .Join(_context.Order, 
                op => op.OrderId,
                o => o.OrderId,
                (op, o) => new {OrderProduct = op, Order = o})
                .Where(opAndo => opAndo.OrderProduct.ProductId == product.ProductId)
                .Where(opAndo => opAndo.Order.PaymentTypeId != null)).Count();

            product.Quantity = product.Quantity - productSales;


            if (product == null)
            {
                return NotFound();
            }
            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel(product);
            return View(productDetailViewModel);
        }
       
        public async Task<IActionResult> Types()
        {
            var model = new ProductTypesViewModel();

            // Build list of Product instances for display in view
            // LINQ is awesome
            model.GroupedProducts = await (
                from t in _context.ProductType
                join p in _context.Product
                on t.ProductTypeId equals p.ProductTypeId
                group new { t, p } by new { t.ProductTypeId, t.Label } into grouped
                select new GroupedProducts
                {
                    TypeId = grouped.Key.ProductTypeId,
                    TypeName = grouped.Key.Label,
                    ProductCount = grouped.Select(x => x.p.ProductId).Count(),
                    Products = grouped.Select(x => x.p).Take(3)
                }).ToListAsync();

            return View(model);
        }

        // GET: Products/Create
        // Sends user to Create product view. ProductTypes are added to the Products SelectList on the ProductCreateViewModel
        public async Task<IActionResult> Create()
        {

            ProductCreateViewModel product = new ProductCreateViewModel();
            product.Product = new Product();
            product.Product.ApplicationUser = await GetCurrentUserAsync();
            product.Products = new SelectList(_context.ProductType, "ProductTypeId", "Label").ToList();
            product.Products.Insert(0, new SelectListItem { Text = "None", Value = "0" });
            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // On submission of the new product. Create Post will only be called if all the fields are valid. Adds the current userId to the
        // product being posted to the DB
        // If ModelState validation fails, a new ProductCreateViewModel will be generated with the current Products information and will
        // be returned to the view. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Description,City,Title,Price,Quantity,ApplicationUserId,ProductTypeId")] Product product)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();
            product.ApplicationUserId = currentUser.Id;
            ModelState.Remove("product.ApplicationUserId");
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ProductCreateViewModel returnModel = new ProductCreateViewModel()
            {
                Product = product,
                Products = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId).ToList()
            };
            returnModel.Product.ApplicationUser = await GetCurrentUserAsync();
            returnModel.Products.Insert(0, new SelectListItem { Text = "None", Value = "0" });
            return View(returnModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.ApplicationUserId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DateCreated,Description,City,Title,Price,Quantity,ApplicationUserId,ProductTypeId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", product.ApplicationUserId);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductType, "ProductTypeId", "Label", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ApplicationUser)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
        
        public async Task<IActionResult> Search (string searchQuery)
        {
            

            if (searchQuery.Contains("city:"))
            {
                
                List<string> newQuery = searchQuery.Split(" ").ToList();

                //string cityQuery = newQuery.Where(x => x.Contains("city:")).ToString();
                string cityThing = "";
                string queryString = "";
                List<string> newArray = new List<string>();

                newQuery.ForEach(thing =>
                {
                    if (thing.Contains("city:"))
                    {
                        cityThing = thing.Remove(0,5).ToString();
                    }
                    else
                    {
                        newArray.Add(thing);
                    }
                });
                queryString = String.Join(" ", newArray);
                List<Product> searchResults = new List<Product>();
                searchResults = (queryString != "") ? await _context.Product.Where(e => (e.Title.Contains(queryString) && e.City == cityThing)).ToListAsync() : await _context.Product.Where(e => (e.City == cityThing)).ToListAsync();
                return View(searchResults);
            }
            else
            {
                List<Product> searchResults = new List<Product>();
                searchResults = await _context.Product.Where(e => e.Title.Contains(searchQuery)).ToListAsync();
                return View(searchResults);
            }
        }
    }
}

