using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APIVoucherTypeController : ApiController
    {
        private IdbVoucherType _dbVoucherType;
        public APIVoucherTypeController(IdbVoucherType dbVoucherType)
        {
            _dbVoucherType = dbVoucherType;
        }

        [HttpGet]
        public string VoucherTypeGET(
        int? pVoucherTypeId = null,
        string pVoucherTypeCode = null,
        string pVoucherTypeNameL1 = null,
        string pVoucherTypeNameL2 = null,
        bool? pVoucherTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbVoucherType.funVoucherTypeGET(
            pVoucherTypeId : pVoucherTypeId,
            pVoucherTypeCode : pVoucherTypeCode,
            pVoucherTypeNameL1 : pVoucherTypeNameL1,
            pVoucherTypeNameL2 : pVoucherTypeNameL2,
            pVoucherTypeIsActive : pVoucherTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
