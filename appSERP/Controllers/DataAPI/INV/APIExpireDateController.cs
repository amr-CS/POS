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
    public class APIExpireDateController : ApiController
    {

        private IdbExpireDate _dbExpireDate;
        public APIExpireDateController(IdbExpireDate dbExpireDate) {
            _dbExpireDate = dbExpireDate;
        }

        [HttpGet]
        public string ExpireDateGET(
      int? pExpireDateId = null,
        string pExpireDateCode = null,
        DateTime? pExpireDate = null,
        int? pItemId = null,
       bool? pExpireDateIsActive = true,
  bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbExpireDate.funExpireDateGET(
           pExpireDateId: pExpireDateId,
         pExpireDateCode: pExpireDateCode,
        pExpireDate: pExpireDate,
       pItemId: pItemId,
          pExpireDateIsActive: pExpireDateIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
