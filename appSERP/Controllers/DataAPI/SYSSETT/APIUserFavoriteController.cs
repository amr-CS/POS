using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SYSSETT
{
    public class APIUserFavoriteController : ApiController
    {
        private IdbUserFavorite _dbUserFavorite;
        public APIUserFavoriteController(IdbUserFavorite dbUserFavorite)
        {
            _dbUserFavorite = dbUserFavorite;
        }

        [HttpGet]
        public  string UserFavoriteGET(
        int? pUserFavoriteId = null,
        int? pUserId = null,
        int? pObjectId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Set Value
            string vData = _dbUserFavorite.funUserFavoriteGET(
          pUserFavoriteId : pUserFavoriteId,
          pUserId : pUserId,
          pObjectId : pObjectId,
          pIsDeleted : pIsDeleted,
          pQueryTypeId : pQueryTypeId
                );
            // Get The Data
            return vData;
        }
        }
}
