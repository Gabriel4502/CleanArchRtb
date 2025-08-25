using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;
using System;

namespace CleanArch.MVC.InvoiceReport
{
    public class CustomReportProvider : IReportProvider
    {
        public XtraReport GetReport(string id, ReportProviderContext context)
        {

            throw new InvalidOperationException("InvoiceId must be passed from the controller.");
        }

        public static XtraReport CreateReportWithInvoiceId(string reportId, int invoiceId)
        {
            if (ReportsFactory.Reports.TryGetValue(reportId, out var reportFactory))
            {
                return reportFactory(invoiceId);
            }

            throw new InvalidOperationException($"Report '{reportId}' not found.");
        }
    }
}
