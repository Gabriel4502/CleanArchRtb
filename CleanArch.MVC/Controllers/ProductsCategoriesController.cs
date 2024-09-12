using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers

{
    public class ProductsCategoriesController : Controller
    {
        private readonly IProductsCategoriesService _pCatService;
        public ProductsCategoriesController(IProductsCategoriesService pCatService)
        {
            _pCatService = pCatService;

        }


        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var result = await _pCatService.GetProductsCategories();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryId,ProductId")] ProductsCategoriesViewModel pCategoryVm)
        {
            if (ModelState.IsValid)
            {
                _pCatService.Add(pCategoryVm);
                return RedirectToAction(nameof(Index));
            }
            return View(pCategoryVm);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productVM = await _pCatService.GetById(id);
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("CategoryId, ProductId")]
            ProductsCategoriesViewModel pCategoryVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _pCatService.Update(pCategoryVm);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pCategoryVm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productVM = await (_pCatService.GetById(id));

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
            var productVM = await _pCatService.GetById(id);
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
                _pCatService.Remove(id.Value);
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
