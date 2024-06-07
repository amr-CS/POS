using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class ProductsQuantitiesController : Controller
    {
        private ILog _ILog;
        private IdbInvStoreItemQty _dbInvStoreItemQty;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public ProductsQuantitiesController(ILog log, IdbInvStoreItemQty dbInvStoreItemQty, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbInvStoreItemQty = dbInvStoreItemQty;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: ProductsQuantities
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        public string InvStoreItemQtyGET(int? pInvStoreItemQtyId = null, int? pStoreId = null, int? pItemId = null, DateTime? pExpireDate = null, float? pItemOpenQty = null, float? pItemQty = null, float? pItemReservedQty = null, string pNotes = null, string pUSERNAME = null, float? pItemOpenCost = null, int? pQueryTypeId = 400, int? pUnitId = null, int? pItemType = null)
        {
            string vPath = "/APIInvStoreItemQty/InvStoreItemQtyGET";
            string vParameters =
               "?pInvStoreItemQtyId=" + pInvStoreItemQtyId +
               "&pStoreId=" + pStoreId +
               "&pItemId=" + pItemId +
               "&pExpireDate=" + pExpireDate +
               "&pItemOpenQty=" + pItemOpenQty +
               "&pItemQty=" + pItemQty +
               "&pItemReservedQty=" + pItemReservedQty +
               "&pNotes=" + pNotes +
               "&pItemOpenCost=" + pItemOpenCost +
               "&pUnitId=" + pUnitId +
               "&pQueryTypeId=" + pQueryTypeId +
               "&pItemType=" + pItemType;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public string SearchStoreByCode(string pStoreCode = null)
        {
            string vPath = appAPIDirectory.vAPIStore;
            string vParameters =
                "?pStoreCode=" + pStoreCode +
                "&pQueryTypeId=" + 400;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public string SearchTypeByCode(string pTypeCode = null)
        {
            string vPath = appAPIDirectory.vAPICategoryAccount;
            string vParameters =
                "?pCategoryAccountCode=" + pTypeCode +
                "&pQueryTypeId=" + 400;
            //string vPath = "/APILookup/LookupGET";
            //string vParameters =
            //        "?pIsDetail=" + true +
            //   "&pLookupId=" + 120 +
            //   "&pdORD=" + pTypeCode +
            //    "&pQueryTypeId=" + @clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        //public string SearchProductByCode(string pInvItemCode = null)
        public string SearchProductByCode(int? pInvItemId = null)
        {


            string vPath = "/APIInvItem/InvItemGet";

            string pItemTypeList = "1,2";

            //string vParameters =
            //    "?pInvItemCodeSearch=" + pInvItemCode +
            //"&pItemType=1" +
            //"&pQueryTypeId=" + 400;

            // string vParameters =
            //    "?pInvItemCode=" + pInvItemCode +
            //"&pItemTypeList=" + pItemTypeList +
            //"&pQueryTypeId=" + 400;


            string vParameters =
             "?pInvItemId=" + pInvItemId +
         "&pItemTypeList=" + pItemTypeList +
         "&pQueryTypeId=" + 400;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public string SearchUnitByCode(int? pUnitCode = null)
        {



            string vPath = "/APIVUnit/VUnitGet";
            //string vParameters =
            //        "?pORD=" + pUnitCode +
            //    "&pQueryTypeId=" + 400;
            string vParameters =
                "?pCodeId=" + pUnitCode +
            "&pQueryTypeId=" + 400;



            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public void ShowSimple()
        {
            DataTable DT;
            //string vStoreId = null;
            //string vItemId = null;
            //string vItemType = null;
            //string vUnitId = null;
            string vReportPath;
            int vStoreId = Convert.ToInt32(Session["pStoreId"]);

            int vItemId = Convert.ToInt32(Session["pItemId"]);


            int vItemType = Convert.ToInt32(Session["pItemType"]);


            int vUnitId = Convert.ToInt32(Session["pUnitId"]);
            string vType = Session["pType"].ToString();
            string vZeroType = Session["pZeroType"].ToString();
            int? IsZero = null;
            if (Session["IsZero"] != null)
            {
                IsZero = 0;
            }
            int ReportType = Convert.ToInt32(Session["ReportType"].ToString());
            DT = _dbInvStoreItemQty.funGetProductionQtyReport(pStoreId: vStoreId, pItemId: vItemId, pItemType: vItemType, pUnitId: vUnitId, pType: vZeroType, ReportTypeId: ReportType,
                IsZero: IsZero);
            if (vType == "Store")
            {
                vReportPath = Server.MapPath("~/Reports") + "//ProductionQtyByStoreReport.rpt";
            }
            else if (vType == "Type")
            {
                vReportPath = Server.MapPath("~/Reports") + "//ProductionQtyByTypeReport.rpt";
            }
            else
            {
                vReportPath = Server.MapPath("~/Reports") + "//ProductionQtyReport.rpt";
            }

            ClsReport.Printreport(DT, vReportPath);


        }

        public ActionResult ProductionQuantitiesReport(int? pStoreId = null, int? pItemId = null, int? pItemType = null, int? pUnitId = null, string pType = null, string pZeroType = null, int? ReportType = null, int? IsZero = null)
        {
            Session["pStoreId"] = pStoreId;
            Session["pItemId"] = pItemId;
            Session["pItemType"] = pItemType;
            Session["pUnitId"] = pUnitId;
            Session["pType"] = pType;
            Session["pZeroType"] = pZeroType;
            Session["ReportType"] = ReportType;
            Session["IsZero"] = IsZero;
            return View();
        }
        public static DataTable QuantitiesOfItemInAllUnits(DataTable DT)
        {
            var GroupData = from row in DT.AsEnumerable()
                            group row by new
                            {
                                ItemId = row.Field<int>("ItemId"),
                                StoreId = row.Field<int>("StoreId")
                            } into grouped
                            select new
                            {
                                GroupKey = grouped.Key,
                                Rows = grouped.OrderBy(r => r.Field<int>("InvItemUnitId")) // ترتيب الصفوف داخل كل مجموعة
                            };

            decimal previousItemQty = 0;
            int qtyBeforeDecimalPoint = 0;
            decimal qtyAfterDecimalPoint = 0;
            foreach (var i in GroupData)
            {
                int first = 1;
                foreach (DataRow item in DT.Rows)
                {
                    if (i.GroupKey.ItemId.ToString() == item["ItemId"].ToString() && i.GroupKey.StoreId.ToString() == item["StoreId"].ToString())
                    {
                        if (first == 1)
                        {
                            previousItemQty = Convert.ToDecimal(item["ItemQty"]);
                        }
                        //else if (i.Rows.Count() == first)
                        //{

                        //}
                        else
                        {
                            previousItemQty = qtyAfterDecimalPoint * Convert.ToDecimal(item["PartsInParents"]);
                        }

                        qtyBeforeDecimalPoint = (int)previousItemQty;
                        qtyAfterDecimalPoint = previousItemQty - Math.Truncate(previousItemQty);
                        item["ItemQty"] = qtyBeforeDecimalPoint;
                        //item["InvItemNameL1"] = item["InvItemNameL1"] + " - بدش";
                        first += 1;
                        //foreach (var row in i.Rows)
                        //{
                        //    item["ItemQty"] = qtyBeforeDecimalPoint;
                        //    item["InvItemNameL1"] = item["InvItemNameL1"]+" - بدش";// + row.Field<decimal>("ItemQty").ToString();
                        //}

                    }
                }
            }
            return DT;
        }
        public ActionResult ProductionQuantitieshtmlReport(int? pStoreId = null, int? pItemId = null, int? pItemType = null, int? pUnitId = null, string pType = null, string pZeroType = null, int? ReportType = null, int? IsZero = null)
        {
            // الكميات في المخازن في التقرير مختلف على الشاشة
            int BranchId = 0;
            if (Request.Cookies["BranchId"] != null)
            { BranchId = Convert.ToInt32(Request.Cookies["BranchId"].Value); };
            DataTable DT = _dbInvStoreItemQty.funGetProductionQtyReport(pStoreId: pStoreId, pItemId: pItemId, pItemType: pItemType, pUnitId: pUnitId, pType: pZeroType, ReportTypeId: ReportType,
               IsZero: IsZero, BranchId: BranchId);
            if (DT.Rows.Count > 0)
            {
                if (ReportType == 1) // جلب كمية الصنف تفصيلي بكل الوحدات بدون كسور عدا الاخيرة
                {
                    //ItemQty,PartsInParents - InvItemUnitId
                    DT = QuantitiesOfItemInAllUnits(DT);
                }
                DataRow dataRow = DT.Rows[0];
                ViewBag.vDT = DT;
                ViewBag.ReportName = "تقرير الكميات في المخازن";
                ViewBag.DateTo = DateTime.Now.ToString();
                ViewBag.DateFrom = DateTime.Now.ToString();
                ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
                ViewBag.Type = pType;
            }

            if (pType == "Store")
            {

                return View("ProductionQtyByStorehtmlReport");

            }
            else if (pType == "Type")
            {
                return View("ProductionQtyByStorehtmlReport");
            }
            else
            {
                return View();
            }

        }

        public ActionResult ProductSearch()
        {
            return View();
        }

    }
}