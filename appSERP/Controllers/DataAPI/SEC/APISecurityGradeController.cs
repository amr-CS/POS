using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APISecurityGradeController : ApiController
    {
        private IdbSecurityGrade _dbSecurityGrade;
        public APISecurityGradeController(IdbSecurityGrade dbSecurityGrade)
        {
            _dbSecurityGrade = dbSecurityGrade;
        }
        [HttpGet]
        public string SecurityGradeGET(
        int? pSecurityGradeId = null,
        string pSecurityGradeCode = null,
        string pSecurityGradeNameL1 = null,
        string pSecurityGradeNameL2 = null,
        bool? pSecurityGradeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSecurityGrade.funSecurityGradeGET(
            pSecurityGradeId: pSecurityGradeId,
            pSecurityGradeCode: pSecurityGradeCode,
            pSecurityGradeNameL1: pSecurityGradeNameL1,
            pSecurityGradeNameL2: pSecurityGradeNameL2,
            pSecurityGradeIsActive: pSecurityGradeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
