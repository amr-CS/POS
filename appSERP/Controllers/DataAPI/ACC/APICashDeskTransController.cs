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
    public class APICashDeskTransController : ApiController
    {
        private IdbCashDeskTrans _dbCashDeskTrans;
        public APICashDeskTransController(IdbCashDeskTrans dbCashDeskTrans) {
            _dbCashDeskTrans = dbCashDeskTrans;
        }

        [HttpGet]
       public object CashDeskTransDataGet(
       string pCashDeskTransId = null,
       string pCashDeskTransCode = null,
       string pCashDeskTransNameL1 = null,
       string pCashDeskTransNameL2 = null,
       string pCashDeskTransNo = null,
       int? pVoucherTypeId = null,
       int? pFinancialYearId = null,
       int? pSystemId = null,
       int? pCashDeskId = null,
       int? pMainCashDeskId = null,
       string pGLVoucherId = null,
       DateTime? pCashDeskTransDate = null,
       DateTime? pCashDeskTransTime = null,
       int? pCashDeskTransRef = null,
       DateTime? pCashDeskTransRefDate = null,
       int? pPaymentTypeId = null,
       bool? pIsPosted = null,
       bool? pIsIssued = null,
       bool? pDateFrom = null,
       bool? pDateTo = null,
       bool? pIsCashDeskIn = null,
       string pCashDeskTransNote = null,
       int? pUserId = null,
       string pUserFullNameL1 = null,
       string pUserFullNameL2 = null,
       string pUserName = null,
       bool? pDocIsCancelled = null,
       bool? pDocIsWait = null,
       bool? pCashDeskTransIsRepeated = null,
       int? pGLIdPayType = null,
       int? pCashDeskTransCategoryId = null,
       decimal? pGLOppsVoucherValue = null,
       int? pGLOppsVoucherId = null,
       int? pGLOppsVoucherYearId = null,
       int? pStoreId = null,
       int? pInvTransactionTypeId = null,
       int? pCSId = null,
       int? pVoucherSeq = null,
       bool? pCashDeskTransIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET Data
            string vCashDeskTransData = _dbCashDeskTrans.funCashDeskTransGET(
            pCashDeskTransId: pCashDeskTransId,
            pCashDeskTransCode: pCashDeskTransCode,
            pCashDeskTransNameL1: pCashDeskTransNameL1,
            pCashDeskTransNameL2: pCashDeskTransNameL2,
            pCashDeskTransNo: pCashDeskTransNo,
            pVoucherTypeId: pVoucherTypeId,
            pFinancialYearId: pFinancialYearId,
            pSystemId: pSystemId,
            pCashDeskId: pCashDeskId,
            pMainCashDeskId : pMainCashDeskId,
            pGLVoucherId : pGLVoucherId,
            pCashDeskTransDate: pCashDeskTransDate,
            pCashDeskTransTime: pCashDeskTransTime,
            pCashDeskTransRef: pCashDeskTransRef,
            pCashDeskTransRefDate: pCashDeskTransRefDate,
            pPaymentTypeId: pPaymentTypeId,
            pIsPosted: pIsPosted,
            pIsIssued: pIsIssued,
            pDateFrom : pDateFrom,
            pDateTo : pDateTo,
            pIsCashDeskIn: pIsCashDeskIn,
            pCashDeskTransNote: pCashDeskTransNote,
            pUserId: pUserId,
            pUserFullNameL1: pUserFullNameL1,
            pUserFullNameL2: pUserFullNameL2,
            pUserName: pUserName,
            pDocIsCancelled: pDocIsCancelled,
            pDocIsWait: pDocIsWait,
            pCashDeskTransIsRepeated: pCashDeskTransIsRepeated,
            pGLIdPayType: pGLIdPayType,
            pCashDeskTransCategoryId: pCashDeskTransCategoryId,
            pGLOppsVoucherValue: pGLOppsVoucherValue,
            pGLOppsVoucherId: pGLOppsVoucherId,
            pGLOppsVoucherYearId: pGLOppsVoucherYearId,
            pStoreId: pStoreId,
            pInvTransactionTypeId: pInvTransactionTypeId,
            pCSId: pCSId,
            pVoucherSeq: pVoucherSeq,
            pCashDeskTransIsActive: pCashDeskTransIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vCashDeskTransData;
        }
    }
}
