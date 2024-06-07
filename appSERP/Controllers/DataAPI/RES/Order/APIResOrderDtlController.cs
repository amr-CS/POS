using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.dbCode.RES.Order;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES.Order
{
    public class APIResOrderDtlController : ApiController
    {
        private IdbResOrderDtl _dbResOrderDtl;
        public APIResOrderDtlController(IdbResOrderDtl dbResOrderDtl)
        {

            _dbResOrderDtl = dbResOrderDtl;
        }
        [HttpGet]
        public string ResOrderDtlGET(
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
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbResOrderDtl.funResOrderDtlGET(
            pOrderDTLID: pOrderDTLID,
            pOrderId: pOrderId,
            pORDER_LOC_SEQ: pORDER_LOC_SEQ,
            pITEM_UNIT_SEQ: pITEM_UNIT_SEQ,
            pTAG: pTAG,
            pQTY: pQTY,
            pPRICE: pPRICE,
            pNOTES: pNOTES,
            pSLICING_TYPE: pSLICING_TYPE,
            pSHEEP_REMAINDER: pSHEEP_REMAINDER,
            pCUST_SHEEP: pCUST_SHEEP,
            pCUST_PLATE: pCUST_PLATE,
            pQTY_PLATE: pQTY_PLATE,
            pTYP: pTYP,
            pPRICE_INSUR: pPRICE_INSUR,
            pUPDATE_PRICE: pUPDATE_PRICE,
            pDISC_AMT: pDISC_AMT,
            pVAT_PRICE: pVAT_PRICE,
            pVAT_TOTAL: pVAT_TOTAL,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            return vData;

        }

    }
}
