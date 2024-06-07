using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.dbCode.ACC.Doc;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC.Doc
{
    public class APIGLVoucherController : ApiController
    {

        private IdbAccountCostCenter _dbAccountCostCenter;
        private IdbGLVoucher _dbGLVoucher;
        private IdbAccountLastChild _dbAccountLastChild;
        public APIGLVoucherController(IdbAccountCostCenter dbAccountCostCenter, IdbGLVoucher dbGLVoucher,
            IdbAccountLastChild dbAccountLastChild)
        {
            _dbAccountCostCenter = dbAccountCostCenter;
            _dbGLVoucher = dbGLVoucher;
            _dbAccountLastChild = dbAccountLastChild;
        }
        [HttpGet]
        public string FinancialDateCheckGET(
            DateTime? pDate = null)
        {
            // Get Data 
            string vData = _dbGLVoucher.funFinancialDateCheckGET(
                pDate: pDate);
            // Result
            return vData;
        }

        [HttpGet]
        public string AccountLastChildGET(
            int? pParentId = null,
            bool? AccountIsActive = null,
            string pAccountNo=null,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbAccountLastChild.funAccountLastChildGET(
                pParentId: pParentId,
                pAccountNo: pAccountNo,
                AccountIsActive: AccountIsActive,
                pQueryTypeId: pQueryTypeId
                );

            // Result
            return vData;
        }

        [HttpGet]
        public string AccountCostCenterGET(
            int? pAccountId = null,
            string pCostCenterCode=null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbAccountCostCenter.funAccountCostCenterGET(
             pAccountId: pAccountId,
             pCostCenterCode: pCostCenterCode,
             pIsDeleted: pIsDeleted,
             pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }

        [HttpGet]
        public string GLVoucherGET(
            // Head Parameters
            int? phGLVoucherId = null,
            int? phVoucherTypeId = null,
            int? phFinancialYearId = null,
            int? phSystemId = null,
            int? phCashDeskId = null,
            DateTime? phGLVoucherDate = null,
            TimeSpan? phGLVoucherTime = null,
            string phGLVoucherRef = null,
            DateTime? phGLVoucherRefDate = null,
            int? phPaymentTypeId = null,
            bool? phIsPosted = null,
            bool? phIsIssued = null,
            bool? phIsOpps = null,
            string phGLVoucherNote = null,
            int? phUserId = null,
            bool? phDocIsCancelled = null,
            bool? phDocIsWait = null,
            bool? phGLVoucherIsRepeated = null,
            string phGLIdPayType = null,
            int? phGLVoucherCategoryId = null,
            decimal? phGLOppsVoucherValue = null,
            int? phGLOppsVoucherId = null,
            int? phGLOppsVoucherYearId = null,
            int? phStoreId = null,
            int? phInvTransactionTypeId = null,
            int? phCSId = null,
            int? phVoucherSeq = null,
            string phPerson = null,
            int? phSalesId = null,
            bool? phGLVoucherIsActive = null,
            bool? phIsDeleted = null,
            string phNumbers=null,

            // Detail Parameters
            int? pdGLVoucherDtlId = null,
            int? pdGLVoucherId = null,
            int? pdGLVoucherTypeId = null,
            int? pdFinancialYearId = null,
            int? pdAccountId = null,
            int? pdCashDeskId = null,
            int? pdCurrencyId = null,
            decimal? pdGLVoucherDtlDebit = null,
            decimal? pdGLVoucherDtlCredit = null,
            decimal? pdGLVoucherDtlDebitBase = null,
            decimal? pdGLVoucherDtlCreditBase = null,
            decimal? pdBaseCurrencyValue = null,
            decimal? pdGLVoucherDtlPayDebit = null,
            decimal? pdGLVoucherDtlPayCredit = null,
            decimal? pdPayCurrencyValue = null,
            string pdGLVoucherDtlNote = null,
            int? pdCostCenterId = null,
            bool? pdIsPosted = null,
            int? pdUserId = null,
            int? pdGLVoucherDtlTransSeq = null,
            bool? pdIsDeleted = null,

            // Search Parameters
            string psGLVoucherNo = null,
            DateTime? psDateFrom = null,
            DateTime? psDateTo = null,

            // Main Parameters
            int? pLanguageId = null,
            bool? pIsGLVoucherDetail=null,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbGLVoucher.funGLVoucherGET(
             // Head Parameters
             phGLVoucherId: phGLVoucherId,
             phVoucherTypeId: phVoucherTypeId,
             phFinancialYearId: phFinancialYearId,
             phSystemId: phSystemId,
             phCashDeskId: phCashDeskId,
             phGLVoucherDate: phGLVoucherDate,
             phGLVoucherTime: clsTimeSetting.funBranchTime().TimeOfDay,
             phGLVoucherRef: phGLVoucherRef,
             phGLVoucherRefDate: phGLVoucherRefDate,
             phPaymentTypeId: phPaymentTypeId,
             phIsPosted: phIsPosted,
             phIsIssued: phIsIssued,
             phIsOpps: phIsOpps,
             phGLVoucherNote: phGLVoucherNote,
             phDocIsCancelled: phDocIsCancelled,
             phDocIsWait: phDocIsWait,
             phGLVoucherIsRepeated: phGLVoucherIsRepeated,
             phGLIdPayType: phGLIdPayType,
             phGLVoucherCategoryId: phGLVoucherCategoryId,
             phGLOppsVoucherValue: phGLOppsVoucherValue,
             phGLOppsVoucherId: phGLOppsVoucherId,
             phGLOppsVoucherYearId: phGLOppsVoucherYearId,
             phStoreId: phStoreId,
             phInvTransactionTypeId: phInvTransactionTypeId,
             phCSId: phCSId,
             phVoucherSeq: phVoucherSeq,
             phPerson:phPerson,
             phSalesId:phSalesId,
             phGLVoucherIsActive: phGLVoucherIsActive,
             phIsDeleted: phIsDeleted,
             phNumbers: phNumbers,
             // Detail Parameters
             pdGLVoucherDtlId: pdGLVoucherDtlId,
             pdGLVoucherId: pdGLVoucherId,
             pdGLVoucherTypeId: pdGLVoucherTypeId,
             pdFinancialYearId: pdFinancialYearId,
             pdAccountId: pdAccountId,
             pdCashDeskId: pdCashDeskId,
             pdCurrencyId: pdCurrencyId,
             pdGLVoucherDtlDebit: pdGLVoucherDtlDebit,
             pdGLVoucherDtlCredit: pdGLVoucherDtlCredit,
             pdGLVoucherDtlDebitBase: pdGLVoucherDtlDebitBase,
             pdGLVoucherDtlCreditBase: pdGLVoucherDtlCreditBase,
             pdBaseCurrencyValue: pdBaseCurrencyValue,
             pdGLVoucherDtlPayDebit: pdGLVoucherDtlPayDebit,
             pdGLVoucherDtlPayCredit: pdGLVoucherDtlPayCredit,
             pdPayCurrencyValue: pdPayCurrencyValue,
             pdGLVoucherDtlNote: pdGLVoucherDtlNote,
             pdCostCenterId: pdCostCenterId,
             pdIsPosted: pdIsPosted,
             pdGLVoucherDtlTransSeq: pdGLVoucherDtlTransSeq,
             pdIsDeleted: pdIsDeleted,

             // Search Parameters
             psGLVoucherNo: psGLVoucherNo,
             psDateFrom: psDateFrom,
             psDateTo: psDateTo,

             // Main Parameters
             pIsGLVoucherDetail: pIsGLVoucherDetail,
             pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }

        public IHttpActionResult GLVoucherInsertUpdate(IEnumerable<VoucherBoxCheck> voucherBoxes,
            int? phGLVoucherId = null,
            int? phVoucherTypeId = null,
            int? phFinancialYearId = null,
            int? phSystemId = null,
            int? phCashDeskId = null,
            DateTime? phGLVoucherDate = null,
            TimeSpan? phGLVoucherTime = null,
            string phGLVoucherRef = null,
            DateTime? phGLVoucherRefDate = null,
            int? phPaymentTypeId = null,
            bool? phIsPosted = null,
            bool? phIsIssued = null,
            bool? phIsOpps = null,
            string phGLVoucherNote = null,
            int? phUserId = null,
            bool? phDocIsCancelled = null,
            bool? phDocIsWait = null,
            bool? phGLVoucherIsRepeated = null,
            string phGLIdPayType = null,
            int? phGLVoucherCategoryId = null,
            decimal? phGLOppsVoucherValue = null,
            int? phGLOppsVoucherId = null,
            int? phGLOppsVoucherYearId = null,
            int? phStoreId = null,
            int? phInvTransactionTypeId = null,
            int? phCSId = null,
            int? phVoucherSeq = null,
            string phPerson = null,
            int? phSalesId = null,
            bool? phGLVoucherIsActive = null,
            bool? phIsDeleted = null,
            string phNumbers = null,

            // Detail Parameters
            int? pdGLVoucherDtlId = null,
            int? pdGLVoucherId = null,
            int? pdGLVoucherTypeId = null,
            int? pdFinancialYearId = null,
            int? pdAccountId = null,
            int? pdCashDeskId = null,
            int? pdCurrencyId = null,
            decimal? pdGLVoucherDtlDebit = null,
            decimal? pdGLVoucherDtlCredit = null,
            decimal? pdGLVoucherDtlDebitBase = null,
            decimal? pdGLVoucherDtlCreditBase = null,
            decimal? pdBaseCurrencyValue = null,
            decimal? pdGLVoucherDtlPayDebit = null,
            decimal? pdGLVoucherDtlPayCredit = null,
            decimal? pdPayCurrencyValue = null,
            string pdGLVoucherDtlNote = null,
            int? pdCostCenterId = null,
            bool? pdIsPosted = null,
            int? pdUserId = null,
            int? pdGLVoucherDtlTransSeq = null,
            bool? pdIsDeleted = null,

            // Search Parameters
            string psGLVoucherNo = null,
            DateTime? psDateFrom = null,
            DateTime? psDateTo = null,

            // Main Parameters
            int? pLanguageId = null,
            bool? pIsGLVoucherDetail = null)
        {
            return Ok();
        }

    }
}
