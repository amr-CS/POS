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
    public class APIStoreTypeController : ApiController
    {
        private IdbStoreType _dbStoreType;
        public APIStoreTypeController(IdbStoreType dbStoreType)
        {
            _dbStoreType = dbStoreType;
        }
        [HttpGet]
        public string StoreTypeGET(
        int? pStoreTypeId = null,
        string pStoreTypeCode = null,
        string pStoreTypeNameL1 = null,
        string pStoreTypeNameL2 = null,
        int? pStoreId = null,
        bool? pStoreTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbStoreType.funStoreTypeGET(
            pStoreTypeId: pStoreTypeId,
            pStoreTypeCode: pStoreTypeCode,
            pStoreTypeNameL1: pStoreTypeNameL1,
            pStoreTypeNameL2: pStoreTypeNameL2,
            pStoreId:pStoreId,
            pStoreTypeIsActive: pStoreTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
