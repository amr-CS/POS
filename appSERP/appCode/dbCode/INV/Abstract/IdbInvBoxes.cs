using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvBoxes
    {
        string funBoxGET(
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
