﻿using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIEmpStatusController : ApiController
    {
        private IdbEmpStatus _dbEmpStatus;
        public APIEmpStatusController(IdbEmpStatus dbEmpStatus)
        {
            _dbEmpStatus = dbEmpStatus;
        }

        [HttpGet]
        public string EmpStatusGET(
int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbEmpStatus.funEmpStatusGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}