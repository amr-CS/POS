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
    public class APIStoreController : ApiController
    {
        private IdbStore _dbStore;
        public APIStoreController(IdbStore dbStore) {
            _dbStore = dbStore;
        }

        [HttpGet]
  public string StoreGET(
  int? pStoreId = null,
  string pStoreCode = null,
  string pStoreNameL1 = null,
  string pStoreNameL2 = null,
  string pStoreShortName = null,
  int? pStoreTypeId = null,
  int? pCountryId = null,
  int? pCityId = null,
  string pStoreNotes = null, 
  string pStorePhone = null,
  string pStoreAddress = null,
  bool? pStoreIsActive = null,
  bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbStore.funStoreGET(
            pStoreId: pStoreId,
            pStoreCode: pStoreCode,
            pStoreNameL1: pStoreNameL1,
            pStoreNameL2: pStoreNameL2,
            pStoreShortName: pStoreShortName,
            pStoreTypeId: pStoreTypeId,
            pCountryId: pCountryId,
            pCityId: pCityId,
            pStoreNotes: pStoreNotes,
            pStorePhone: pStorePhone,
            pStoreAddress: pStoreAddress,
            pStoreIsActive: pStoreIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
