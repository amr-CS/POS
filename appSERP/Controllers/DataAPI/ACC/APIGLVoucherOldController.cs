using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APIGLVoucherOldController : ApiController
    {
        private IdbGLVoucherOld _dbGLVoucherOld;
        public APIGLVoucherOldController(IdbGLVoucherOld dbGLVoucherOld) {
            _dbGLVoucherOld = dbGLVoucherOld;
        }

        [HttpGet]
        public object GLVoucherDataGet(
        string pGLVoucherId = null,
        string pGLVoucherCode = null,
        string pGLVoucherNameL1 = null,
        string pGLVoucherNameL2 = null,
        string pGLVoucherNo = null,
        int? pVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pSystemId = null,
        int? pCashDeskId = null,
        DateTime? pGLVoucherDate = null,
        DateTime? pGLVoucherTime = null,
        int? pGLVoucherRef = null,
        DateTime? pGLVoucherRefDate = null,
        int? pPaymentTypeId = null,
        bool? pIsPosted = null,
        bool? pIsIssued = null,
        string pGLVoucherNote = null,
        int? pUserId = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        bool? pDocIsCancelled = null,
        bool? pDocIsWait = null,
        bool? pGLVoucherIsRepeated = null,
        int? pGLIdPayType = null,
        int? pGLVoucherCategoryId = null,
        decimal? pGLOppsVoucherValue = null,
        int? pGLOppsVoucherId = null,
        int? pGLOppsVoucherYearId = null,
        int? pStoreId = null,
        int? pInvTransactionTypeId = null,
        int? pCSId = null,
        int? pVoucherSeq = null,
        bool? pGLVoucherIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET Data
            string vGLVoucherData = _dbGLVoucherOld.funGLVoucherGET(
            pGLVoucherId: pGLVoucherId,
            pGLVoucherCode: pGLVoucherCode,
            pGLVoucherNameL1: pGLVoucherNameL1,
            pGLVoucherNameL2: pGLVoucherNameL2,
            pGLVoucherNo: pGLVoucherNo,
            pVoucherTypeId: pVoucherTypeId,
            pFinancialYearId: pFinancialYearId,
            pSystemId: pSystemId,
            pCashDeskId: pCashDeskId,
            pGLVoucherDate: pGLVoucherDate,
            pGLVoucherTime: pGLVoucherTime,
            pGLVoucherRef: pGLVoucherRef,
            pGLVoucherRefDate: pGLVoucherRefDate,
            pPaymentTypeId: pPaymentTypeId,
            pIsPosted: pIsPosted,
            pIsIssued: pIsIssued,
            pGLVoucherNote: pGLVoucherNote,
            pUserId: pUserId,
            pUserFullNameL1: pUserFullNameL1,
            pUserFullNameL2: pUserFullNameL2,
            pUserName: pUserName,
            pDocIsCancelled: pDocIsCancelled,
            pDocIsWait: pDocIsWait,
            pGLVoucherIsRepeated: pGLVoucherIsRepeated,
            pGLIdPayType: pGLIdPayType,
            pGLVoucherCategoryId: pGLVoucherCategoryId,
            pGLOppsVoucherValue: pGLOppsVoucherValue,
            pGLOppsVoucherId: pGLOppsVoucherId,
            pGLOppsVoucherYearId: pGLOppsVoucherYearId,
            pStoreId: pStoreId,
            pInvTransactionTypeId: pInvTransactionTypeId,
            pCSId: pCSId,
            pVoucherSeq: pVoucherSeq,
            pGLVoucherIsActive: pGLVoucherIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vGLVoucherData;
        }
    }
}
