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
    public class APIStoreKeeperController : ApiController
    {

        private IdbStoreKeeper _dbStoreKeeper;
        public APIStoreKeeperController(IdbStoreKeeper dbStoreKeeper) {
            _dbStoreKeeper = dbStoreKeeper;
        }

        [HttpGet]
        public string StoreKeeperGET(
    int? pStoreKeeperId = null,
    string pStoreKeeperCode = null,
    string pStoreKeeperNameL1 = null,
    string pStoreKeeperNameL2 = null,
    int? pStoreId = null,
    bool? pStoreKeeperIsActive = null,
    bool? pIsDeleted = false,
    int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbStoreKeeper.funStoreKeeperGET(
            pStoreKeeperId: pStoreKeeperId,
            pStoreKeeperCode: pStoreKeeperCode,
            pStoreKeeperNameL1: pStoreKeeperNameL1,
            pStoreKeeperNameL2: pStoreKeeperNameL2,
            pStoreId: pStoreId,
            pStoreKeeperIsActive: pStoreKeeperIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
