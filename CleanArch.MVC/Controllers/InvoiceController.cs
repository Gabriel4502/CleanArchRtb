using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.Services;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoicesService _invoiceService;
        private ILogger<InvoiceController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IInvoicesProductsService _productService;
        public InvoiceController(IInvoicesService invoiceService, ILogger<InvoiceController> logger, ICustomerService customer, IInvoicesProductsService productService)
        {
            _invoiceService = invoiceService;
            _customerService = customer;
            _logger = logger;
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _invoiceService.GetInvoices();
            return View(result);
        }

        [HttpGet()]
        public async Task <IActionResult> Create()
        {
            var customers = await _customerService.GetCustomers();

            ViewBag.CustomerId = new SelectList(customers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId, Description")] InvoiceViewModel invoice)
        {
            if (ModelState.IsValid)
            {

                _invoiceService.Add(invoice);
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            var customers = await _customerService.GetCustomers();

            ViewBag.CustomerId = new SelectList(customers, "Id", "Name");

            if (id == null) return NotFound();
            var invoiceVM = await _invoiceService.GetById(id);
            if (invoiceVM == null) return NotFound();
            return View(invoiceVM);
        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id,CustomerId, Description, Ammount")]
            InvoiceViewModel invoiceVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    _invoiceService.Update(invoiceVM);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceVM);
        }


        public async Task<IActionResult> Details(int? id)
        {

            var products = _productService.GetInvoicesProducts().Result.Where(_ => _.InvoiceId == id).ToList();
            ViewBag.ProductsOptions = products.Select(ip => new SelectListItem
            {
                Value = ip.Id.ToString(),
                Text = $"ID: {ip.Id} | Quantity: {ip.Quantity} | Sales Price: {ip.SalesPrice:F2} | Product-Name: {ip.Product?.Name}"
            }).ToList();
            if (id == null)
            {
                return NotFound();
            }
            var invoiceVM = await (_invoiceService.GetById(id));

            if (invoiceVM == null) return NotFound();
            return View(invoiceVM);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var invoiceVM = await _invoiceService.GetById(id);
            if (invoiceVM == null) return NotFound();

            return View(invoiceVM);
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
                _logger.LogInformation("Executando método deleteConfirmed");
                _invoiceService.Remove(id.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting invoice with ID: {InvoiceId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting invoice.");
                Console.WriteLine(ex.Message);

                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
