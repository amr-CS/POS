using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using appSERP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIINVItemUnitController : ApiController
    {
        private IdbInvItemUnit _dbInvItemUnit;
        private IdbINVInvoice _dbINVInvoice;
        public APIINVItemUnitController(IdbInvItemUnit dbInvItemUnit, IdbINVInvoice dbINVInvoice)
        {
            _dbInvItemUnit = dbInvItemUnit;
            _dbINVInvoice = dbINVInvoice;
        }


       [HttpGet]
       public string InvItemUnitGET(
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
            //  فحص وجود حركات للوحدة الصنف قبل تنفيذ عملية حذف وحدة الصنف او الوجبة
            // لكن في حالة تعديل بيانات وحدة الصنف او حذفها تضرب تكلفة وكمية الصنف في النظام لذالك 
            // يمنع تعديل وحدة صنف او حذفها اذا وجد لها حركات من قبل
            // الصنف له عمليات سابقة ومن آجل لا تضرب التكلفة والكمية يمنع تعديل او حذف وحداته
            if (pQueryTypeId == clsQueryType.qDelete)
            {
                var dtItemUnitById = _dbInvItemUnit.GetItemUnitById(pInvItemUnitId??0);
                if (dtItemUnitById != null && dtItemUnitById.Rows.Count > 0)
                {
                    int? itemId = Convert.ToInt32(dtItemUnitById.Rows[0]["ItemId"].ToString());
                    //int? unitId = Convert.ToInt32(dtItemUnitById.Rows[0]["UnitId"].ToString());
                    var dt = _dbINVInvoice.GetItemHasInvoice(pItemId = itemId );
                    if (dt != null && dt.Rows.Count > 0)
                        return SystemMessageCode.ToJSON(SystemMessageCode.GetError("الصنف له عمليات سابقة ومن آجل لا تضرب التكلفة والكمية يمنع حذف وحداته"));

                    /*
                    var dtItemUnitParent = _dbInvItemUnit.GetItemUnitParentBy((int)unitId, (int)itemId);
                    if (dtItemUnitParent != null && dtItemUnitParent.Rows.Count > 0)
                        return SystemMessageCode.ToJSON(SystemMessageCode.Get("للآسف وحدة الصنف تعتبر وحدة اب لوحدة أخرى لنفس الصنف لا يمكن حذفها"));

                    var dt = _dbINVInvoice.GetItemHasInvoice(pItemId = itemId, pUnitId = unitId);
                    if (dt != null && dt.Rows.Count > 0)
                        return SystemMessageCode.ToJSON(SystemMessageCode.Get("للآسف وحدة الصنف لها فاتورة من سابق لا يمكن حذفها"));
                    */
                }
                else
                    throw new ArgumentException("InvItemUnitId is Null");
            }
            // Get Data 
            string vData = _dbInvItemUnit.funInvItemUnitGET(
            pInvItemUnitId: pInvItemUnitId,
            pUnitId: pUnitId,
            pUnitCode: pUnitCode,
            pUnitNameL1: pUnitNameL1,
            pUnitNameL2: pUnitNameL2,
            pUnitParentId: pUnitParentId,
            pUnitCost: pUnitCost,
            pPartsInParents: pPartsInParents,
            pUnitPrice: pUnitPrice,
            pNotes: pNotes,
            pCurrencyId: pCurrencyId,
            pPriceCurrency: pPriceCurrency,
            pDefaultUnit: pDefaultUnit,
            pUnitOrderLimit: pUnitOrderLimit,
            pItemId: pItemId,
            pBarcode : pBarcode,
            pIsDecreasable : pIsDecreasable,
            pIsDefault : pIsDefault,
            pSellUnit: pSellUnit,
            pUnitProduction: pUnitProduction,
            pUnitIsActive: pUnitIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
