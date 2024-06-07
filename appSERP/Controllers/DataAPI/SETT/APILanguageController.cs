using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SETT
{
    public class APILanguageController : ApiController
    {
        private IdbLanguage _dbLanguage;
        public APILanguageController(IdbLanguage dbLanguage)
        {
            _dbLanguage = dbLanguage;
        }
        [HttpGet]
        public string LanguageGET(
        int? pLanguageId = null,
        string pLanguageCode = null,
        string pLanguageNameL1 = null,
        string pLanguageNameL2 = null,
        string pCultureName = null,
        string pLanguageImage = null,
        int? pDefaultFontId = null,
        bool? pLanguageIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbLanguage.funLanguageGET(
            pLanguageId: pLanguageId,
            pLanguageCode: pLanguageCode,
            pLanguageNameL1: pLanguageNameL1,
            pLanguageNameL2: pLanguageNameL2,
            pCultureName: pCultureName,
            pLanguageImage: pLanguageImage,
            pDefaultFontId: pDefaultFontId,
            pLanguageIsActive: pLanguageIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vData;
        }
    }
}
