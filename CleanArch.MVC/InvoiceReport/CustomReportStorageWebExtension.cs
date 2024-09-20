using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using DevExpress.XtraReports.Web.Extensions;

public class CustomReportStorageWebExtension : ReportStorageWebExtension
{
    private readonly string ReportDirectory;
    private readonly string FileExtension = ".repx"; // Extensão dos arquivos de relatório

    public CustomReportStorageWebExtension(IWebHostEnvironment hostingEnvironment)
    {
        // Definir o caminho do diretório de relatórios
        ReportDirectory = Path.Combine(hostingEnvironment.ContentRootPath, "Reports");
    }

    // Sobrescrever o método GetData para carregar e aplicar os parâmetros manualmente
    public override byte[] GetData(string url)
    {
        try
        {
            // Parsear a string com o nome do relatório e os valores dos parâmetros.
            string[] parts = url.Split('?');
            string reportName = parts[0]; // Nome do relatório
            string parametersQueryString = parts.Length > 1 ? parts[1] : string.Empty; // String dos parâmetros

            // Criar a instância do relatório
            XtraReport report = null;

            if (Directory.EnumerateFiles(ReportDirectory).Select(Path.GetFileNameWithoutExtension).Contains(reportName))
            {
                byte[] reportBytes = File.ReadAllBytes(Path.Combine(ReportDirectory, reportName + FileExtension));
                using (MemoryStream ms = new MemoryStream(reportBytes))
                    report = XtraReport.FromStream(ms);
            }

            if (report != null)
            {
                // Aplicar os valores dos parâmetros ao relatório
                var parameters = HttpUtility.ParseQueryString(parametersQueryString);

                foreach (string parameterName in parameters.AllKeys)
                {
                    report.Parameters[parameterName].Value = Convert.ChangeType(
                        parameters.Get(parameterName), report.Parameters[parameterName].Type);
                }

                // Desativar a propriedade Visible de todos os parâmetros do relatório
                foreach (var parameter in report.Parameters)
                {
                    parameter.Visible = false;
                }

                // Se não ocultar o painel, desabilitar a propriedade RequestParameters do relatório.
                // report.RequestParameters = false;

                using (MemoryStream ms = new MemoryStream())
                {
                    report.SaveLayoutToXml(ms);
                    return ms.ToArray();
                }
            }
        }
        catch (Exception ex)
        {
            throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Could not get report data.", ex);
        }
        throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
    }

    // Outros métodos do ReportStorageWebExtension também podem ser implementados aqui, conforme necessário
}
