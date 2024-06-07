using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.CalendarSetting;
using appSERP.appCode.Setting.CaptchaImageResult;
using appSERP.appCode.Setting.SYSSETT;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using Neodynamic.SDK.Web;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using appSERP.Logger;
using System.Web;
using System.Net.Mail;
using System.Net;
using Rotativa;
using System.IO;
using ZXing.QrCode;
using ZXing;
using System.Drawing;
using System.Drawing.Imaging;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.SYSSETT.Abstract;
using appSERP.appCode.Setting.GD.Abstract;

namespace appSERP.Controllers
{
    public class HomeController : Controller
    {
        private ILog _ILog;
        private static X509KeyStorageFlags STORAGE_FLAGS = X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable;
        private IdbInvItem _dbInvItem;
        private IdbLookup _dbLookup;
        private IdbStoreType _dbStoreType;
        private IdbPeriod _dbPeriod;
        private IdbDashBoard _dbDashBoard;
        private IdbObjects _dbObjects;
        private IdbLanguage _dbLanguage;
        private IdbSystem _dbSystem;
        private IclsAPI _clsAPI;
        private ISYSSETTSetting _SYSSETTSetting;
        private IDevCompanySetting _DevCompanySetting;



        public HomeController(ILog log, IdbInvItem dbInvItem, IdbLookup dbLookup, IdbStoreType dbStoreType,
            IdbPeriod dbPeriod, IdbDashBoard dbDashBoard, IdbObjects dbObjects, IdbLanguage dbLanguage, IdbSystem dbSystem, IclsAPI clsAPI, ISYSSETTSetting SYSSETTSetting, IDevCompanySetting devCompanySetting)
        {
            _ILog = log;
            _dbInvItem = dbInvItem;
            _dbLookup = dbLookup;
            _dbStoreType = dbStoreType;
            _dbPeriod = dbPeriod;
            _dbDashBoard = dbDashBoard;
            _dbObjects = dbObjects;
            _dbLanguage = dbLanguage;
            _dbSystem = dbSystem;
            _clsAPI = clsAPI;
            _SYSSETTSetting = SYSSETTSetting;
            _DevCompanySetting = devCompanySetting;
            
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        [HttpGet]
        [NoDirectAccess]
        [Authorize]
        public ActionResult Index()
        {
            List<int> vlst = clsCalendar.funYear();
            ViewBag.vbDashBoard = _dbDashBoard.funDashBoardGET();
            ViewBag.DevCompanySetting = _DevCompanySetting;
            //ClsReport.PrinterName = ClsReport.GetDefaultPrinterName();
            DataTable DT = _dbPeriod.funPeriodGET(pIsPosted: null, pIsDeleted: false, pFromDate: DateTime.Now);
            if (DT.Rows.Count > 0)
            {
                DataRow DR = DT.Rows[0];
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
            WebClientPrint.LicenseOwner = "nopsam2007";
            WebClientPrint.LicenseKey = "BBF5F841AC437F129950EC3B312303EDE2C681C927C18D0081905F99223AA763";
            ViewBag.WCPPDetectionScript = Neodynamic.SDK.Web.WebClientPrint.CreateWcppDetectionScript(Url.Action("ProcessRequest", "WebClientPrintAPI", null, HttpContext.Request.Url.Scheme), HttpContext.Session.SessionID);
            return View();
        }
        [HttpGet]
        public ActionResult test()
        {

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
        [AllowAnonymous]
        public ActionResult PrintPDF()
        {
            DataTable Data = _dbInvItem.funInvItemGET(1000, null);
            return new PartialViewAsPdf(Data)
            {
                FileName = @"D:\altacv-template.pdf"
            };
        }


        public ActionResult ReportTemplate()
        {

            return View();
        }
        public ActionResult AttendanceSTAT()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            DataTable CategoryItem = _dbLookup.funtblLookupGET(pQueryTypeId: 500, pLookupId: 120);
            return View(CategoryItem);


        }


        public PartialViewResult Chart()
        {

            return PartialView();
        }
        public PartialViewResult ChartBandwidth()
        {

            return PartialView();
        }
        public ActionResult test1()
        {

            return View();
        }
        public ActionResult SignMessage()
        {
            string request = Request.QueryString["request"];
            //var WEBROOT_PATH = Server.MapPath("/");
            var CURRENT_PATH = Server.MapPath("~");
            var PARENT_PATH = HttpRuntime.AppDomainAppPath; //(CURRENT_PATH).Parent.FullName;
            string vAppConnectionOnline = @"\tray\privateKey.pfx";
            var KEY = PARENT_PATH + vAppConnectionOnline;
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
        public ActionResult Contact()
        {
            /*  // Get Objects
              DataTable vDtObject = null;
                  //dbUserObjectAction.funUserObjectGET();
              // Get Distinct Object Type
              DataTable vDtObjectType = dbUserObjectAction.funUserObjectTypeGET(vDtObject);
              // Get Distinct System
              DataTable vDtSystem = dbUserObjectAction.funUserSystemGET(vDtObjectType);
              // ViewBag
              if (vDtObject.Rows.Count > 0 && vDtObject.Rows.Count >0 && vDtSystem.Rows.Count>0)
              {
                  ViewBag.vbObject = vDtObject;
                  ViewBag.vbObjectType = vDtObjectType;
                  ViewBag.vbSystem = vDtSystem;
              }
            */
            return View();
        }

        // Login [Get]
        public ActionResult Login()
        {
            bool vCheckConnection = CaptchaImageResult.CheckForInternetConnection();
            ViewBag.vbCheck = vCheckConnection;
            ViewBag.dbSystem = _dbSystem.funSystemDataGET();
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        // List For Users
        [HttpPost]
        public string GetLanguage()
        {
            string vLanguagePath = appAPIDirectory.vAPILanguage;
            string vLanguageParameters = "?pLanguageIsActive=True";
            DataTable dtLanguage = _clsAPI.funResultGet(vLanguagePath + vLanguageParameters);
            // Convert to Json
            string vLanguageJson = JsonConvert.SerializeObject(dtLanguage);
            // Return Result
            return vLanguageJson;
        }

        [HttpPost]
        public string GetCountry()
        {
            string vCountryPath = appAPIDirectory.vAPICountry;
            string vCountryParameters = "?pCountryIsActive=True";
            DataTable dtCountry = _clsAPI.funResultGet(vCountryPath + vCountryParameters);
            // Convert to Json
            string vCountryJson = JsonConvert.SerializeObject(dtCountry);
            // Return Result
            return vCountryJson;
        }


        [HttpPost]
        public string GetVoucherType(string id)
        {
            string vVoucherTypePath = appAPIDirectory.vAPIVoucherType;
            string vVoucherTypeParameters = "?pVoucherTypeId=" + id;
            DataTable dtVoucherType = _clsAPI.funResultGet(vVoucherTypePath + vVoucherTypeParameters);
            // Convert to Json
            string vVoucherTypeJson = JsonConvert.SerializeObject(dtVoucherType);
            // Return Result
            return vVoucherTypeJson;
        }
        [HttpPost]
        public string GetPaymentType()
        {
            string vPaymentTypePath = appAPIDirectory.vAPIPaymentType;
            string vPaymentTypeParameters = "?pPaymentTypeIsActive=True";
            DataTable dtPaymentType = _clsAPI.funResultGet(vPaymentTypePath + vPaymentTypeParameters);
            // Convert to Json
            string vPaymentTypeJson = JsonConvert.SerializeObject(dtPaymentType);
            // Return Result
            return vPaymentTypeJson;
        }
        [HttpPost]
        public string GetObject()
        {
            string vObjectPath = appAPIDirectory.vAPIObjects;
            string vObjectParameters = "?pObjectIsActive=True";
            DataTable dtObject = _clsAPI.funResultGet(vObjectPath + vObjectParameters);
            // Convert to Json
            string vObjectJson = JsonConvert.SerializeObject(dtObject);
            // Return Result
            return vObjectJson;
        }
        [HttpPost]
        public string GetFontSize()
        {
            string vFontSizePath = appAPIDirectory.vAPIFontSizeType;
            string vFontSizeParameters = "?pFontSizeIsActive=True";
            DataTable dtFontSize = _clsAPI.funResultGet(vFontSizePath + vFontSizeParameters);
            // Convert to Json
            string vFontSizeJson = JsonConvert.SerializeObject(dtFontSize);
            // Return Result
            return vFontSizeJson;
        }
        [HttpPost]
        public string GetFont()
        {
            string vFontPath = appAPIDirectory.vAPIFont;
            string vFontParameters = "?pFontIsActive=True";
            DataTable dtFont = _clsAPI.funResultGet(vFontPath + vFontParameters);
            // Convert to Json
            string vFontJson = JsonConvert.SerializeObject(dtFont);
            // Return Result
            return vFontJson;
        }
        [HttpPost]
        public string GetUserType()
        {
            string vUserTypePath = appAPIDirectory.vAPIUserType;
            string vUserTypeParameters = "?pUserTypeIsActive=True";
            DataTable dtUserType = _clsAPI.funResultGet(vUserTypePath + vUserTypeParameters);
            // Convert to Json
            string vUserTypeJson = JsonConvert.SerializeObject(dtUserType);
            // Return Result
            return vUserTypeJson;
        }
        [HttpPost]
        public string GetUser()
        {
            string vUserPath = appAPIDirectory.vAPIUser;
            string vUserParameters = "?pUserIsActive=True";
            DataTable dtUser = _clsAPI.funResultGet(vUserPath + vUserParameters);
            // Convert to Json
            string vUserJson = JsonConvert.SerializeObject(dtUser);
            // Return Result
            return vUserJson;
        }

        [HttpPost]
        public string GetUserSecurityTransactionType()
        {
            string vUserSecurityTransactionTypePath = appAPIDirectory.vAPIUserSecurityTransactionType;

            DataTable dtUserSecurityTransactionType = _clsAPI.funResultGet(vUserSecurityTransactionTypePath);
            // Convert to Json
            string vUserSecurityTransactionTypeJson = JsonConvert.SerializeObject(dtUserSecurityTransactionType);
            // Return Result
            return vUserSecurityTransactionTypeJson;
        }
        // Account
        [HttpPost]
        public string GetAccountType()
        {
            string vAccountTypePath = appAPIDirectory.vAPIAccountType;
            string vAccountTypeParameters = "?pAccountTypeIsActive=True";
            DataTable dtAccountType = _clsAPI.funResultGet(vAccountTypePath + vAccountTypeParameters);
            // Convert to Json
            string vAccountTypeJson = JsonConvert.SerializeObject(dtAccountType);
            // Return Result
            return vAccountTypeJson;
        }
        [HttpGet]
        public void funSendMail(string pSubject, string pBody, string pMessageTo, string vMail, string vMailPassword, string vMailHost,
           int vMailPort)
        {


            // Main Data
            String FROM = vMail;
            String FROMNAME = "";
            String TO = pMessageTo;
            String SMTP_USERNAME = vMail;
            String SMTP_PASSWORD = vMailPassword;
            String HOST = vMailHost;
            int PORT = vMailPort;
            String SUBJECT = pSubject;
            String BODY = pBody;

            // Build Message
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;
            var filename = @"D:\altacv-template.pdf";
            message.Attachments.Add(new Attachment(filename));
            //// CHECK ATTACHMENT
            //foreach (string vFilePath in pLstFilePath)
            //{
            //    Attachment vAttachment = new Attachment(vFilePath);
            //    message.Attachments.Add(vAttachment);
            //}




            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.

                // Send
                client.Send(message);

                // Error
            }
        }
        /*     [HttpGet]
         public  ActionResult funSendMail(string pSubject, string pBody,string pMessageTo, string vMail, string vMailPassword, string vMailHost,
            int vMailPort)
         {


             // Specify the from and to email address
             MailMessage mailMessage = new MailMessage(vMail, pMessageTo);
             // Specify the email body
             mailMessage.Body = pBody;
             // Specify the email Subject
             mailMessage.Subject = pSubject;

             // Specify the SMTP server name and post number
             SmtpClient smtpClient = new SmtpClient(vMailHost, vMailPort);
             // Specify your gmail address and password
             smtpClient.Credentials = new System.Net.NetworkCredential()
             {
                 UserName = vMail,
                 Password = vMailPassword
             };
             // Gmail works on SSL, so set this property to true
             smtpClient.EnableSsl = true;
             // Finall send the email message using Send() method
             smtpClient.Send(mailMessage);




             return null;

         }*/
        // Area
        [HttpPost]
        public string GetCity()
        {
            string vCityPath = appAPIDirectory.vAPICity;
            string vCityParameters = "?pCityIsActive=True";
            DataTable dtCity = _clsAPI.funResultGet(vCityPath + vCityParameters);
            // Convert to Json
            string vCityJson = JsonConvert.SerializeObject(dtCity);
            // Return Result
            return vCityJson;
        }

        // Area
        [HttpPost]
        public string GetCashDesk()
        {
            string vCashDeskPath = appAPIDirectory.vAPICashDesk;
            string vCashDeskParameters = "?pCashDeskIsActive=True";
            DataTable dtCashDesk = _clsAPI.funResultGet(vCashDeskPath + vCashDeskParameters);
            // Convert to Json
            string vCashDeskJson = JsonConvert.SerializeObject(dtCashDesk);
            // Return Result
            return vCashDeskJson;
        }
        [HttpPost]
        public string GetAccount(string AccountId, string AccountNo, string pQueryTypeId)
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            string vParameter;
            if (pQueryTypeId != null)
            {
                vParameter = "?pAccountNo=" + AccountNo + "&pAccountId=" + AccountId + "&pQueryTypeId=" + pQueryTypeId;
            }
            else
            {
                vParameter = "?pAccountNo=" + AccountNo + "&pAccountId=" + AccountId;
            }


            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath + vParameter);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }

        [HttpPost]
        public string GetAssetDebitAccount()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }
        [HttpPost]
        public string GetAssetCreditAccount()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }
        [HttpPost]
        public string GetAssetPurchaseAccount()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }
        [HttpPost]
        public string GetAssetSalesAccount()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }
        [HttpPost]
        public string GetAccountName()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            string vAccountParameters = "?pAccountId=1";
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath + vAccountParameters);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }

        // Customer Supplier
        [HttpPost]
        public string GetArea()
        {
            string vAreaPath = appAPIDirectory.vAPIArea;
            string vAreaParameters = "?pAreaIsActive=True";
            DataTable dtArea = _clsAPI.funResultGet(vAreaPath + vAreaParameters);
            // Convert to Json
            string vAreaJson = JsonConvert.SerializeObject(dtArea);
            // Return Result
            return vAreaJson;
        }
        [HttpPost]
        public string GetCSGroup(string Id)
        {
            string vCSGroupPath = appAPIDirectory.vAPICustomerSupplierGroup;
            string vCSGroupParameters = "?pCSGroupIsActive=True&pCSGroupId=" + Id;
            DataTable dtCSGroup = _clsAPI.funResultGet(vCSGroupPath + vCSGroupParameters);
            // Convert to Json
            string vCSGroupJson = JsonConvert.SerializeObject(dtCSGroup);
            // Return Result
            return vCSGroupJson;
        }
        [HttpPost]
        public string GetCostCenter(string CostCenterId, string CostCenterCode, string pQueryTypeId)
        {
            string vCostCenterPath = appAPIDirectory.vAPICostCenter;
            string vCostCenterParameters = "?pCostCenterIsActive=True&pCostCenterId=" + CostCenterId + "&pCostCenterCode=" + CostCenterCode + "&pQueryTypeId=" + pQueryTypeId;
            DataTable dtCostCenter = _clsAPI.funResultGet(vCostCenterPath + vCostCenterParameters);
            // Convert to Json
            string vCostCenterJson = JsonConvert.SerializeObject(dtCostCenter);
            // Return Result
            return vCostCenterJson;
        }
        [HttpPost]
        public string GetCostCenterAll()
        {
            string vCostCenterPath = appAPIDirectory.vAPICostCenter;
            string vCostCenterParameters = "?pCostCenterIsActive=True";
            DataTable dtCostCenter = _clsAPI.funResultGet(vCostCenterPath + vCostCenterParameters);
            // Convert to Json
            string vCostCenterJson = JsonConvert.SerializeObject(dtCostCenter);
            // Return Result
            return vCostCenterJson;
        }
        [HttpPost]
        public string GetAccountAll()
        {
            string vAccountPath = appAPIDirectory.vAPIAccount;
            string vAccountParameters = "?pAccountIsActive=True";
            DataTable dtAccount = _clsAPI.funResultGet(vAccountPath + vAccountParameters);
            // Convert to Json
            string vAccountJson = JsonConvert.SerializeObject(dtAccount);
            // Return Result
            return vAccountJson;
        }
        [HttpPost]
        public string GetAccountCostCenter()
        {
            string vAccountCostCenterPath = appAPIDirectory.vAPIAccountCostCenter;
            string vAccountCostCenterParameters = "?pAccountCostCenterIsActive=True";
            DataTable dtAccountCostCenter = _clsAPI.funResultGet(vAccountCostCenterPath + vAccountCostCenterParameters);
            // Convert to Json
            string vAccountCostCenterJson = JsonConvert.SerializeObject(dtAccountCostCenter);
            // Return Result
            return vAccountCostCenterJson;
        }
        [HttpPost]
        public string GetCurrencyFactor()
        {
            string vCurrencyFactorPath = appAPIDirectory.vAPICurrencyFactor;
            string vCurrencyFactorParameters = "?pCurrencyFactorIsActive=True";
            DataTable dtCurrencyFactor = _clsAPI.funResultGet(vCurrencyFactorPath + vCurrencyFactorParameters);
            // Convert to Json
            string vCurrencyFactorJson = JsonConvert.SerializeObject(dtCurrencyFactor);
            // Return Result
            return vCurrencyFactorJson;
        }
        [HttpPost]
        public string GetCurrencyGender()
        {
            string vCurrencyGenderPath = appAPIDirectory.vAPICurrencyGender;
            string vCurrencyGenderParameters = "?pCurrencyGenderIsActive=True";
            DataTable dtCurrencyGender = _clsAPI.funResultGet(vCurrencyGenderPath + vCurrencyGenderParameters);
            // Convert to Json
            string vCurrencyGenderJson = JsonConvert.SerializeObject(dtCurrencyGender);
            // Return Result
            return vCurrencyGenderJson;
        }
        [HttpPost]
        public string GetCurrency(string id)
        {
            string vCurrencyPath = appAPIDirectory.vAPICurrency;
            string vCurrencyParameters = "?pCurrencyIsActive=True&pCurrencyId=" + id;
            DataTable dtCurrency = _clsAPI.funResultGet(vCurrencyPath + vCurrencyParameters);
            // Convert to Json
            string vCurrencyJson = JsonConvert.SerializeObject(dtCurrency);
            // Return Result
            return vCurrencyJson;
        }

        [HttpPost]
        public string GetFinancialYearStatus()
        {
            string vFinancialYearStatusPath = appAPIDirectory.vAPIFinancialYearStatus;
            string vFinancialYearStatusParameters = "?pFinancialYearStatusIsActive=True";
            DataTable dtFinancialYearStatus = _clsAPI.funResultGet(vFinancialYearStatusPath + vFinancialYearStatusParameters);
            // Convert to Json
            string vFinancialYearStatusJson = JsonConvert.SerializeObject(dtFinancialYearStatus);
            // Return Result
            return vFinancialYearStatusJson;
        }
        [HttpPost]
        public string GetSystem()
        {
            string vSystemPath = appAPIDirectory.vAPISystem;
            string vSystemParameters = "?pSystemIsActive=True";
            DataTable dtSystem = _clsAPI.funResultGet(vSystemPath + vSystemParameters);
            // Convert to Json
            string vSystemJson = JsonConvert.SerializeObject(dtSystem);
            // Return Result
            return vSystemJson;
        }
        [HttpPost]
        public string GetSecurityGrade()
        {
            string vSecurityGradePath = appAPIDirectory.vAPISecurityGrade;
            string vSecurityGradeParameters = "?pSecurityGradeIsActive=True";
            DataTable dtSecurityGrade = _clsAPI.funResultGet(vSecurityGradePath + vSecurityGradeParameters);
            // Convert to Json
            string vSecurityGradeJson = JsonConvert.SerializeObject(dtSecurityGrade);
            // Return Result
            return vSecurityGradeJson;
        }
        [HttpPost]
        public string GetCashFlowType()
        {
            string vCashFlowTypePath = appAPIDirectory.vAPICashFlowType;
            string vCashFlowTypeParameters = "?pCashFlowTypeIsActive=True";
            DataTable dtCashFlowType = _clsAPI.funResultGet(vCashFlowTypePath + vCashFlowTypeParameters);
            // Convert to Json
            string vCashFlowTypeJson = JsonConvert.SerializeObject(dtCashFlowType);
            // Return Result
            return vCashFlowTypeJson;
        }
        [HttpPost]
        public string GetFinancialYear()
        {
            string vFinancialYearPath = appAPIDirectory.vAPIFinancialYear;
            string vFinancialYearParameters = "?pFinancialYearIsActive=True";
            DataTable dtFinancialYear = _clsAPI.funResultGet(vFinancialYearPath + vFinancialYearParameters);
            // Convert to Json
            string vFinancialYearJson = JsonConvert.SerializeObject(dtFinancialYear);
            // Return Result
            return vFinancialYearJson;
        }


        [HttpPost]
        public string GetCompanyBranch()
        {
            string vCompanyBranchPath = appAPIDirectory.vAPICompanyBranch;
            string vCompanyBranchParameters = "?pCompanyBranchIsActive=True";
            DataTable dtCompanyBranch = _clsAPI.funResultGet(vCompanyBranchPath + vCompanyBranchParameters);
            // Convert to Json
            string vCompanyBranchJson = JsonConvert.SerializeObject(dtCompanyBranch);
            // Return Result
            return vCompanyBranchJson;
        }
        [HttpPost]
        public string GetTimeZone()
        {
            string vTimeZonePath = appAPIDirectory.vAPITimeZone;
            DataTable dtTimeZone = _clsAPI.funResultGet(vTimeZonePath);
            // Convert to Json
            string vTimeZoneJson = JsonConvert.SerializeObject(dtTimeZone);
            // Return Result
            return vTimeZoneJson;
        }
        [HttpPost]
        public string GetCountryType()
        {
            string vCountryTypePath = appAPIDirectory.vAPICountryType;
            string vCountryTypeParameters = "?pCountryTypeIsActive=True";
            DataTable dtCountryType = _clsAPI.funResultGet(vCountryTypePath + vCountryTypeParameters);
            // Convert to Json
            string vCountryTypeJson = JsonConvert.SerializeObject(dtCountryType);
            // Return Result
            return vCountryTypeJson;
        }


        [HttpPost]
        public string GetAsset()
        {
            string vAssetPath = appAPIDirectory.vAPIAsset;
            DataTable dtAsset = _clsAPI.funResultGet(vAssetPath);
            // Convert to Json
            string vAssetJson = JsonConvert.SerializeObject(dtAsset);
            // Return Result
            return vAssetJson;
        }
        [HttpPost]
        public string GetCurrencyList()
        {
            string vCurrencyPath = appAPIDirectory.vAPICurrency;
            DataTable dtCurrency = _clsAPI.funResultGet(vCurrencyPath);
            // Convert to Json
            string vCurrencyJson = JsonConvert.SerializeObject(dtCurrency);
            // Return Result
            return vCurrencyJson;
        }
        [HttpPost]
        public string GetTransactionType()
        {
            string vTransactionTypePath = appAPIDirectory.vAPIAssetTransactionType;
            DataTable dtTransactionType = _clsAPI.funResultGet(vTransactionTypePath);
            // Convert to Json
            string vTransactionTypeJson = JsonConvert.SerializeObject(dtTransactionType);
            // Return Result
            return vTransactionTypeJson;
        }
        [HttpPost]
        public string GetAssetReasonType()
        {
            string vAssetReasonTypePath = appAPIDirectory.vAPIAssetReasonType;
            DataTable dtAssetReasonType = _clsAPI.funResultGet(vAssetReasonTypePath);
            // Convert to Json
            string vAssetReasonTypeJson = JsonConvert.SerializeObject(dtAssetReasonType);
            // Return Result
            return vAssetReasonTypeJson;
        }

        [HttpPost]
        public string GetFixedAssetMethod()
        {
            string vFixedAssetMethodPath = appAPIDirectory.vAPIFixedAssetMethod;
            string vFixedAssetMethodParameters = "?pFixedAssetMethodIsActive=True";
            DataTable dtFixedAssetMethod = _clsAPI.funResultGet(vFixedAssetMethodPath + vFixedAssetMethodParameters);
            // Convert to Json
            string vFixedAssetMethodJson = JsonConvert.SerializeObject(dtFixedAssetMethod);
            // Return Result
            return vFixedAssetMethodJson;
        }

        [HttpPost]
        public string GetMainGroup()
        {
            string vMainGroupPath = appAPIDirectory.vAPIMainGroup;
            string vMainGroupParameters = "?pMainGroupIsActive=True";
            DataTable dtMainGroup = _clsAPI.funResultGet(vMainGroupPath + vMainGroupParameters);
            // Convert to Json
            string vMainGroupJson = JsonConvert.SerializeObject(dtMainGroup);
            // Return Result
            return vMainGroupJson;
        }
        [HttpPost]
        public string GetGroup(string pMainGroupId)
        {
            string vGroupPath = appAPIDirectory.vAPIGroup;
            string vGroupParameters = "?pGroupIsActive=True&pMainGroupId=" + pMainGroupId;
            DataTable dtGroup = _clsAPI.funResultGet(vGroupPath + vGroupParameters);
            // Convert to Json
            string vGroupJson = JsonConvert.SerializeObject(dtGroup);
            // Return Result
            return vGroupJson;
        }
        [HttpPost]
        public string GetAccountReport()
        {
            // ViewBag Account
            DataTable vDtAccountReport = _clsAPI.funResultGet(appAPIDirectory.vAPIAccount + "?pQueryTypeId=450");
            // Convert to Json
            string vAccountReportJson = JsonConvert.SerializeObject(vDtAccountReport);
            // Return Result
            return vAccountReportJson;
        }

        [HttpPost]
        public string GetGroupAccounts(string pGroupId)
        {
            string vGroupPath = appAPIDirectory.vAPIGroup;
            string vGroupParameters = "?pGroupId=" + pGroupId + "&pQueryTypeId=401";
            DataTable dtGroup = _clsAPI.funResultGet(vGroupPath + vGroupParameters);
            // Convert to Json
            string vGroupJson = JsonConvert.SerializeObject(dtGroup);
            // Return Result
            return vGroupJson;
        }
        [HttpPost]
        public string GetFixedAssetUnit()
        {
            string vFixedAssetUnitPath = appAPIDirectory.vAPIFixedAssetUnit;
            string vFixedAssetUnitParameters = "?pFixedAssetUnitIsActive=True";
            DataTable dtFixedAssetUnit = _clsAPI.funResultGet(vFixedAssetUnitPath + vFixedAssetUnitParameters);
            // Convert to Json
            string vFixedAssetUnitJson = JsonConvert.SerializeObject(dtFixedAssetUnit);
            // Return Result
            return vFixedAssetUnitJson;
        }
        [HttpPost]
        public string GetBuyGroup()
        {
            string vBuyGroupPath = appAPIDirectory.vAPIBuyGroup;
            string vBuyGroupParameters = "?pBuyGroupIsActive=True";
            DataTable dtBuyGroup = _clsAPI.funResultGet(vBuyGroupPath + vBuyGroupParameters);
            // Convert to Json
            string vBuyGroupJson = JsonConvert.SerializeObject(dtBuyGroup);
            // Return Result
            return vBuyGroupJson;
        }
        [HttpPost]
        public string GetFixedAssetCompany()
        {
            string vFixedAssetCompanyPath = appAPIDirectory.vAPIFixedAssetCompany;
            string vFixedAssetCompanyParameters = "?pFixedAssetCompanyIsActive=True";
            DataTable dtFixedAssetCompany = _clsAPI.funResultGet(vFixedAssetCompanyPath + vFixedAssetCompanyParameters);
            // Convert to Json
            string vFixedAssetCompanyJson = JsonConvert.SerializeObject(dtFixedAssetCompany);
            // Return Result
            return vFixedAssetCompanyJson;
        }
        [HttpPost]
        public string GetSiteDonor()
        {
            string vDonorPath = appAPIDirectory.vAPISiteDonor;
            string vDonorParameters = "?pSiteDonorIsActive=True";
            DataTable dtDonor = _clsAPI.funResultGet(vDonorPath + vDonorParameters);
            // Convert to Json
            string vDonorJson = JsonConvert.SerializeObject(dtDonor);
            // Return Result
            return vDonorJson;
        }
        [HttpPost]
        public string GetSite()
        {
            string vDonorPath = appAPIDirectory.vAPISite;
            string vDonorParameters = "?pSiteIsActive=True";
            DataTable dtDonor = _clsAPI.funResultGet(vDonorPath + vDonorParameters);
            // Convert to Json
            string vDonorJson = JsonConvert.SerializeObject(dtDonor);
            // Return Result
            return vDonorJson;
        }
        [HttpPost]
        public string GetSupplier()
        {
            string vCSPath = appAPIDirectory.vAPICustomerSupplier;


            string vCSParameters = "?pCSIsActive=True";


            DataTable dtCS = _clsAPI.funResultGet(vCSPath + vCSParameters);
            // Convert to Json
            string vCSJson = JsonConvert.SerializeObject(dtCS);
            // Return Result
            return vCSJson;
        }
        public ActionResult GetUserObject(int pObject)
        {

            clsUser.ObjectId = pObject;
            clsUser.ObjectIsFav = false;
            // API Path
            string vPath = appAPIDirectory.vAPIUserFavorite;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            if (vDtData.Rows.Count > 0)
            {
                DataRow[] foundObject = vDtData.Select("ObjectId='" + pObject + "'");
                if (foundObject.Length != 0)
                {
                    clsUser.ObjectIsFav = true;
                }
                else
                {
                    clsUser.ObjectIsFav = false;
                }
            }
            return null;
        }
        // Logout
        public ActionResult Logout()
        {
            // Logout
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public string GetCompantlanguages(int pCompanyBranchId)
        {
            string vCountryPath = appAPIDirectory.vAPICompanyBranch;
            string vCountryParameters = "?pCompanyBranchId=" + pCompanyBranchId;
            DataTable dtCountry = _clsAPI.funResultGet(vCountryPath + vCountryParameters);
            // Convert to Json
            string vCountryJson = JsonConvert.SerializeObject(dtCountry);
            // Return Result
            return vCountryJson;
        }



        [HttpPost]
        public string ChangeUserLanguage(int pLanguageId, string pLanguageCulture)
        {
            // QueryType
            int vQueryTypeId = clsQueryType.qUpdateUserLanguage;

            // API Path
            string vPath = appAPIDirectory.vAPIUser;
            string vParameters =
                "?pUserId=" + Convert.ToInt32(Session["UserId"]) +
                 "&pLanguageId=" + pLanguageId +
                 "&pQueryTypeId=" + vQueryTypeId;

            // Set New Language, Culture
            clsUser.vUserLanguageId = pLanguageId;
            clsUser.vUserCulture = pLanguageCulture;

            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            return vDrwResult.ToString();
        }

        [HttpGet]
        public string FirstGl()
        {
            string vFirst = _SYSSETTSetting.funFirstGl();
            return vFirst;
        }
        [HttpGet]
        public string LastGl()
        {
            string vLast = _SYSSETTSetting.funLastGL();
            return vLast;
        }
        [HttpGet]
        public string NextGl()
        {
            string vNext = _SYSSETTSetting.funNextGL();
            return vNext;
        }
        [HttpGet]
        public string PrevGl()
        {
            string vPrev = _SYSSETTSetting.funPrevGL();
            return vPrev;
        }



        [HttpGet]
        public string FirstCashDeskTrans()
        {
            string vFirst = _SYSSETTSetting.funFirstCashDeskTrans();
            return vFirst;
        }
        [HttpGet]
        public string LastCashDeskTrans()
        {
            string vLast = _SYSSETTSetting.funLastCashDeskTrans();
            return vLast;
        }
        [HttpGet]
        public string NextCashDeskTrans()
        {
            string vNext = _SYSSETTSetting.funNextCashDeskTrans();
            return vNext;
        }
        [HttpGet]
        public string PrevCashDeskTrans()
        {
            string vPrev = _SYSSETTSetting.funPrevCashDeskTrans();
            return vPrev;
        }
        [HttpPost]
        public string GetFixedAssetCompanyType()
        {
            string vFixedAssetCompanyTypePath = appAPIDirectory.vAPIFixedAssetCompanyType;
            string vFixedAssetCompanyTypeParameters = "?pFixedAssetCompanyTypeIsActive=True";
            DataTable dtFixedAssetCompanyType = _clsAPI.funResultGet(vFixedAssetCompanyTypePath + vFixedAssetCompanyTypeParameters);
            // Convert to Json
            string vFixedAssetCompanyTypeJson = JsonConvert.SerializeObject(dtFixedAssetCompanyType);
            // Return Result
            return vFixedAssetCompanyTypeJson;
        }
        [HttpPost]
        public string GetSiteDetail()
        {
            string vSiteDetailPath = appAPIDirectory.vAPISiteDetail;
            DataTable dtSiteDetailPath = _clsAPI.funResultGet(vSiteDetailPath);
            // Convert to Json
            string vSiteDetailJson = JsonConvert.SerializeObject(dtSiteDetailPath);
            // Return Result
            return vSiteDetailJson;
        }

        [HttpPost]
        public void funChangeLogInCulture(int pLanguageId, string pCultureName)
        {
            // SET No User Language
            clsUser.vUserLanguageId = pLanguageId;
            // Change User Culture
            clsUser.vUserCulture = pCultureName;


            // Applciation Culture [Culture]
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(pCultureName);
            // Applciation Culture [UI Culture]
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(pCultureName);
        }
        [HttpPost]
        public string funGetLanguages()
        {
            // Data
            string vLanguageData = _dbLanguage.funLanguageGET();
            // Return Result
            return vLanguageData;
        }

        [HttpPost]
        public void funObjectName(string pObjectName)
        {
            // Set Object Name From SideBar
            _dbObjects.vObjectName = pObjectName;
        }

        [HttpPost]
        public string GetYear()
        {
            // Year
            List<int> vYear = clsCalendar.funYear();
            // Convert to Json
            string vYearJson = JsonConvert.SerializeObject(vYear);
            // Return Result
            return vYearJson;
            // Return Result
        }
        [HttpPost]
        public string GetMonth()
        {
            // Month
            List<string> vMonth = clsCalendar.funMonth();
            // Convert to Json
            string vYearJson = JsonConvert.SerializeObject(vMonth);
            // Return Result
            return vYearJson;
        }
        [HttpPost]
        public string GetStoreType()
        {
            // Data
            string vStoreTypeData = _dbStoreType.funStoreTypeGET();
            // Return Result
            return vStoreTypeData;
        }
        [HttpPost]
        public string GetAssetContractPayType()
        {
            string vAssetContractPayTypePath = appAPIDirectory.vAPIAssetContractPayType;
            DataTable dtAssetContractPayType = _clsAPI.funResultGet(vAssetContractPayTypePath);
            // Convert to Json
            string vAssetContractPayTypeJson = JsonConvert.SerializeObject(dtAssetContractPayType);
            // Return Result
            return vAssetContractPayTypeJson;
        }
        [HttpPost]
        public string GetPeriod()
        {
            string vPeriodPath = appAPIDirectory.vAPIPeriod;
            DataTable dtPeriod = _clsAPI.funResultGet(vPeriodPath);
            // Convert to Json
            string vPeriodJson = JsonConvert.SerializeObject(dtPeriod);
            // Return Result
            return vPeriodJson;
        }

    }
}