using CleanArch.Domain.Entities;
using CleanArch.MVC.InvoiceReport;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.MVC.Controllers
{
    public class ReportController : Controller
    {

        public IActionResult InvoiceReport(int id)
        {
            ViewBag.InvoiceId = ("InvoiceId");
            return View();
        }
        
        public IActionResult DocumentViewer(
            [FromServices] IWebDocumentViewerClientSideModelGenerator viewerModelGenerator,
            [FromQuery] string reportName)
        {
            reportName = string.IsNullOrEmpty(reportName) ? "InvoiceReport" : reportName;
            var viewerModel = viewerModelGenerator.GetModel(reportName, WebDocumentViewerController.DefaultUri);
            return View(viewerModel);
        }
    }
}
