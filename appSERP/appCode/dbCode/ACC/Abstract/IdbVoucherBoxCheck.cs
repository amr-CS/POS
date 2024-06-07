using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbVoucherBoxCheck
    {
        string funVoucherBoxCheckGET(
        int? pVoucherBoxCheckId = null,
        int? pGLVoucherId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        string pAccountId = null,
        decimal? pPayDebit = null,
        decimal? pPayCurrencyValue = null,
        decimal? pDebit = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pBaseDebit = null,
        decimal? pCredit = null,
        decimal? pBaseCredit = null,
        string pNote = null,
        int? pCostCenterId = null,
        bool? pVoucherIsCheck = null,
        int? pCheckBankId = null,
        int? pCheckNo = null,
        DateTime? pCheckDate = null,
        decimal? pCheckDebit = null,
        decimal? pCheckCurrencyValue = null,
        decimal? pCheckBaseDebit = null,
        string pCheckNote = null,
        int? pCheckCostCenterId = null,
        int? pCheckBankBranchId = null,
        int? pPayTypeId = null,
        int? pEPayTypeId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);
    }
}
