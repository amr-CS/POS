using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIProductionController : ApiController
    {
        private IdbProduction _dbProduction;
        public APIProductionController(IdbProduction dbProduction) {
            _dbProduction = dbProduction;
        }

        [HttpGet]
        public string ProductionGET(
        int? pProductionId = null,
        string pProductionCode = null,
        int? pSubSeq = null,
        int? pTransId = null,
        DateTime? pTransDate = null,
        int? pTransStatus = null,
        int? pEmpId = null,
        int? pProdLine = null,
        bool? pIsPosted = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pProductionDtlId = null,
        int? pItemId = null,
        int? pSourceStore = null,
        int? pDestStore = null,
        int? pSellStore = null,
        int? pAddId = null,
        int? pQTY = null,
        int? pUnitId = null,
        int? pTagId = null,
        string pNOTES = null,
        int? pRemainderQty = null,
        string phNumbers = null,
        bool? pIsDetail = null,
        int? branchid = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbProduction.funProductionGET(
             pProductionId: pProductionId,
            pProductionCode: pProductionCode,
            pSubSeq: pSubSeq,
            pTransId: pTransId,
            pTransDate: pTransDate,
            pTransStatus: pTransStatus,
            //pEmpId: pEmpId,
            pProdLine: pProdLine,
            pIsPosted: pIsPosted,
            pCompanyId: pCompanyId,
            pIsDeleted: pIsDeleted,
            pProductionDtlId: pProductionDtlId,
            pItemId: pItemId,
            pEmpId:pEmpId,
            pSourceStore: pSourceStore,
            pDestStore: pDestStore,
            pSellStore: pSellStore,
            pAddId: pAddId,
            pQTY: pQTY,
            pUnitId: pUnitId,
            pTagId: pTagId,
            pNOTES: pNOTES,
            phNumbers: phNumbers,
            pRemainderQty: pRemainderQty,
            pIsDetail: pIsDetail,
            branchid: branchid,
            pQueryTypeId: pQueryTypeId);

        return vData;
                }
    }
}
