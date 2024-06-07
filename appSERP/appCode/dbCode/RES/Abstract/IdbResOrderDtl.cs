using appSERP.appCode.SQL.QueryType;
using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbResOrderDtl
    {
        string funResOrderDtlGET(
        int? pOrderDTLID = null,
        int? pOrderId = null,
        int? pORDER_LOC_SEQ = null,
        int? pITEM_UNIT_SEQ = null,
        int? pTAG = null,
        float? pQTY = null,
        int? pPRICE = null,
        string pNOTES = null,
        int? pSLICING_TYPE = null,
        int? pSHEEP_REMAINDER = null,
        int? pCUST_SHEEP = null,
        int? pCUST_PLATE = null,
        int? pQTY_PLATE = null,
        int? pTYP = null,
        float? pPRICE_INSUR = null,
        float? pUPDATE_PRICE = null,
        int? pDISC_AMT = null,
        float? pVAT_PRICE = null,
        float? pVAT_TOTAL = null,
        int? pCOMP_ID = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        object spResOrderDtlInsertBulk(ICollection<ResOrderDtl> resOrderDtls, int? orderId, int? branchId);
        DataTable GetOrderDetails(int orderId);
    }
}
