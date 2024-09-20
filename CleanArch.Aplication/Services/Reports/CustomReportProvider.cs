//using DevExpress.XtraReports.Services;
//using DevExpress.XtraReports.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CleanArch.Aplication.Services.Reports
//{
//    public class CustomReportProvider : IReportProvider
//    {
//        public XtraReport GetReport(string id, ReportProviderContext context)
//        {
//            if (ReportsFactory.Reports.TryGetValue(id, out var report))
//            {
//                return report();
//            }
//            throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", id));
//        }

//    }
//}
