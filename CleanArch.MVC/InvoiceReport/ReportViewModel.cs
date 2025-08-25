using DevExpress.XtraReports.Web.WebDocumentViewer;

namespace CleanArch.MVC.InvoiceReport



    {
        public class ReportViewModel
        {
            public WebDocumentViewerModel ViewerModelToBind { get; set; }
            public int InvoiceId {  get; set; }
        }
    }


