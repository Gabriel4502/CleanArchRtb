using DevExpress.XtraReports.UI;
using CleanArch.MVC.Reports;
using System;
using System.Collections.Generic;

namespace CleanArch.MVC.InvoiceReport
{
    public static class ReportsFactory
    {

        public static Dictionary<string, Func<int, XtraReport>> Reports = new Dictionary<string, Func<int, XtraReport>>()
        {

            ["InvoiceReport"] = (invoiceId) => CreateInvoiceReport(invoiceId)
        };


        private static XtraReport CreateInvoiceReport(int invoiceId)
        {
            var report = new InvoiceProductsReports(invoiceId);


            report.Parameters["InvoiceId"].Value = invoiceId;
            report.Parameters["InvoiceId"].Visible = false;

            return report;
        }
    }
}
