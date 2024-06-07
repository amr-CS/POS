using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLVoucher
    {

        string funFinancialDateCheckGET(
            DateTime? pDate = null);

        string funGLVoucherGET(

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
            string phNumbers = null,
            int? phCSId = null,
            int? phVoucherSeq = null,
            string phPerson = null,
            int? phSalesId = null,
            bool? phGLVoucherIsActive = null,
            bool? phIsDeleted = null,

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
            int? pdGLVoucherDtlTransSeq = null,
            bool? pdIsDeleted = null,

            // Search Parameters
            string psGLVoucherNo = null,
            DateTime? psDateFrom = null,
            DateTime? psDateTo = null,

            // Main Parameters
            bool? pIsGLVoucherDetail = null,
            int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
