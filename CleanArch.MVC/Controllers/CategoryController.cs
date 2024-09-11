using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.Services;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _categoryService = service;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetCategories();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Description")] CategoryViewModel category)
        {
            _logger.LogInformation("Create method called with Category: {@Category}", category);
            if (ModelState.IsValid)
            {

                _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }
            var validationErrors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in validationErrors)
            {
                _logger.LogWarning("ModelState Error: {ErrorMessage}", error.ErrorMessage);
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productVM = await _categoryService.GetById(id);
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id, Name, Description")]
            CategoryViewModel categoryVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Update(categoryVM);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productVM = await (_categoryService.GetById(id));

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
            var productVM = await _categoryService.GetById(id);
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
                _categoryService.Remove(id.Value);
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