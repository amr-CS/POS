using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC.Login
{
    public class APIUserLoginController : ApiController
    {

        private IdbUser _dbUser;
        public APIUserLoginController(IdbUser dbUser)
        {
            _dbUser = dbUser;
        }

        [HttpGet]
            public string UserLoginGET(
            string pUserName=null, 
            string pUserPassword = null, 
            string pDevice = null, 
            bool? pUserIsActive = null, 
            bool? pIsDeleted = null, 
            int? pQueryTypeId = clsQueryType.qSelectLogin)
        {
            // Declaration
            string vDtUser = _dbUser.funUserLogin(
             pUserName : pUserName,
             pUserPassword : pUserPassword,
             pDevice : pDevice,
             pUserIsActive : pUserIsActive,
             pIsDeleted : pIsDeleted,
             pQueryTypeId : clsQueryType.qSelectLogin
                );
         
            // Return Result
            return vDtUser;
        }
    }
}
