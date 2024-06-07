using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbLookup
    {
        string funLookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pCompanyId = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        DateTime? pdDate1 = null,
        DateTime? pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = null,
        string pSelectList = null,
        int? BranchId = null
        );

        DataTable funGetLookupReport();

        DataTable funtblLookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pCompanyId = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        DateTime? pdDate1 = null,
        DateTime? pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = null,
        string pSelectList = null,
        int? BranchId = null

        );


    }
}
