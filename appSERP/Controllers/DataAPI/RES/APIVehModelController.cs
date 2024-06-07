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
    public class APIVehModelController : ApiController
    {
        private IdbVehModel _dbVehModel;
        public APIVehModelController(IdbVehModel dbVehModel) 
        {
            _dbVehModel = dbVehModel;
        }

        [HttpGet]
        public string VehModelGET(
            int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVehModel.funVehModelGET(
                pCodeId : pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
