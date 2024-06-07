using appSERP.Models.INV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreConversion
    {
        string funStoreConversionGET(
        int? pStoreConversionId = null,
        int? pStoreConversionCode = null,
        int? pSourceBranchId = null,
        int? pTargetBranchId = null,
        int? pStoreId = null,
        int? pStoreConversionType = null,
        int? pStoreConversionYear = null,
        DateTime? pStoreConversionDate = null,
        int? pSourceStoreId = null,
        string pNotes = null,
        int? pReqId = null,
        int? pReqYear = null,
        float? pReceivedQty = null,
        string pReceivedUser = null,
        DateTime? pReceivedDate = null,
        bool? pStoreConversionIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pStoreConversionDtlId = null,
        int? pdStoreId = null,
        int? pdStoreConversionId = null,
        int? pdStoreConversionType = null,
        int? pdStoreConversionYear = null,
        int? pdSoureStoreType = null,
        int? pdItemId = null,
        int? pdUnitId = null,
        DateTime? pdExpireDate = null,
        int? pdStoreSectId = null,
        float? pdItemQty = null,
        string pdNotes = null,
        bool? pdIsDeleted = null,
        int? pdCreatedBy = null,
        DateTime? pdCreatedOn = null,
        int? pdLastUpdatedBy = null,
        DateTime? pdLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pCompanyId = null,
        bool? pIsStoreConversionDetail = null,
        int? pQueryTypeId = null,
        string pLstStores = null,
        string pLstSource = null,
        string pLstConversionId = null,
        string pSearchDate = null

        );

        object spStoreConversionBulk(ICollection<StoreConversion> storeConversion, int? StoreConversionId,int? SourceBranchId, int? TargetBranchId, int? StoreId, DateTime? StoreConversionDate,
             int? SourceStoreId, string Notes, bool? StoreConversionIsActive, bool? IsDeleted, int? CreatedBy, int? LastUpdatedBy,int?branchId);

        DataTable funGetStoreConversionReport(int? pStoreConversionId = null, bool? pIsActive = null);


    }
}
