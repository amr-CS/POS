using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbResOrder
    {
        string funResOrderGET(
        int? pOrderId = null,
        int? pORDER_SEQ = null,
        int? pCOMP_ID = null,
        int? pORDER_TYPE = null,
        int? pSUB_SEQ = null,
        DateTime? pORDER_DATE = null,
        DateTime? pDELIVERY_DATE = null,
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
        string pORDER_PHONE_NUMBER = null,
        string phNumbers = null,
        float? pDISCOUNT = null,
        float? pPRICE_CAT = null,
        float? pDISCOUNT_SELL = null,
        float? pCASH_DISCOUNT = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qSelect,int?branchId=null);

        DataTable MovementOrderGET(int? pOrderId = null,int?BranchId=null);
        DataTable funResOrderReport(int? id = null);
        DataTable GetOrderById(int orderId);
        
    }
}
