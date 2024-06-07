using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.User;
using appSERP.Reports;
using appSERP.Reports.POS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.Caching;

namespace appSERP.appCode.Setting.ReportSetting
{
    public static class ClsReport
    {
        public static PrintOptions printOptions;
        public static string PrinterName;
       
        public static string PrinteInss(ReportClass rpt, DataTable temp,string Printer)
        {
            try
            {
                // Fill Data Source
                rpt.SetDataSource(temp);
                // Printer Options
                //PrintOptions printOption = rpt.PrintOptions;
                //PrinterSettings settings = new PrinterSettings();
                // printOptions.PrinterName = GetDefaultPrinterName();
                //PrinterName= settings.PrinterName;
                rpt.PrintOptions.PrinterName = Printer;
                rpt.PrintToPrinter(1, true, 1, 1);
                rpt.Close();
                rpt.Dispose();
                return "print";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string PrintKitchen(ReportClass rpt, DataTable temp,string PrinterName )
        {
            try
            {
                // Fill Data Source
                rpt.SetDataSource(temp);
                // Printer Options
                printOptions = rpt.PrintOptions;
                //PrinterSettings settings = new PrinterSettings();
                // printOptions.PrinterName = GetDefaultPrinterName();
                //PrinterName= settings.PrinterName;
                printOptions.PrinterName = PrinterName;
                rpt.PrintToPrinter(1, true, 1, 1);

                rpt.Close();
                rpt.Dispose();
                return printOptions.PrinterName;
        }
            catch (Exception ex)
            {
                return ex.Message;
            }

}
        public static string GetDefaultPrinterName()
        {
            var query = new ObjectQuery("SELECT * FROM Win32_Printer");
            var searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject mo in searcher.Get())
            {
                if (((bool?)mo["Default"]) ?? false)
                {
                    return mo["Name"] as string;
                }
            }

            return null;
        }
        public static object Printreport(DataTable DT, string FullPath)
        {
            using (ReportClass rp = new ReportClass())
            {
                rp.FileName = FullPath;
                rp.Load();
                /////*Get data from detatbase using Data layer via business layer*/

                rp.SetDataSource(DT);
                rp.Refresh();

                rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat,System.Web.HttpContext.Current.Response, false, "crReport");
                return rp;
            }

        }

    }
}