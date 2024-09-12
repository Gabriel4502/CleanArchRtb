using CleanArch.Aplication.Interfaces;
using CleanArch.Aplication.Services;
using CleanArch.Aplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var result = await _customerService.GetCustomers();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Name, Address, City, Email, Phone ")] CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.Add(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound(); 
            var customerVM = await _customerService.GetById(id);
            if (customerVM == null) return NotFound();
            return View(customerVM);

        }

        [HttpPost()]
        public IActionResult Edit([Bind("Id, Name, Address, City, Email, Phone ")] CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.Update(customerVM);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(customerVM);

        }

        public async Task<IActionResult> Details(int? id) {
        
            if (id == null) return NotFound();

            var customerVM = await (_customerService.GetById(id));
            if (customerVM == null) return NotFound();
            return View(customerVM);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customerVM = await _customerService.GetById(id);
            if (customerVM == null) return NotFound();

            return View(customerVM);
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
                _customerService.Remove(id.Value);
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
