using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers

{
    public class InvoicesProducts : Controller
    {
        private readonly IInvoicesProductsService _inProductsService;
        public InvoicesProducts(IInvoicesProductsService inProdService)
        {
            _inProductsService = inProdService;

        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _inProductsService.GetInvoicesProducts();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Quantity, SalesPrice, Ammount, InvoiceId, ProductId")] InvoicesProductsViewModel invoiceProdVm)
        {
            if (ModelState.IsValid)
            {

                _inProductsService.Add(invoiceProdVm);
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceProdVm);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productVM = await _inProductsService.GetById(id);
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id, Quantity, SalesPrice, Ammount, InvoiceId, ProductId")]
            InvoicesProductsViewModel invoiceProdVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _inProductsService.Update(invoiceProdVm);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceProdVm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productVM = await (_inProductsService.GetById(id));

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
            var productVM = await _inProductsService.GetById(id);
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
                _inProductsService.Remove(id.Value);
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
