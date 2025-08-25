using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers

{
    public class InvoicesProductsController : Controller
    {
        private readonly IInvoicesProductsService _inProductsService;
        private readonly IProductService _productService;
        private readonly IInvoicesService _invoiceService;
        public InvoicesProductsController(IInvoicesProductsService inProdService,
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
            //ViewBag.InvoiceOptions = new SelectList(invoices, "Id", "Name");

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

        [HttpGet]
        public async Task<IActionResult> Comprar(int? id)
        {
            if (id == null) return NotFound();

            var invoice = await _invoiceService.GetById(id);
            if (invoice == null) return NotFound();

            var products = await _productService.GetProducts();
            var invproducts = await _inProductsService.GetInvoicesProductsByIdEqual(invoice.Id)
                              ?? new List<InvoicesProductsViewModel>();

            ViewBag.ProductOptions = new SelectList(products, "Id", "Name");
            ViewBag.Invoice = invoice;

            var model = new ComprarViewModel
            {
                InvoiceId = invoice.Id,
                Invoice = invoice,
                InvoiceProducts = invproducts
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comprar(ComprarViewModel model)
        {
 
            var toCreate = new InvoicesProductsViewModel
            {
                InvoiceId = model.InvoiceId,
                ProductId = model.ProductId,
                Quantity = model.InvoiceProduct?.Quantity ?? 0,
                SalesPrice = model.InvoiceProduct?.SalesPrice ?? 0m,
                Ammount = (model.InvoiceProduct?.Quantity ?? 0) * (model.InvoiceProduct?.SalesPrice ?? 0m)
            };

        
            ModelState.Clear();
            if (!TryValidateModel(toCreate, prefix: ""))
            {
                var errs = ModelState
                    .Where(k => k.Value?.Errors?.Any() == true)
                    .Select(k => new { k.Key, Errors = k.Value!.Errors.Select(e => e.ErrorMessage) })
                    .ToList();
                System.Diagnostics.Debug.WriteLine("toCreate MS: " + System.Text.Json.JsonSerializer.Serialize(errs));


                var products = await _productService.GetProducts();
                ViewBag.ProductOptions = new SelectList(products, "Id", "Name");
                model.Invoice = await _invoiceService.GetById(model.InvoiceId);
                model.InvoiceProducts = await _inProductsService.GetInvoicesProductsByIdEqual(model.InvoiceId);
                return View(model);
            }

            System.Diagnostics.Debug.WriteLine("toCreate payload: " + System.Text.Json.JsonSerializer.Serialize(toCreate));

            await _inProductsService.Add(toCreate);
            return RedirectToAction(nameof(Comprar), new { id = model.InvoiceId });
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

        [HttpGet]
        public async Task<JsonResult> GetSalesPrice(int productId)
        {
            var product = await _productService.GetById(productId);
            if (product != null)
            {
               
                return Json(new { salesPrice = product.Price });
            }

            return Json(new { salesPrice = 0 });
        }
    }
}
