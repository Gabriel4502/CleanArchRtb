using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers

{
    public class InvoicesProducts : Controller
    {
        private readonly IInvoicesProductsService _inProductsService;
        private readonly IProductService _productService;
        private readonly IInvoicesService _invoiceService;
        public InvoicesProducts(IInvoicesProductsService inProdService,
            IProductService prodService, IInvoicesService invoicesService )
        {
            _inProductsService = inProdService;
            _productService = prodService;
            _invoiceService = invoicesService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _inProductsService.GetInvoicesProducts();
            return View(result);
        }

        [HttpGet()]
        public async Task <IActionResult> Create()
        {

            var products  = await _productService.GetProducts();
            var invoices  = await _invoiceService.GetInvoices();

            ViewBag.InvoiceId = new SelectList(invoices , "Id","Description");
            ViewBag.ProductId = new SelectList(products, "Id", "Name");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>  Create([Bind("Id, Quantity, SalesPrice, Ammount, InvoiceId, ProductId")] InvoicesProductsViewModel invoiceProdVm)
        {
            if (ModelState.IsValid)
            {

                await _inProductsService.Add(invoiceProdVm);
                return RedirectToAction(nameof(Index));
            }
            ModelState.Clear();
            return View(invoiceProdVm);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            var productVM = await _inProductsService.GetById(id);
            var products  = await _productService.GetProducts();
            var invoices  = await _invoiceService.GetInvoices();

            ViewBag.InvoiceId = new SelectList(invoices , "Id","Description");
            ViewBag.ProductId = new SelectList(products, "Id", "Name");
            if (id == null) return NotFound();
           
            if (productVM == null) return NotFound();
            return View(productVM);
        }

        [HttpPost()]
        public async Task <IActionResult> Edit([Bind("Id, Quantity, SalesPrice, Ammount, InvoiceId, ProductId")]
            InvoicesProductsViewModel invoiceProdVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _inProductsService.Update(invoiceProdVm);
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
