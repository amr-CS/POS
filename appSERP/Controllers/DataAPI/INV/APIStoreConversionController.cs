using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIStoreConversionController : ApiController
    {
        private IdbStoreConversion _dbStoreConversion;
        public APIStoreConversionController(IdbStoreConversion dbStoreConversion) {
            _dbStoreConversion = dbStoreConversion;
        }

      [HttpGet]
      public string StoreConversionGET(
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
      bool? pIsDeleted = false,
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
      int? pQueryTypeId = clsQueryType.qSelect,
    string pLstStores = null,
        string pLstSource = null,
        string pLstConversionId = null,
       string pSearchDate = null
      )
        {

            // Set Values
            string vData = _dbStoreConversion.funStoreConversionGET(
            pStoreConversionId: pStoreConversionId,
            pStoreConversionCode: pStoreConversionCode,
            pSourceBranchId : pSourceBranchId,
            pTargetBranchId : pTargetBranchId,
            pStoreId: pStoreId,
            pStoreConversionType: pStoreConversionType,
            pStoreConversionYear: pStoreConversionYear,
            pStoreConversionDate: pStoreConversionDate,
            pSourceStoreId: pSourceStoreId,
            pNotes: pNotes,
            pReqId: pReqId,
            pReqYear: pReqYear,
            pReceivedQty: pReceivedQty,
            pReceivedUser: pReceivedUser,
            pReceivedDate: pReceivedDate,
            pStoreConversionIsActive: pStoreConversionIsActive,
            pIsDeleted: pIsDeleted,
            pCreatedBy: pCreatedBy,
            pCreatedOn: pCreatedOn,
            pLastUpdatedBy: pLastUpdatedBy,
            pLastUpdatedOn: pLastUpdatedOn,
            pStoreConversionDtlId: pStoreConversionDtlId,
            pdStoreId: pdStoreId,
            pdStoreConversionId: pdStoreConversionId,
            pdStoreConversionType: pdStoreConversionType,
            pdStoreConversionYear: pdStoreConversionYear,
            pdSoureStoreType: pdSoureStoreType,
            pdItemId: pdItemId,
            pdUnitId: pdUnitId,
            pdExpireDate: pdExpireDate,
            pdStoreSectId: pdStoreSectId,
            pdItemQty: pdItemQty,
            pdNotes: pdNotes,
            pdIsDeleted: pdIsDeleted,
            pdCreatedBy: pdCreatedBy,
            pdCreatedOn: pdCreatedOn,
            pdLastUpdatedBy: pdLastUpdatedBy,
            pdLastUpdatedOn: pdLastUpdatedOn,
            pLanguageId: pLanguageId,
            pCompanyId: pCompanyId,
            pIsStoreConversionDetail: pIsStoreConversionDetail,
            pQueryTypeId: pQueryTypeId,
            pLstStores : pLstStores,
           pLstSource : pLstSource,
           pLstConversionId : pLstConversionId,
           pSearchDate: pSearchDate

            );

            // Return Data
            return vData;



        }
    }
}
