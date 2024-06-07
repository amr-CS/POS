using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.Encode;
using appSERP.appCode.Setting.GSetting.Encode;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.RES;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using appSERP.Models;
using ZXing;
using ZXing.QrCode;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.Utils;

namespace appSERP.Controllers.DataController.RES.Order
{

     [NoDirectAccess]
    [Authorize]
    public class ResOrderController : Controller
    {

        private IdbINVInvoice _dbINVInvoice;
        private IdbPeriod _dbPeriod;
        private IdbResOrder _dbResOrder;
        private IdbResOrderDtl _dbResOrderDtl;
        private IdbUserCashier _dbUserCashier;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        private IdbBranchSetting _dbBranchSetting;

        public ResOrderController(IdbINVInvoice dbINVInvoice, IdbPeriod dbPeriod, IdbResOrder dbResOrder, IdbResOrderDtl dbResOrderDtl, IdbUserCashier dbUserCashier, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting, IdbBranchSetting dbBranchSetting)
        {
            _dbINVInvoice = dbINVInvoice;
            _dbPeriod = dbPeriod;
            _dbResOrder = dbResOrder;
            _dbResOrderDtl = dbResOrderDtl;
            _dbUserCashier = dbUserCashier;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
            _dbBranchSetting = dbBranchSetting;
        }

        // GET: ResOrder
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbBranchSetting = _dbBranchSetting;

            int UserId = 0;
            if (Request.Cookies["UserId"] != null)
            { UserId = Convert.ToInt32(Request.Cookies["UserId"].Value); }
            DataRow Permission = _dbUserCashier.TableUserCashierGET(pUserId: UserId, pQueryTypeId: 500).Rows[0];
            bool Discount = Convert.ToBoolean(Permission["Discount"]);
            if (!Discount) { ViewBag.Discount = "Disabled"; }
            else { ViewBag.Discount = ""; }
            // TimeZone time = DateTime.Now.ToLocalTime();

            return View();
        }
        [AllowAnonymous]
        public ActionResult POSOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            int UserId = 0;
            if (Request.Cookies["UserId"] != null)
            { UserId = Convert.ToInt32(Request.Cookies["UserId"].Value); }
            DataRow Permission = _dbUserCashier.TableUserCashierGET(pUserId: UserId, pQueryTypeId: 500).Rows[0];
            ViewBag.Branch=_dbBranchSetting.GetBranchSetting(pQueryTypeId: 407);
            bool Discount = Convert.ToBoolean(Permission["Discount"]);
            if (!Discount) { ViewBag.Discount = "Disabled"; }
            else { ViewBag.Discount = ""; }
            // TimeZone time = DateTime.Now.ToLocalTime();

