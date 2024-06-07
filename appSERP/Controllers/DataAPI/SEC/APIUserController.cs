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
    public class APIUserController : ApiController
    {
        private IdbUser _dbUser;
        public APIUserController(IdbUser dbUser) {
            _dbUser = dbUser;
        }

        [HttpGet]
        public string UserGET(
        int? pUserId = null,
        string pUserCode = null,
        string Printer = null,

        string pUserFullName = null,
        string pUserAddress = null,
        string pUserPhone = null,
        string pUserEmail = null,
        string pUserName = null,
        string pUserPassword = null,
        bool? pIsUserLock = null,
        string pUserImage = null,
        string phNumbers = null,
        int? pSecurityGradeId = null,
        int? pLanguageId=null,
        int? pCountryId = null,
        int? pFontSizeTypeId = null,
        int? pUserTypeId = null,
        int? pEmployeeId = null,
        int? pUserTimeZoneId = null,
        bool? pUserTimeZoneDST = null,
        bool? pUserIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbUser.funUserGET(
            pUserId : pUserId,
            pUserCode : pUserCode,
            Printer:Printer,
            pUserFullName : pUserFullName,
            pUserAddress : pUserAddress,
            pUserPhone : pUserPhone,
            pUserEmail : pUserEmail,
            pUserName : pUserName,
            pUserPassword : pUserPassword,
            pIsUserLock : pIsUserLock,
            pUserImage : pUserImage,
            phNumbers: phNumbers,
            pSecurityGradeId : pSecurityGradeId,
            pLanguageId: pLanguageId,
            pCountryId : pCountryId,
            pFontSizeTypeId : pFontSizeTypeId,
            pUserTypeId : pUserTypeId,
            pEmployeeId: pEmployeeId,
            pUserTimeZoneId : pUserTimeZoneId,
            pUserTimeZoneDST : pUserTimeZoneDST,
            pUserIsActive : pUserIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
