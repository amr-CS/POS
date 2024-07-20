
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.ZatcaEInvoicing.LinkPro;
using appSERP.ZatcaEInvoicing.LinkPro.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace appSERP.appCode.dbCode.RES
{
    public class branchsettingForHangeFire
    {

        HttpClient client = ApiHelper.ApiClient;

        #region DB
        public DataTable GetBranchSetting(
         int? pBranchSettingId = null,
         string pBranchSettingCode = null,
         string pBranchDesc = null,
         string pBranchDescL = null,
         int? pBranchId = null,
         int? pFraction = null,
         string pMaskAmount = null,
         int? pFormatDate = null,
         int? pEmpAtType = null,
         DateTime? pEmpDate = null,
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
         int? pDiscountMax = null,
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
         bool? pIsDeleted = null,
         int? pCreatedBy = null,
         DateTime? pCreatedOn = null,
         int? pLastUpdatedBy = null,
         DateTime? pLastUpdatedOn = null,
         int? pLanguageId = null,
         string MailHost = null,
            string MailPassword = null,
            string MailPort = null,
            string MailSubject = null,
            string MailBody = null,
            string MailFrom = null,
            string MailTo = null,
            string IBAN = null,
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
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("BranchSettingId", pBranchSettingId));
            vlstParam.Add(new SqlParameter("BranchSettingCode", pBranchSettingCode));
            vlstParam.Add(new SqlParameter("BranchDesc", pBranchDesc));
            vlstParam.Add(new SqlParameter("BranchDescL", pBranchDescL));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("Fraction", pFraction));
            vlstParam.Add(new SqlParameter("MaskAmount", pMaskAmount));
            vlstParam.Add(new SqlParameter("FormatDate", pFormatDate));
            vlstParam.Add(new SqlParameter("EmpAtType", pEmpAtType));
            vlstParam.Add(new SqlParameter("EmpDate", pEmpDate));
            vlstParam.Add(new SqlParameter("PlateCode", pPlateCode));
            vlstParam.Add(new SqlParameter("DesFormat", pDesFormat));
            vlstParam.Add(new SqlParameter("DesName", pDesName));
            vlstParam.Add(new SqlParameter("DesType", pDesType));
            vlstParam.Add(new SqlParameter("ReportServer", pReportServer));
            vlstParam.Add(new SqlParameter("Rrovirtualdir", pRrovirtualdir));
            vlstParam.Add(new SqlParameter("ReportsINTerface", pReportsINTerface));
            vlstParam.Add(new SqlParameter("Hostname", pHostname));
            vlstParam.Add(new SqlParameter("Virtualdir", pVirtualdir));
            vlstParam.Add(new SqlParameter("Physicaldir", pPhysicaldir));
            vlstParam.Add(new SqlParameter("Useorarrp", pUseorarrp));
            vlstParam.Add(new SqlParameter("Usequeuetables", pUsequeuetables));
            vlstParam.Add(new SqlParameter("RepExtINTion", pRepExtINTion));
            vlstParam.Add(new SqlParameter("DefaultLocation", pDefaultLocation));
            vlstParam.Add(new SqlParameter("ImgPath", pImgPath));
            vlstParam.Add(new SqlParameter("PlateStore", pPlateStore));
            vlstParam.Add(new SqlParameter("PlateUnit", pPlateUnit));
            vlstParam.Add(new SqlParameter("SellStore", pSellStore));
            vlstParam.Add(new SqlParameter("PcDetectionType", pPcDetectionType));
            vlstParam.Add(new SqlParameter("HoldInvTimer", pHoldInvTimer));
            vlstParam.Add(new SqlParameter("InsuranceLimit", pInsuranceLimit));
            vlstParam.Add(new SqlParameter("InvoiceRemark", pInvoiceRemark));
            vlstParam.Add(new SqlParameter("OrderRemark", pOrderRemark));
            vlstParam.Add(new SqlParameter("KitchenPrINTer", pKitchenPrINTer));
            vlstParam.Add(new SqlParameter("FontPath", pFontPath));
            vlstParam.Add(new SqlParameter("BranchPhone", pBranchPhone));
            vlstParam.Add(new SqlParameter("SheepCat", pSheepCat));
            vlstParam.Add(new SqlParameter("AllowSwithoutcprINTers", pAllowSwithoutcprINTers));
            vlstParam.Add(new SqlParameter("LocationImgPath", pLocationImgPath));
            vlstParam.Add(new SqlParameter("FoodPrepareCat", pFoodPrepareCat));
            vlstParam.Add(new SqlParameter("CashCode", pCashCode));
            vlstParam.Add(new SqlParameter("ShowRefItem", pShowRefItem));
            vlstParam.Add(new SqlParameter("ShowRefProduct", pShowRefProduct));
            vlstParam.Add(new SqlParameter("CustAcc", pCustAcc));
            vlstParam.Add(new SqlParameter("RecevAcc", pRecevAcc));
            vlstParam.Add(new SqlParameter("CostCenter", pCostCenter));
            vlstParam.Add(new SqlParameter("BounsAccount", pBounsAccount));
            vlstParam.Add(new SqlParameter("LaterAccounts", pLaterAccounts));
            vlstParam.Add(new SqlParameter("VPosCaneclAcc", pVPosCaneclAcc));
            vlstParam.Add(new SqlParameter("RentAccounts", pRentAccounts));
            vlstParam.Add(new SqlParameter("DriverSeq", pDriverSeq));
            vlstParam.Add(new SqlParameter("KitchenStore", pKitchenStore));
            vlstParam.Add(new SqlParameter("SheepCatProduct", pSheepCatProduct));
            vlstParam.Add(new SqlParameter("SheepOutRes", pSheepOutRes));
            vlstParam.Add(new SqlParameter("SellAcc", pSellAcc));
            vlstParam.Add(new SqlParameter("InsurAcc", pInsurAcc));
            vlstParam.Add(new SqlParameter("RentAcc", pRentAcc));
            vlstParam.Add(new SqlParameter("ShowQty", pShowQty));
            vlstParam.Add(new SqlParameter("SubSeqInv", pSubSeqInv));
            vlstParam.Add(new SqlParameter("BranchMgr", pBranchMgr));
            vlstParam.Add(new SqlParameter("ReservType", pReservType));
            vlstParam.Add(new SqlParameter("DeliveryTrans", pDeliveryTrans));
            vlstParam.Add(new SqlParameter("AllowBlkList", pAllowBlkList));
            vlstParam.Add(new SqlParameter("ItemDelivery", pItemDelivery));
            vlstParam.Add(new SqlParameter("AllowCancelInvoice", pAllowCancelInvoice));
            vlstParam.Add(new SqlParameter("GrpAddPlate", pGrpAddPlate));
            vlstParam.Add(new SqlParameter("QtyPlateRice", pQtyPlateRice));
            vlstParam.Add(new SqlParameter("RiceCat", pRiceCat));
            vlstParam.Add(new SqlParameter("ShowQtyZero", pShowQtyZero));
            vlstParam.Add(new SqlParameter("OrderEmp", pOrderEmp));
            vlstParam.Add(new SqlParameter("OrderPhone", pOrderPhone));
            vlstParam.Add(new SqlParameter("BranchPhoneOrder", pBranchPhoneOrder));
            vlstParam.Add(new SqlParameter("BranchAddress", pBranchAddress));
            vlstParam.Add(new SqlParameter("DefaultProdCost", pDefaultProdCost));
            vlstParam.Add(new SqlParameter("SubSeqOrder", pSubSeqOrder));
            vlstParam.Add(new SqlParameter("DecreaseProdAuto", pDecreaseProdAuto));
            vlstParam.Add(new SqlParameter("CommAccount", pCommAccount));
            vlstParam.Add(new SqlParameter("ShortNum", pShortNum));
            vlstParam.Add(new SqlParameter("NewOrderTime", pNewOrderTime));
            vlstParam.Add(new SqlParameter("DeliveryCashier", pDeliveryCashier));
            vlstParam.Add(new SqlParameter("PayCashierAmount", pPayCashierAmount));
            vlstParam.Add(new SqlParameter("AssemblingPrINTer", pAssemblingPrINTer));
            vlstParam.Add(new SqlParameter("DefaultLocationDelivery", pDefaultLocationDelivery));
            vlstParam.Add(new SqlParameter("ModifyInvoice", pModifyInvoice));
            vlstParam.Add(new SqlParameter("PrINTCancelInvoice", pPrINTCancelInvoice));
            vlstParam.Add(new SqlParameter("DisplayDirverAccount", pDisplayDirverAccount));
            vlstParam.Add(new SqlParameter("DisplayUpdateDirver", pDisplayUpdateDirver));
            vlstParam.Add(new SqlParameter("PrINTUpdateInvoice", pPrINTUpdateInvoice));
            vlstParam.Add(new SqlParameter("LimitInvId", pLimitInvId));
            vlstParam.Add(new SqlParameter("PrINTBasicInvId", pPrINTBasicInvId));
            vlstParam.Add(new SqlParameter("AutoOpenPeriod", pAutoOpenPeriod));
            vlstParam.Add(new SqlParameter("AutoClosePeriod", pAutoClosePeriod));
            vlstParam.Add(new SqlParameter("LengthPeriodDay", pLengthPeriodDay));
            vlstParam.Add(new SqlParameter("CompIdPost", pCompIdPost));
            vlstParam.Add(new SqlParameter("UpdateInvoiceDriver", pUpdateInvoiceDriver));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForCancel", pShowAllInvoiceForCancel));
            vlstParam.Add(new SqlParameter("ShowAllInvoiceForUpdate", pShowAllInvoiceForUpdate));
            vlstParam.Add(new SqlParameter("ChangeUpdateDate", pChangeUpdateDate));
            vlstParam.Add(new SqlParameter("ManualProduction", pManualProduction));
            vlstParam.Add(new SqlParameter("ChangeUpdateCashier", pChangeUpdateCashier));
            vlstParam.Add(new SqlParameter("DiscountMax", pDiscountMax));
            vlstParam.Add(new SqlParameter("EnterHelfoodAllowed", pEnterHelfoodAllowed));
            vlstParam.Add(new SqlParameter("EnterPartbuildAllowed", pEnterPartbuildAllowed));
            vlstParam.Add(new SqlParameter("AllowDiscount", pAllowDiscount));
            vlstParam.Add(new SqlParameter("ConvertProductionFullQty", pConvertProductionFullQty));
            vlstParam.Add(new SqlParameter("CloseFormUpdateAuto", pCloseFormUpdateAuto));
            vlstParam.Add(new SqlParameter("StoreBasic", pStoreBasic));
            vlstParam.Add(new SqlParameter("ProductTypeOut", pProductTypeOut));
            vlstParam.Add(new SqlParameter("AssemblingPost", pAssemblingPost));
            vlstParam.Add(new SqlParameter("ClientStoreId", pClientStoreId));
            vlstParam.Add(new SqlParameter("BranchAccount", pBranchAccount));
            vlstParam.Add(new SqlParameter("EmpCostId", pEmpCostId));
            vlstParam.Add(new SqlParameter("StoreProduction", pStoreProduction));
            vlstParam.Add(new SqlParameter("ChoiceStoreProdAuto", pChoiceStoreProdAuto));
            vlstParam.Add(new SqlParameter("AddQyProductbeforeSpend", pAddQyProductbeforeSpend));
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("IsVat", pIsVat));
            vlstParam.Add(new SqlParameter("VatCode", pVatCode));
            vlstParam.Add(new SqlParameter("VatPerc", pVatPerc));
            vlstParam.Add(new SqlParameter("RoundLowerHalf", pRoundLowerHalf));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("MailHost", MailHost));
            vlstParam.Add(new SqlParameter("MailPassword", MailPassword));
            vlstParam.Add(new SqlParameter("MailPort", MailPort));
            vlstParam.Add(new SqlParameter("MailSubject", MailSubject));
            vlstParam.Add(new SqlParameter("MailBody", MailBody));
            vlstParam.Add(new SqlParameter("MailFrom", MailFrom));
            vlstParam.Add(new SqlParameter("MailTo", MailTo));
            vlstParam.Add(new SqlParameter("IBAN", IBAN));
            vlstParam.Add(new SqlParameter("BOX_ID", BOX_ID));
            vlstParam.Add(new SqlParameter("CostID", CostID));
            vlstParam.Add(new SqlParameter("VatAccount", VatAccount));
            vlstParam.Add(new SqlParameter("TotalAccount", TotalAccount));
            vlstParam.Add(new SqlParameter("InsuranceAccount", InsuranceAccount));
            vlstParam.Add(new SqlParameter("ReturnAccount", ReturnAccount));
            vlstParam.Add(new SqlParameter("NumberReports", NumberReports));
            vlstParam.Add(new SqlParameter("MadaPerc", MadaPerc));
            vlstParam.Add(new SqlParameter("VisaPerc", VisaPerc));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            clsADO_ForHangFire clsADO_ForHangFire = new clsADO_ForHangFire();
            vData = clsADO_ForHangFire.funFillDataTable("RES.spBranchSettingCRUD", vlstParam, "Data GET");
            return vData;
        }


        public DataTable ZatacaAuto(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 400
           , string pZatcaResponse = null, bool? pIsPassed = true, DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pBranchId = null, string pInvCode = null)
        {
            // Declaration 
            //DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("orderId", pOrderId));
            vlstParam.Add(new SqlParameter("InvCode", pInvCode));
            vlstParam.Add(new SqlParameter("IsPassed", pIsPassed ?? true));
            vlstParam.Add(new SqlParameter("ZatcaResponse", pZatcaResponse));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            // vData = _clsADO.funFillDataTable("RES.spInvoiceOrderOrPOS", vlstParam, "Data GET");
            // return vData;
            clsADO_ForHangFire clsADO_ForHangFire = new clsADO_ForHangFire();

            return clsADO_ForHangFire.funFillDataTable("RES.spZatacaAuto", vlstParam, "Data GET");

        }

        public DataTable funInvItemGET(
                    int? pInvId = null,
                    string phNumbers = null)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", 400));
            clsADO_ForHangFire clsADO_ForHangFire = new clsADO_ForHangFire();

            vData = clsADO_ForHangFire.funFillDataTable("RES.InvoicePOS", vlstParam, "Data GET");
            return vData;
        }

        private string getProcName_spInvoiceOrderOrPOS => "RES.spInvoiceOrderOrPOS";
        public object funInvoiceOrderOrPOS(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 400
           , string pZatcaResponse = null, bool? pIsPassed = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pInvType = null, int? pBranchId = null, string pInvCode = null)
        {
            // Declaration 
            //DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = SetParam_spInvoiceOrderOrPOS(pInvId: pInvId, pOrderId: pOrderId, pInvCode: pInvCode,
                pIsPassed: pIsPassed, pZatcaResponse: pZatcaResponse, pDateFrom: pDateFrom, pDateTo: pDateTo, pInvType: pInvType
                , pBranchId: pBranchId, pQueryTypeId: pQueryTypeId);

            // vData = _clsADO.funFillDataTable("RES.spInvoiceOrderOrPOS", vlstParam, "Data GET");
            // return vData;
            clsADO_ForHangFire clsADO_ForHangFire = new clsADO_ForHangFire();

            return clsADO_ForHangFire.funExecuteScalar(getProcName_spInvoiceOrderOrPOS, vlstParam, "Data GET");

        }

        private List<SqlParameter> SetParam_spInvoiceOrderOrPOS(int? pInvId = null, int? pOrderId = null, int pQueryTypeId = 400
         , string pZatcaResponse = null, bool? pIsPassed = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pInvType = null, int? pBranchId = null, string pInvCode = null)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("orderId", pOrderId));
            vlstParam.Add(new SqlParameter("InvCode", pInvCode));
            vlstParam.Add(new SqlParameter("IsPassed", pIsPassed));
            vlstParam.Add(new SqlParameter("ZatcaResponse", pZatcaResponse));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            return vlstParam;
        }





        public DataTable funResOrderReport(int? id = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("orderId", id));
            clsADO_ForHangFire clsADO_ForHangFire = new clsADO_ForHangFire();

            vData = clsADO_ForHangFire.funFillDataTable("RES.spResOrderReport", vlstParam, "Data GET");


            return vData;
        }

        #endregion db



        #region Zatca_Class

        // دالة إعادة ارسال الفاتورة الى الهيئة للموافقة عليها
        public Tuple<bool, string> ResendInvoice(int pInvId, int? pOrderId)
        {
            bool SuccessStatus = false;
            // نتحقق من الفاتورة انه تم مصادقتها
            var json = funInvoiceOrderOrPOS(pInvId: pInvId, pQueryTypeId: 401).ToString();
            if (string.IsNullOrWhiteSpace(json) || json.Trim().Length < 1)
                //return SystemMessageCode.ToJSON(SystemMessageCode.GetError("لا يوجد فاتورة بهذا الرقم"));
                return Tuple.Create(SuccessStatus, "لا يوجد فاتورة بهذا الرقم");
            var dtInv = JsonConvert.DeserializeObject<DataTable>(json);
            DateTime invDate = Convert.ToDateTime(dtInv.Rows[0].Field<DateTime>("InvDate").ToString());
            if (invDate > DateTime.Now.AddMinutes(-2))
                return Tuple.Create(SuccessStatus, "انتظر دقيقتين ثم أعد إرسالها لإنها فاتورة جديدة");

            bool isPassed = Convert.ToBoolean(dtInv.Rows[0].Field<bool>("IsPassed").ToString());
            if (isPassed == false)
            {
                InvoiceResponseDto dto = new InvoiceResponseDto();
                if (pOrderId != null && pOrderId > 0)
                    dto = SendToZatcaOrder((int)pOrderId);
                else
                {
                    DataTable dt = GetInvoicePOSData(pInvId);
                    dto = _SendToZatcaPOS(pInvId, dt);
                }
                if (dto.isSuccess)
                    return Tuple.Create(true, "تمت الإعادة بنجاح");
                else
                    return Tuple.Create(SuccessStatus, "فشلت العملية");
            }
            else
                return Tuple.Create(true, "تم إجتياز الفاتورة مسبقا");

        }


        #region Send Invoice POS To Zatca
        private DataTable GetInvoicePOSData(int InvId)
        {
            DataTable Data = funInvItemGET(InvId, null);
            return Data;
        }

        public void SendToZatcaPOS(DataTable dataTable)
        {
            //Task.Run(async()=> await Task.Delay(120000));
            int InvId = Convert.ToInt32(dataTable.Rows[0].Field<int>("InvId").ToString());
            _SendToZatcaPOS(InvId, dataTable);

        }
        private InvoiceResponseDto _SendToZatcaPOS(int InvId, DataTable dataTable)
        {
            var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            InvoiceCreateRequest obj = SetZatcaInvoicePOSValues(dataTable);
            InvoiceResponseDto dto = SendInvoice(TokenDb, obj);
            string responseJson = string.Empty;
            if (dto.isSuccess)
            {
                responseJson = JsonConvert.SerializeObject(dto);
                //responseJson = JsonConvert.SerializeObject(dto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                PassedInvoicePOS(InvId, responseJson);
            }
            SendInvoiceToZatcaLog(obj.invoice_pk, dto);
            return dto;
        }
        void PassedInvoicePOS(int InvId, string responseJson, bool isPassed = true)
        {
            // تعديل الموافقة على الفاتورة وإجتيازها
            // تعديل حالة موافقة الضرائب للفاتورة عندنا
            var dt = funInvoiceOrderOrPOS(pInvId: InvId, pQueryTypeId: 200, pZatcaResponse: responseJson, pIsPassed: isPassed);
        }
        InvoiceCreateRequest SetZatcaInvoicePOSValues(DataTable dataTable)
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
                // فاتورة كاشير فقط إرسال الاصناف للضريبة بدون التأمين والاضافات
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

            //itemlst.Add(
            //        new InvoiceItem()
            //        {
            //            name = "جريش مجاني",
            //            price = "0",
            //            quantity = "1"
            //        });

            //var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            var InvCode = dataTable.Rows[0].Field<string>("InvCode").ToString();
            var account_id = dataTable.Rows[0].Field<string>("account_id").ToString();
            var Discount = dataTable.Rows[0].Field<double>("DiscountBeforeVAT").ToString();

            if (!String.IsNullOrEmpty(tax_number) && !String.IsNullOrEmpty(organization))
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn), //invoice, credit, debit
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
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn),
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

        #region Send Invoice Order To Zatca

        public InvoiceResponseDto SendToZatcaOrder(int OrderId)
        {
            DataTable dt = GetInvoiceOrderData(OrderId);
            return _SendToZatcaOrder(OrderId, dt);
        }
        //public void SendToZatcaOrder(DataTable dataTable)
        //{
        //    //Task.Run(async()=> await Task.Delay(120000));
        //    int OrderId = Convert.ToInt32(dataTable.Rows[0].Field<int>("OrderId").ToString());
        //    _SendToZatcaOrder(OrderId,dataTable);
        //}
        private DataTable GetInvoiceOrderData(int OrderId)
        {
            DataTable Data = funResOrderReport(OrderId);
            return Data;
        }
        private InvoiceResponseDto _SendToZatcaOrder(int OrderId, DataTable dataTable)
        {
            var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            InvoiceCreateRequest obj = SetZatcaInvoiceOrderValues(dataTable);
            InvoiceResponseDto dto = SendInvoice(TokenDb, obj);
            string responseJson = string.Empty;
            if (dto.isSuccess)
            {
                responseJson = JsonConvert.SerializeObject(dto);
                //responseJson = JsonConvert.SerializeObject(dto, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                PassedInvoiceOrder(OrderId, responseJson);
            }
            SendInvoiceToZatcaLog(obj.invoice_pk, dto);
            return dto;
        }
        InvoiceCreateRequest SetZatcaInvoiceOrderValues(DataTable dataTable)
        {
            InvoiceCreateRequest obj = new InvoiceCreateRequest();
            List<InvoiceItem> itemlst = new List<InvoiceItem>() { };
            string organization = dataTable.Rows[0].Field<string>("organization").ToString();
            string tax_number = dataTable.Rows[0].Field<string>("tax_number").ToString();
            string IsReturn = "false";
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
                // فاتورة طلب فقط إرسال الاصناف للضريبة بدون التأمين
                if (item["CategoryId"].ToString() != item["PlateCode"].ToString())
                {
                    itemlst.Add(
                     new InvoiceItem()
                     {
                         name = item["InvItemNameL1"].ToString(),
                         price = item["PRICEPro"].ToString(),
                         quantity = item["QTY"].ToString()
                     }
                    );
                }

            }

            //var TokenDb = dataTable.Rows[0].Field<string>("LinkProApi").ToString();
            var InvCode = dataTable.Rows[0].Field<string>("InvCode").ToString();
            var account_id = dataTable.Rows[0].Field<string>("account_id").ToString();
            var Discount = dataTable.Rows[0].Field<double>("DiscountBeforeVAT").ToString();
            if (!String.IsNullOrEmpty(tax_number) && !String.IsNullOrEmpty(organization))
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn), //"invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,
                    customer = customerLinkPro


                };
            }
            else
            {
                obj = new InvoiceCreateRequest()
                {
                    account_id = account_id,
                    invoice_code = InvoiceCode.InvoiceCodeType(IsReturn),//"invoice",
                    invoice_pk = InvCode,
                    payment_method = "10",
                    discount_amount = Discount,
                    items = itemlst,

                };
            }
            return obj;
        }
        void PassedInvoiceOrder(int OrderId, string responseJson, bool isPassed = true)
        {
            // تعديل حالة موافقة الضرائب للفاتورة عندنا
            var dt = funInvoiceOrderOrPOS(pOrderId: OrderId, pQueryTypeId: 201, pZatcaResponse: responseJson, pIsPassed: isPassed);
        }
        #endregion

       
        // async Task<InvoiceResponseDto> SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        InvoiceResponseDto SendInvoice(string TokenDb, InvoiceCreateRequest obj)
        {
            try
            {
                //await Task.Delay(120000); // تأخير دقيقتين
                // await Task.Delay(60000); // تأخير دقيقة
                if (obj.items.Count > 0)
                {
                    //IZatcaEInvoice _api = new ZatcaEInvoiceAPI();
                    var result = Task.Run(() => SendInvoiceApi(TokenDb, obj));
                    InvoiceResponseDto invoiceResponseDto = result.Result;
                    if (string.IsNullOrWhiteSpace(invoiceResponseDto.status) == false)
                        invoiceResponseDto.status = invoiceResponseDto.status.ToLower();
                    invoiceResponseDto.isSuccess = false;
                    if (invoiceResponseDto != null && (invoiceResponseDto.statusCode == "200" || invoiceResponseDto.statusCode == "201" || invoiceResponseDto.statusCode == "202")
                        && invoiceResponseDto.qrcode != null && string.IsNullOrWhiteSpace(invoiceResponseDto.qrcode) == false
                        && string.IsNullOrWhiteSpace(invoiceResponseDto.status) != true && invoiceResponseDto.status != "rejected" && invoiceResponseDto.status != "error" && invoiceResponseDto.status != "failed")
                        invoiceResponseDto.isSuccess = true; // (passed - passed with warnings - rejected) - failed

                    return invoiceResponseDto;
                }
                else
                {
                    var invoiceResponseDto = new InvoiceResponseDto() { isSuccess = false, note = " items.Count = 0", statusCode = "error user" };
                    return invoiceResponseDto;
                }

            }
            catch (Exception ex)
            {
                var invoiceResponseDto = new InvoiceResponseDto() { isSuccess = false, note = ex.Message, statusCode = "Exception" };
                SendInvoiceToZatcaLog(obj.invoice_pk, invoiceResponseDto);
                throw new AggregateException(ex);
            }
        }

        #region Send the invoice to the Zatca Log
        void SendInvoiceToZatcaLog(string invoice_pk, InvoiceResponseDto dto)
        {
            try
            {
                string responseJson = JsonConvert.SerializeObject(dto);
                string pathDirectory = string.Format(@"{0}\{1}\{2}\{3}", AppDomain.CurrentDomain.BaseDirectory, "WhiteCloud", "Log User File", "SendInvoiceToZatca");
                string fileName = string.Format("{0}_{1}.txt", "SendToZatca", DateTime.Now.ToString("dd-MM-yyyy"));
                string filePath = string.Format(@"{0}\{1}", pathDirectory, fileName);

                if (Directory.Exists(pathDirectory) == false)
                    Directory.CreateDirectory(pathDirectory);
                if (File.Exists(filePath) == false)
                    File.CreateText(filePath).Dispose();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("== Send Invoice To Zatca : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                sb.AppendLine("invoice_pk = " + invoice_pk + " , status = " + dto.status + " , isSuccess = " + dto.isSuccess + " , statusCode = " + dto.statusCode + " .");
                sb.AppendLine("Response : " + responseJson + " .");
                sb.AppendLine("======================================================================================");

                using (StreamWriter write = new StreamWriter(filePath, true)) //using (StreamWriter w = File.AppendText(filePath))
                {
                    write.Write(sb.ToString());
                    write.Flush();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        private async Task<HttpResponseMessage> post(string TokenDb, InvoiceCreateRequest entity)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
            HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
            string s = response.StatusCode.ToString();
            // التحقق من نجاح الاستجابة
            //response.EnsureSuccessStatusCode(); // التحقق من نجاح الاستجابة يشير إلى نجاح الطلب أم لا إذا كان لا ستقوم بإلقاء استثناء 
            /*
                وظيفة الدالة EnsureSuccessStatusCode() في فئة HttpResponseMessage هي التحقق مما إذا كان 
                رمز حالة الاستجابة (status code) يشير إلى نجاح الطلب أم لا. إذا كان رمز حالة الاستجابة يشير إلى نجاح (2xx)، فإن الدالة لا تفعل شيئًا وتعود بدون أي استثناء.
                ومع ذلك، إذا كان رمز حالة الاستجابة يشير إلى خطأ (3xx, 4xx, 5xx)، فإن الدالة ستقوم بإلقاء استثناء من 
                نوع HttpRequestException وستتضمن تفاصيل حول الخطأ.
             */
            return response;
        }
        //public async Task<InvoiceResponseDto> SendInvoice(InvoiceCreateRequest entity)
        public async Task<InvoiceResponseDto> SendInvoiceApi(string TokenDb, InvoiceCreateRequest entity)
        {
            InvoiceResponseDto result = new InvoiceResponseDto();
            if (CheckInternetConnection() == false)
            {
                result.isSuccess = false;
                result.statusCode = "800";
                result.status = "Not Internet";
                result.note = "لا يوجد اتصال بالإنترنت";
                return result;
            }
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
                //HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
                HttpResponseMessage response = await post(TokenDb, entity);
                //response.EnsureSuccessStatusCode(); // التحقق من نجاح الاستجابة يشير إلى نجاح الطلب أم لا إذا كان لا ستقوم بإلقاء استثناء            
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<InvoiceResponseDto>();
                }
                result.statusCode = ((int)response.StatusCode).ToString();
                return result;
            }
            catch (Exception)
            {
                result.statusCode = "900";
                result.status = "Exception";
                return result;
                //throw new ArgumentException("");
            }
        }

        public async Task<string> SendInvoiceStr(string TokenDb, InvoiceCreateRequest entity)
        {
            string result = null;
            try
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", TokenDb);
                //HttpResponseMessage response = await client.PostAsJsonAsync("invoices/", entity);
                HttpResponseMessage response = await post(TokenDb, entity);
                //response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                result += ";=;" + ((int)response.StatusCode).ToString();
                return result;
            }
            catch (Exception)
            {
                result = "900";
                return result;
                //throw new ArgumentException("");
            }
        }


        static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }

}