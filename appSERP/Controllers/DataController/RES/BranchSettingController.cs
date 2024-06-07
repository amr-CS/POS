using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using Newtonsoft.Json;
using System.Data;
using System.Web;
using System.Web.Mvc;
using appSERP.Logger;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class BranchSettingController : Controller
    {
        private ILog _ILog;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public BranchSettingController(ILog log, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)

        {
            _ILog = log;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: BranchSetting
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                string vBasicPath = "/Image/";
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Image/") + fileName); //File will be saved in application root

            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }

        // Save 
        public string funBranchSetting(
        int? pBranchSettingId = null,
        string pBranchSettingCode = null,
        string pBranchDesc = null,
        string pBranchDescL = null,
        int? pFraction = null,
        string pMaskAmount = null,
        int? pFormatDate = null,
        int? pEmpAtType = null,
        string pEmpDate = null,
        int? pPlateCode = null,
        string pDesFormat = null,
        string pDesName = null,
        string pDesType = null,
        string pReportServer = null,
        string pRrovirtualdir = null,
        string pReportsINTerface = null,
        string pHostname = null,
        string pVirtualdir = null,
        string pPhysicaldir = null,
        string pUseorarrp = null,
        string pUsequeuetables = null,
        string pRepExtINTion = null,
        float? pDefaultLocation = null,
        string pImgPath = null,
        int? pPlateStore = null,
        int? pPlateUnit = null,
        int? pSellStore = null,
        int? pPcDetectionType = null,
        int? pHoldInvTimer = null,
        int? pInsuranceLimit = null,
        string pInvoiceRemark = null,
        string pOrderRemark = null,
        string pKitchenPrINTer = null,
        string pFontPath = null,
        string pBranchPhone = null,
        int? pSheepCat = null,
        int? pAllowSwithoutcprINTers = null,
        string pLocationImgPath = null,
        int? pFoodPrepareCat = null,
        int? pCashCode = null,
        bool? pShowRefItem = null,
        bool? pShowRefProduct = null,
        int? pCustAcc = null,
        int? pRecevAcc = null,
        string pCostCenter = null,
        string pBounsAccount = null,
        string pLaterAccounts = null,
        string pVPosCaneclAcc = null,
        string pRentAccounts = null,
        int? pDriverSeq = null,
        int? pKitchenStore = null,
        int? pSheepCatProduct = null,
        int? pSheepOutRes = null,
        int? pSellAcc = null,
        int? pInsurAcc = null,
        int? pRentAcc = null,
        int? pShowQty = null,
        int? pSubSeqInv = null,
        int? pBranchMgr = null,
        int? pReservType = null,
        int? pDeliveryTrans = null,
        bool? pAllowBlkList = null,
        int? pItemDelivery = null,
        bool? pAllowCancelInvoice = null,
        int? pGrpAddPlate = null,
        int? pQtyPlateRice = null,
        int? pRiceCat = null,
        bool? pShowQtyZero = null,
        string pOrderEmp = null,
        string pOrderPhone = null,
        string pBranchPhoneOrder = null,
        string pBranchAddress = null,
        bool? pDefaultProdCost = null,
        int? pSubSeqOrder = null,
        bool? pDecreaseProdAuto = null,
        int? pCommAccount = null,
        string pShortNum = null,
        int? pNewOrderTime = null,
        bool? pDeliveryCashier = null,
        bool? pPayCashierAmount = null,
        bool? pAssemblingPrINTer = null,
        int? pDefaultLocationDelivery = null,
        bool? pModifyInvoice = null,
        bool? pPrINTCancelInvoice = null,
        bool? pDisplayDirverAccount = null,
        bool? pDisplayUpdateDirver = null,
        bool? pPrINTUpdateInvoice = null,
        int? pLimitInvId = null,
        bool? pPrINTBasicInvId = null,
        bool? pAutoOpenPeriod = null,
        bool? pAutoClosePeriod = null,
        int? pLengthPeriodDay = null,
        int? pCompIdPost = null,
        bool? pUpdateInvoiceDriver = null,
        bool? pShowAllInvoiceForCancel = null,
        bool? pShowAllInvoiceForUpdate = null,
        bool? pChangeUpdateDate = null,
        bool? pManualProduction = null,
        bool? pChangeUpdateCashier = null,
        int? pDiscountType = null,
        bool? pEnterHelfoodAllowed = null,
        bool? pEnterPartbuildAllowed = null,
        bool? pAllowDiscount = null,
        bool? pConvertProductionFullQty = null,
        bool? pCloseFormUpdateAuto = null,
        int? pStoreBasic = null,
        int? pProductTypeOut = null,
        bool? pAssemblingPost = null,
        string pClientStoreId = null,
        string pBranchAccount = null,
        int? pEmpCostId = null,
        int? pStoreProduction = null,
        bool? pChoiceStoreProdAuto = null,
        bool? pAddQyProductbeforeSpend = null,
        int? pCompanyId = null,
        string pIsVat = null,
        string pVatCode = null,
        float? pVatPerc = null,
        float? pRoundLowerHalf = null,
        bool? pIsDeleted = false,
                 int? BOX_ID = null,
            int? CostID = null,
            string VatAccount = null,
            string TotalAccount = null,
            string InsuranceAccount = null,
            string ReturnAccount = null,
            string NumberReports = null,
            float? MadaPerc = null,
            float? VisaPerc = null,
            int? pQueryTypeId = null)
        {

            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath ="/APIBranchSetting/BranchSettingGet";
            // Praremeter
            string vParameters =
                "?pBranchSettingId="+ pBranchSettingId+
                "&pCompanyId="+ pCompanyId  +
                "&pBranchDesc="+ pBranchDesc +
                "&pBranchDescL="+ pBranchDescL +
                "&pEmpAtType="+ pEmpAtType  +
                "&pVatPerc=" + pVatPerc +
                "&pFoodPrepareCat="+ pFoodPrepareCat +
                "&pDefaultLocation="+ pDefaultLocation +
                "&pSheepCatProduct="+ pSheepCatProduct +
                "&pSheepCat="+ pSheepCat+
                "&pSheepOutRes="+ pSheepOutRes +
                "&pRiceCat="+ pRiceCat +
                "&pSellStore="+ pSellStore  +
                "&pPlateUnit="+ pPlateUnit  +
                "&pPlateStore="+ pPlateStore +
                "&pPlateCode="+ pPlateCode  +
                "&pQtyPlateRice="+ pQtyPlateRice+
                "&pInsuranceLimit="+ pInsuranceLimit  +
                "&pShowQty="+ pShowQty +
                "&pFormatDate="+ pFormatDate  +
                "&pSellAcc="+ pSellAcc +
                "&pRentAcc="+ pRentAcc +
                "&pLimitInvId="+ pLimitInvId  +
                "&pBranchPhone="+ pBranchPhone +
                "&pMaskAmount="+ pMaskAmount  +
                "&pHoldInvTimer="+ pHoldInvTimer+
                "&pPcDetectionType="+ pPcDetectionType +
                "&pInsurAcc="+ pInsurAcc+
                "&pCommAccount="+ pCommAccount +
                "&pLengthPeriodDay="+ pLengthPeriodDay +
                "&pOrderEmp="+ pOrderEmp+
                "&pBranchAddress="+ pBranchAddress+
                "&pOrderPhone="+ pOrderPhone  +
                "&pBranchPhoneOrder="+ pBranchPhoneOrder+
                "&pDefaultLocationDelivery="+ pDefaultLocationDelivery +
                "&pDefaultLocationDelivery="+ pDefaultLocationDelivery +
                "&pBranchMgr="+ pBranchMgr +
                "&pGrpAddPlate="+ pGrpAddPlate +
                "&pProductTypeOut="+ pProductTypeOut  +
                "&pReservType="+ pReservType  +
                "&pItemDelivery="+ pItemDelivery+
                "&pKitchenPrINTer="+ pKitchenPrINTer  +
                "&pCashCode="+ pCashCode+
                "&pDriverSeq="+ pDriverSeq  +
                "&pSheepOutRes="+ pSheepOutRes +
                "&pFontPath="+ pFontPath+
                "&pEmpDate="+ pEmpDate +
                "&pNewOrderTime="+ pNewOrderTime+
                "&pCompIdPost="+ pCompIdPost  +
                "&pBranchAccount="+ pBranchAccount  +
                "&pDeliveryTrans="+ pDeliveryTrans+
                "&pDiscountType="+ pDiscountType+
                "&pStoreBasic="+ pStoreBasic  +
                "&pFraction="+ pFraction+
                "&pShortNum="+ pShortNum+
                "&pCostCenter="+ pCostCenter  +
                "&pClientStoreId="+ pClientStoreId+
                "&pEmpCostId="+ pEmpCostId  +
                "&pAllowSwithoutcprINTers="+ pAllowSwithoutcprINTers  +
                "&pStoreProduction="+ pStoreProduction +
                "&pImgPath="+ pImgPath +
                "&pInvoiceRemark="+ pInvoiceRemark+
                "&pOrderRemark=" + pOrderRemark +
                "&pAssemblingPrINTer="+ pAssemblingPrINTer  +
                "&pModifyInvoice="+ pModifyInvoice  +
                "&pPrINTCancelInvoice="+ pPrINTCancelInvoice  +
                "&pPrINTUpdateInvoice="+ pPrINTUpdateInvoice  +
                "&pAutoOpenPeriod="+ pAutoOpenPeriod  +
                "&pEnterHelfoodAllowed="+ pEnterHelfoodAllowed +
                "&pEnterPartbuildAllowed="+ pEnterPartbuildAllowed  +
                "&pManualProduction="+ pManualProduction+
                "&pAssemblingPost="+ pAssemblingPost  +
                "&pChoiceStoreProdAuto="+ pChoiceStoreProdAuto +
                "&pDeliveryCashier="+ pDeliveryCashier +
                "&pPayCashierAmount="+ pPayCashierAmount+
                "&pDisplayDirverAccount="+ pDisplayDirverAccount+
                "&pDisplayUpdateDirver="+ pDisplayUpdateDirver +
                "&pAutoClosePeriod="+ pAutoClosePeriod +
                "&pChangeUpdateCashier="+ pChangeUpdateCashier +
                "&pChangeUpdateDate="+ pChangeUpdateDate+
                "&pConvertProductionFullQty="+ pConvertProductionFullQty+
                "&pCloseFormUpdateAuto="+ pCloseFormUpdateAuto +
                "&pDecreaseProdAuto="+ pDecreaseProdAuto+
                "&pShowRefItem="+ pShowRefItem +
                "&pShowRefProduct="+ pShowRefProduct  +
                "&pAllowBlkList="+ pAllowBlkList+
                "&pAllowCancelInvoice="+ pAllowCancelInvoice  +
                "&pPrINTBasicInvId="+ pPrINTBasicInvId +
                "&pShowAllInvoiceForCancel="+ pShowAllInvoiceForCancel +
                "&pShowAllInvoiceForUpdate="+ pShowAllInvoiceForUpdate +
                "&pAllowDiscount="+ pAllowDiscount  +
                "&pAddQyProductbeforeSpend="+ pAddQyProductbeforeSpend +
                "&pUpdateInvoiceDriver="+ pUpdateInvoiceDriver +
                "&BOX_ID=" + BOX_ID +
                "&CostID=" + CostID +
                "&VatAccount=" + VatAccount +
                "&VatAccount=" + VatAccount +
                "&TotalAccount=" + TotalAccount +
                "&ReturnAccount=" + ReturnAccount +
                "&NumberReports=" + NumberReports +
                "&MadaPerc=" + MadaPerc +
                "&VisaPerc=" + VisaPerc +
                "&pQueryTypeId=" + pQueryTypeId;

            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }

        public ActionResult BranchSettingSearch(string pTypeId)
        {
            ViewBag.vbTypeId = pTypeId;
            return View();
        }

        public ActionResult EmpAtTypeSearch()
        {
            return View();
        }
        public ActionResult FoodPrepareCatSearch()
        {
            return View();
        }


        public ActionResult SheepCatProductSearch()
        {
            return View();
        }

        public ActionResult SheepCatSearch()
        {
            return View();
        }


        public ActionResult SheepOutResSearch()
        {
            return View();
        }
        public ActionResult RiceCatSearch()
        {
            return View();
        }
        public ActionResult SellStoreSearch()
        {
            return View();
        }
        public ActionResult PlatCodeSearch()
        {
            return View();
        }



        public ActionResult PlatUnitSearch()
        {
            return View();
        }

        public ActionResult PlateStoreSearch()
        {
            return View();
        }


        public ActionResult SellAccSearch()
        {
            return View();
        }
        public ActionResult RentAccSearch()
        {
            return View();
        }
        public ActionResult InsurAccSearch()
        {
            return View();
        }
        public ActionResult CommAccountSearch()
        {
            return View();
        }

        public ActionResult DefaultLocationSearch()
        {
            return View();
        }
        public ActionResult DefaultLocationDeliverySearch()
        {
            return View();
        }
        ////////////////////
        public ActionResult BranchMgrSearch()
        {
            return View();
        }
        public ActionResult GrpAddPlateSearch()
        {
            return View();
        }



        public ActionResult ProductTypeOutSearch()
        {
            return View();
        }

        public ActionResult ReservTypeSearch()
        {
            return View();
        }


        public ActionResult ItemDeliverySearch()
        {
            return View();
        }
        public ActionResult KitchenPrinterSearch()
        {
            return View();
        }
        public ActionResult CashCodeSearch()
        {
            return View();
        }
        public ActionResult DriverSeqSearch()
        {
            return View();
        }

        public ActionResult StoreBasicSearch()
        {
            return View();
        }
        public ActionResult StoreProductionSearch()
        {
            return View();
        }
        // GET: BranchSetting
        public ActionResult SearchBranchSetting()
        {
            return View();
        }

    }
}