using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APIUserGroupController : ApiController
    {
        IdbUserGroup _dbUserGroup;
        public APIUserGroupController(IdbUserGroup dbUserGroup)
        {
            _dbUserGroup = dbUserGroup;
        }

        [HttpGet]
        public string UserGroupGET(
       int? pUserGroupId = null,
       int? pUserId = null,
       int? pGroupId = null,
       bool? pIsDeleted = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbUserGroup.funUserGroupGET(
            pUserGroupId: pUserGroupId,
            pUserId: pUserId,
            pGroupId: pGroupId,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            return vData;
        }
    }
}
