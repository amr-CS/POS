using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.Reports.POS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Neodynamic.SDK.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers
{
    public class PrintRPTController : Controller
    {
        private IdbInvItem _dbInvItem;
        public PrintRPTController(IdbInvItem dbInvItem)
        {
            _dbInvItem = dbInvItem;
        }

        public ActionResult Index()
        {
                 WebClientPrint.LicenseOwner = "nopsam2007";
                WebClientPrint.LicenseKey = "BBF5F841AC437F129950EC3B312303EDE2C681C927C18D0081905F99223AA763";

            ViewBag.WCPScript = WebClientPrint.CreateScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), Url.Action("PrintFile", "PrintRPT", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);

            return View();
        }
        public ActionResult Test()
        {
           

            return View();
        }
        [AllowAnonymous]
        public void PrintFile(string useDefaultPrinter, string printerName)
        {
            try
            {
                //load and set report's data source
                //  DataSet ds = new DataSet();
                //ds.ReadXml(Server.MapPath("~/NorthwindProducts.xml"));

                //create and load rpt in memory
                //ReportDocument myCrystalReport = new ReportDocument();
                //myCrystalReport.Load(Server.MapPath("~/Reports") + "//testPrint.rpt");
                DataTable Data = _dbInvItem.funInvItemGET(1, null);
                NewPOS myCrystalReport = new NewPOS();
                 myCrystalReport.SetDataSource(Data);
                //Export rpt to a temp PDF and get binary content
                byte[] pdfContent = null;
                using (Stream rptStream = myCrystalReport.ExportToStream(ExportFormatType.PortableDocFormat))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[10000];
                        int bytesRead = 0;
                        do
                        {
                            bytesRead = rptStream.Read(buffer, 0, buffer.Length);
                            ms.Write(buffer, 0, bytesRead);
                        } while (bytesRead > 0);
                        ms.Position = 0;
                        pdfContent = ms.ToArray();
                    }
                }

                //create a temp file name for our PDF file...
                string fileName = "MyFile-" + Guid.NewGuid().ToString("N");

                //Create a PrintFilePDF object with the PDF file
                PrintFilePDF file = new PrintFilePDF(pdfContent, fileName);
                 WebClientPrint.LicenseOwner = "nopsam2007";
                WebClientPrint.LicenseKey = "BBF5F841AC437F129950EC3B312303EDE2C681C927C18D0081905F99223AA763";
                //Create a ClientPrintJob and send it back to the client!
                ClientPrintJob cpj = new ClientPrintJob();
                //set file to print...
                cpj.PrintFile = file;

                //set client printer...
                if (useDefaultPrinter == "checked" || printerName == "null")
                    cpj.ClientPrinter = new DefaultPrinter();
                else
                    cpj.ClientPrinter = new InstalledPrinter(printerName);

                //send it...
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.BinaryWrite(cpj.GetContent());
                System.Web.HttpContext.Current.Response.End();
                                 WebClientPrint.LicenseOwner = "nopsam2007";
                WebClientPrint.LicenseKey = "BBF5F841AC437F129950EC3B312303EDE2C681C927C18D0081905F99223AA763";
            }catch(Exception ex)
            {

            }
        
        }
    }
}