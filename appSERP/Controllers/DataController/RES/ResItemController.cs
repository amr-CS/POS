using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.dbCode.INV.Doc;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models;
using appSERP.Models.INV;
using appSERP.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class ResItemController : Controller
    {

        public List<InvItemModel> list = new List<InvItemModel>();
        private ILog _ILog;
        private IdbINVInvoice _dbINVInvoice;
        private IdbInvItem _dbInvItem;
        private IdbInvItemUnit _dbInvItemUnit;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public ResItemController(ILog log, IdbINVInvoice dbINVInvoice, IdbInvItem dbInvItem, IdbInvItemUnit dbInvItemUnit, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbINVInvoice = dbINVInvoice;
            _dbInvItem = dbInvItem;
            _dbInvItemUnit = dbInvItemUnit;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: ResItem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ResItems()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        [HttpGet]
        public void uploadImage(/*HttpPostedFileBase pFile = null*/)
        {
            // User Image
            //    if (pFile != null)
            //   {
            //clsFileSave.funFileSave(pFile, "/Image/DataImage/GD", null);
            //    }
        }
        public ActionResult ResMeal()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult Item()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult ItemHead(int pItemType)
        {
            ViewBag.ItemType = pItemType;
            int BranchId = 0;
            if (Request.Cookies["BranchId"] != null)
            { BranchId =Convert.ToInt32( Request.Cookies["BranchId"].Value); };
            // Result
            DataTable vDtData = _dbInvItem.funGetItems(BranchId:BranchId,pItemType: pItemType, pQueryTypeId: 500);
            string[] Columns = {"InvItemId", "InvItemCode", "InvItemNameL1", "InvItemNameL2",
        "ItemImage", "SequenceByCategory", "GRPId", "GroupCode", "GroupName", "CategoryId","CategoryCode", "CategoryName", "StoreId", "StoreCode", "StoreName", "OrderLimit", "PrinterCode", "PrinterId", "PrinterName", "ItemSales", "DetailGroup", "InvItemIsActive"};
            DataTable ItemTable = _dbInvItem.GetDistinctRecords(vDtData, Columns);
            //var ItemHead = vDtData.AsEnumerable().Select(x => new {
            //    InvItemId = x["InvItemId"],
            //    InvItemCode = x["InvItemCode"],
            //    InvItemNameL1 = x["InvItemNameL1"],
            //    InvItemNameL2 = x["InvItemNameL2"],
            //    ItemImage = x["ItemImage"],
            //    SequenceByCategory = x["SequenceByCategory"],
            //    GRPId = x["GRPId"],
            //    GroupCode = x["GroupCode"],
            //    GroupName = x["GroupName"],
            //    CategoryId = x["CategoryId"],
            //    CategoryCode = x["CategoryCode"],
            //    CategoryName = x["CategoryName"],
            //    StoreId = x["StoreId"],
            //    StoreCode = x["StoreCode"],
            //    StoreName = x["StoreName"],
            //    OrderLimit = x["OrderLimit"],
            //    PrinterCode = x["PrinterCode"],
            //    PrinterId = x["PrinterId"],
            //    PrinterName = x["PrinterName"],
            //    ItemSales = x["ItemSales"],
            //    DetailGroup = x["DetailGroup"],
            //    InvItemIsActive = x["InvItemIsActive"],
            //}).ToList().Distinct();
            //foreach (var item in ItemHead)
            //{
            //    InvItemModel itemModel = new InvItemModel();
            //    itemModel.InvItemId = dbInvItem.ToNullableInt(item.InvItemId.ToString());
            //    itemModel.InvItemCode = item.InvItemCode.ToString();
            //    itemModel.InvItemNameL1 =item.InvItemNameL1.ToString();
            //    itemModel.InvItemNameL2 =item.InvItemNameL2.ToString();
            //    itemModel.ItemImage = item.ItemImage.ToString();
            //    itemModel.SequenceByCategory = dbInvItem.ToNullableInt(item.SequenceByCategory.ToString());
            //    itemModel.GRPId = dbInvItem.ToNullableInt(item.GRPId.ToString());
            //    itemModel.CategoryId = dbInvItem.ToNullableInt(item.CategoryId.ToString());
            //    itemModel.GroupCode = item.GroupCode.ToString();
            //    itemModel.GroupName = item.GroupName.ToString();
            //    itemModel.CategoryCode = item.CategoryCode.ToString();
            //    itemModel.CategoryName = item.CategoryName.ToString();
            //    itemModel.StoreId = dbInvItem.ToNullableInt(item.StoreId.ToString());
            //    itemModel.StoreCode = item.StoreCode.ToString();
            //    itemModel.StoreName = item.StoreName.ToString();
            //    itemModel.PrinterCode = item.PrinterCode.ToString();
            //    itemModel.PrinterId = dbInvItem.ToNullableInt(item.PrinterId.ToString());
            //    itemModel.PrinterName = item.PrinterName.ToString();
            //    itemModel.DetailGroup = dbInvItem.ToNullableInt(item.DetailGroup.ToString());
            //    if (item.OrderLimit.ToString() != "")
            //    {
            //        itemModel.OrderLimit = Convert.ToDecimal(item.OrderLimit.ToString());
            //    }
            //    itemModel.ItemSales = dbInvItem.ToNullableInt(item.ItemSales.ToString());

            //        itemModel.InvItemIsActive =item.InvItemIsActive.ToString();

            //    list.Add(itemModel);
            //}


            // Result
            // dbInvItemUnit.vDtDataUnit = dbInvItem.funGetItems(pQueryTypeId: 501);
            //dbInvItemUnit.vDtDataContent = dbInvItem.funGetItems(pQueryTypeId: 502);
            //dbInvItemUnit.vDtDataItemPrice = dbInvItem.funGetItems(pQueryTypeId: 503);
            //dbInvItemUnit.vDtDataItemPrice = dbInvItem.funGetItems(pQueryTypeId: 504);
            return PartialView(vDtData);
        }
        [HttpGet]
        public ActionResult ItemUnit(int ItemId)
        {
            //dbInvItemUnit.vDtDataUnit = dbInvItem.funGetItems(pQueryTypeId: 501);

            DataView dv = new DataView(_dbInvItemUnit.vDtDataUnit);
            if (dv != null)
            {
                dv.RowFilter = "ItemId=" + ItemId;
            }
            dv.RowFilter = "ItemId=" + ItemId;
            DataTable DtData = dv.ToTable();
            if (DtData == null)
            {
                ViewBag.Unitempty = true;
            }
            else
            {
                ViewBag.Unitempty = false;
            }
            return PartialView(DtData);
        }
        [HttpGet]
        public ActionResult ItemContent(int ItemId = 0)
        {
            DataView dv = new DataView(_dbInvItemUnit.vDtDataContent);
            if (dv != null)
            {
                dv.RowFilter = "ItemId=" + ItemId;
            }

            DataTable DtData = dv.ToTable();
            return PartialView(DtData);
        }
        [HttpGet]
        public ActionResult ItemAdd(int ItemId)
        {
            DataView dv = new DataView(_dbInvItemUnit.vDtDataItemPrice);
            dv.RowFilter = "ItemId=" + ItemId;
            DataTable DtData = dv.ToTable();
            return PartialView(DtData);
        }
        [HttpGet]
        public ActionResult ItemPrice(int UnitId)
        {
            DataView dv = new DataView(_dbInvItemUnit.vDtDataItemPrice);
            dv.RowFilter = "UnitId=" + UnitId;
            DataTable DtData = dv.ToTable();
            return PartialView(DtData);
        }
        public ActionResult CatAccountSearch()
        {
            return View();
        }
        public ActionResult CatAccountSearch_124()
        {
            return View();
        }
        public ActionResult CatAccountSearch_123()
        {
            return View();
        }
        public ActionResult CatProductSearch()
        {

            return View();
        }
        public ActionResult StoreSearch()
        {

            return View();
        }
        
        public ActionResult ContentSearch()
        {

            return View();
        }
        public ActionResult MealSearch()
        {

            return View();
        }
        public ActionResult UnitSearch(int pItemId)
        {
            ViewBag.vbItemId = pItemId;
            return View();
        }


        public ActionResult PriceCatSearch()
        {

            return View();
        }

        public ActionResult ItemSearch()
        {

            return View();
        }
        public ActionResult ContentItemSearch()
        {

            return View();
        }
        public ActionResult AddSearch()
        {

            return View();
        }

        public string funSavePrice(
        int? pPriceId = null,
        string pPriceCode = null,
        int? pItemId = null,
        int? pUnitId = null,
        int? pSellCostType = null,
        decimal? pPrice = null,
        int? pPriceCat = null,
        string pNotes = null,
        bool? pPriceIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APIInvItemsUnitsPrice/InvItemsUnitsPriceGet";
            // Praremeter
            string vParameters =
                            "?pPriceId=" + pPriceId +
                            "&pUnitId=" + pUnitId +
                            "&pPrice=" + pPrice +
                            "&pPriceCat=" + pPriceCat +
                            "&pPriceIsActive=" + pPriceIsActive +
                            "&pIsDeleted=" + pIsDeleted +
                            "&pQueryTypeId=" + pQueryTypeId;

            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }






        public string LookupGET(
      int? pLookupId = null,
      int? pLookupParentId = null,
      string pLookupCode = null,
      float? pLookupSeq = null,
      string pLookupDescL1 = null,
      string pLookupDescL2 = null,
      int? pParentId = null,
      int? pLookupGroup = null,
      bool? pLookupStatus = null,
      int? pHC = null,
      string pNotes = null,
      int? pUserPriv = null,
      int? pParentIdDtl = null,
      bool? pIsDeleted = null,
      int? pLookupDtlId = null,
      string pdLookupDtlCode = null,
      string pdLookupDtlDesc = null,
      string pdLookupDtlDescL = null,
      string pdLookupDtlDescShort = null,
      string pdLookupDtlDescShortL = null,
      string pdLookupDtlDesc2 = null,
      string pdLookupDtlDesc2L = null,
      float? pdLookupDtlSeq = null,
      float? pdTypeSeq = null,
      int? pdORD = null,
      bool? pdDflt = null,
      bool? pdLookupDtlStatus = null,
      string pdNotes = null,
      decimal? pdValue1 = null,
      decimal? pdValue2 = null,
      decimal? pdValue3 = null,
      int? pdValLink = null,
      string pdDate1 = null,
      string pdDate2 = null,
      string pdText = null,
      string pdAccountId = null,
      string pdAccountId2 = null,
      bool? pdIsDeleted = null,
      bool? pIsDetail = null,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APILookup/LookupGet";
            // Praremeter
            string vParameters =
           "?pLookupId=" + pLookupId +
            "&pLookupParentId=" + pLookupParentId +
            "&pLookupCode=" + pLookupCode +
            "&pLookupSeq=" + pLookupSeq +
            "&pLookupDescL1=" + pLookupDescL1 +
            "&pLookupDescL2=" + pLookupDescL2 +
            "&pParentId=" + pParentId +
            "&pLookupGroup=" + pLookupGroup +
            "&pLookupStatus=" + pLookupStatus +
            "&pHC=" + pHC +
            "&pNotes=" + pNotes +
            "&pUserPriv=" + pUserPriv +
            "&pParentIdDtl=" + pParentIdDtl +
            "&pIsDeleted=" + pIsDeleted +
            "&pLookupDtlId=" + pLookupDtlId +
            "&pdLookupDtlCode=" + pdLookupDtlCode +
            "&pdLookupDtlDesc=" + pdLookupDtlDesc +
            "&pdLookupDtlDescL=" + pdLookupDtlDescL +
            "&pdLookupDtlDescShort=" + pdLookupDtlDescShort +
            "&pdLookupDtlDescShortL=" + pdLookupDtlDescShortL +
            "&pdLookupDtlDesc2=" + pdLookupDtlDesc2 +
            "&pdLookupDtlDesc2L=" + pdLookupDtlDesc2L +
            "&pdLookupDtlSeq=" + pdLookupDtlSeq +
            "&pdTypeSeq=" + pdTypeSeq +
            "&pdORD=" + pdORD +
            "&pdDflt=" + pdDflt +
            "&pdLookupDtlStatus=" + pdLookupDtlStatus +
            "&pdNotes=" + pdNotes +
            "&pdValue1=" + pdValue1 +
            "&pdValue2=" + pdValue2 +
            "&pdValue3=" + pdValue3 +
            "&pdValLink=" + pdValLink +
            "&pdDate1=" + pdDate1 +
            "&pdDate2=" + pdDate2 +
            "&pdText=" + pdText +
            "&pdAccountId=" + pdAccountId +
            "&pdAccountId2=" + pdAccountId2 +
            "&pdIsDeleted=" + pdIsDeleted +
            "&pIsDetail=" + pIsDetail +
            "&pQueryTypeId=" + pQueryTypeId;

            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;


        }
        public string funSaveUnit(
        int? pInvItemUnitId = null,
        int? pUnitId = null,
        string pUnitCode = null,
        string pUnitNameL1 = null,
        string pUnitNameL2 = null,
        int? pUnitParentId = null,
        decimal? pUnitCost = null,
        float? pPartsInParents = null,
        decimal? pUnitPrice = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pPriceCurrency = null,
        int? pDefaultUnit = null,
        decimal? pUnitOrderLimit = null,
        int? pItemId = null,
        string pBarcode = null,
        bool? pIsDecreasable = null,
        bool? pSellUnit = null,
        bool? pUnitProduction = null,
        bool? pIsDefault = null,
        bool? pUnitIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APIINVItemUnit/InvItemUnitGET";
            // Praremeter
            string vParameters =
                                "?pInvItemUnitId=" + pInvItemUnitId +
                                "&pUnitId=" + pUnitId +
                                "&pPartsInParents=" + pPartsInParents +
                                "&pUnitParentId=" + pUnitParentId +
                                "&pItemId=" + pItemId +
                                "&pBarcode=" + pBarcode +
                                "&pIsDecreasable=" + pIsDecreasable +
                                "&pSellUnit=" + pSellUnit +
                                "&pUnitProduction=" + pUnitProduction +
                                "&pIsDefault=" + pIsDefault +
                                "&pUnitIsActive=" + pUnitIsActive +
                                "&pQueryTypeId=" + pQueryTypeId;

            // Result
            string vDtData = _clsAPI.funResultGetJSON(vPath + vParameters);

            // JSON
            //  vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vDtData;
        }



        public string funSaveItem(
        int? pInvItemId = null,
        string pInvItemCode = null,
        string pInvItemSymbol = null,
        string pInvItemBarCode = null,
        string pInvItemNameL1 = null,
        string pInvItemNameL2 = null,
        int? pCategoryId = null,
        bool? pHasEdate = null,
        bool? pFollowUp = null,
        string pSupCompany = null,
        decimal? pBonusLimit = null,
        decimal? pBonus = null,
        decimal? pDiscLimit = null,
        decimal? pDiscPerc = null,
        decimal? pOrderLimit = null,
        decimal? pItemMaxQuantity = null,
        decimal? pItemMinQuantity = null,
        DateTime? pLastBuy = null,
        DateTime? pLastSell = null,
        decimal? pItemLastCost = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pCollective = null,
        string pItemIdNo = null,
        int? pItemFactorId = null,
        int? pItemMeasurement = null,
        int? pCategoryMeasureId = null,
        DateTime? pProductDate = null,
        bool? pItemSales = null,
        int? pCategorySizes = null,
        int? pServiceItem = null,
        int? pGRPId = null,
        int? pStoreId = null,
        int? pPoints = null,
        bool? pIsDefault = null,
        bool? pDetailGroup = null,
        string pItemImage = null,
        int? pCatProduct = null,
        int? pCancel = null,
        int? pSequenceByCategory = null,
        bool? pIsVATApply = null,
        int? pItemType = null,
        bool? pInvItemIsActive = true,
        bool? pIsItemContent = null,
        int? pItemContentId = null,
        int? pItemId = null,
        int? pGrp_id = null,
        int? pCont_id = null,
        bool? pExp = null,
        decimal? pQty = null,
        int? pUnit_id = null,
        bool? pItem_con_status = null,
        int? pItem_avl_qty = null,
        bool? pMark_as_packing = null,
        decimal? pPrice = null,
        int? pItem_unit_id = null,
        decimal? pPrice_cat = null,
        // ItemAdd
        bool? pIsItemAdd = null,
        int? pItemAddId = null,
        int? pItemAddSeq = null,
        int? pAddOrder = null,
        int? pItemAddQty = null,
        decimal? pItemAddPrice = null,
        //
        bool? pIsDeleted = false,
         int? pQueryTypeId = clsQueryType.qSelect,
         int? pPrinterId = null,
        string pAccount=null
        
            )
        {
            int BranchId = 0;
            if (Request.Cookies["BranchId"] != null)
            { BranchId = Convert.ToInt32(Request.Cookies["BranchId"].Value); };
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APIInvItem/InvItemGET";
            // Praremeter
            string vParameters =
                            "?pInvItemId=" + pInvItemId +
                            "&BranchId=" + BranchId +
                            "&pInvItemNameL1=" + pInvItemNameL1 +
                            "&pInvItemCode=" + pInvItemCode +
                            "&pInvItemNameL2=" + pInvItemNameL2 +
                            "&pGRPId=" + pGRPId +
                            "&pCategoryId=" + pCategoryId +
                            "&pCatProduct=" + pCatProduct +
                            "&pOrderLimit=" + pOrderLimit +
                            "&pStoreId=" + pStoreId +
                            "&pPoints=" + pPoints +
                            "&pIsDefault=" + pIsDefault +
                            "&pDetailGroup=" + pDetailGroup +
                            "&pItemSales=" + pItemSales +
                            "&pSequenceByCategory=" + pSequenceByCategory +
                            "&pItemImage=" + pItemImage +

                            //
                            "&pIsItemContent=" + pIsItemContent +
                            "&pItemContentId=" + pItemContentId +
                            "&pCont_id=" + pCont_id +
                            "&pItemId=" + pItemId +
                            "&pExp=" + pExp +
                            "&pQty=" + pQty +
                            "&pUnit_id=" + pUnit_id +
                            "&pItem_con_status=" + pItem_con_status +
                            "&pPrice=" + pPrice +
                            // ItemId
                            "&pIsItemAdd=" + pIsItemAdd +
                            "&pItemAddId=" + pItemAddId +
                            "&pItemAddSeq=" + pItemAddSeq +
                            "&pAddOrder=" + pAddOrder +
                            "&pItemAddQty=" + pItemAddQty +
                            "&pItemAddPrice=" + pItemAddPrice +
                            //
                            "&pItemType=" + pItemType +
                            "&pInvItemIsActive=" + pInvItemIsActive +
                            "&pIsDeleted=" + pIsDeleted +
                             "&pPrinterId=" + pPrinterId +
                             "&pQueryTypeId=" + pQueryTypeId+
                             "&pAccount=" + pAccount;


            // Result
            string vDtData = _clsAPI.funResultGetJSON(vPath + vParameters);

            // JSON
            //vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vDtData;
        }
        [HttpPost]
        public JsonResult InsertItemBulk(ICollection<ItemUnit> Units, int ItemId)
        {
            // الصنف له عمليات سابقة ومن آجل لا تضرب التكلفة والكمية يمنع تعديل او حذف وحداته
            var dt = _dbINVInvoice.GetItemHasInvoice(ItemId);
            if (dt != null && dt.Rows.Count > 0)
            {
                string message = "الصنف له عمليات سابقة ومن آجل لا تضرب التكلفة والكمية يمنع تعديل او حذف وحداته";
                var dtItemUnits = _dbInvItemUnit.GetItemUnits(ItemId);
                if(dtItemUnits.Rows.Count != Units.Count)
                    return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError(message)));
                bool allowModification = true;
                foreach (DataRow item in dtItemUnits.Rows)
                {
                    int invItemUnitId = Convert.ToInt32(item["InvItemUnitId"].ToString());

                    int unitId = Convert.ToInt32(item["UnitId"].ToString());
                    double unitParentId = Convert.ToDouble(item["UnitParentId"].ToString());
                    double partsInParents = Convert.ToDouble(item["PartsInParents"].ToString());
                    var mdlLst = Units.Where(a => a.InvItemUnitId == invItemUnitId);
                    if (mdlLst.Any())
                    {
                        var mdl = mdlLst.FirstOrDefault();
                        if (mdl.UnitId != unitId || mdl.UnitParentId != unitParentId || mdl.PartsInParents != partsInParents)
                        {
                            allowModification = false;
                            break;
                        }
                    }
                    else
                    {
                        allowModification = false;
                        break;
                    }
                }
                if (allowModification==false)
                    return Json(SystemMessageCode.ToJSON(SystemMessageCode.GetError(message)));
            }

            /*
            var dtItemUnits = _dbInvItemUnit.GetItemUnits(ItemId);
            string message = "";
            foreach (DataRow item in dtItemUnits.Rows)
            {
                int invItemUnitId = Convert.ToInt32(item["InvItemUnitId"].ToString());                
                if (invItemUnitId > 0)
                {
                    int unitId = Convert.ToInt32(item["UnitId"].ToString());
                    double unitParentId = Convert.ToDouble(item["UnitParentId"].ToString());
                    double partsInParents = Convert.ToDouble(item["PartsInParents"].ToString());
                    var mdlLst = Units.Where(a => a.InvItemUnitId == invItemUnitId);
                    if (mdlLst.Any())
                    {
                        var mdl = mdlLst.FirstOrDefault();
                        if (mdl.UnitId != unitId || mdl.UnitParentId != unitParentId || mdl.PartsInParents != partsInParents)
                        {
                            var dt = _dbINVInvoice.GetItemHasInvoice(ItemId, unitId);
                            if (dt != null && dt.Rows.Count > 0)
                                message += mdl.UnitId + " للآسف لها فاتورة من سابق لا يمكن تعديل بياناتها \n";
                        }
                    }
                }
            }
            message = message.Trim();
            if (string.IsNullOrWhiteSpace(message) == false || message.Length>0)
                return Json(SystemMessageCode.ToJSON(SystemMessageCode.Get(message)));
            */

            var data = _dbINVInvoice.spItemBulk(Units, ItemId);
            return Json(data);
        }
        public void ShowSimple()
        {
            //int vCompany = Convert.ToInt32(Session["SCompany"]);
            DataTable DT = _dbInvItem.funGetResItemsReport();
            string vReportPath = Server.MapPath("~/Reports") + "//ResItemsReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }

        public ActionResult ResItemsReport(int? pCompanyId = null)
        {
            //ViewBag.vbCompanyId = pCompanyId;
            //Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }
        public ActionResult ResItemshtmlReport(
          DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbInvItem.funGetResItemsReport();
            if (vDT.Rows.Count > 0)
            {
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "تقرير المنتجات";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;

            }
            return View();
        }
        public ActionResult ItemshtmlReport(
    DateTime? pDateFrom = null, DateTime? pDateTo = null, int? pCashierId = null, int? branchId = null)
        {

            DataTable vDT = _dbInvItem.funGetItemsReport();
            if (vDT.Rows.Count > 0)
            {
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "تقرير الاصناف";
                ViewBag.DateTo = pDateTo;
                ViewBag.DateFrom = pDateFrom;

            }
            return View();
        }
        public void ShowItemSimple()
        {

            DataTable DT = _dbInvItem.funGetItemsReport();
            string vReportPath = Server.MapPath("~/Reports") + "//ItemsReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult ItemsReport(int? pCompanyId = null)
        {

            return View();
        }
        public void ShowMealSimple()
        {

            DataTable DT = _dbInvItem.funGetMealsReport();
            string vReportPath = Server.MapPath("~/Reports") + "//ResMealsReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult MealsReport(int? pCompanyId = null)
        {

            return View();
        }
        public ActionResult MealshtmlReport(int? pCompanyId = null)
        {
            DataTable vDT = _dbInvItem.funGetMealsReport();
            if (vDT.Rows.Count > 0)
            {
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "تقرير الوجبات";
            }
            return View();
        }
        public ActionResult MealCostReport(int? pCompanyId = null)
        {
            DataTable vDT = _dbInvItem.funGetMealsReport();
            if (vDT.Rows.Count > 0)
            {
                ViewBag.vDT = vDT;
                ViewBag.ReportName = "تقرير الوجبات مع التكلفة";
            }
            return View();
        }
        public void ShowItemsSimple()
        {

            DataTable DT = _dbInvItem.funGetMealsReport();
            string vReportPath = Server.MapPath("~/Reports") + "//ItemReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult ItemReport(int? pCompanyId = null)
        {

            return View();
        }

        public ActionResult PlateSearch()
        {
            DataTable PlateData = _dbInvItem.funGetItems(pQueryTypeId: 505);

            return View(PlateData);
        }
    }
}