using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvStoreItemQtyController : ApiController
    {

        private IdbInvStoreItemQty _dbInvStoreItemQty;
        public APIInvStoreItemQtyController(IdbInvStoreItemQty dbInvStoreItemQty) {
            _dbInvStoreItemQty = dbInvStoreItemQty;
        }

        [HttpGet]
        public string InvStoreItemQtyGET(
         int? pInvStoreItemQtyId = null,
        int? pStoreId = null,
       int? pItemId = null,
     DateTime? pExpireDate = null,
    float? pItemOpenQty = null,
     float? pItemQty = null,
     int? IsZero=null,
     int? ReportTypeId = null,
      float? pItemReservedQty = null,
      string pNotes = null,
       float? pItemOpenCost = null,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect,
     int? pUnitId = null,
     int? pItemType = null
     )
        {
            // الكميات في المخازن في الشاشة مختلف على التقرير
            // Get Data 
            DataTable vData = _dbInvStoreItemQty.funInvStoreItemQtyGET(
            pInvStoreItemQtyId: pInvStoreItemQtyId,
            pStoreId: pStoreId,
            pItemId: pItemId,
            pExpireDate: pExpireDate,
            pItemOpenQty: pItemOpenQty,
            pItemQty: pItemQty,
            pItemReservedQty: pItemReservedQty,
            pNotes: pNotes,
            pItemOpenCost: pItemOpenCost,
            IsZero:IsZero,
            ReportTypeId: ReportTypeId,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pUnitId: pUnitId,
            pItemType: pItemType
            );
            if(ReportTypeId==1) // جلب كمية الصنف تفصيلي بكل الوحدات بدون كسور عدا الاخيرة
            {
                vData = DataController.RES.ProductsQuantitiesController.QuantitiesOfItemInAllUnits(vData);
                
            }
            string json = JsonConvert.SerializeObject(vData, Formatting.Indented);
            // Result
            return json;
        }
    }
}
