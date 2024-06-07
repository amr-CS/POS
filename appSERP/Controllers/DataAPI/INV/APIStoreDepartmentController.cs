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
    public class APIStoreDepartmentController : ApiController
    {
        private IdbStoreDepartment _dbStoreDepartment;
        public APIStoreDepartmentController(IdbStoreDepartment dbStoreDepartment) {
            _dbStoreDepartment = dbStoreDepartment;
        }

        [HttpGet]
        public string StoreDepartmentGET(
       int? pStoreDepartmentId = null,
       string pStoreDepartmentCode = null,
       string pStoreDepartmentNameL1 = null,
       string pStoreDepartmentNameL2 = null,
       bool? pStoreDepartmentIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbStoreDepartment.funStoreDepartmentGET(
            pStoreDepartmentId: pStoreDepartmentId,
            pStoreDepartmentCode: pStoreDepartmentCode,
            pStoreDepartmentNameL1: pStoreDepartmentNameL1,
            pStoreDepartmentNameL2: pStoreDepartmentNameL2,
            pStoreDepartmentIsActive: pStoreDepartmentIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }

    }
}
