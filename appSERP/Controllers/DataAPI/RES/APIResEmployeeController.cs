using appSERP.appCode.dbCode.RES;
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
    public class APIResEmployeeController : ApiController
    {
        private IdbResEmployee _dbResEmployee;
        public APIResEmployeeController(IdbResEmployee dbResEmployee) {
            _dbResEmployee = dbResEmployee;
        }

        [HttpGet]
        public string ResEmployeeGET(
       int? pResEmployeeId = null,
        string pResEmployeeCode = null,
        int? pEmpSeq = null,
        int? Credit = null,
        string pResEmployeeNameL1 = null,
        string pResEmployeeNameL2 = null,
        DateTime? pHireDate = null,
        int? pDeptSeq = null,
        int? pEmpStatusId = null,
        DateTime? pExitDate = null,
        string pAddress = null,
        DateTime? pBirthDate = null,
        string pMobile = null,
        int? pGender = null,
        int? pIdentityTypeId = null,
        int? pIdentityNumber = null,
        DateTime? pIdentityDate = null,
        int? pNationalityId = null,
        decimal? pDeliveryValue = null,
        int? pValueTypeId = null,
        decimal? pPercentageRange = null,
        int? pExitTypeId = null,
        string pExitReason = null,
        bool? pResEmployeeIsActive = null,
        bool? pIsDeleted = false,
  int? pQueryTypeId = null,
         string pLstNationality = null,
        string pLstIdentityType = null,
        string pLstEmpStatus = null,
        string pLstValueType = null,
        string pLstExitType = null,
        int ? UserId=null
            )
        {
            // Get Data 
            string vData = _dbResEmployee.funResEmployeeGET(
            pResEmployeeId: pResEmployeeId,
            pResEmployeeCode: pResEmployeeCode,
            Credit: Credit,
            pEmpSeq: pEmpSeq,
            pResEmployeeNameL1 : pResEmployeeNameL1,
            pResEmployeeNameL2 : pResEmployeeNameL2,
            pHireDate : pHireDate,
            pDeptSeq : pDeptSeq,
            pEmpStatusId : pEmpStatusId,
            pExitDate : pExitDate,
            pAddress : pAddress,
            pBirthDate: pBirthDate,
            pMobile : pMobile,
            pGender : pGender,
            pIdentityTypeId : pIdentityTypeId,
            pIdentityNumber : pIdentityNumber,
            pIdentityDate : pIdentityDate,
            pNationalityId : pNationalityId,
            pDeliveryValue : pDeliveryValue,
            pValueTypeId : pValueTypeId,
            pPercentageRange : pPercentageRange,
            pExitTypeId : pExitTypeId,
            pExitReason : pExitReason,
            pResEmployeeIsActive : pResEmployeeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pLstNationality: pLstNationality,
            pLstIdentityType: pLstIdentityType,
            pLstEmpStatus : pLstEmpStatus,
            pLstValueType : pLstValueType,
            pLstExitType : pLstExitType,
            UserId: UserId

            );
            // Result
            return vData;
        }
    }
}
