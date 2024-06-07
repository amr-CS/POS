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
    public class APIStoreSettingController : ApiController
    {
        private IdbStoreSetting _dbStoreSetting;
        public APIStoreSettingController(IdbStoreSetting dbStoreSetting) {
            _dbStoreSetting = dbStoreSetting;
        }

        [HttpGet]
        public string StoreSettingGET(
      int? pStoreSettingId = null,
      string pStoreSettingCode = null,
        string pStoreSettingNotes = null,
      string pStoreSettingNameL1 = null,
      string pStoreSettingNameL2 = null,
      int?   pStoreId = null,
      bool? pStoreSettingIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbStoreSetting.funStoreSettingGET(
            pStoreSettingId: pStoreSettingId,
            pStoreSettingCode: pStoreSettingCode,
            pStoreSettingNameL1: pStoreSettingNameL1,
            pStoreSettingNameL2: pStoreSettingNameL2,
            pStoreSettingNotes : pStoreSettingNotes,
            pStoreId: pStoreId,
            pStoreSettingIsActive: pStoreSettingIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
