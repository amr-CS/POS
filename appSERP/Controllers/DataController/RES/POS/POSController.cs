using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.Encode;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.Encode;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models;
using appSERP.Models.RES;
using appSERP.Reports.POS;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.QrCode;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.ZatcaEInvoicing.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using appSERP.ZatcaEInvoicing;
using appSERP.Utils;

namespace appSERP.Controllers.DataController.RES.POS
{
    [NoDirectAccess]
    [Authorize]
    public class POSController : Controller
    {
        private static X509KeyStorageFlags STORAGE_FLAGS = X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable;
        private bool IsPOSPrinterNetwork;
        private string InsuranceCategory;
        private int DeliveryCount;
        private int DiscountMax;
        private bool IsDiscount;
        private string MailHost;
        private string MailPassword;
        private string MailPort;
        private string MailSubject;
        private string MailBody;
        private string MailFrom;
        private string MailTo;
        private ILog _ILog;
        private IdbINVInvoice _dbINVInvoice;
        private IdbInvItem _dbInvItem;
        private IdbPOSReport _dbPOSReport;
        private IdbLookup _dbLookup;
        private IdbBranchSetting _dbBranchSetting;
        private IdbPeriod _dbPeriod;
        private IdbUserCashier _dbUserCashier;
        private IDevCompanySetting _DevCompanySetting;
        private IdbUser _dbUser;
        private PrepareInvoiceBeforeSendingToZatca _prepareInvoiceBeforeSendingToZatca;
       public static  DataTable AllPOSData;
       public static  DataTable ReturnInsuranseData;
        public POSController(ILog log, IdbINVInvoice dbINVInvoice, IdbInvItem dbInvItem, IdbPOSReport dbPOSReport, IdbLookup dbLookup,
            IdbBranchSetting dbBranchSetting, IdbPeriod dbPeriod, IdbUserCashier dbUserCashier, IDevCompanySetting DevCompanySetting, dbUser dbUser
            , PrepareInvoiceBeforeSendingToZatca prepareInvoiceBeforeSendingToZatca)
        {
            _dbBranchSetting = dbBranchSetting;
            DataTable Branch = _dbBranchSetting.GetBranchSetting(pQueryTypeId: 407);
            IsPOSPrinterNetwork = Convert.ToBoolean(Branch.Rows[0]["IsPOSPrinterNetwork"].ToString());
            InsuranceCategory = Branch.Rows[0]["PlateCode"].ToString();
            DeliveryCount = Convert.ToInt32(Branch.Rows[0]["DeliveryTrans"].ToString());
            DiscountMax = Convert.ToInt32(Branch.Rows[0]["DiscountMax"].ToString());
            MailHost = Branch.Rows[0]["MailHost"].ToString();
            MailPort = Branch.Rows[0]["MailPort"].ToString();
            MailFrom = Branch.Rows[0]["MailFrom"].ToString();
            MailTo = Branch.Rows[0]["MailTo"].ToString();
            MailPassword = Branch.Rows[0]["MailPassword"].ToString();
            MailSubject = Branch.Rows[0]["MailSubject"].ToString();
            MailBody = Branch.Rows[0]["MailBody"].ToString();
            _ILog = log;
            _dbINVInvoice = dbINVInvoice;
            _dbInvItem = dbInvItem;
            _dbPOSReport = dbPOSReport;
            _dbLookup = dbLookup;
            _dbPeriod = dbPeriod;
            _dbUserCashier = dbUserCashier;
            _DevCompanySetting = DevCompanySetting;
            _dbUser = dbUser;
            _prepareInvoiceBeforeSendingToZatca = prepareInvoiceBeforeSendingToZatca;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        public ActionResult SignMessage()
        {
            string request = Request.QueryString["request"];
            //var WEBROOT_PATH = Server.MapPath("/");
            var CURRENT_PATH = Server.MapPath("~");
            var PARENT_PATH = HttpRuntime.AppDomainAppPath; //(CURRENT_PATH).Parent.FullName;
            string vAppConnectionOnline = @"\tray\privateKey.pfx";
            var KEY = PARENT_PATH + vAppConnectionOnline;
            //var KEY = @"D:\tray\privateKey.pfx";
            var PASS = "123456";

            try
            {
                /* var cert = new X509Certificate2(KEY, PASS, X509KeyStorageFlags.MachineKeySet);*/
                var cert = new X509Certificate2(KEY, PASS, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
                RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey;  // PFX defaults to the weaker "SHA1"
                byte[] data = new ASCIIEncoding().GetBytes(request);
                RSACryptoServiceProvider cspStrong = new RSACryptoServiceProvider(); // 2.1 and higher: Make RSACryptoServiceProvider that can handle SHA256, SHA512
                cspStrong.ImportParameters(csp.ExportParameters(true)); // Copy to stronger RSACryptoServiceProvider
                byte[] hash = new SHA512CryptoServiceProvider().ComputeHash(data);  // Use SHA1CryptoServiceProvider for QZ Tray 2.0 and older
                string base64 = Convert.ToBase64String(cspStrong.SignHash(hash, CryptoConfig.MapNameToOID("SHA512"))); // Use "SHA1" for QZ Tray 2.0 and older
                return Content(base64, "text/plain");
            }
            catch (Exception ex)
            {
                if ((STORAGE_FLAGS & X509KeyStorageFlags.MachineKeySet) == X509KeyStorageFlags.MachineKeySet)
                {
                    // IISExpress may fail with "Invalid provider type specified"; remove MachineKeySet flag, try again
                    STORAGE_FLAGS = STORAGE_FLAGS & ~X509KeyStorageFlags.MachineKeySet;
                    return SignMessage();
                }
                throw ex;
            }
        }
        public JsonResult InsertPOSBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,
            int? Invtype = null, bool? InvIsWait = null, string CardNo = null, DateTime? InvDate = null, int? PayTypeId = null, string Notes = null, int? CashDeskId = null, float? Insurance = null, int? Service = null, float? Tax = null, float? Discount = null, string InvMachine = null, bool? DeliveryInvoice = null, int? Delivery = 0, DateTime? DeliveryDate = null, string InvPhoneNo = null, int? SiteId = null, string LocAddressInvoice = null, float? InvCurValue = null, string CustomerName = null, int? CustomerId = null, int? OrderType = null, int? UsedPoints = null, int? MealPoints = null, string CustomerAddress = null, string CustomerPhoneNumber = null, int? UserId = null, int? BranchId = null, int? TableId = null, int? InvStatus = null)

        {
            try
            {
                return Json(_dbINVInvoice.spInvoicePOSBulk(InvoiceDtls, InvId, Invtype, InvIsWait, CardNo, InvDate, PayTypeId, Notes, CashDeskId, Insurance, Service, Tax, Discount, InvMachine, DeliveryInvoice, Delivery, DeliveryDate, InvPhoneNo, SiteId, LocAddressInvoice, InvCurValue, CustomerName, CustomerId, OrderType, UsedPoints, MealPoints, CustomerAddress, CustomerPhoneNumber, UserId, BranchId, TableId, InvStatus));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        public JsonResult CancelInvoice(int? phINVId, int? pLastUpdatedBy,
           int? pQueryTypeId
         )
        {
            try
            {
                object data = _dbINVInvoice.CancelInvoice(phINVId, pLastUpdatedBy, pQueryTypeId);
                //  dbINVInvoice.InvoicePosData = data;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // GET: POS
        public ActionResult Index(int? tableId, string tableName)
        {
            try
            {
                if (tableId != null)
                {
                    ViewBag.tableId = tableId;
                    ViewBag.tableName = tableName;

                    string data = _dbINVInvoice.funINVInvoiceGET(phTableId: tableId, pInvStatus: 1, pQueryTypeId: 400);
                    if (data != string.Empty)
                    {
                        ViewBag.data = data;
                        // JObject json = JObject.Parse(data);
                    }
                }

                ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
                ViewBag.InsuranceCategory = InsuranceCategory;
                ViewBag.DeliveryCount = DeliveryCount;
                ViewBag.DiscountMax = DiscountMax;
                ViewBag.DevCompanySetting = _DevCompanySetting;
                ViewBag.dbUser = _dbUser;
                // PrinterSettings settings = new PrinterSettings();
                //foreach (string name in PrinterSettings.InstalledPrinters)
                //{
                //     PrinterSettings ps = new PrinterSettings();
                //     //  ps.PrinterName = name;
                //     if (ps.IsDefaultPrinter)
                //     {
                //         ViewBag.PrinterName = name;
                //     }
                // }
                DataTable DT = _dbPeriod.funPeriodGET(pIsPosted: false, pFromDate: DateTime.Now,
                    pCreatedBy: Convert.ToInt32(Request.Cookies["UserId"].Value));
                if (DT.Rows.Count > 0)
                {
                    DataRow DR = DT.Rows[0];
                    ViewBag.PeriodId = DR["PeriodId"];
                    ViewBag.DateFrom = DR["FromDate"];
                    ViewBag.DateTo = DR["ToDate"];
                    ViewBag.IsCashier = DR["IsCashier"];
                    ViewBag.open = true;
                }
                else
                {
                    DataTable DTPeriod = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);
                    if (DTPeriod.Rows.Count > 0)
                    {
                        ViewBag.open = false;
                    }
                    else
                    {
                        // Add Day To Period
                        DateTime OpenDateFrom = DateTime.Now;
                        TimeSpan ts = new TimeSpan(4, 00, 0);
                        OpenDateFrom = OpenDateFrom.Date + ts;
                        DateTime OpenDateTo = OpenDateFrom.AddDays(1);
                        _dbPeriod.funPeriodGET(pFromDate: OpenDateFrom, pToDate: OpenDateTo, pIsPosted: false, pIsDeleted: false, pQueryTypeId: clsQueryType.qInsert);


                    }

                }
                int UserId = 0;
                if (Request.Cookies["UserId"] != null)
                { UserId = Convert.ToInt32(Request.Cookies["UserId"].Value); }
                DataRow Permission = _dbUserCashier.TableUserCashierGET(pUserId: UserId, pQueryTypeId: 500).Rows[0];
                string InsuranceLimit = Permission["InsuranceLimit"].ToString();
                if (InsuranceLimit != "") { Session["InsuranceLimit"] = InsuranceLimit; }
                else { ViewBag.InsuranceLimit = ""; }
                bool HoldInvoice = Convert.ToBoolean(Permission["HoldInvoice"]);
                if (!HoldInvoice) { ViewBag.HoldInvoice = "Disabled"; }
                else { ViewBag.HoldInvoice = ""; }
                bool SearchInvoice = Convert.ToBoolean(Permission["SearchInvoice"]);
                if (!SearchInvoice) { ViewBag.SearchInvoice = "Disabled"; }
                else { ViewBag.SearchInvoice = ""; }
                bool ReturnInvoice = Convert.ToBoolean(Permission["ReturnInsurance"]);
                if (!ReturnInvoice) { ViewBag.ReturnInvoice = "Disabled"; }
                else { ViewBag.ReturnInvoice = ""; }
                bool PCVerfiy = Convert.ToBoolean(Permission["PCVerfiy"]);
                if (!PCVerfiy) { ViewBag.PCVerfiy = "Disabled"; }
                else { ViewBag.PCVerfiy = ""; }
                bool IsCashierDelivery = Convert.ToBoolean(Permission["IsCashierDelivery"]);
                if (!IsCashierDelivery) { ViewBag.IsCashierDelivery = "Disabled"; }
                else { ViewBag.IsCashierDelivery = ""; }
                bool RePrintInvoice = Convert.ToBoolean(Permission["RePrintInvoice"]);
                if (!RePrintInvoice) { ViewBag.RePrintInvoice = "Disabled"; }
                else { ViewBag.RePrintInvoice = ""; }
                bool CancelInvoice = Convert.ToBoolean(Permission["CancelInvoice"]);
                if (!CancelInvoice) { ViewBag.CancelInvoice = "Disabled"; }
                else { ViewBag.CancelInvoice = ""; }
                bool ModifyInvoice = Convert.ToBoolean(Permission["ModifyInvoice"]);
                if (!ModifyInvoice) { ViewBag.ModifyInvoice = "Disabled"; }
                else { ViewBag.ModifyInvoice = ""; }
                bool Discount = Convert.ToBoolean(Permission["Discount"]);
                if (!Discount) { ViewBag.Discount = "Disabled"; }
                else { ViewBag.Discount = ""; }

                if (Request.Cookies["UserId"] != null)
                {
                    return View();
                }
                else
                {
                    return Redirect("/home/login");
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        public ActionResult IndexCore(int? tableId, string tableName)
        {
            if (tableId != null)
            {
                ViewBag.tableId = tableId;
                ViewBag.tableName = tableName;

                string data = _dbINVInvoice.funINVInvoiceGET(phTableId: tableId, pInvStatus: 1, pQueryTypeId: 400);
                if (data != string.Empty)
                {
                    ViewBag.data = data;
                    // JObject json = JObject.Parse(data);

                }
            }
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            ViewBag.InsuranceCategory = InsuranceCategory;
            ViewBag.DeliveryCount = DeliveryCount;
            ViewBag.DiscountMax = DiscountMax;
            // PrinterSettings settings = new PrinterSettings();
            //foreach (string name in PrinterSettings.InstalledPrinters)
            //{
            //     PrinterSettings ps = new PrinterSettings();
            //     //  ps.PrinterName = name;
            //     if (ps.IsDefaultPrinter)
            //     {
            //         ViewBag.PrinterName = name;
            //     }
            // }
            DataTable DT = _dbPeriod.funPeriodGET(pIsPosted: false, pFromDate: DateTime.Now,
                pCreatedBy: Convert.ToInt32(Request.Cookies["UserId"].Value));
            if (DT.Rows.Count > 0)
            {
                DataRow DR = DT.Rows[0];
                ViewBag.PeriodId = DR["PeriodId"];
                ViewBag.DateFrom = DR["FromDate"];
                ViewBag.DateTo = DR["ToDate"];
                ViewBag.IsCashier = DR["IsCashier"];
                ViewBag.open = true;
            }
            else
            {
                DataTable DTPeriod = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);
                if (DTPeriod.Rows.Count > 0)
                {
                    ViewBag.open = false;
                }
                else
                {
                    // Add Day To Period
                    DateTime OpenDateFrom = DateTime.Now;
                    TimeSpan ts = new TimeSpan(4, 00, 0);
                    OpenDateFrom = OpenDateFrom.Date + ts;
                    DateTime OpenDateTo = OpenDateFrom.AddDays(1);
                    _dbPeriod.funPeriodGET(pFromDate: OpenDateFrom, pToDate: OpenDateTo, pIsPosted: false, pIsDeleted: false, pQueryTypeId: clsQueryType.qInsert);
                }
            }
            int UserId = 0;
            if (Request.Cookies["UserId"] != null)
            { UserId = Convert.ToInt32(Request.Cookies["UserId"].Value); }
            DataRow Permission = _dbUserCashier.TableUserCashierGET(pUserId: UserId, pQueryTypeId: 500).Rows[0];
            string InsuranceLimit = Permission["InsuranceLimit"].ToString();
            if (InsuranceLimit != "") { Session["InsuranceLimit"] = InsuranceLimit; }
            else { ViewBag.InsuranceLimit = ""; }
            bool HoldInvoice = Convert.ToBoolean(Permission["HoldInvoice"]);
            if (!HoldInvoice) { ViewBag.HoldInvoice = "Disabled"; }
            else { ViewBag.HoldInvoice = ""; }
            bool SearchInvoice = Convert.ToBoolean(Permission["SearchInvoice"]);
            if (!SearchInvoice) { ViewBag.SearchInvoice = "Disabled"; }
            else { ViewBag.SearchInvoice = ""; }
            bool ReturnInvoice = Convert.ToBoolean(Permission["ReturnInsurance"]);
            if (!ReturnInvoice) { ViewBag.ReturnInvoice = "Disabled"; }
            else { ViewBag.ReturnInvoice = ""; }
            bool PCVerfiy = Convert.ToBoolean(Permission["PCVerfiy"]);
            if (!PCVerfiy) { ViewBag.PCVerfiy = "Disabled"; }
            else { ViewBag.PCVerfiy = ""; }
            bool IsCashierDelivery = Convert.ToBoolean(Permission["IsCashierDelivery"]);
            if (!IsCashierDelivery) { ViewBag.IsCashierDelivery = "Disabled"; }
            else { ViewBag.IsCashierDelivery = ""; }
            bool RePrintInvoice = Convert.ToBoolean(Permission["RePrintInvoice"]);
            if (!RePrintInvoice) { ViewBag.RePrintInvoice = "Disabled"; }
            else { ViewBag.RePrintInvoice = ""; }
            bool CancelInvoice = Convert.ToBoolean(Permission["CancelInvoice"]);
            if (!CancelInvoice) { ViewBag.CancelInvoice = "Disabled"; }
            else { ViewBag.CancelInvoice = ""; }
            bool ModifyInvoice = Convert.ToBoolean(Permission["ModifyInvoice"]);
            if (!ModifyInvoice) { ViewBag.ModifyInvoice = "Disabled"; }
            else { ViewBag.ModifyInvoice = ""; }
            bool Discount = Convert.ToBoolean(Permission["Discount"]);
            if (!Discount) { ViewBag.Discount = "Disabled"; }
            else { ViewBag.Discount = ""; }
            if (Request.Cookies["UserId"] != null)
            {
                return View();
            }
            else
            { return Redirect("/home/login");}
        }

        public ActionResult TableManagement()
        {
            DataTable data = _dbINVInvoice.TableManagmentGet(pQueryTypeId: 800);
            // ViewBag.floor
            var p = data.AsEnumerable().Select(x => new { col1 = x["floorId"], col2 = x["floorName"] }).ToList().Distinct();
            List<Floor> floor = new List<Floor>();
            _dbINVInvoice.TableData = data;
            foreach (var item in p)
            {
                floor.Add(new Floor()
                {
                    FloorId = Convert.ToInt32(item.col1),
                    FloorName = Convert.ToString(item.col2)
                });
            }
            ViewBag.data = data;
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View(floor);
        }
       
        public ActionResult TableManagementPartial(int floorid)
        {
            //DataTable data = _dbINVInvoice.TableData;
            DataTable data = _dbINVInvoice.TableManagmentGet(pQueryTypeId: 800);
            // ViewBag.floor
            var p = data.AsEnumerable().Select(x => (TableId: x["TableId"], TableName: x["TableName"], TableStatus: x["TableStatus"], FloorId: x["FloorId"]))
                .Where(u => Convert.ToInt32(u.FloorId) == floorid);
            List<Floor> floor = new List<Floor>();
            foreach (var item in p)
            {
                floor.Add(new Floor()
                {
                    TableId = Convert.ToInt32(item.TableId),
                    TableName = Convert.ToString(item.TableName),
                    Tablestatue = Convert.ToString(item.TableStatus),
                    FloorId = Convert.ToInt32(item.FloorId),
                });
            }
            // IEnumerable<Floor> floors = floor.Where(x=> x.FloorId == floorid);

            return PartialView(floor);
        }

        [AllowAnonymous]
        public ActionResult NewPOS()
        {
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            ViewBag.InsuranceCategory = InsuranceCategory;
            ViewBag.DeliveryCount = DeliveryCount;
            ViewBag.DiscountMax = DiscountMax;
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbUser = _dbUser;

            DataTable DT = _dbPeriod.funPeriodGET(pIsDeleted: false, pFromDate: DateTime.Now,
                pCreatedBy: Convert.ToInt32(Request.Cookies["UserId"].Value));
            if (DT.Rows.Count > 0)
            {
                DataRow DR = DT.Rows[0];
                ViewBag.PeriodId = DR["PeriodId"];
                ViewBag.DateFrom = DR["FromDate"];
                ViewBag.DateTo = DR["ToDate"];
                ViewBag.IsCashier = DR["IsCashier"];
                ViewBag.open = true;
            }
            else
            {
                ViewBag.open = false;
            }
            int UserId = 0;
            if (Request.Cookies["UserId"] != null)
            { UserId = Convert.ToInt32(Request.Cookies["UserId"].Value); }
            DataRow Permission = _dbUserCashier.TableUserCashierGET(pUserId: UserId, pQueryTypeId: 500).Rows[0];
            bool InsuranceLimit = Convert.ToBoolean(Permission["InsuranceLimit"]);
            if (!InsuranceLimit) { ViewBag.InsuranceLimit = "Disabled"; }
            else { ViewBag.InsuranceLimit = ""; }
            bool HoldInvoice = Convert.ToBoolean(Permission["HoldInvoice"]);
            if (!HoldInvoice) { ViewBag.HoldInvoice = "Disabled"; }
            else { ViewBag.HoldInvoice = ""; }
            bool SearchInvoice = Convert.ToBoolean(Permission["SearchInvoice"]);
            if (!SearchInvoice) { ViewBag.SearchInvoice = "Disabled"; }
            else { ViewBag.SearchInvoice = ""; }
            bool ReturnInvoice = Convert.ToBoolean(Permission["ReturnInsurance"]);
            if (!ReturnInvoice) { ViewBag.ReturnInvoice = "Disabled"; }
            else { ViewBag.ReturnInvoice = ""; }
            bool PCVerfiy = Convert.ToBoolean(Permission["PCVerfiy"]);
            if (!PCVerfiy) { ViewBag.PCVerfiy = "Disabled"; }
            else { ViewBag.PCVerfiy = ""; }
            bool IsCashierDelivery = Convert.ToBoolean(Permission["IsCashierDelivery"]);
            if (!IsCashierDelivery) { ViewBag.IsCashierDelivery = "Disabled"; }
            else { ViewBag.IsCashierDelivery = ""; }
            bool RePrintInvoice = Convert.ToBoolean(Permission["RePrintInvoice"]);
            if (!RePrintInvoice) { ViewBag.RePrintInvoice = "Disabled"; }
            else { ViewBag.RePrintInvoice = ""; }
            bool CancelInvoice = Convert.ToBoolean(Permission["CancelInvoice"]);
            if (!CancelInvoice) { ViewBag.CancelInvoice = "Disabled"; }
            else { ViewBag.CancelInvoice = ""; }
            bool ModifyInvoice = Convert.ToBoolean(Permission["ModifyInvoice"]);
            if (!ModifyInvoice) { ViewBag.ModifyInvoice = "Disabled"; }
            else { ViewBag.ModifyInvoice = ""; }
            bool Discount = Convert.ToBoolean(Permission["Discount"]);
            if (!Discount) { ViewBag.Discount = "Disabled"; }
            else { ViewBag.Discount = ""; }
            if (Request.Cookies["UserId"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/home/login");
            }
            return View();
        }
        // GET: POS
        [AllowAnonymous]
        public ActionResult Category()
        {
            try
            {
                int BranchId = 0;
                if (Request.Cookies["BranchId"] != null)
                { BranchId = Convert.ToInt32(Request.Cookies["BranchId"].Value); };

                DataTable CategoryItem = _dbLookup.funtblLookupGET(pQueryTypeId: 500, pLookupId: 120,BranchId:BranchId);
                return PartialView(CategoryItem);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public ActionResult CategoryCore()
        {
            DataTable CategoryItem = _dbLookup.funtblLookupGET(pQueryTypeId: 500, pLookupId: 120);
            return PartialView(CategoryItem);
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        // POS  Report
        public ActionResult POSReport()
        {
            return View();
        }

        // Get Customer
        public ActionResult CustomerSearch()
        {
            return View();
        }
        // Get Voucher
        public ActionResult InvoiceSearch()
        {
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            DataTable data = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);
            if (data.Rows.Count > 0)
            {
                DataRow DT = data.Rows[0];
                ViewBag.PeriodId = DT["PeriodId"];
                ViewBag.DateFrom = DT["FromDate"];
                ViewBag.DateTo = DT["ToDate"];

                // Add Day To Period
                DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

                DateTime OpenDateTo = OpenDateFrom.AddDays(1);

                // ViewBag
                ViewBag.OpenDateFrom = OpenDateFrom;
                ViewBag.OpenDateTo = OpenDateTo;

            }
            ViewBag.date = DateTime.Now.ToString("yyyy-M-ddThh:mm:ss");
            return View();
        }
        public ActionResult POSSearch()
        {
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            DataTable data = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);

            if (data.Rows.Count > 0)
            {
                DataRow DT = data.Rows[0];
                ViewBag.PeriodId = DT["PeriodId"];
                ViewBag.DateFrom = DT["FromDate"];
                ViewBag.DateTo = DT["ToDate"];

                // Add Day To Period
                DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

                DateTime OpenDateTo = OpenDateFrom.AddDays(1);

                // ViewBag
                ViewBag.OpenDateFrom = OpenDateFrom;
                ViewBag.OpenDateTo = OpenDateTo;

                _dbINVInvoice.TableData = data;


            }
            ViewBag.date = DateTime.Now.ToString("yyyy-M-ddThh:mm:ss");
            return View();
        }
        public ActionResult POSInvoicePartial(string InvCode, DateTime? DateFrom = null, DateTime? DateTo = null,int?BranchId=null)
        {
           // DataTable AllPOSData = _dbINVInvoice.POSData(InvCode, DateFrom, DateTo);
             AllPOSData = _dbINVInvoice.POSData(InvCode, DateFrom, DateTo,BranchId);
            //Session["mydata"] = AllPOSData;
            IEnumerable<Invoice> InvoiceData = AllPOSData.AsEnumerable().Select(x =>
           new Invoice
           {
               InvId = Convert.ToInt32(x["InvId"]),
               InvCode = Convert.ToString(x["InvCode"]),
               InvDate = Convert.ToDateTime(x["InvDate"]),
               Total = Convert.ToDouble(x["Total"]),
               InvPhoneNo = Convert.ToString(x["InvPhoneNo"]),
               CustomerName = Convert.ToString(x["CustomerName"])
           }).Distinct().ToList().OrderByDescending(s => s.InvId);

            return PartialView(InvoiceData);
        }
        public ActionResult POSDtlPartial(int InvId)
        {
            // DataTable AllPOSData = dbINVInvoice.POSData("", null, null);
            double dOut;
            int iOut;
            DateTime dtOut;
            float fOut;

            DataTable POSData = AllPOSData;
                //Session["mydata"] as DataTable;

            IEnumerable<InvoiceDtl> InvoiceData = POSData.AsEnumerable().Select(x =>
              new InvoiceDtl
              {
                  InvId = int.TryParse(x["InvId"].ToString(), out iOut) ? iOut : (int?)null,
                  InvItemName = Convert.ToString(x["InvItemName"]),
                  InvDate = DateTime.TryParse(x["InvDate"].ToString(), out dtOut) ? dtOut : (DateTime?)null,
                  VatTotal = Double.TryParse(x["vatTotal"].ToString(), out dOut) ? dOut : (double?)null,
                  Qty = float.TryParse(x["Qty"].ToString(), out fOut) ? fOut : (float?)null,
                  Total = Double.TryParse(x["Total"].ToString(), out dOut) ? dOut : (double?)null,
                  Price = Double.TryParse(x["Price"].ToString(), out dOut) ? dOut : (double?)null

              }).Where(x => x.InvId == InvId);
            return PartialView(InvoiceData);
        }
        public ActionResult InvoiceDriverSearch()
        {
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];

            // Add Day To Period
            DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

            DateTime OpenDateTo = OpenDateFrom.AddDays(1);
            // ViewBag
            ViewBag.OpenDateFrom = OpenDateFrom;
            ViewBag.OpenDateTo = OpenDateTo;
            ViewBag.date = DateTime.Now.ToString("yyyy-M-ddThh:mm:ss");
            return View();
        }
        // Get Voucher
        public ActionResult CancelSearch()
        {
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];

            // Add Day To Period
            DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

            DateTime OpenDateTo = OpenDateFrom.AddDays(1);

            // ViewBag
            ViewBag.OpenDateFrom = OpenDateFrom;
            ViewBag.OpenDateTo = OpenDateTo;

            return View();
        }

        // Wait Invoice
        public ActionResult WaitSearch()
        {
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];

            // Add Day To Period
            DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

            DateTime OpenDateTo = OpenDateFrom.AddDays(1);

            // ViewBag
            ViewBag.OpenDateFrom = OpenDateFrom;
            ViewBag.OpenDateTo = OpenDateTo;

            return View();

        }

        public ActionResult InsuranceSearch()
        {
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            ViewBag.InsuranceLimit = Session["InsuranceLimit"];
            return View();
        }


        public ActionResult DeliverySearch()
        {
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];

            // Add Day To Period
            DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

            DateTime OpenDateTo = OpenDateFrom.AddDays(1);

            // ViewBag
            ViewBag.OpenDateFrom = OpenDateFrom;
            ViewBag.OpenDateTo = OpenDateTo;
            return View();
        }

        public ActionResult InvoiceStatus()
        {
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];

            // Add Day To Period
            DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

            DateTime OpenDateTo = OpenDateFrom.AddDays(1);

            // ViewBag
            ViewBag.OpenDateFrom = OpenDateFrom;
            ViewBag.OpenDateTo = OpenDateTo;
            return View();
        }

        public ActionResult Payment()
        {
            ViewBag.DiscountMax = DiscountMax;

            return View();
        }

        //public DataTable FillReport(InvoiceDtl[] InvoicDtl = null)
        //{
        //    DataTable _result = new DataTable("MyViewModel");

        //    // Do this for each field
        //    _result.Columns.Add("Field1", typeof(String));
        //    _result.Columns.Add("Field2", typeof(int));
        //    _result.Columns.Add("Field3", typeof(String));

        //    foreach (var Model in InvoicDtl)
        //    {
        //        DataRow _row = _result.NewRow();
        //        _row["Field1"] = Model.ItemType;
        //        _row["Field2"] = Model.ItemUnitId;
        //        _row["Field3"] = Model.Price;
        //        _result.Rows.Add(_row);
        //    }
        //    return _result;
        //}
        [HttpGet]
        public void ShowPOSReport(int InvId)
        {
            DataTable Data = _dbInvItem.funInvItemGET(InvId, null);
            string vFullPath = Server.MapPath("~/Reports/POS") + "//NewPOSCopy.rpt";
            bool IsDelivery = Convert.ToBoolean(Data.Rows[0]["Delivery"].ToString());
            ClsReport.Printreport(Data, vFullPath);
        }
        //public void ShowInsuranceReport(string phNumbers)
        //{

        //    DataTable Data = _dbInvItem.funInvItemGET(null, phNumbers);

        //    string vFullPath = Server.MapPath("~/Reports/POS") + "//ReturnIns.rpt";

        //    ClsReport.Printreport(Data, vFullPath);

        //}
        [HttpPost]
        public void ShowInsuranceReport(ICollection<InvoiceDtl> arr)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Qty");
            dt.Columns.Add("DeliveryInvoice");
            dt.Columns.Add("Price");
            dt.Columns.Add("InvCode");
            dt.Columns.Add("InvDate");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("UserFullName");
            dt.Columns.Add("InvItemName");
            dt.Columns.Add("Total");
            foreach (var item in arr)
            {
                DataRow _ravi = dt.NewRow();
                _ravi["Qty"] = item.Qty;
                _ravi["Price"] = item.Price;
                _ravi["InvCode"] = item.InvCode;
                _ravi["InvDate"] = item.InvDate;
                _ravi["CustomerName"] = item.CustomerName;
                _ravi["UserFullName"] = item.Username;
                _ravi["InvItemName"] = item.InvItemName;
                _ravi["Total"] = item.Total;
                _ravi["DeliveryInvoice"] = "";
                dt.Rows.Add(_ravi);
            }
            ReturnInsuranseData = dt;


        }
        [HttpGet]
        public ActionResult HtmlReturnInsuranceReport()
        {
            ViewBag.Data = ReturnInsuranseData;
            return View();
        }
        [HttpGet]
        public void GetData(string InvoiceDtls)
        {
            /* Session["newData"] = JsonConvert.DeserializeObject<DataTable>(InvoiceDtls);*/

        }

        public string GenerateQRCode(string qrcodeText)
        {
            string folderPath = "~/Images/";
            string imagePath = "~/Images/QrCode.jpg";
            // If the directory doesn't exist then create it.
            if (!Directory.Exists(Server.MapPath(folderPath)))
            {
                Directory.CreateDirectory(Server.MapPath(folderPath));
            }
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = options;
            var result = barcodeWriter.Write(qrcodeText);

            string barcodePath = Server.MapPath(imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }

        [AllowAnonymous]
        public ActionResult HtmlReport(int InvId)
        {
            DataTable Data = _dbInvItem.funInvItemGET(InvId, null);
            DataRow dataRow = Data.Rows[0];
            ViewBag.Data = Data;           
            string CompanyName = dataRow["CompanyNameL2"].ToString();
            string VatCode = dataRow["VatCode"].ToString();
            DateTime d = Convert.ToDateTime( dataRow["InvDate"].ToString());
            //string Date = d.ToString("yyyy-MM-dd")+' '+d.ToString("HH:mm:ss");
            string Date = InvoiceQR.InvoiceDateForQR(d);
            string Total = dataRow["TotalPrice"].ToString();// Discount
            string Vat = dataRow["Vat"].ToString();
            string EncodData = InvoiceQR.encodeQrText(CompanyName, VatCode, Date, Total, Vat);
            ViewBag.ImgPath = GenerateQRCode(EncodData);
            PrintKHtml(Data);
            Task.Run( ()=> _prepareInvoiceBeforeSendingToZatca.SendToZatcaPOS(Data));
            return PartialView();
        }

        
        [AllowAnonymous]
        public ActionResult HtmlPOSReport(int InvId)
        {
            DataTable Data = _dbInvItem.funInvItemGET(InvId, null);
            DataRow dataRow = Data.Rows[0];
            ViewBag.CreatedBy = dataRow["UserFullName"].ToString();
            ViewBag.orderremark = dataRow["InvoiceRemark"].ToString();
            ViewBag.DELIVERY = dataRow["DeliveryInvoice"].ToString();
            ViewBag.Data = Data;
            ViewBag.VatCode = dataRow["VatCode"].ToString();
            string CompanyName = dataRow["CompanyNameL2"].ToString();
            string VatCode = dataRow["VatCode"].ToString();
            DateTime d = Convert.ToDateTime(dataRow["InvDate"].ToString());
            //string Date = d.ToString("yyyy-MM-dd") + ' ' + d.ToString("HH:mm:ss");
            string Date = InvoiceQR.InvoiceDateForQR(d);
            string Total = dataRow["TotalPrice"].ToString();
            string Vat = dataRow["Vat"].ToString();
            string EncodData = InvoiceQR.encodeQrText(CompanyName, VatCode, Date, Total, Vat);
            ViewBag.ImgPath = GenerateQRCode(EncodData);

            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult HtmlRePrintReport(int InvId)
        {
            DataTable Data = _dbInvItem.funInvItemGET(InvId, null);
            DataRow dataRow = Data.Rows[0];
            string CompanyName = dataRow["CompanyNameL2"].ToString();
            string VatCode = dataRow["VatCode"].ToString();
            DateTime d = Convert.ToDateTime(dataRow["InvDate"].ToString());
            //string Date = d.ToString("yyyy-MM-dd") + ' ' + d.ToString("HH:mm:ss");
            string Date = InvoiceQR.InvoiceDateForQR(d);
            string Total = dataRow["TotalPrice"].ToString();
            string Vat = dataRow["Vat"].ToString();
            string EncodData = InvoiceQR.encodeQrText(CompanyName, VatCode, Date, Total, Vat);
            ViewBag.ImgPath = GenerateQRCode(EncodData);

            ViewBag.Data = Data;
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult HtmlPOSKReport(string PrinterName, int PrinterId, int KitchenPrinterId)
        {

            DataTable data = _dbINVInvoice.InvoicePosData;
            string printerName = PrinterName;
            int printerId = PrinterId;
            if (printerId != KitchenPrinterId)
            {
                DataTable selectedTable = data.AsEnumerable()
                               .Where(r => r.Field<string>("PrinterName") == printerName && r.Field<int>("PrinterId") == printerId)
                               .CopyToDataTable();
                ViewBag.Data = selectedTable;
            }
            else
            {
                ViewBag.Data = data;
            }


            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public void PrintKHtml(DataTable data)
        {
            string PrinterKitchenName = data.Rows[0]["KitchenPrinter"].ToString();
            int PrinterKitchenId = Convert.ToInt32(data.Rows[0]["KitchenPrinterId"].ToString());
            bool IsCancel = Convert.ToBoolean(data.Rows[0]["IsCancel"].ToString());
            bool IsReturn = Convert.ToBoolean(data.Rows[0]["IsReturn"].ToString());
            var Printer = data.AsEnumerable().Select(x => new { col1 = x["PrinterName"], col2 = x["PrinterId"] }).ToList().Distinct();
            if (!IsCancel && !IsReturn)
            {
                NewPOSKMain rptMain = new NewPOSKMain();
                ClsReport.PrinteInss(rptMain, data, PrinterKitchenName);
                foreach (var item in Printer)
                {
                    string printerName = "";
                    int printerId = 0;
                    if (item.col1.ToString() != "")
                    {
                        printerName = item.col1.ToString();
                        printerId = Convert.ToInt32(item.col2);
                    }
                    if (printerId != PrinterKitchenId)
                    {
                        DataTable selectedTable = data.AsEnumerable()
                                       .Where(r => r.Field<string>("PrinterName") == printerName && r.Field<int>("PrinterId") == printerId)
                                       .CopyToDataTable();
                        NewPOSK rpt = new NewPOSK();

                        ClsReport.PrinteInss(rpt, selectedTable, printerName);
                    }
                }

            }
            else
            {
                foreach (var item in Printer)
                {
                    string printerName = item.col1.ToString();
                    int printerId = Convert.ToInt32(item.col2);

                    DataTable selectedTable = data.AsEnumerable()
                                .Where(r => r.Field<string>("PrinterName") == printerName && r.Field<int>("PrinterId") == printerId)
                                .CopyToDataTable();
                    rptPOSKCancel rpt = new rptPOSKCancel();
                    ClsReport.PrintKitchen(rpt, selectedTable, printerName);
                }
            }

        }

        public string GetReport(int? pInvId = null, string phNumbers = "")
        {
            string Printer = string.Empty;
            if (Request.Cookies["Printer"] != null)
            { Printer = Request.Cookies["Printer"].Value; };
            int? vInvId = pInvId;
            DataTable Data = _dbInvItem.funInvItemGET(vInvId, phNumbers);
            /* if (phNumbers !="")
             {
                 //clsExportPrinter.funReportExportPrint("Insurance", Data, false);
                 ReturnIns rpt = new ReturnIns();
                ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);
             }
             else
             {
                 // Amr 27/11/2019
                 //   Customer rpt = new Customer();
                 if (IsPOSPrinterNetwork)
                 {
                     NewPOS rpt = new NewPOS();
                     bool IsDelivery = Convert.ToBoolean(Data.Rows[0]["Delivery"].ToString());
                     if (IsDelivery == true)
                     {
                         int i = 1;
                         while (i <= DeliveryCount)
                         {
                             NewPOS rpt1 = new NewPOS();
                             ClsReport.PrinterName = ClsReport.PrinteInss(rpt1, Data, Printer);
                             i++;
                         }
                     }
                     else
                     {
                         ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);
                     }
                 }
                 //  string  vFullPath = Server.MapPath("~/Reports/POS") + "//POSReport.rpt";

                 //ClsReport.Printreport(Data, vFullPath);
                 //  KitchenPrinter;
                 string PrinterName=Data.Rows[0]["KitchenPrinter"].ToString();
                 NewPOSKMain rptMain = new NewPOSKMain();
              ClsReport.PrinteInss(rptMain, Data, PrinterName);
         }*/
            // Convert to Json
            string vDataJson = JsonConvert.SerializeObject(Data);
            return vDataJson;
        }
        public string GetPrintReport(int? pInvId = null)
        {
            string Printer = string.Empty;
            if (Request.Cookies["Printer"] != null)
            { Printer = Request.Cookies["Printer"].Value; };
            int? vInvId = pInvId;
            DataTable Data = _dbInvItem.funInvItemGET(vInvId, null);

            // Amr 27/11/2019
            CustomerCopy rpt = new CustomerCopy();
            ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);

            //clsExportPrinter.funReportExportPrint("rptPOS", Data, false);

            // Convert to Json
            string vDataJson = JsonConvert.SerializeObject(Data);
            return vDataJson;
        }

        public object RePrintInvoiceReport(int? InvId = null)
        {

            int? vInvId = InvId;
            DataTable Data = _dbInvItem.funInvItemGET(vInvId, null);


            string vFullPath = Server.MapPath("~/Reports/POS") + "//CustomerCopy.rpt";


            ClsReport.Printreport(Data, vFullPath);


            return ClsReport.Printreport(Data, vFullPath);


            // Amr 27/11/2019
            //CustomerCopy rpt = new CustomerCopy();
            //ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);

            //clsExportPrinter.funReportExportPrint("rptPOS", Data, false);

            // Convert to Json
            //string vDataJson = JsonConvert.SerializeObject(Data);
            //return vDataJson;
        }
        public void GetPrintDeliveryReport(DateTime? DateFrom = null, DateTime? DateTo = null, int? DeliveryId = null, int? CashierId = null)
        {
            string Printer = string.Empty;
            if (Request.Cookies["Printer"] != null) { Printer = Request.Cookies["Printer"].Value; };
            DataTable Data = _dbPOSReport.funDriverCashReportGET(DateFrom, DateTo, null, DeliveryId, CashierId);
            // Amr 27/11/2019
            if (!IsPOSPrinterNetwork)
            {
                string vFullPath = Server.MapPath("~/Reports/POS") + "//DeliveryCash.rpt";
                ClsReport.Printreport(Data, vFullPath);
            }
            else
            {
                DeliveryCash rpt = new DeliveryCash();
                ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);
            }
        }
        public string GetPrintGeneralReport()
        {
            string Printer = string.Empty;
            if (Request.Cookies["Printer"] != null) { Printer = Request.Cookies["Printer"].Value; };
            // 
            DataTable Data = _dbPOSReport.funPOSReportGET(pTodayDate: DateTime.Now, pCashierId: clsUser.vUserId);

            // Amr 27/11/2019
            BrosetGeneralReport rpt = new BrosetGeneralReport();
            ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);

            // Convert to Json
            string vDataJson = JsonConvert.SerializeObject(Data);
            return vDataJson;

        }
        public void GetPrintTestReport()
        {

            // 
            DataTable Data = _dbPOSReport.funPOSReportGET(pTodayDate: DateTime.Now, pCashierId: clsUser.vUserId);

            string vFullPath = Server.MapPath("~/Reports/POS") + "//BrosetGeneralReport.rpt";


            ClsReport.Printreport(Data, vFullPath);

            // Amr 27/11/2019
            //BrosetGeneralReport rpt = new BrosetGeneralReport();
            //ClsReport.PrinterName = ClsReport.PrinteInss(rpt, Data, Printer);

            //// Convert to Json
            //string vDataJson = JsonConvert.SerializeObject(Data);
            //return vDataJson;

        }
        public void GetKitchenReport(int? pInvId = null, string pPrinterId = null, string pPrinterName = "LocalKT")
        {
            string Printer = string.Empty;
            if (Request.Cookies["Printer"] != null)
            {
                Printer = Request.Cookies["Printer"].Value;
            };
            int? vInvId = pInvId;
            if (pPrinterId != null && pPrinterId != "0")
            {
                DataTable Data = _dbInvItem.funKitchenGET(vInvId, pPrinterId);
                if (Data != null)
                {
                    // clsExportPrinter.funReportExportPrint("rptPOSK", Data, false);

                    // Amr 27/11/2019
                    NewPOSK rpt = new NewPOSK();
                    ClsReport.PrintKitchen(rpt, Data, pPrinterName);
                }
            }
        }
        public void ShowCancelReport(int? pInvId = null)
        {
            DataTable Data = _dbInvItem.funInvItemGET(pInvId, null);
            string vFullPath = Server.MapPath("~/Reports/POS") + "//rptPOSCancel.rpt";
            ClsReport.Printreport(Data, vFullPath);
        }
        public string GetCancelReport(int? pInvId = null, string phNumbers = "")
        {
            string Printer = string.Empty;
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            if (Request.Cookies["Printer"] != null) { Printer = Request.Cookies["Printer"].Value; };
            int? vInvId = pInvId;
            DataTable Data = _dbInvItem.funInvItemGET(vInvId, phNumbers);
            if (phNumbers != "")
            {
                clsExportPrinter.funReportExportPrint("Insurance", Data, false);
            }
            else
            {
                if (IsPOSPrinterNetwork)
                {
                    rptPOSCancel rpt = new rptPOSCancel();
                    //Amr 27 / 11 / 2019
                    ClsReport.PrinteInss(rpt, Data, Printer);
                }
                //clsExportPrinter.funReportExportPrint("rptPOS", Data, false);
            }
            // Convert to Json
            string vDataJson = JsonConvert.SerializeObject(Data);
            return vDataJson;
        }
        public void GetCancelKitchenReport(int? pInvId = null, string pPrinterId = null, string pPrinterName = "LocalKT")
        {

            int? vInvId = pInvId;
            if (pPrinterId != null && pPrinterId != "0")
            {
                DataTable Data = _dbInvItem.funKitchenGET(vInvId, pPrinterId);
                if (Data != null)
                {
                    // Amr 27/11/2019
                    rptPOSKCancel rpt = new rptPOSKCancel();
                    ClsReport.PrinteInss(rpt, Data, pPrinterName);
                }
            }
        }
        public void ShowSimplePOSReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            int? branchId = null;

            if (Session["sTDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sTDateFrom"]);
            }
            if (Session["sTDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sTDateTo"]);
            }
            if (Session["sTodayDate"] != null)
            {
                vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sCashier"]);
            }
            if (Session["branchId"] != null)
            {
                branchId = Convert.ToInt32(Session["branchId"]);
            }
            DataTable vDT = null;
            string vFullPath = "";

            if (Session["sType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSReportGET(pTodayDate: vToday, BranchId: branchId);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSReportGET(pTodayDate: vToday, pCashierId: vCashierId, BranchId: branchId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, BranchId: branchId);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId, BranchId: branchId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSReport.rpt";
            }

            ClsReport.Printreport(vDT, vFullPath);



            // POSTodayReportBroset rpt = new POSTodayReportBroset();
            // ClsReport.PrinterName = ClsReport.PrinteInss(rpt, vDT);
        }
        public ActionResult SimplePOSReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null, int? branchId = null)
        {
            Session["sTDateFrom"] = pDateFrom;
            Session["sTDateTo"] = pDateTo;
            Session["sTodayDate"] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sType"] = "Today";
            }
            else
            {
                Session["sType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sCashier"] = pCashierId;
            }
            else
            {
                Session["sCashier"] = null;
            }
            if (branchId != null)
            {
                Session["branchId"] = branchId;
            }
            else
            {
                Session["branchId"] = null;
            }
            return View();
        }
        public ActionResult SimplePOSHtmlReport(
            DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbPOSReport.funPOSReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId, BranchId: branchId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة الكاشير";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSWithReturnHtmlReport(
            DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbPOSReport.funPOSReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId, BranchId: branchId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "صافي المبيعات";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult SimplePOSHtmlReportForMail(
          DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbPOSReport.funPOSReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId, BranchId: branchId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة الكاشير";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            var pdf = new ViewAsPdf2("SimplePOSHtmlReport");
            byte[] pdfByteArray = pdf.GetByte(ControllerContext);
            MemoryStream file = new MemoryStream(pdfByteArray);
            file.Seek(0, SeekOrigin.Begin);
            Attachment data = new Attachment(file, "POSReport.pdf", "application/pdf");
            // Build Message
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(MailFrom, "");
            string ToEmail = MailTo;
            string[] Multi = ToEmail.Split(','); //spiliting input Email id s
            foreach (string Multiemailid in Multi)
            {
                message.To.Add(new MailAddress(Multiemailid)); //adding
            }
            message.Subject = MailSubject;
            message.Body = MailBody;
            message.Attachments.Add(data);

            using (var client = new System.Net.Mail.SmtpClient(MailHost.Trim(), Convert.ToInt32(MailPort.Trim())))
            {
                client.Credentials = new NetworkCredential(MailFrom.Trim(), MailPassword.Trim());
                client.EnableSsl = true;
                client.Send(message);
            }
            //   return View();
            return new PartialViewAsPdf("SimplePOSHtmlReport")
            {
                FileName = "TestPartialViewAsPdf.pdf"
            };
        }
        public ActionResult SimplePOSDTLHtmlReport(
        DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null,
        int? branchId = null)
        {

            DataTable vDT = _dbPOSReport.funPOSDTLReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId,BranchId:branchId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة المبيعات تفصيلي";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSGroupingHtmlReport(
     DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbPOSReport.funPOSGroupingReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId,BranchId: branchId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة المبيعات تجميعي";
                ViewBag.Title = ViewBag.ReportName;
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult showDriverHtmlReport(
    DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null, int? InvTypeId = null)
        {
            DataTable vDT = _dbPOSReport.funDriverReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, InvTypeId: InvTypeId,BranchId:branchId);

            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة السائقين";
                ViewBag.Title = ViewBag.ReportName;
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSDeletedHtmlReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? CustomerId = null, int? branchId = null, bool? IsCancel = null)
        {
            DataTable vDT = _dbPOSReport.funPOSDeletedReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId, CustomerId: CustomerId, IsCancel: IsCancel, InvType: 33);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                if (IsCancel == false)
                {
                    ViewBag.ReportName = "تقرير فواتير الكاشيرات";
                }
                else
                {
                    ViewBag.ReportName = " تقرير فواتير الكاشيرات الملغية";
                }
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSReturnhtmlReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? CustomerId = null, int? branchId = null, bool? IsCancel = null)
        {
            DataTable vDT = _dbPOSReport.funPOSDeletedReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId, CustomerId: CustomerId, IsCancel: IsCancel, InvType: 34);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;

