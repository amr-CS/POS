using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvChecks
    {
        string funCheckGET(
        int? pCheckId = null,
        string pCheckCode = null,
        int? pInvId = null,
        int? pInvType = null,
        int? pYear = null,
        int? pCheckDtlId = null,
        int? pAccountId = null,
        int? pBankId = null,
        int? pBranchId = null,
        int? pCheckNo = null,
        DateTime? pCheckPayDate = null,
        int? pCostCenterId = null,
        float? pCheckCredit = null,
        float? pCheckDebit = null,
        float? pCurValue = null,
        float? pCheckBaseCredit = null,
        float? pCheckBaseDebit = null,
        bool? pIsPosted = null,
        bool? pPosting = null,
        int? pStoreId = null,
        string pNotes = null,
        float? pTransSeq = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);
    }
}
