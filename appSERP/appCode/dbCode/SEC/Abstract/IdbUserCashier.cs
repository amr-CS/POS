using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserCashier
    {
        string funUserCashierGET(
        int? pUserCashierId = null,
        int? pUserId = null,
        int? pCashierId = null,
        bool? pModifyInvoice = null,
        bool? pCancelInvoice = null,
        bool? pRePrintInvoice = null,
        bool? pIsCashierDelivery = null,
        bool? pPcVerfiy = null,
        bool? pReturnInsurance = null,
        bool? pSearchInvoice = null,
        bool? pHoldInvoice = null,
        bool? Discount = null,
        int? pInsuranceLimit = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? ReportPeriod = null,
        int? pQueryTypeId = null);

        DataTable TableUserCashierGET(
        int? pUserCashierId = null,
        int? pUserId = null,
        int? pCashierId = null,
        bool? pModifyInvoice = null,
        bool? pCancelInvoice = null,
        bool? pRePrintInvoice = null,
        bool? pIsCashierDelivery = null,
        bool? pPcVerfiy = null,
        bool? pReturnInsurance = null,
        bool? pSearchInvoice = null,
        bool? pHoldInvoice = null,
        int? pInsuranceLimit = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? ReportPeriod = null,
        int? pQueryTypeId = null);
    }
}