                ViewBag.ReportName = "تقرير المرتجعات ";

                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSInsuranceHtmlReport(
        DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {
            DataTable vDT = _dbPOSReport.funPOSInsReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة التأمين";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSInsuranceReturnHtmlReport(
       DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {
            DataTable vDT = _dbPOSReport.funPOSInsReturnReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "حركة مردودات التأمين";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult SimplePOSInsuranceReturnHtmlReportPDF(
DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {
            return new ActionAsPdf("SimplePOSInsuranceReturnHtmlReport", new
            {
                pDateFrom = pDateFrom,
                pDateTo = pDateTo,
                pCashierId = pCashierId,
                branchId = branchId
            });
        }
        public ActionResult SimpleSheepHtmlReport(
        DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {
            DataTable vDT = _dbPOSReport.SheepReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, pCashierId: pCashierId);
            if (vDT.Rows.Count > 0)
            {
                DataRow dataRow = vDT.Rows[0];
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "تقرر الذبائح";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
            }
            return View();
        }
        public ActionResult GeneralPOSReport()
        {


            dbERPEntities dbERPEntities = new dbERPEntities();

            ViewBag.Branches = new SelectList(dbERPEntities.Branches, "BranchId", "BranchName");
            ViewBag.DevCompanySetting = _DevCompanySetting;
            DataRow DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now).Rows[0];
            ViewBag.PeriodId = DT["PeriodId"];
            ViewBag.DateFrom = DT["FromDate"];
            ViewBag.DateTo = DT["ToDate"];
            return View();
        }
        public void ShowSimplePOSDTLReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sDateFrom"]);
            }
            if (Session["sDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sDateTo"]);
            }
            if (Session["sTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sCashier"]);
            }

