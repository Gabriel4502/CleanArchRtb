namespace CleanArch.MVC.Controllers
{
    using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
    using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
    using DevExpress.XtraReports.Web.WebDocumentViewer;
    using Microsoft.AspNetCore.Mvc;

    namespace CustomWebDocumentViewerController.Controllers
    {
        public class CustomWebDocumentViewerController : WebDocumentViewerController
        {
            public CustomWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService)
            {
            }
        }
    }

}
