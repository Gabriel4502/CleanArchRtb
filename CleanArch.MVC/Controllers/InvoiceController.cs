using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.Services;
using CleanArch.Aplication.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.MVC.InvoiceReport;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoicesService _invoiceService;
        private readonly IProductService _productService1;
        private ILogger<InvoiceController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IInvoicesProductsService _productService;
        public InvoiceController(IInvoicesService invoiceService, ILogger<InvoiceController> logger, ICustomerService customer, IInvoicesProductsService productService, IProductService productService1)
        {
            _invoiceService = invoiceService;
            _customerService = customer;
            _logger = logger;
            _productService = productService;
            _productService1 = productService1;
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

        //[HttpGet]
        //public async Task<IActionResult> Comprar(Nullable<int> id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }


        //    var invoiceVm = await _invoiceService.GetById(id);

        //    var invoiceProd = _productService.GetInvoicesProducts().Result.Where(_ => _.InvoiceId == id).ToList();
        //    invoiceVm.InvoicesProducts = invoiceProd;
        //    var productList = await _productService1.GetProducts();
        //    invoiceVm.InvoiceProduct = new InvoicesProductsViewModel();

        //    // Armazena a lista no ViewBag
        //    ViewBag.ProductsOptions = invoiceProd.Select(ip => new SelectListItem
        //    {
        //        Value = ip.Id.ToString(),
        //        Text = $"ID: {ip.Id} | Quantity: {ip.Quantity} | Sales Price: {ip.SalesPrice:F2} | Product-Name: {ip.Product?.Name}"
        //    }).ToList();

        //    invoiceVm.ProductList = productList;

        //    ViewBag.ProductList = productList.Select(p => new SelectListItem
        //    {
        //        Value = p.Id.ToString(),
        //        Text = $"{p.Name} - {p.Price:C}"
        //    }).ToList();

        //    if (invoiceVm == null) return NotFound();

        //    return View(invoiceVm);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Comprar([Bind("Id, InvoiceProduct.ProductId, InvoiceProduct.Quantity, InvoiceProduct.SalesPrice")] InvoiceViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Console.WriteLine(model);
        //        if (model.ProductsOptions == null || !model.ProductsOptions.Any())
        //        {
        //            Console.WriteLine("A lista de InvoicesProducts está vazia.");
        //            ModelState.AddModelError(string.Empty, "Nenhum produto foi selecionado para compra.");

        //        }

        //        var invoice = await _invoiceService.GetById(model.Id);

        //        if (invoice != null)
        //        {
        //            //foreach (var item in model.ProductsOptions)
        //            //{
        //            //    var invoiceProduct = new InvoicesProductsViewModel
        //            //    {
        //            //        ProductId = item.ProductId,
        //            //        Quantity = item.Quantity,
        //            //        SalesPrice = item.SalesPrice,
        //            //        InvoiceId = model.Id
        //            //    };

        //            //    _productService.Add(invoiceProduct);
        //            //}
        //            //_productService.Add(model.InvoiceProduct);

        //            var invoiceProduct = new InvoicesProductsViewModel
        //            {
        //                ProductId = model.InvoiceProduct.ProductId,
        //                Quantity = model.InvoiceProduct.Quantity,
        //                SalesPrice = model.InvoiceProduct.SalesPrice,
        //                InvoiceId = model.Id
        //            };

        //            _productService.Add(invoiceProduct);

        //            return RedirectToAction("Index");
        //        }
        //    }

        //    foreach (var modelStateKey in ModelState.Keys)
        //    {
        //        var value = ModelState[modelStateKey];
        //        foreach (var error in value.Errors)
        //        {
        //            Console.WriteLine($"Erro no campo {modelStateKey}: {error.ErrorMessage}");
        //        }
        //    }

        //    // Caso ocorra algum erro, recarrega a lista de produtos
        //    var invoiceVm = await _invoiceService.GetById(model.Id);
        //    var productList = await _productService1.GetProducts();
        //    ViewBag.ProductList = productList.Select(p => new SelectListItem
        //    {
        //        Value = p.Id.ToString(),
        //        Text = $"{p.Name} - {p.Price:C}"
        //    }).ToList();

        //    var invoiceProd = _productService.GetInvoicesProducts().Result.Where(_ => _.InvoiceId == model.Id).ToList();
        //    ViewBag.ProductsOptions = invoiceProd.Select(ip => new SelectListItem
        //    {
        //        Value = ip.Id.ToString(),
        //        Text = $"ID: {ip.Id} | Quantity: {ip.Quantity} | Sales Price: {ip.SalesPrice:F2} | Product-Name: {ip.Product?.Name}"
        //    }).ToList();

        //    return View(invoiceVm);
        //}


        public IActionResult Comprar(int? id)
        {
           return RedirectToAction("InvoicesProducts/Comprar");
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

        [HttpPost]
        public IActionResult GeneratePdfReport(int invoiceId)
        {

            var invoiceData = _invoiceService.GetById (invoiceId);

           
            var report = new InvoiceProductsReport();

            report.Parameters["InvoiceId"].Value = invoiceId;
            report.CreateDocument();

            String reportName = report.Name;
            using (var memoryStream = new MemoryStream())
            {
                report.ExportToPdf(memoryStream);
                return File(memoryStream.ToArray(), "application/pdf", "InvoiceReport.pdf");
            }
        }



       
    }
}
