using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class InvItemController : Controller
    {
        private ILog _ILog;
        private IdbInvItem _dbInvItem;
        private IclsAPI _clsAPI;
        public InvItemController(ILog log, IdbInvItem dbInvItem, IclsAPI clsAPI)
        {
            _ILog = log;
            _dbInvItem = dbInvItem;
            _clsAPI = clsAPI;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: InvItem
        public ActionResult Index()
        {
            return View();
        }

        public string GetItem(string ItemCode)
        {
            return _dbInvItem.GETItem(ItemCode);

        }
        public string SaveHeader(string id = "1",
             int? pInvItemId = null,
               string pInvItemSymbol = null,
            string pInvItemNameL1 = null,
            string pInvItemNameL2 = null,
            int? pCategoryId = null,
            string pSupCompany = null,
            decimal? pBonusLimit = null,
              decimal? pBonus= null,
             decimal? pDiscLimit = null,
              decimal? pDiscPerc = null,
              decimal? pOrderLimit = null,
             decimal?  pItemMaxQuantity = null,
                decimal?  pItemMinQuantity= null,
            DateTime? pLastBuy= null,
              DateTime? pLastSell = null,
            decimal? pItemLastCost = null,
            int? pCurrencyId = null,
            string pItemIdNo = null,
            int? pItemFactorId = null,
            string pItemMeasurement = null,
            int? pCategoryMeasureId = null,
              DateTime? pProductDate = null,
            //pItemImage: $('.clsimg').attr('src'), 
            string pItemImage = null,
              string pbasicpath = null,
            string pfilename= null,
            HttpPostedFileBase pFile = null
            )
        {
            // Check File [Image]
            if (pFile != null)
            {
                // Set Model [Image Path] [Save and Get Path]
                pItemImage = clsFileSave.funFileSave(pFile, "/Image/DataImage", pItemImage);

            }
         
            string vAPIPath = "/APIInvItem/InvItemGET?pInvItemId=" + pInvItemId + "&&pInvItemSymbol="+ pInvItemSymbol + "&&pInvItemNameL1=" + pInvItemNameL1 + "&&pInvItemNameL2=" + pInvItemNameL2 + "&&pCategoryId=" + pCategoryId + "&&pSupCompany=" + pSupCompany + "&&pBonusLimit=" + pBonusLimit+ "&&pBonus=" + pBonus + "&&pDiscLimit="+ pDiscLimit + "&&pDiscPerc=" + pDiscPerc + "&&pOrderLimit=" + pOrderLimit + "&&pItemMaxQuantity=" + pItemMaxQuantity + "&&pItemMinQuantity=" + pItemMinQuantity + "&&pLastBuy=" + Convert.ToDateTime( pLastBuy).ToString("yyyy-MM-dd") + "&&pLastSell=" + Convert.ToDateTime(pLastSell).ToString("yyyy-MM-dd") + "&&pItemLastCost=" + pItemLastCost + "&&pCurrencyId=" + pCurrencyId + "&&pItemIdNo=" + pItemIdNo + "&&pItemFactorId=" + pItemFactorId + "&&pItemMeasurement=" + pItemMeasurement + "&&pCategoryMeasureId=" + pCategoryMeasureId + "&&pProductDate=" + Convert.ToDateTime(pProductDate).ToString("yyyy-MM-dd") + "&&pItemImage=" + pItemImage + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
  
            return vJSONResult;

        }
     
        public string SaveUnit(int? pInvItemUnitId = null,int? pUnitId = null,string pUnitNameL1 = null, decimal? pUnitCost = null, int? pPartsInParents = null, int? pUnitParentId = null, decimal? pUnitPrice = null, int? pCurrencyId = null,int? pDefaultUnit = null,decimal? pUnitOrderLimit = null, int? pItemId = null )
        {
            string vAPIPath = "/APIINVItemUnit/InvItemUnitGET?pInvItemUnitId=" + pInvItemUnitId + "&&pUnitId=" + pUnitId + "&&pUnitNameL1=" + pUnitNameL1 + "&&pUnitCost=" + pUnitCost + "&&pPartsInParents=" + pPartsInParents + "&&pUnitParentId="+ pUnitParentId + "&&pUnitPrice=" + pUnitPrice + "&&pCurrencyId=" + pCurrencyId + "&&pDefaultUnit=" + pDefaultUnit + "&&pUnitOrderLimit=" + pUnitOrderLimit + "&&pItemId=" + pItemId + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteHeader(string id = "1",
            int? pInvItemId = null
           )
        {
      

            string vAPIPath = "/APIInvItem/InvItemGET?pInvItemId=" + pInvItemId + "&&pIsDeleted= true" +"&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;

        }


        public string DeleteUnit(int? pInvItemUnitId = null)
        {
            string vAPIPath = "/APIINVItemUnit/InvItemUnitGET?pInvItemUnitId="+ pInvItemUnitId + "&&pIsDeleted= true" + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveBarCode(int? pInvItemBarcodeId = null,int? pUnitId = null,string pItemBarCode = null)
        {
            try
            {
                string vAPIPath = "/APIInvItemBarcode/InvItemBarcodeGET?pInvItemBarcodeId=" + pInvItemBarcodeId + "&&pUnitId=" + pUnitId + "&&pItemBarCode=" + pItemBarCode + "&&pQueryTypeId=" + 100;
                string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

                return vJSONResult;
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
        
        }
        public string DeleteBarCode(int? pInvItemBarcodeId = null, int? pUnitId = null, string pItemBarCode = null)
        {
            string vAPIPath = "/APIInvItemBarcode/InvItemBarcodeGET?pInvItemBarcodeId=" + pInvItemBarcodeId  +"&&pIsDeleted= true" + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveEquip(int? pEquipId = null,string pEquipCode = null,string pEquipName = null,int? pItemId = null,string pNotes = null)
        {
            string vAPIPath = "/APIInvItemsEquip/InvItemsEquipGET?pEquipId=" + pEquipId + "&&pEquipName=" + pEquipName + "&&pItemId=" + pItemId + "&&pNotes="+ pNotes + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteEquip(int? pEquipId = null, string pEquipCode = null, string pEquipName = null, int? pItemId = null, string pNotes = null)
        {
            string vAPIPath = "/APIInvItemsEquip/InvItemsEquipGET?pEquipId=" + pEquipId + "&&pIsDeleted= true" + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveItemReplace(int? pInvItemReplaceId = null,string pInvItemReplaceCode = null,int? pItemId = null,int? pReplaceItemId = null,string pNotes = null)
        {
            string vAPIPath = "/APIInvItemReplace/InvItemReplaceGET?pInvItemReplaceId=" + pInvItemReplaceId + "&&pItemId=" + pItemId + "&&pReplaceItemId=" + pReplaceItemId + "&&pNotes=" + pNotes + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string DeleteItemReplace(int? pInvItemReplaceId = null, string pInvItemReplaceCode = null, int? pItemId = null, int? pReplaceItemId = null, string pNotes = null)
        {
            string vAPIPath = "/APIInvItemReplace/InvItemReplaceGET?pInvItemReplaceId=" + pInvItemReplaceId + "&&pIsDeleted= true"  + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string SavePrice(
             int? pPriceId = null,string pPriceCode = null,int? pItemId = null,int? pSellCostType = null,decimal? pPrice = null,string pNotes = null
            )
        {
            string vAPIPath = "/APIInvItemsUnitsPrice/InvItemsUnitsPriceGET?pPriceId=" + pPriceId + "&&pItemId=" + pItemId + "&&pSellCostType=" + pSellCostType + "&&pPrice=" + pPrice +"&&pNotes=" + pNotes + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeletePrice(
         int? pPriceId = null, string pPriceCode = null, int? pItemId = null, int? pSellCostType = null, decimal? pPrice = null, string pNotes = null
        )
        {
            string vAPIPath = "/APIInvItemsUnitsPrice/InvItemsUnitsPriceGET?pPriceId=" + pPriceId  +"&&pIsDeleted= true" + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
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
                string vBasicPath = "/Image/DataImage/";
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Image/DataImage/") + fileName); //File will be saved in application root
         
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }
        public string GetInvItem(string id = "1", string pInvItemBarCode = null)
        {
            string vAPIPath;
                vAPIPath = "/APIInvItem/InvItemGET?pInvItemBarCode=" + pInvItemBarCode + "&&pQueryTypeId=" + clsQueryType.qSelect;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;
        }
        public string GetInvItemByParCode(string id = "1", string pInvItemBarCode = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pInvItemBarCode=" + pInvItemBarCode + "&&pQueryTypeId=" + 407;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetFirstInvItem(string id = "1")
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pQueryTypeId=" + 402;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetLastInvItem(string id = "1")
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pQueryTypeId=" + 403;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetPreviousInvItem(string id = "1", int? pInvItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pInvItemId=" + pInvItemId + "&&pQueryTypeId=" + 404;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;
        }
        public string GetNextInvItem(string id = "1", int? pInvItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pInvItemId=" + pInvItemId + "&&pQueryTypeId=" + 405;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetInvItemUnit(string id = "1", string pItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIINVItemUnit/InvItemUnitGET?pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qSelect;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetBarcode(string id = "1", string pUnitId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItemBarcode/InvItemBarcodeGET?pUnitId=" + pUnitId + "&&pQueryTypeId=" + clsQueryType.qSelect;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetEquip(string id = "1", string pItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItemsEquip/InvItemsEquipGET?pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qSelect;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetItemReplace(string id = "1", string pItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItemReplace/InvItemReplaceGET?pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qSelect;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;
        }
        public string GetPrices(string id = "1", string pItemId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItemsUnitsPrice/InvItemsUnitsPriceGET?pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qSelect;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
    
            return vJSONResult;
        }
        public string GetSubItems(string id = "1", int? pSubItemId = null, string pSubItemCode = null,string pSubItemNameL1 = null,string pSubItemNameL2 = null,int? pPiecesCount = null,int? pItemId = null,string pNotes = null)
        {
            
            string vAPIPath;

            //vAPIPath = "/APIInvSubItem/InvSubItemGET?pSubItemId=" + pSubItemId + "&&pSubItemCode="+ pSubItemCode + "&&pSubItemNameL1="+ pSubItemNameL1 + "pSubItemNameL2="+ pSubItemNameL2 + "&&pPiecesCount=" + pPiecesCount+ "&&pItemId="+ pItemId+ "&&pNotes="+ pNotes + "&&pQueryTypeId=" + clsQueryType.qSelect;
            vAPIPath = "/APIInvSubItem/InvSubItemGET?pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qSelect;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;


        }
        public string DeleteSubItems(string id = "1", int? pSubItemId = null, string pSubItemCode = null, string pSubItemNameL1 = null, string pSubItemNameL2 = null, int? pPiecesCount = null, int? pItemId = null, string pNotes = null)
        {
            string vAPIPath;
            //vAPIPath = "/APIInvSubItem/InvSubItemGET?pSubItemId=" + pSubItemId + "&&pSubItemCode="+ pSubItemCode + "&&pSubItemNameL1="+ pSubItemNameL1 + "pSubItemNameL2="+ pSubItemNameL2 + "&&pPiecesCount=" + pPiecesCount+ "&&pItemId="+ pItemId+ "&&pNotes="+ pNotes + "&&pQueryTypeId=" + clsQueryType.qSelect;
            vAPIPath = "/APIInvSubItem/InvSubItemGET?pSubItemId=" + pSubItemId + "&&pIsDeleted=true" + "&&pQueryTypeId=" + 300;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string GetExpireDate(string id = "1", int? pExpireDateId = null, string pExpireDateCode = null, DateTime? pExpireDate = null, int? pItemId = null, int? pPiecesCount = null, string pNotes = null)
        {
            string vAPIPath;
            //vAPIPath = "/APIExpireDate/ExpireDateGET?pExpireDateId=" + pExpireDateId + "&&pExpireDateCode=" + pExpireDateCode + "&&pExpireDate=" + pExpireDate + "pItemId=" + pItemId  +"&&pQueryTypeId=" + clsQueryType.qSelect;
            vAPIPath = "/APIExpireDate/ExpireDateGET?pItemId=" + pItemId +"&&pQueryTypeId=" + clsQueryType.qSelect;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string DeleteExpireDate(string id = "1", int? pExpireDateId = null, string pExpireDateCode = null, DateTime? pExpireDate = null, int? pItemId = null, int? pPiecesCount = null, string pNotes = null)
        {
            string vAPIPath;
            //vAPIPath = "/APIExpireDate/ExpireDateGET?pExpireDateId=" + pExpireDateId + "&&pExpireDateCode=" + pExpireDateCode + "&&pExpireDate=" + pExpireDate + "pItemId=" + pItemId  +"&&pQueryTypeId=" + clsQueryType.qSelect;
            vAPIPath = "/APIExpireDate/ExpireDateGET?pExpireDateId=" + pExpireDateId + "&&pIsDeleted=true" + "&&pQueryTypeId=" + 300;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string SaveSubItems(string id = "1", int? pSubItemId = null, string pSubItemCode = null, string pSubItemNameL1 = null, string pSubItemNameL2 = null, int? pPiecesCount = null, int? pItemId = null, string pNotes = null)
        {
            string vAPIPath;
            vAPIPath = "/APIInvSubItem/InvSubItemGET?pSubItemId=" + pSubItemId + "&&pSubItemCode="+ pSubItemCode + "&&pSubItemNameL1="+ pSubItemNameL1 + "&&pSubItemNameL2="+ pSubItemNameL2 + "&&pPiecesCount=" + pPiecesCount+ "&&pItemId="+ pItemId+ "&&pNotes="+ pNotes + "&&pQueryTypeId=" + clsQueryType.qInsert;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }
        public string SaveExpireDate(string id = "1", int? pExpireDateId = null, string pExpireDateCode = null, DateTime? pExpireDate = null, int? pItemId = null, int? pPiecesCount = null, string pNotes = null)
        {
            string vAPIPath;
            vAPIPath = "/APIExpireDate/ExpireDateGET?pExpireDateId=" + pExpireDateId + "&&pExpireDateCode=" + pExpireDateCode + "&&pExpireDate=" + Convert.ToDateTime(pExpireDate).ToString("yyyy-MM-dd") + "&&pItemId=" + pItemId + "&&pQueryTypeId=" + clsQueryType.qInsert;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;
        }

        // Account Search
        public ActionResult SearchItem(int? ItemId = 0)
        {
            ViewBag.pItemId = ItemId;
            return View();
        }
        // Size GET
        public string CurrencyGET()
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICurrency;
            // Praremeter
            string vParameters =
                "?pCurrencyIsActive=" + true +
                "&pIsDeleted=" + false +
                "&pQueryTypeId=" + 400;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        // Size GET
        public string GETBasicUnit()
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APIVUnit/VUnitGET?pQueryTypeId=" + 401;
   
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath );

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public string GetDefaultUnit(string id = "1")
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pQueryTypeId=" + 406;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;
        }
        public string GetInvItemByCode(string id = "1", string pInvItemCode = null)
        {
            string vAPIPath;

            vAPIPath = "/APIInvItem/InvItemGET?pInvItemCode=" + pInvItemCode + "&&pQueryTypeId=" + 408;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;


        }
        public ActionResult SearchInvItemUnit()
        {
          
            return View();
        }
        public string SearchInvItemByCode(string pInvItemCode = null)
        {
            string vPath = "/APIInvItem/InvItemGET";
            string vParameters =
                "?pInvItemCode=" + pInvItemCode +
                "&pQueryTypeId=" + 410;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;

        }
        public void ShowSimple()
        {
            int vInvItemId = Convert.ToInt32(Session["InvItemId"]);

            DataTable DT = _dbInvItem.funGetItemsCardReport(pInvItemId: vInvItemId);
            string vReportPath = Server.MapPath("~/Reports") + "//ItemsCardReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult ItemsCardReport(int? pInvItemId = null)
        {
            ViewBag.vbInvItemId = pInvItemId;
            Session["InvItemId"] = ViewBag.vbInvItemId;
            return View();
        }
        public ActionResult SearchInvItem(int? ItemId = 0)
        {
         
            return View();
        }


    }
}