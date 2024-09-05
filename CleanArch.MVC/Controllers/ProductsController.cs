using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers

{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController( IProductService productAppService)
        {
            _productService = productAppService;
             
        }


        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Description, Price")] ProductViewModel product)
        {
            if (ModelState.IsValid) { 
            
                _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();
            var productVM = await _productService.GetById(id);
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id, Name, Description, Price")]
            ProductViewModel productVM)
        {
            if (ModelState.IsValid) {
                try
                {
                    _productService.Update(productVM);
                }
                catch (Exception) {
                    throw;
                }
               return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
            return NotFound();
            }
            var productVM = await (_productService.GetById(id));
            
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productVM = await _productService.GetById(id);
            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                _productService.Remove(id.Value);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);

                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
