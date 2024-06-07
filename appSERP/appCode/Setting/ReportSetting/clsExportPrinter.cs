using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WinForms;
namespace appSERP.appCode.Setting.ReportSetting
{
    public class clsExportPrinter
    {
            // Export and Print [Report]
            public static void funReportExportPrint(
                string pReportName = null,
                System.Data.DataTable pDtRptSource = null,
                bool pIsA4 = false)
            {
                // Load Report Path
                string vReportMainFolder = @"~\Reports\";
                string vReportExtension = ".rdlc";
                string vReportPath = System.Web.Hosting.HostingEnvironment.MapPath(vReportMainFolder) + pReportName + vReportExtension;

                // Report
                LocalReport vLocalReport = new LocalReport();
                vLocalReport.ReportPath = vReportPath;

                // Report Source
                ReportDataSource vRptSource = new ReportDataSource();
                vRptSource.Name = "DataSet1";
                vRptSource.Value = pDtRptSource;
                vLocalReport.DataSources.Add(vRptSource);


                // Device Info [Report Size]
                string vDeviceInfo = "";
                if (pIsA4)
                {
                    vDeviceInfo =
                        @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.5in</PageWidth>
                        <PageHeight>11in</PageHeight>
                        <MarginTop>0.25in</MarginTop>
                        <MarginLeft>0.25in</MarginLeft>
                        <MarginRight>0.25in</MarginRight>
                        <MarginBottom>0.25in</MarginBottom>
                    </DeviceInfo>";
                }
                else
                {
                // vDeviceInfo =
                //        @"<DeviceInfo>
                //    <OutputFormat>EMF</OutputFormat>
                //    <PageWidth>3.14961in</PageWidth>
                //    <PageHeight>11.69in</PageHeight>
                //    <MarginTop>0.5in</MarginTop>
                //    <MarginLeft>0.5in</MarginLeft>
                //    <MarginRight>0.5in</MarginRight>
                //    <MarginBottom>0.5in</MarginBottom>
                //</DeviceInfo>";
                vDeviceInfo =
                       @"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                <PageWidth>2in</PageWidth>
                <PageHeight>8.3in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            
                </DeviceInfo>";
            }
            //create file
            string vPath = @"C:\TempFiles\";
                //Check IF Exist 
                bool exists = System.IO.Directory.Exists(vPath);
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(vPath);
                }
                // Get Default Temp Files Storage Partition
                string vDefaultTempStorage = vPath;

                // Export
                Warning[] warnings;
                string[] streams;
                string mimeType;
                string encoding;
                string fileNameExtension = "doc";
                Byte[] vBytes = vLocalReport.Render(
                 "word", vDeviceInfo, out mimeType, out encoding, out fileNameExtension,
                 out streams, out warnings);

                // File Storage
                string vFileExportPath = vDefaultTempStorage + "appPresentTempFile" + Guid.NewGuid().ToString() + "." + fileNameExtension;

                try
                {
                    using (FileStream vFS = File.Create(@vFileExportPath))
                    {
                        vFS.Write(vBytes, 0, vBytes.Length);
                        vFS.Close();
                        vFS.Dispose();
                    }

                    // Get Saved File
                    FileInfo vFileInfo = new FileInfo(vFileExportPath);
                    // Get Full Name
                    string vFileFullName = vFileInfo.FullName;

                // Printer
                object vPrinterName = 10;
                    if (!pIsA4)
                    {
                    vPrinterName = 11;
                    }


                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(vFileFullName);
                 //info.Arguments = "\"" + vPrinterName.ToString() + "\"";
                    info.Arguments = "\"" + "RONGTA 80mm Series Printer" + "\"";
                    info.CreateNoWindow = true;
                    info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    info.WindowStyle = ProcessWindowStyle.Minimized;
                    info.Verb = "PrintTo";
                    System.Diagnostics.Process.Start(info);

                }
                catch (Exception ex)
                {

                }
            }
    }
}