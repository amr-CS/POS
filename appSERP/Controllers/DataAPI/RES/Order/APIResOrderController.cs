using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.SQL.QueryType;
using appSERP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES.Order
{
    public class APIResOrderController : ApiController
    {
        private IdbResOrder _dbResOrder;
        public APIResOrderController(IdbResOrder dbResOrder) {
            _dbResOrder = dbResOrder;
        }

        [HttpGet]
        public string ResOrderGET(
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
        DateTime? pDELIVERY_DATE2 = null,
        bool? pMULTI_DAY = null,
        bool? pDELIVERY = null,
        float? pPAY_CASH = null,
        float? pPAY_NET = null,
        float? pCREDIT = null,
        string pORDER_PHONE_NO = null,
        string phNumbers = null,
        string pORDER_PHONE_NUMBER = null,
        float? pDISCOUNT = null,
        float? pPRICE_CAT = null,
        float? pDISCOUNT_SELL = null,
        float? pCASH_DISCOUNT = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        int? pLastUpdatedBy = null,
        int? pQueryTypeId = clsQueryType.qSelect,
        int ? branchId=null)
        {
            
            DateTime? DELIVERY_DATE=null ;
            DateTime? ORDER_DATE=null;
            if (pDELIVERY_DATE != null && pORDER_DATE != null)
            {
                 DELIVERY_DATE = DateTime.Parse(pDELIVERY_DATE);
                 ORDER_DATE = DateTime.Parse(pORDER_DATE);
            }
            ORDER_DATE = DateTime.Now;
            if (pQueryTypeId == clsQueryType.qInsert)
            {
                if (branchId == null || branchId == 0)
                {
                    return SystemMessageCode.ToJSON(SystemMessageCode.GetError("الفرع غير محدد حدد فرعك اولا"));
                }
                //    var DELIVERY_DATE_Server = DateTime.Now;
                //    if (DELIVERY_DATE_Server > DELIVERY_DATE)
                //    {
                //        return SystemMessageCode.ToJSON(SystemMessageCode.Get("تاريخ التوصيل غير صحيح و غير مقبول"));
                //    }
            }
            string Data = _dbResOrder.funResOrderGET(
        pOrderId : pOrderId,
        pORDER_SEQ : pORDER_SEQ,
        pORDER_TYPE : pORDER_TYPE,
        pSUB_SEQ : pSUB_SEQ,
        pCreatedBy: pCreatedBy,
        pLastUpdatedBy: pLastUpdatedBy,
        pORDER_DATE : ORDER_DATE,
        pDELIVERY_DATE : DELIVERY_DATE,
        pCUST_SEQ : pCUST_SEQ,
        pADDRESS : pADDRESS,
        pORDER_STATUS : pORDER_STATUS,
        pPERIOD_TYPE : pPERIOD_TYPE,
        pCOST_ID : pCOST_ID,
        pNOTES : pNOTES,
        pDELIVERY_DATE2 : pDELIVERY_DATE2,
        pMULTI_DAY : pMULTI_DAY,
        pDELIVERY : pDELIVERY,
        pPAY_CASH : pPAY_CASH,
        pPAY_NET : pPAY_NET,
        pCREDIT : pCREDIT,
        pORDER_PHONE_NO : pORDER_PHONE_NO,
        pORDER_PHONE_NUMBER : pORDER_PHONE_NUMBER,
        pDISCOUNT : pDISCOUNT,
        pPRICE_CAT : pPRICE_CAT,
        pDISCOUNT_SELL : pDISCOUNT_SELL,
        pCASH_DISCOUNT : pCASH_DISCOUNT,
        phNumbers: phNumbers,
        pIsDeleted: pIsDeleted,
        pQueryTypeId: pQueryTypeId,
        branchId: branchId
        
        );
        return Data;
        }
    }
}