            DataTable vDT = null;

            string vFullPath = "";

            if (Session["sType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDTLReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDTLReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSDTLTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDTLReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDTLReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSDTLReport.rpt";
            }

            ClsReport.Printreport(vDT, vFullPath);

            // POSTodayReportBroset rpt = new POSTodayReportBroset();
            // ClsReport.PrinterName = ClsReport.PrinteInss(rpt, vDT);
        }
        public ActionResult SimplePOSDTLReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sDateFrom"] = pDateFrom;
            Session["sDateTo"] = pDateTo;
            Session["sTodayDate"] = pTodayDate;

            if (pTodayDate != null)
            {
                Session["sType"] = "Today";
            }
            else
            {
                Session["sType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sCashier"] = pCashierId;
            }
            else
            {
                Session["sCashier"] = null;
            }

            return View();
        }


        public void ShowSimpleSheepReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sDateFrom"]);
            }
            if (Session["sDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sDateTo"]);
            }
            if (Session["sTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sCashier"]);
            }

            DataTable vDT = null;

            string vFullPath = "";



            vDT = _dbPOSReport.SheepReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);


            vFullPath = Server.MapPath("~/Reports/POS") + "//SheepReport.rpt";


            ClsReport.Printreport(vDT, vFullPath);

            // POSTodayReportBroset rpt = new POSTodayReportBroset();
            // ClsReport.PrinterName = ClsReport.PrinteInss(rpt, vDT);
        }
        public ActionResult SimpleSheepReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sDateFrom"] = pDateFrom;
            Session["sDateTo"] = pDateTo;
            Session["sTodayDate"] = pTodayDate;

            if (pTodayDate != null)
            {
                Session["sType"] = "Today";
            }
            else
            {
                Session["sType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sCashier"] = pCashierId;
            }
            else
            {
                Session["sCashier"] = null;
            }

            return View();
        }
        public void ShowSimplePOSGroupingReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sGDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sGDateFrom"]);
            }
            if (Session["sGDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sGDateTo"]);
            }
            if (Session["sGTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sGCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sGCashier"]);
            }
            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sGType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSGroupingReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSGroupingReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSGroupingTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSGroupingReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSGroupingReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSGroupingReport.rpt";
            }

            ClsReport.Printreport(vDT, vFullPath);
        }
        public void ShowDriverReport(DateTime? pDateFrom, DateTime? pDateTo, int? InvTypeId)
        {
            if (pDateFrom == null || pDateTo == null)
            {
                pDateFrom = DateTime.Now;
                pDateTo = DateTime.Now;
            }
            //if (Today != null)
            //{
            //    Today = DateTime.Now;
            //}

            DataTable vDT = _dbPOSReport.funDriverReportGET(pDateFrom: pDateFrom, pDateTo: pDateTo, InvTypeId: InvTypeId);

            string vFullPath = Server.MapPath("~/Reports/POS") + "//DriverReport.rpt";

            ClsReport.Printreport(vDT, vFullPath);
        }

        public ActionResult SimplePOSGroupingReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sGDateFrom"] = pDateFrom;
            Session["sGDateTo"] = pDateTo;
            Session["sGTodayDate "] = pTodayDate;

            if (pTodayDate != null)
            {
                Session["sGType"] = "Today";
            }
            else
            {
                Session["sGType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sGCashier"] = pCashierId;
            }
            else
            {
                Session["sGCashier"] = null;
            }

            return View();
        }
        // Grouping With Cashier
        public void ShowSimplePOSGroupingCashReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sGCDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sGCDateFrom"]);
            }
            if (Session["sGCDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sGCDateTo"]);
            }
            if (Session["sGCTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sGCCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sGCCashier"]);
            }
            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sGCType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSGroupingCasherReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSGroupingCasherReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSGroupingCasherTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSGroupingCasherReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSGroupingCasherReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSGroupingCasherReport.rpt";
            }

            //DateTime vDateFrom = Convert.ToDateTime(Session["sGCDateFrom"]);
            //DateTime vDateTo = Convert.ToDateTime(Session["sGCDateTo"]);



            ClsReport.Printreport(vDT, vFullPath);
        }
        public ActionResult SimplePOSGroupingCashReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sGCDateFrom"] = pDateFrom;
            Session["sGCDateTo"] = pDateTo;
            Session["sGCTodayDate "] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sGCType"] = "Today";
            }
            else
            {
                Session["sGCType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sGCCashier"] = pCashierId;
            }
            else
            {
                Session["sGCCashier"] = null;
            }

            return View();
        }
        //DTL With Cashier
        public void ShowSimplePOSDTLCashReport()
        {
            DateTime vDateFrom = DateTime.Now;
            DateTime vDateTo = DateTime.Now;
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sDCDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sDCDateFrom"]);
            }
            if (Session["sDCDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sDCDateTo"]);
            }
            if (Session["sDCTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sDCCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sDCCashier"]);
            }
            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sDCType"].ToString() == "Today")
            {

                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDTLCasherReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDTLCasherReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }
                vFullPath = Server.MapPath("~/Reports/POS") + "//POSDTLCasherTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDTLCasherReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDTLCasherReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSDTLCasherReport.rpt";
            }


            ClsReport.Printreport(vDT, vFullPath);
        }
        public ActionResult SimplePOSDTLCashReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sDCDateFrom"] = pDateFrom;
            Session["sDCDateTo"] = pDateTo;
            Session["sDCTodayDate "] = pTodayDate;

            if (pTodayDate != null)
            {
                Session["sDCType"] = "Today";
            }
            else
            {
                Session["sDCType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sDCCashier"] = pCashierId;
            }
            else
            {
                Session["sDCCashier"] = null;
            }

            return View();
        }

        public void ShowSimplePOSInsuranceReturnReport()
        {
            DateTime vDateFrom = Convert.ToDateTime(Session["sInsDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["sInsDateTo"]);
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sInsDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sInsDateFrom"]);
            }
            if (Session["sInsDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sInsDateTo"]);
            }
            if (Session["sInsTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sInsCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sInsCashier"]);
            }
            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sInsType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }
                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSInsReturnReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSInsReturnReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceReturnReport.rpt";
            }


            ClsReport.Printreport(vDT, vFullPath);
        }
        //Insurance With Cashier
        public void ShowSimplePOSInsuranceReport()
        {
            DateTime vDateFrom = Convert.ToDateTime(Session["sInsDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["sInsDateTo"]);
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sInsDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sInsDateFrom"]);
            }
            if (Session["sInsDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sInsDateTo"]);
            }
            if (Session["sInsTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sInsCashier"] != null)
            {
                vCashierId = Convert.ToInt32(Session["sInsCashier"]);
            }
            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sInsType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pTodayDate: vToday);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pTodayDate: vToday, pCashierId: vCashierId);
                }
                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSInsReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceReport.rpt";
            }


            ClsReport.Printreport(vDT, vFullPath);
        }
        public ActionResult SimplePOSInsuranceReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sInsDateFrom"] = pDateFrom;
            Session["sInsDateTo"] = pDateTo;
            Session["sInsTodayDate"] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sInsType"] = "Today";
            }
            else
            {
                Session["sInsType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sInsCashier"] = pCashierId;
            }
            else
            {
                Session["sInsCashier"] = null;
            }


            return View();
        }

        public ActionResult SimplePOSInsuranceReturnReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sInsDateFrom"] = pDateFrom;
            Session["sInsDateTo"] = pDateTo;
            Session["sInsTodayDate"] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sInsType"] = "Today";
            }
            else
            {
                Session["sInsType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sInsCashier"] = pCashierId;
            }
            else
            {
                Session["sInsCashier"] = null;
            }


            return View();
        }





        //Insurance With Cashier
        public void ShowSimplePOSDeletedReport()
        {
            DateTime vDateFrom = Convert.ToDateTime(Session["sDeletedDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["sDeletedDateTo"]);
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            bool IsCancel = true;
            if (Session["sDeletedDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sDeletedDateFrom"]);
            }
            if (Session["IsCancel"] != null)
            {
                IsCancel = Convert.ToBoolean(Session["IsCancel"]);
            }
            if (Session["sDeletedDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sDeletedDateTo"]);
            }
            if (Session["sDeletedTodayDate"] != null)
            {
                //vToday = Convert.ToDateTime(Session["sTodayDate"]);
            }
            if (Session["sDeletedCashier"] != null)
            {

                vCashierId = Convert.ToInt32(Session["sDeletedCashier"]);
            }
            if (Session["IsCancel"] != null)
            {

                IsCancel = Convert.ToBoolean(Session["IsCancel"]);
            }


            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sDeletedType"].ToString() == "Today")
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDeletedReportGET(pTodayDate: vToday, IsCancel: IsCancel, InvType: 33);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDeletedReportGET(pTodayDate: vToday, pCashierId: vCashierId, IsCancel: IsCancel, InvType: 33);
                }


                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceDeletedTodayReport.rpt";
            }
            else
            {
                if (vCashierId == 0)
                {
                    vDT = _dbPOSReport.funPOSDeletedReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, IsCancel: IsCancel, InvType: 33);
                }
                else
                {
                    vDT = _dbPOSReport.funPOSDeletedReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo, pCashierId: vCashierId, IsCancel: IsCancel, InvType: 33);
                }

                vFullPath = Server.MapPath("~/Reports/POS") + "//POSInsuranceDeletedReport.rpt";
            }


            ClsReport.Printreport(vDT, vFullPath);
        }

        public ActionResult SimplePOSDeletedReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null, int? pCashierId = null, bool? IsCancel = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sDeletedDateFrom"] = pDateFrom;
            Session["sDeletedDateTo"] = pDateTo;
            Session["sDeletedTodayDate"] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sDeletedType"] = "Today";
            }
            else
            {
                Session["sDeletedType"] = "";
            }
            if (pCashierId != null)
            {
                Session["sDeletedCashier"] = pCashierId;
            }
            else
            {
                Session["sDeletedCashier"] = null;
            }

            if (IsCancel != null)
            {
                Session["IsCancel"] = IsCancel;
            }
            else
            {
                Session["IsCancel"] = null;
            }


            return View();
        }
        //Insurance With Cashier
        public void ShowSimplePOSReceiptVoucherReport()
        {
            DateTime vDateFrom = Convert.ToDateTime(Session["sRVDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["sRVDateTo"]);
            DateTime vToday = DateTime.Now;
            int vCashierId = 0;
            if (Session["sRVDateFrom"] != null)
            {
                vDateFrom = Convert.ToDateTime(Session["sRVDateFrom"]);
            }
            if (Session["sRVDateTo"] != null)
            {
                vDateTo = Convert.ToDateTime(Session["sRVDateTo"]);
            }
            if (Session["sRVTodayDate"] != null)
            {
                vToday = Convert.ToDateTime(Session["sRVTodayDate"]);
            }
            //if (Session["sDeletedCashier"] != null)
            //{

            //    vCashierId = Convert.ToInt32(Session["sDeletedCashier"]);
            //}


            DataTable vDT = null;
            string vFullPath = "";
            if (Session["sRVType"].ToString() == "Today")
            {

                vDT = _dbPOSReport.funPOSReceiptVoucherReportGET(pTodayDate: vToday);
                vFullPath = Server.MapPath("~/Reports/POS") + "//POSReceiptVoucherToday.rpt";
            }
            else
            {

                vDT = _dbPOSReport.funPOSReceiptVoucherReportGET(pDateFrom: vDateFrom, pDateTo: vDateTo);
                vFullPath = Server.MapPath("~/Reports/POS") + "//POSReceiptVoucher.rpt";
            }


            ClsReport.Printreport(vDT, vFullPath);
        }

        public ActionResult SimplePOSReceiptVoucherReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, DateTime? pTodayDate = null)
        {

            //string vDateFrom = Convert.ToDateTime(pDateFrom).ToString("yyyy-MM-dd");
            //   string vDateTo = Convert.ToDateTime(pDateTo).ToString("yyyy-MM-dd");
            Session["sRVDateFrom"] = pDateFrom;
            Session["sRVDateTo"] = pDateTo;
            Session["sRVTodayDate"] = pTodayDate;
            if (pTodayDate != null)
            {
                Session["sRVType"] = "Today";
            }
            else
            {
                Session["sRVType"] = "";
            }
            //if (pCashierId != null)
            //{
            //    Session["sDeletedCashier"] = pCashierId;
            //}
            //else
            //{
            //    Session["sDeletedCashier"] = null;
            //}



            return View();
        }

        // Create Partial View For MAp
        public PartialViewResult Map()
        {
            return PartialView();
        }

        [HttpGet]
        public void FirstCount(int count = 0)
        {
            _dbINVInvoice.FirstCount = count;
        }
        [HttpGet]
        public void SecondCount(int count = 0)
        {
            _dbINVInvoice.SecondCount = count;
        }
        
        [AllowAnonymous]
        public ActionResult ReturnPOS()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            DataTable data = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);
            if (data.Rows.Count > 0)
            {
                DataRow DT = data.Rows[0];
                ViewBag.PeriodId = DT["PeriodId"];
                ViewBag.DateFrom = DT["FromDate"];
                ViewBag.DateTo = DT["ToDate"];

                // Add Day To Period
                DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

                DateTime OpenDateTo = OpenDateFrom.AddDays(1);

                // ViewBag
                ViewBag.OpenDateFrom = OpenDateFrom;
                ViewBag.OpenDateTo = OpenDateTo;

            }
            ViewBag.date = DateTime.Now.ToString("yyyy-M-ddThh:mm:ss");
            return View();
        }

        [AllowAnonymous]
        public ActionResult FollowUpOnStatusOfInvoicesWithZatca()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            //ViewBag.IsPOSPrinterNetwork = IsPOSPrinterNetwork;
            DataTable data = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);

            if (data.Rows.Count > 0)
            {
                DataRow DT = data.Rows[0];
                ViewBag.PeriodId = DT["PeriodId"];
                ViewBag.DateFrom = DT["FromDate"];
                ViewBag.DateTo = DT["ToDate"];

                // Add Day To Period
                DateTime OpenDateFrom = Convert.ToDateTime(DT["ToDate"]);

                DateTime OpenDateTo = OpenDateFrom.AddDays(1);

                // ViewBag
                ViewBag.OpenDateFrom = OpenDateFrom;
                ViewBag.OpenDateTo = OpenDateTo;

                _dbINVInvoice.TableData = data;


            }
            ViewBag.date = DateTime.Now.ToString("yyyy-M-ddThh:mm:ss");
            return View();
        }
        
        [HttpGet]
        public ActionResult MealReport(DateTime DateFrom, DateTime DateTo, int? CashId, int? ItemId, bool? IsGrouping)
        {
            ViewBag.IsGrouping = IsGrouping;
            if (IsGrouping == true)
            {
                ViewBag.ReportName = "اجمالي مبيعات الوجبات تجميعي";
            }
            else
            {
                ViewBag.ReportName = "اجمالي مبيعات الوجبات ";
            }
            ViewBag.DateFrom = DateFrom;
            ViewBag.DateTo = DateTo;
            ViewBag.MealData=  _dbInvItem.MealData( DateFrom,  DateTo, CashId, ItemId ,  IsGrouping);
            return View();
        }
        [HttpGet]
        public ActionResult ItemCostMinMaxReport(DateTime DateFrom, DateTime DateTo,  int? ItemId)
        {
          
                ViewBag.ReportName = "تقرير  حساب متوسط تكلفة اصناف مواد خام  ";
            
            ViewBag.DateFrom = DateFrom;
            ViewBag.DateTo = DateTo;
            ViewBag.MealData = _dbInvItem.ItemCostMinMaxData( DateFrom,  DateTo,  ItemId);
            return View();
        }

        public string SendInvoice(int pInvId,int? pOrderId)
        {
            if(pInvId < 1 && pOrderId == null)
                return SystemMessageCode.ToJSON(SystemMessageCode.GetError("تجربة إعادة إرسال الفاتورة الى الهيئة"));
            var result = _prepareInvoiceBeforeSendingToZatca.ResendInvoice(pInvId, pOrderId);
            return result;
        }

        /*
        #region Send To Zatca
        public void SendToZatca(DataTable dataTable)
        {
            var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            InvoiceCreateRequest obj = SetZatcaInvoiceValues(dataTable);
            SendInvoice(TokenDb,obj);            
        }
        void SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        {
            try
            {
               //await Task.Delay(120000); // ثنتان دقائق
               //await Task.Delay(60000); // دقيقة
                IZatcaEInvoice api = new ZatcaEInvoiceAPI();
                var result = Task.Run(() => api.SendInvoice(TokenDb, obj));
                string status = "";
                InvoiceResponseDto invoiceResponseDto = result.Result;
                if (invoiceResponseDto != null &&(invoiceResponseDto.statusCode != "200" || invoiceResponseDto.statusCode != "201"))
                {
                    // DOTO : تعديل حالة موافقة الضرائب للفاتورة عندنا
                    string responseJson = JsonConvert.SerializeObject(invoiceResponseDto);

                    string responseJson66 = JsonConvert.SerializeObject(invoiceResponseDto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    status = invoiceResponseDto.status;
                }
                Console.WriteLine("-----------------");
                Console.WriteLine(status);
                Console.WriteLine("-----------------");

                //var result = Task.Run(() => api.SendInvoiceStr(TokenDb, obj));
                //string invoiceResponseDto = result.Result;
                //string responseJson = JsonConvert.SerializeObject(invoiceResponseDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }


        InvoiceCreateRequest SetZatcaInvoiceValues(DataTable dataTable)
        {
            InvoiceCreateRequest obj = new InvoiceCreateRequest();

            List<InvoiceItem> itemlst = new List<InvoiceItem>() { };

            string organization = dataTable.Rows[0].Field<string>("organization").ToString();
            string tax_number = dataTable.Rows[0].Field<string>("tax_number").ToString();
            string IsReturn = Convert.ToString(dataTable.Rows[0].Field<string>("IsReturn"));
            string reference_pk = null;
            string reference_date = null;
            if (IsReturn == "true")
            {
                reference_pk = dataTable.Rows[0].Field<string>("invref").ToString();
                reference_date = dataTable.Rows[0].Field<string>("IDate").ToString();
            }
            InvoiceCustomer customerLinkPro = new InvoiceCustomer()
            {
                organization = organization,
                tax_number = tax_number,
                street = dataTable.Rows[0].Field<string>("street").ToString(),
                city = dataTable.Rows[0].Field<string>("city").ToString(),
                building_number = dataTable.Rows[0].Field<string>("building_number").ToString(),
                postal_zone = dataTable.Rows[0].Field<string>("postal_zone").ToString(),
                district_name = dataTable.Rows[0].Field<string>("district_name").ToString()
            };


            foreach (DataRow item in dataTable.Rows)
            {
                if (item["ItemType"].ToString() == "1")
                {
                    itemlst.Add(
                    new InvoiceItem()
                    {
                        name = item["InvItemNameL1"].ToString(),
                        price = item["PricePro"].ToString(),
                        quantity = item["Qty"].ToString()
                    });
                }
            }

            

            //var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            var InvCode = dataTable.Rows[0].Field<string>("InvCode").ToString();
            var account_id = dataTable.Rows[0].Field<string>("account_id").ToString();
            var Discount = dataTable.Rows[0].Field<double>("Discount").ToString();

            if (!String.IsNullOrEmpty(tax_number) && !String.IsNullOrEmpty(organization))
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = "invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    customer = customerLinkPro,
                    reference_pk = reference_pk,
                    reference_date = reference_date
                };
            }
            else
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = "invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    reference_pk = reference_pk,
                    reference_date = reference_date

                };
            }

            return obj;
        }
        #endregion
        */
    }
}