using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvBoxesController : ApiController
    {
        private IdbInvBoxes _dbInvBoxes;
        public APIInvBoxesController(IdbInvBoxes dbInvBoxes) {
            _dbInvBoxes = dbInvBoxes;
        }

        [HttpGet]
        public string BoxGET(
        int? pBoxId = null,
        string pBoxCode = null,
        int? pInvId = null,
        int? pInvType = null,
        int? pYear = null,
        int? pBoxDtlId = null,
        int? pAccountId = null,
        int? pCostCenterId = null,
        float? pBoxCredit = null,
        float? pBoxDebit = null,
        float? pCurValue = null,
        float? pBoxBaseCredit = null,
        float? pBoxBaseDebit = null,
        bool? pIsPosted = null,
        bool? pPosting = null,
        int? pStoreId = null,
        string pNotes = null,
        float? pTransSeq = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Values
             string vData = _dbInvBoxes.funBoxGET(
             pBoxId: pBoxId,
             pBoxCode: pBoxCode,
             pInvId: pInvId,
             pInvType: pInvType,
             pYear: pYear,
             pBoxDtlId: pBoxDtlId,
             pAccountId: pAccountId,
             pCostCenterId: pCostCenterId,
             pBoxCredit: pBoxCredit,
             pBoxDebit: pBoxDebit,
             pCurValue: pCurValue,
             pBoxBaseCredit: pBoxBaseCredit,
             pBoxBaseDebit: pBoxBaseDebit,
             pIsPosted: pIsPosted,
             pPosting: pPosting,
             pStoreId: pStoreId,
             pNotes: pNotes,
             pTransSeq: pTransSeq,
             pIsDeleted: pIsDeleted,
             pQueryTypeId: pQueryTypeId);

            // Get Result
            return vData;
                
        }
    }
}