            return View();
        }
        public ActionResult POSOrderHtmlReport(int? Id = null)
        {
            DataTable DT = _dbResOrder.funResOrderReport(Id);
            DataRow row = DT.Rows[0];
            string CompanyName = row["CompanyName"].ToString();
            string VatCode = row["VatCode"].ToString();
            string InvDate = row["InvDate"].ToString();
            DateTime d = Convert.ToDateTime(row["InvDate"].ToString());
            //string Date = d.ToString("yyyy-MM-dd") + ' ' + d.ToString("HH:mm:ss");
            string Date = InvoiceQR.InvoiceDateForQR(d);
            string Total = row["TotalPrice"].ToString();
            string Vat = row["Vat"].ToString();
            string EncodData = InvoiceQR.encodeQrText(CompanyName, VatCode, Date, Total, Vat);
            ViewBag.ImgPath = GenerateQRCode(EncodData);
            ViewBag.CreatedBy = row["CreatedBy"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.orderremark = row["orderremark"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.VatCode = row["VatCode"].ToString();
            ViewBag.vDT = DT;
            return View();
        }
        public ActionResult ResOrderHtmlReport(int? Id = null)
        {
            DataTable DT = _dbResOrder.funResOrderReport(Id);
            DataRow row = DT.Rows[0];
            string CompanyName = row["CompanyName"].ToString();
            string VatCode = row["VatCode"].ToString();
            //string InvDate = row["InvDate"].ToString();
            string Total = row["TotalPrice"].ToString();
            string Vat = row["Vat"].ToString();
            DateTime d = Convert.ToDateTime(row["InvDate"].ToString());
            string Date = InvoiceQR.InvoiceDateForQR(d);
            string EncodData = InvoiceQR.encodeQrText(CompanyName, VatCode, Date, Total, Vat);
            ViewBag.ImgPath = GenerateQRCode(EncodData);
            ViewBag.CreatedBy = row["CreatedBy"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.orderremark = row["orderremark"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.VatCode = row["VatCode"].ToString();
            ViewBag.CompanySite = row["CompanySite"].ToString();
            ViewBag.vDT = DT;
            return View();
        }
        public ActionResult ResOrderKitchenHtmlReport(int? Id = null)
        {
            DataTable DT = _dbResOrder.funResOrderReport(Id);
            DataRow row = DT.Rows[0];
            ViewBag.ImgPath = GenerateQRCode(row["QRCode"].ToString());
            ViewBag.CreatedBy = row["CreatedBy"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.orderremark = row["orderremark"].ToString();
            ViewBag.DELIVERY = row["DELIVERY"].ToString();
            ViewBag.VatCode = row["VatCode"].ToString();
            ViewBag.CompanySite = row["CompanySite"].ToString();
            ViewBag.header = "نموذج تحضير";
            ViewBag.vDT = DT;
            return View();
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
        public ActionResult MovementOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            DataTable DT = _dbPeriod.funPeriodGET(pIsPosted: false, pFromDate: DateTime.Now,
               pCreatedBy: Convert.ToInt32(Request.Cookies["UserId"].Value));
            if (DT.Rows.Count > 0)
            {
                ViewBag.open = true;
            }
            else
            {
                ViewBag.open = false;
            }
            
           
            int BranchId = 0;
            if (Request.Cookies["BranchId"] != null)
            { BranchId = Convert.ToInt32(Request.Cookies["BranchId"].Value); };

            ViewBag.MovementOrder = _dbResOrder.MovementOrderGET(BranchId: BranchId);
            return View();
        }
        // Save Order
        public string funSaveOrder(
        int? pOrderId = null,
        int? pORDER_SEQ = null,
        int? pCOMP_ID = null,
        int? pORDER_TYPE = null,
        int? pSUB_SEQ = null,
        string pORDER_DATE = null,
        string pDELIVERY_DATE = null,
        int? pCUST_SEQ = null,
        string pADDRESS = null,
        int? pORDER_STATUS = null,
        int? pPERIOD_TYPE = null,
        int? pCOST_ID = null,
        string pNOTES = null,
        string pDELIVERY_DATE2 = null,
        bool? pMULTI_DAY = null,
        bool? pDELIVERY = null,
        float? pPAY_CASH = null,
        float? pPAY_NET = null,
        float? pCREDIT = null,
        string pORDER_PHONE_NO = null,
        string pORDER_PHONE_NUMBER = null,
        int? pDISCOUNT = null,
        int? pPRICE_CAT = null,
        int? pDISCOUNT_SELL = null,
        int? pCASH_DISCOUNT = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            DateTime DELIVERY_DATE = DateTime.Parse(pDELIVERY_DATE);
            DateTime ORDER_DATE = DateTime.Parse(pORDER_DATE);
            // PAth
            string vPath = "/APIResOrder/ResOrderGET";
            // Paramter
            string vParameters =
                   "?pOrderId=" + pOrderId +
                   "&pORDER_SEQ=" + pORDER_SEQ +
                   "&pCOMP_ID=" + pCOMP_ID +
                   "&pORDER_TYPE=" + pORDER_TYPE +
                   "&pSUB_SEQ=" + pSUB_SEQ +
                   "&pORDER_DATE=" + ORDER_DATE +
                   "&pDELIVERY_DATE=" + DELIVERY_DATE +
                   "&pCUST_SEQ=" + pCUST_SEQ +
                   "&pADDRESS=" + pADDRESS +
                   "&pORDER_STATUS=" + pORDER_STATUS +
                   "&pPERIOD_TYPE=" + pPERIOD_TYPE +
                   "&pCOST_ID=" + pCOST_ID +
                   "&pNOTES=" + pNOTES +
                   "&pDELIVERY_DATE2=" + pDELIVERY_DATE2 +
                   "&pMULTI_DAY=" + pMULTI_DAY +
                   "&pDELIVERY=" + pDELIVERY +
                   "&pPAY_CASH=" + pPAY_CASH +
                   "&pPAY_NET=" + pPAY_NET +
                   "&pCREDIT=" + pCREDIT +
                   "&pORDER_PHONE_NO=" + pORDER_PHONE_NO +
                   "&pORDER_PHONE_NUMBER=" + pORDER_PHONE_NUMBER +
                   "&pDISCOUNT=" + pDISCOUNT +
                   "&pPRICE_CAT=" + pPRICE_CAT +
                   "&pDISCOUNT_SELL=" + pDISCOUNT_SELL +
                   "&pCASH_DISCOUNT=" + pCASH_DISCOUNT +
                   "&pIsDeleted=" + pIsDeleted +
                   "&pQueryTypeId=" + pQueryTypeId;

            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vResult;
        }
        // Save Order DTL
        public string funSaveOrderDtl(
       int? pOrderDTLID = null,
        int? pOrderId = null,
        int? pORDER_LOC_SEQ = null,
        int? pITEM_UNIT_SEQ = null,
        int? pTAG = null,
        float? pQTY = null,
        int? pPRICE = null,
        string pNOTES = null,
        int? pSLICING_TYPE = null,
        int? pSHEEP_REMAINDER = null,
        int? pCUST_SHEEP = null,
        int? pCUST_PLATE = null,
        int? pQTY_PLATE = null,
        int? pTYP = null,
        float? pPRICE_INSUR = null,
        float? pUPDATE_PRICE = null,
        int? pDISC_AMT = null,
        float? pVAT_PRICE = null,
        float? pVAT_TOTAL = null,
        int? pCOMP_ID = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APIResOrderDtl/ResOrderDtlGET";
            // Paramter
            string vParameters =
            "?pOrderDTLID=" + pOrderDTLID +
            "&pOrderId=" + pOrderId +
            "&pORDER_LOC_SEQ=" + pORDER_LOC_SEQ +
            "&pITEM_UNIT_SEQ=" + pITEM_UNIT_SEQ +
            "&pTAG=" + pTAG +
            "&pQTY=" + pQTY +
            "&pPRICE=" + pPRICE +
            "&pNOTES=" + pNOTES +
            "&pSLICING_TYPE=" + pSLICING_TYPE +
            "&pSHEEP_REMAINDER=" + pSHEEP_REMAINDER +
            "&pCUST_SHEEP=" + pCUST_SHEEP +
            "&pCUST_PLATE=" + pCUST_PLATE +
            "&pQTY_PLATE=" + pQTY_PLATE +
            "&pTYP=" + pTYP +
            "&pPRICE_INSUR=" + pPRICE_INSUR +
            "&pUPDATE_PRICE=" + pUPDATE_PRICE +
            "&pDISC_AMT=" + pDISC_AMT +
            "&pVAT_PRICE=" + pVAT_PRICE +
            "&pVAT_TOTAL=" + pVAT_TOTAL +
            "&pIsDeleted=" + pIsDeleted +
            "&pQueryTypeId=" + pQueryTypeId;

            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vResult;
        }
        // Save OrderLocation
        public string funSaveOrderLocation(
        int? pOrderLocId = null,
        int? pOrderId = null,
        int? pCUST_LOC_SEQ = null,
        string pADDRESS = null,
        string pNOTES = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // PAth
            string vPath = "/APIResOrderLocation/ResOrderLocationGET";
            // Paramter
            string vParameters =
            "?pOrderLocId=" + pOrderLocId +
            "&pOrderId=" + pOrderId +
            "&pCUST_LOC_SEQ=" + pCUST_LOC_SEQ +
            "&pADDRESS=" + pADDRESS +
            "&pNOTES=" + pNOTES +
            "&pIsDeleted=" + pIsDeleted +
            "&pQueryTypeId=" + pQueryTypeId;

            // SQL Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vResult;
        }

        public ActionResult OrderSearch()
        {
            return View();
        }
        public ActionResult POSOrderReport(int id)
        {
            ResOrder2_Report rpt = new ResOrder2_Report();
            // rpt.QRCode.Text = "amr mahmoud";
            rpt.QRCode.CanGrow = true;
            //rpt.xrPictureBox1.ImageSource = ImageSource.FromFile(@"D:\Work\appSERP\appSERP\Image\pandalus_B.jpg");
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            rpt.xrLabel42.Text = ticket.Name;
            rpt.Parameters["orderId"].Value = id;
            rpt.RequestParameters = false;
            using (MemoryStream ms = new MemoryStream())
            {
                rpt.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                return File(ms.ToArray(), "application/pdf");
            }
            //return View();
        }
        public ActionResult Report(int id)
        {
            ResOrder_Report rpt = new ResOrder_Report();
            rpt.vCompanyLanguage1NameL1.Text = clsCompany.vCompanyLanguage1NameL1;
            rpt.vCompanySite.Text = clsCompany.vCompanySite;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            rpt.xrLabel42.Text = ticket.Name;
            rpt.Parameters["orderId"].Value = id;
            rpt.RequestParameters = false;
            using (MemoryStream ms = new MemoryStream())
            {
                rpt.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                return File(ms.ToArray(), "application/pdf");
            }
            //return View();
        }

        [HttpPost]
        public JsonResult InsertResOrderDtlBulk(ICollection<ResOrderDtl> resOrderDtls, int? orderId,int? branchId)
        {
            // إضافة تفاصيل طلب جديد
            //if (ModelState.IsValid)
            //{
            if (resOrderDtls.Count < 1)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError("لا يوجد تفاصيل")));
            
            string message = "";
            foreach (var mdl in resOrderDtls)
            {
                if (mdl.ITEM_UNIT_SEQ == null || mdl.UnitId == null || mdl.QTY == null || mdl.QTY <= 0)
                    message += mdl.ITEM_UNIT_SEQ + " للآسف بيانات تفاصيل الطلب فارغة \n";
            }

            message = message.Trim();
            if (string.IsNullOrWhiteSpace(message) == false || message.Length > 0)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError(message)));

            return Json(_dbResOrderDtl.spResOrderDtlInsertBulk(resOrderDtls, orderId, branchId));
            //}

            //var error = ModelState.Select(x => new { x.Key, ErrorMessage = x.Value.Errors.Select(e => e.ErrorMessage) });
            //return Json(error);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }
        public ActionResult OrderData()
        {
            int BranchId = 0;
            if (Request.Cookies["BranchId"] != null)
            { BranchId = Convert.ToInt32(Request.Cookies["BranchId"].Value); };

            ViewBag.MovementOrder = _dbResOrder.MovementOrderGET(BranchId: BranchId);
            return View();

        }
        public ActionResult InvoiceData(int? id = null, DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            ViewBag.InvData = _dbINVInvoice.DtINVInvoiceGET(phInvId: id, psDateFrom: DateFrom, psDateTo: DateTo, pQueryTypeId: 500);
            return View();

        }

        public ActionResult TagSearch(int? CategoryId = null)
        {
            ViewBag.CategoryId = CategoryId;
            return View();
        }
    }
}